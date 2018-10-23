using System;
using System.ComponentModel;
using System.Net.WebSockets;
using DNet.ClientMessages;
using DNet.Http;
using DNet.Http.Gateway;
using Newtonsoft.Json;
using PureWebSockets;

namespace DNet
{
    public class ClientManager
    {
        private readonly Client client;
        private PureWebSocket socket;
        private Nullable<int> heartbeatLastSequence = null;

        public ClientManager(Client client)
        {
            this.client = client;
        }

        private void Send(OpCode opCode, dynamic data)
        {
            var message = new ClientMessage() {
                data = data,
                opCode = opCode
            };

            var serializedMessage = JsonConvert.SerializeObject(message);

            this.socket.Send(serializedMessage);
            Console.WriteLine($"WS Sent => {serializedMessage}");
        }

        public async void connectToWebSocket()
        {
            Console.WriteLine($"Authenticating using token '{this.client.token}'");

            GetGatewayBotResponse response = await Fetch.GetJsonAsyncAuthorized<GetGatewayBotResponse>(ApiEndpoints.BotGateway(), this.client.token);

            string convertedResponse = JsonConvert.SerializeObject(response);
            string connectionUrl = "wss://gateway.discord.gg/?v=6&encoding=json";

            this.socket = new PureWebSocket(connectionUrl, new PureWebSocketOptions() { });

            // Events
            this.socket.OnMessage += (string messageString) =>
                {
                    Console.WriteLine($"WS Received => {messageString}");

                    GatewayMessage message = JsonConvert.DeserializeObject<GatewayMessage>(messageString);

                    Console.WriteLine($"WS Handling message with OPCODE '{message.opCode}'");

                    switch (message.opCode)
                    {
                        case OpCode.Hello:
                            {
                                GatewayHelloMessage helloMessage = (GatewayHelloMessage)JsonConvert.DeserializeObject<GatewayHelloMessage>(JsonConvert.SerializeObject(message.data));

                                Console.WriteLine($"WS Acknowledged heartbeat at {helloMessage.heartbeatInterval}ms interval");

                                Utils.SetInterval(() =>
                                {
                                    this.Send(OpCode.Heartbeat, new ClientHeartbeatMessage(1, this.heartbeatLastSequence));
                                }, TimeSpan.FromMilliseconds(helloMessage.heartbeatInterval));

                                var dat = new ClientIdentifyMessage(
                                    this.client.token,

                                    new ClientIdentifyMessageProperties(
                                        "Linux",
                                        "disco",
                                        "disco"
                                    ),

                                    false,
                                    
                                    250,
                                    
                                    // TODO: Hard-coded
                                    new int[] { 0, 1 },
                                    
                                    new ClientPresence(
                                        new ClientPresenceGame("Testing bot", 0),

                                        "dnd",
                                        
                                        91879201,
                                        false
                                    )
                                );

                                Console.WriteLine("Sending ...");

                                this.Send(OpCode.Identify, dat);

                                break;
                            }

                        default:
                            {
                                Console.WriteLine($"WS Unable to handle OPCODE '{message.opCode}' (Not implemented)");

                                break;
                            }
                    }
                };

            this.socket.OnClosed += (WebSocketCloseStatus reason) =>
            {
                Console.WriteLine($"WS Socket closed => {reason.ToString()}");
            };

            // Connect
            this.socket.Connect();

            Console.WriteLine($"GOT url => {convertedResponse}");
        }
    }

    public static class AttributesHelperExtension
    {
        public static string ToDescription(this Enum value)
        {
            var da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);

