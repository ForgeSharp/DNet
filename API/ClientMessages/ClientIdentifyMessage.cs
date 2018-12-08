using DNet.ClientStructures;
using Newtonsoft.Json;

namespace DNet.API.ClientMessages
{
    public struct ClientIdentifyMessage {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("properties")]
        public ClientIdentifyMessageProperties Properties { get; set; }

        [JsonProperty("compress")]
        public bool? Compress { get; set; }

        [JsonProperty("large_threshold")]
        public int? LargeThreshold { get; set; }

        [JsonProperty("shard")]
        public int[] Shards { get; set; }

        [JsonProperty("presence")]
        public ClientPresence Presence { get; set; }
    }
}