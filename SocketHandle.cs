using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using DNet.ClientMessages;
using DNet.Http;
using DNet.Http.Gateway;
using DNet.Structures;
using Newtonsoft.Json;
using PureWebSockets;

namespace DNet.Socket
{
    // Discord Event Handler Delegates
    public delegate void MessageCreateHandler(Structures.Message message);
    public delegate void GuildBasicHandler(Guild guild);
    public delegate void GuildDeleteHandler(UnavailableGuild guild);
    public delegate void PresenceUpdateHandler(PresenceUpdateEvent update);

    public class SocketHandle
    {
        // Discord Events
        public event EventHandler OnRateLimit;
        public event EventHandler OnReady;
        public event EventHandler OnResumed;
        public event GuildBasicHandler OnGuildCreate;
        public event GuildDeleteHandler OnGuildDelete;
        public event GuildBasicHandler OnGuildUpdate;
        public event EventHandler OnGuildUnavailable;
        public event EventHandler OnGuildAvailable;
        public event EventHandler OnGuildMemberAdd;
        public event EventHandler OnGuildMemberRemove;
        public event EventHandler OnGuildMemberUpdate;
        public event EventHandler OnGuildMemberAvailable;
        public event EventHandler OnGuildMemberSpeaking;
        public event EventHandler OnGuildMembersChunk;
        public event EventHandler OnGuildIntegrationsUpdate;
        // ...
        public event MessageCreateHandler OnMessageCreate;
        public event EventHandler OnMessageDelete;
        public event EventHandler OnMessageUpdate;
        // ...
        public event PresenceUpdateHandler OnPresenceUpdate;

        private readonly Client client;

        private int? heartbeatLastSequence = null;
        private PureWebSocket socket;

        public SocketHandle(Client client)
        {
            this.client = client;
        }

        public async Task Connect()
        {
            Console.WriteLine($"Authenticating using token '{this.client.GetToken()}'");

            // TODO: Use response
            var response = await Fetch.GetJsonAsyncAuthorized<GetGatewayBotResponse>(API.BotGateway(), this.client.GetToken());
            var convertedResponse = JsonConvert.SerializeObject(response);
            var connectionUrl = (string)JsonConvert.DeserializeObject<dynamic>(await Fetch.GetAsync(API.Gateway())).url;

            this.socket = new PureWebSocket(connectionUrl, new PureWebSocketOptions() { });

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
            // TODO: Debugging
            // Console.WriteLine($"WS Received => {messageString}");

            GatewayMessage<dynamic> dynamicMessage = JsonConvert.DeserializeObject<GatewayMessage<dynamic>>(messageString);

            Console.WriteLine($"WS Handling message with OPCODE '{dynamicMessage.OpCode}'");

            Console.WriteLine(messageString);

            switch (dynamicMessage.OpCode)
            {
                case OpCode.Hello:
                    {
                        GatewayHelloMessage helloMessage = (GatewayHelloMessage)JsonConvert.DeserializeObject<GatewayHelloMessage>(JsonConvert.SerializeObject(dynamicMessage.Data));

                        Console.WriteLine($"WS Acknowledged heartbeat at {helloMessage.heartbeatInterval}ms interval");

                        // TODO: To know when to stop, pass CONNECTED or similar BY REFERENCE
                        Utils.SetInterval(() =>
                        {
                            this.Send(OpCode.Heartbeat, new ClientHeartbeatMessage(1, this.heartbeatLastSequence));
                        }, TimeSpan.FromMilliseconds(helloMessage.heartbeatInterval));

                        var dat = new ClientIdentifyMessage(
                            this.client.GetToken(),

                            new ClientIdentifyMessageProperties(
                                "Linux",
                                "disco",
                                "disco"
                            ),

                            false,

                            250,

                            // TODO: Hard-coded
                            new int[] { 0, 1 },

                            // TODO: Also hard-coded
                            new ClientPresence(
                                new ClientPresenceGame("Sometg", 0),

                                "dnd",

                                91879201,
                                false
                            )
                        );

                        this.Send(OpCode.Identify, dat);

                        break;
                    }

                case OpCode.Dispatch:
                    {
                        switch (dynamicMessage.Type)
                        {
                            // Message Events
                            case "MESSAGE_CREATE":
                                {
                                    this.OnMessageCreate(JsonConvert.DeserializeObject<Structures.Message>(JsonConvert.SerializeObject(dynamicMessage.Data)));

                                    break;
                                }
                            
                            // Guild Events
                            case "GUILD_CREATE":
                                {
                                    // TODO
                                    var message = /*(GatewayMessage<Guild>)*/dynamicMessage;

                                    // Update local guild cache
                                    this.client.guilds.Add(message.Data.Id, message.Data);

                                    // Fire event
                                    this.OnGuildCreate(message.Data);

                                    break;
                                }

                            case "GUILD_UPDATE":
                                {
                                    // TODO
                                    var message = /*(GatewayMessage<Guild>)*/dynamicMessage;

                                    // Update local guild cache
                                    this.client.guilds.Add(message.Data.Id, message.Data);

                                    // Fire event
                                    this.OnGuildUpdate(message.Data);

                                    break;
                                }

                            case "GUILD_DELETE":
                                {
                                    // TODO
                                    var message = /*(GatewayMessage<UnavailableGuild>)*/dynamicMessage;

                                    // Update local guild cache
                                    this.client.guilds.Remove(message.Data.Id);

                                    // Fire event
                                    this.OnGuildDelete(message.Data);

                                    break;
                                }

                            // User Events
                            case "PRESENCE_UPDATE":
                                {
                                    // TODO
                                    var message = /*(GatewayMessage<PresenceUpdate>)*/dynamicMessage;

                                    // Update local guild cache

                                    // TODO: Update user's properties, see (https://discordapp.com/developers/docs/topics/gateway#presence-update)
                                    //this.client.users.Add(message.Data.User.Id, message.Data.);

                                    // Fire event
                                    this.OnPresenceUpdate(message.Data);

                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine($"Unknown dispatch message type: {dynamicMessage.Type}");

                                    break;
                                }
                        }

                        break;
                    }

                default:
                    {
                        Console.WriteLine($"WS Unable to handle OPCODE '{dynamicMessage.OpCode}' (Not implemented)");

                        break;
                    }
            }
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