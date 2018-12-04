using Newtonsoft.Json;

namespace DNet.API.Gateway
{
    public struct MessageDeleteEvent
    {
        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; }

        [JsonProperty("guild_id")]
        public string GuildId { get; }
    }
}
