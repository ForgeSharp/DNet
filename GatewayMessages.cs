using DNet.Structures;
using Newtonsoft.Json;

namespace DNet.Http.Gateway
{
    public struct GatewayMessage<DataType>
    {
        [JsonProperty("t")]
        public string Type { get; set; }

        [JsonProperty("d")]
        public DataType Data { get; set; }

        [JsonProperty("op")]
        public OpCode OpCode { get; set; }
    }

    public struct ClientMessage<DataType>
    {
        [JsonProperty("t")]
        public string Type { get; set; }

        [JsonProperty("d")]
        public dynamic Data { get; set; }

        [JsonProperty("op")]
        public OpCode OpCode { get; set; }
    }

    public struct GatewayHelloMessage
    {
        [JsonProperty("heartbeat_interval")]
        public readonly int heartbeatInterval;
    }

    public struct PresenceUpdateEvent
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("roles")]
        public string[] RoleIds { get; set; }

        [JsonProperty("game")]
        public Activity? Game { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        // TODO: String enum
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("activities")]
        public Activity[] Activities { get; set; }
    }

    public struct MessageDeleteEvent
    {
        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; }

        [JsonProperty("guild_id")]
        public string GuildId { get; }
    }

    public struct MessageReactionEvent
    {
        [JsonProperty("user_id")]
        public string UserId { get; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; }

        [JsonProperty("message_id")]
        public string MessageId { get; }

        [JsonProperty("guild_id")]
        public string GuildId { get; }

        // TODO: Partial emoji
        [JsonProperty("emoji")]
        public Emoji Emoji { get; }
    }

    public struct MessageReactionRemoveAllEvent
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; }

        [JsonProperty("message_id")]
        public string MessageId { get; }

        [JsonProperty("guild_id")]
        public string GuildId { get; }
    }
}