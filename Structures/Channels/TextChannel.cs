using Newtonsoft.Json;

namespace DNet.Structures.Channels
{
    public class TextChannel : GuildChannel
    {
        [JsonProperty("rate_limit_per_user")]
        public int RateLimitPerUser { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }
    }
}
