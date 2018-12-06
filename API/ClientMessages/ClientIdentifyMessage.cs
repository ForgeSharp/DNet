using DNet.ClientStructures;
using Newtonsoft.Json;

namespace DNet.API.ClientMessages
{
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