using DNet.ClientStructures;
using DNet.Core;
using Newtonsoft.Json;

namespace DNet.ClientMessages {
    public struct ClientHeartbeatMessage {
        [JsonProperty("op")]
        public readonly int opCode;
        
        public readonly int? d;

        public ClientHeartbeatMessage(int opCode, int? d) {
            this.opCode = opCode;
            this.d = d;
        }
    }

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

    public struct ClientIdentifyMessage {
        public readonly string token;
        public readonly ClientIdentifyMessageProperties properties;
        public readonly bool compress;

        [JsonProperty("large_threshold")]
        public readonly int largeThreshold;

        public readonly int[] shard;
        public readonly ClientPresence presence;

        public ClientIdentifyMessage(string token, ClientIdentifyMessageProperties properties, bool compress, int largeThreshold, int[] shard, ClientPresence presence) {
            this.token = token;
            this.properties = properties;
            this.compress = compress;
            this.largeThreshold = largeThreshold;
            this.shard = shard;
            this.presence = presence;
        }
    }
}