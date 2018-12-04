using Newtonsoft.Json;

namespace DNet.API.Gateway
{
    public struct MessageDeleteBulkEvent
    {
        [JsonProperty("ids")]
        public string[] Ids { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
    }
}
