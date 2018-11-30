using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DNet.Http;
using DNet.Socket;
using DNet.Structures;

namespace DNet
{
    // Discord Event Handler Delegates
    public delegate void MessageCreateHandler(dynamic message);

    public class ClientManager
    {
        public readonly SocketHandle socketHandle;

        private readonly Client client;

        public ClientManager(Client client)
        {
            this.client = client;
            this.socketHandle = new SocketHandle(this.client);
        }

        public Task Connect()
        {
            return this.socketHandle.Connect();
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

    public class Client : IDisposable
    {
        public static readonly CdnEndpoints endpoints = new CdnEndpoints(CdnInfo.cdn);
        public static readonly HttpClient httpClient = new HttpClient();

        public readonly Dictionary<string, Guild> guilds;
        public readonly Dictionary<string, User> users;

        // TODO: Implement Channel structure
        // public readonly Dictionary<string, Channel> channels;

        private readonly ClientManager manager;

        private string token;

        public Client()
        {
            this.manager = new ClientManager(this);
            this.guilds = new Dictionary<string, Guild>();
            this.users = new Dictionary<string, User>(); ;
        }

        public Task Connect(string token)
        {
            this.token = token;
            Client.httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bot", this.token);

            return this.manager.Connect();
        }

        public string GetToken()
        {
            return this.token;
        }

        public SocketHandle GetHandle()
        {
            return this.manager.socketHandle;
        }

        public async void CreateMessage(string channel, string content)
        {
            var response = await Client.PostAsync(API.CreateMessage(channel, content), new Dictionary<string, string>() {
                {"content", content}
            });

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine($"Could not create message: {response.StatusCode}");
            }
        }

        public static Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> values)
        {
            return Client.httpClient.PostAsync(url, new FormUrlEncodedContent(values));
        }

        public void Dispose()
        {
            this.users.Clear();
            this.guilds.Clear();
        }
    }
}