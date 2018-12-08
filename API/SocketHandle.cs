using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using DNet.API.ClientMessages;
using DNet.API.Gateway;
using DNet.ClientStructures;
using DNet.Core;
using DNet.Http;
using DNet.Http.Gateway;
using DNet.Structures;
using DNet.Structures.Guilds;
using DNet.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PureWebSockets;

namespace DNet.API
{
    public partial class SocketHandle
    {
        private readonly Client client;

        private int? heartbeatLastSequence = null;
        private PureWebSocket socket;

        public SocketHandle(Client client)
        {
            this.client = client;
            this.SetupInternalHandlers();
        }

        private void SetupInternalHandlers()
        {
            this.OnReady += (object sender, ReadyEvent ready) =>
            {
                this.client.User = ready.User;
                this.client.SetSessionId(ready.SessionId);
            };

            this.OnGuildCreate += (object sender, Guild guild) =>
            {
                // Update local guild cache
                this.client.guilds.Add(guild.Id, guild);
            };

            this.OnGuildUpdate += (object sender, Guild guild) =>
            {
                // Update local guild cache
                this.client.guilds.Add(guild.Id, guild);
            };

            this.OnGuildDelete += (object sender, UnavailableGuild guild) =>
            {
                // Update local guild cache
                this.client.guilds.Remove(guild.Id);
            };

            this.OnPresenceUpdate += (object sender, PresenceUpdateEvent update) =>
            {
                // TODO: Update user's properties, see (https://discordapp.com/developers/docs/topics/gateway#presence-update)
                if (this.client.users.ContainsKey(update.User.Id))
                {
                    User user = this.client.users[update.User.Id];

                    // TODO: Update cached user's presence, which is not present in User object, therefore must make a new dictionary saving presences.
                }
                else
                {
                    this.client.users.Add(update.User.Id, update.User);
                    // TODO: Also save presence
                }
            };

            this.OnUserUpdate += (object sender, UserUpdateEvent e) => {
                this.client.users.Add(e.UpdatedUser.Id, e.UpdatedUser);
            };

            // TODO
            /* this.OnGuildUnavailable += (object sender, UnavailableGuild guild) =>
            {
                // TODO: Should not remove it
                this.client.guilds.Remove(guild.Id);
            };

            this.OnGuildAvailable += (object sender, Guild guild) =>
            {

            }; */
        }

        public async Task Connect()
        {
            // TODO: Use response
            var response = await Fetch.GetJsonAsyncAuthorized<GetGatewayBotResponse>(DiscordAPI.BotGateway(), this.client.GetToken());
            var convertedResponse = JsonConvert.SerializeObject(response);
            var connectionUrl = (string)JsonConvert.DeserializeObject<dynamic>(await Fetch.GetAsync(DiscordAPI.Gateway())).url;

            this.socket = new PureWebSocket(connectionUrl, new PureWebSocketOptions { });

            // Events
            this.socket.OnMessage += this.WS_OnMessage;
            this.socket.OnClosed += this.WS_OnClosed;

            // Connect
            this.socket.Connect();

            // TODO: Debugging
            Console.WriteLine($"GOT url => {convertedResponse}");
        }

