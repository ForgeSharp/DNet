using Newtonsoft.Json;

namespace DNet.Web
{
    public struct GetGatewayBotResponse
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("shards")]
        public int Shards { get; set; }

        [JsonProperty("session_start_limit")]
        public SessionStartLimit SessionStartLimit { get; set; }
    }
}
