using Newtonsoft.Json;

namespace DNet.API.ClientMessages {
    public struct ClientIdentifyMessageProperties {
        [JsonProperty("$os")]
        public readonly string os;

        [JsonProperty("$browser")]
        public readonly string browser;

        [JsonProperty("$device")]
        public readonly string device;

        public ClientIdentifyMessageProperties(string os, string browser, string device) {
            this.os = os;
            this.browser = browser;
            this.device = device;
        }
    }
}