using Newtonsoft.Json;

namespace DNet.API.Gateway
{
    public struct TypingStartEvent
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
    }
}
