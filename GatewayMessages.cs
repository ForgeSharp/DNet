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

    public class ClientMessage<DataType>
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

        // TODO:
        // [JsonProperty("game")]
        // public Activity? Game { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        // TODO: String enum
        [JsonProperty("status")]
        public string Status { get; set; }

        // TODO:
        // [JsonProperty("activities")]
        // public Activity[] Activities { get; set; }
    }

    public struct MessageDeleteEvent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
    }

    public struct MessageReactionEvent
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        // TODO: Partial emoji
        [JsonProperty("emoji")]
        public Emoji Emoji { get; set; }
    }

    public struct MessageReactionRemoveAllEvent
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
    }
}