        private void WS_OnMessage(string messageString)
        {
            GatewayMessage<JObject> message = JsonConvert.DeserializeObject<GatewayMessage<JObject>>(messageString);

            Console.WriteLine($"WS Handling message with OPCODE '{message.OpCode}'");

            switch (message.OpCode)
            {
                case OpCode.Hello:
                    {
                        GatewayHelloMessage helloMessage = this.ConvertMessage<GatewayHelloMessage>(message);

                        Console.WriteLine($"WS Acknowledged heartbeat at {helloMessage.heartbeatInterval}ms interval");

                        // TODO: To know when to stop, pass CONNECTED or similar BY REFERENCE
                        Utils.SetInterval(() =>
                        {
                            this.Send(OpCode.Heartbeat, new ClientHeartbeatMessage(1, this.heartbeatLastSequence));
                        }, TimeSpan.FromMilliseconds(helloMessage.heartbeatInterval));

                        var identity = new ClientIdentifyMessage {
                            Token = this.client.GetToken(),

                            Properties = new ClientIdentifyMessageProperties
                            {
                                Browser = "disco",
                                Device = "disco",
                                OS = "linux"
                            },

                            // { 0 -> the current shard, 1 -> the total amount of shards }
                            Shards = new int[] { 0, 1 }
                        };

                        this.Send(OpCode.Identify, identity);

                        break;
                    }

                case OpCode.Dispatch:
                    {
                        Console.WriteLine($" => '{message.Type}'");

                        switch (message.Type)
                        {
                            // General events
                            case "READY":
                                {
                                    // Fire event
                                    //                                    this.OnReady?.Invoke(this, null);
                                    this.OnReady?.Invoke(this, this.ConvertMessage<ReadyEvent>(message));
                                    break;
                                }

                            // Message Events
                            case "MESSAGE_CREATE":
                                {
                                    // Fire event
                                    this.OnMessageCreate?.Invoke(this, this.ConvertInjectableMessage<Structures.Message>(message));

                                    break;
                                }

                            case "MESSAGE_UPDATE":
                                {
                                    // Fire event
                                    // TODO: Message is partial, see (https://discordapp.com/developers/docs/topics/gateway#message-update)
                                    this.OnMessageUpdate?.Invoke(this, this.ConvertInjectableMessage<Structures.Message>(message));

                                    break;
                                }

                            case "MESSAGE_DELETE":
                                {
                                    // Fire event
                                    // TODO: Send message instead of event??
                                    this.OnMessageDelete?.Invoke(this, this.ConvertMessage<MessageDeleteEvent>(message));

                                    break;
                                }

                            case "MESSAGE_DELETE_BULK":
                                {
                                    // Fire event
                                    this.OnMessageDeleteBulk?.Invoke(this, this.ConvertMessage<MessageDeleteBulkEvent>(message));

                                    break;
                                }

                            case "MESSAGE_REACTION_ADD":
                                {
                                    // Fire event
                                    this.OnMessageReactionAdd?.Invoke(this, this.ConvertMessage<MessageReactionEvent>(message));

                                    break;
                                }

                            case "MESSAGE_REACTION_REMOVE":
                                {
                                    // Fire event
                                    this.OnMessageReactionRemove?.Invoke(this, this.ConvertMessage<MessageReactionEvent>(message));

                                    break;
                                }

                            case "MESSAGE_REACTION_REMOVE_ALL":
                                {
                                    // Fire event
                                    this.OnMessageReactionRemoveAll?.Invoke(this, this.ConvertMessage<MessageReactionRemoveAllEvent>(message));

                                    break;
                                }

                            // Guild Events
                            case "GUILD_CREATE":
                                {
                                    // Fire event
                                    this.OnGuildCreate?.Invoke(this, this.ConvertInjectableMessage<Guild>(message));

                                    break;
                                }

                            case "GUILD_UPDATE":
                                {
                                    // Fire event
                                    this.OnGuildUpdate?.Invoke(this, this.ConvertInjectableMessage<Guild>(message));

                                    break;
                                }

                            case "GUILD_DELETE":
                                {
                                    // Fire event
                                    this.OnGuildDelete?.Invoke(this, this.ConvertMessage<UnavailableGuild>(message));

                                    break;
                                }

                            // User Events
                            case "PRESENCE_UPDATE":
                                {
                                    // Fire event
                                    this.OnPresenceUpdate?.Invoke(this, this.ConvertMessage<PresenceUpdateEvent>(message));

                                    break;
                                }

                            case "TYPING_START":
                                {
                                    // Fire event
                                    this.OnTypingStart?.Invoke(this, this.ConvertMessage<TypingStartEvent>(message));

                                    break;
                                }

                            case "USER_UPDATE":
                                {
                                    User updatedUser = this.ConvertMessage<User>(message);
                                    User? oldUser = null;

                                    if (this.client.users.ContainsKey(updatedUser.Id))
                                    {
                                        oldUser = this.client.users[updatedUser.Id];
                                    }

                                    this.OnUserUpdate?.Invoke(this, new UserUpdateEvent() {
                                        OldUser = oldUser,
                                        UpdatedUser = updatedUser
                                    });

                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine($"Unknown dispatch message type: {message.Type}");

                                    break;
                                }
                        }

                        break;
                    }

                default:
                    {
                        Console.WriteLine($"WS Unable to handle message with OPCODE '{message.OpCode}' (Not implemented)");

                        break;
                    }
            }
        }

        private DataType ConvertInjectableMessage<DataType>(GatewayMessage<JObject> message) where DataType : ClientInjectable
        {
            return this.client.CreateStructure<DataType>(this.ConvertMessage<DataType>(message));
        }

        private DataType ConvertMessage<DataType>(GatewayMessage<JObject> message)
        {
            return message.Data.ToObject<DataType>();
        }

        private void WS_OnClosed(WebSocketCloseStatus reason)
        {
            Console.WriteLine($"WS Socket closed => {reason.ToString()}");
        }

        private void Send<DataType>(OpCode opCode, DataType data)
        {
            var message = new ClientMessage<DataType>()
            {
                Data = data,
                OpCode = opCode
            };

            var serializedMessage = JsonConvert.SerializeObject(message);

            this.socket.Send(serializedMessage);
            Console.WriteLine($"WS Sent => {serializedMessage}");
        }
    }
}
