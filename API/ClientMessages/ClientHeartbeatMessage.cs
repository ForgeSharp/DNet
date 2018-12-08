using Newtonsoft.Json;

namespace DNet.API.ClientMessages {
    public struct ClientIdentifyMessageProperties {
        [JsonProperty("$os")]
        public string OS { get; set; }

        [JsonProperty("$browser")]
        public string Browser { get; set; }

        [JsonProperty("$device")]
        public string Device { get; set; }
    }
}