            return da.Length > 0 ? da[0].Description : value.ToString();
        }
    }

    public enum ApiErrors : int
    {
        UnknownAccount = 10001,
        UnknownApplication = 10002,
        UnknownChannel = 10003,
        UnknownGuild = 10004,
        UnknownIntegration = 10005,
        UnknownInvite = 10006,
        UnknownMember = 10007,
        UnknownMessage = 10008,
        UnknownOverwrite = 10009,
        UnknownProvider = 10010,
        UnknownRole = 10011,
        UnknownToken = 10012,
        UnknownUser = 10013,
        UnknownEmoji = 10014,
        UnknownWebhook = 10015,
        BotProhibitedEndpoint = 20001,
        BotOnlyEndpoint = 20002,
        MaximumGuilds = 30001,
        MaximumFriends = 30002,
        MaximumPins = 30003,
        MaximumRoles = 30005,
        MaximumReactions = 30010,
        Unauthorized = 40001,
        MissingAccess = 50001,
        InvalidAccountType = 50002,
        CannotExecuteOnDm = 50003,
        EmbedDisabled = 50004,
        CannotEditMessageByOther = 50005
        // ...
    }

    public enum DefaultMessageNotifications
    {
        All,
        Mentions
    }

    public enum ActivityType
    {
        Playing,
        Streaming,
        Listening,
        Watching
    }

    public enum ChannelType
    {
        Text,
        Dm,
        Voice,
        Group,
        Category
    }

    public enum ClientApplicationAssetType
    {
        Small,
        Big
    }

    public enum ClientStatus
    {
        Ready,
        Connecting,
        Reconnecting,
        Idle,
        Nearly,
        Disconnected
    }

    public enum ClientVoiceStatus
    {
        Connected,
        Connecting,
        Authenticating,
        Reconnecting,
        Disconnected
    }

    public enum OpCode
    {
        Dispatch,
        Heartbeat,
        Identify,
        StatusUpdate,
        VoiceStateUpdate,
        VoiceGuildPing,
        Resume,
        Reconnect,
        RequestGuildMembers,
        InvalidSession,
        Hello,
        HeartbeatAck
    }

    public enum ClientVoiceOpCodes
    {
        Identify,
        SelectProtocol,
        Ready,
        Heartbeat,
        SessionDescription,
        Speaking,
        Hello,
        ClientConnect,
        ClientDisconnect
    }

    public enum ClientEvents
    {
        [Description("rateLimit")]
        RateLimit,

        [Description("ready")]
        Ready,

        [Description("resumed")]
        Resumed,

        [Description("guildCreate")]
        GuildCreate,

        [Description("guildDelete")]
        GuildDelete,

        [Description("guildUpdate")]
        GuildUpdate,

        [Description("guildUnavailable")]
        GuildUnavailable,

        [Description("guildAvailable")]
        GuildAvailable,

        [Description("guildMemberAdd")]
        GuildMemberAdd,

        [Description("guildMemberRemove")]
        GuildMemberRemove,

        [Description("guildMemberUpdate")]
        GuildMemberUpdate,

        [Description("guildMemberAvailable")]
        GuildMemberAvailable,

        [Description("guildMemberSpeaking")]
        GuildMemberSpeaking,

        GuildMembersChunk,

        GuildIntegrationsUpdate,

        GuildRoleCreate,

        GuildRoleDelete,

        GuildRoleUpdate,

        GuildEmojiCreate,

        GuildEmojiDelete,

        GuildEmojiUpdate,

        GuildBanAdd,

        GuildBanRemove,

        ChannelCreate,

        ChannelDelete,

        ChannelUpdate,

        ChannelPinsUpdate,

        [Description("messageCreate")]
        MessageCreate,

        [Description("messageDelete")]
        MessageDelete,

        MessageUpdate,

        MessageBulkDelete,

        MessageReactionAdd,

        MessageReactionRemove,

        MessageReactionRemoveAll,

        UserUpdate,

        UserNoteUpdate,

        UserSettingsUpdate,

        PresenceUpdate,

        VoiceStateUpdate,

        VoiceBroadcastSubscribe,

        VoiceBroadcastUnsubscribe,

        TypingStart,

        TypingStop,

        WebhooksUpdate,

        Disconnect,

        Reconnecting,

        Error,

        Warn,

        Debug

    }

    public struct ClientPresenceGame
    {
        public readonly string name;
        public readonly int type;

        public ClientPresenceGame(string name, int type)
        {
            this.name = name;
            this.type = type;
        }
    }

    public struct ClientPresence
    {
        public readonly ClientPresenceGame game;
        public readonly string status;
        public readonly int since;
        public readonly bool afk;

        public ClientPresence(ClientPresenceGame game, string status, int since, bool afk)
        {
            this.game = game;
            this.status = status;
            this.since = since;
            this.afk = afk;
        }
    }

    public class Client
    {
        public static readonly CdnEndpoints endpoints = new CdnEndpoints(CdnInfo.cdn);

        public readonly string token;

        private readonly ClientManager manager;

        public Client(string token)
        {
            this.token = token;
            this.manager = new ClientManager(this);
        }

        public void Connect()
        {
            this.manager.connectToWebSocket();
        }
    }
}