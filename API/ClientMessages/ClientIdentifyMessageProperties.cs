using Newtonsoft.Json;

namespace DNet.API.ClientMessages
{
    // TODO
    public struct ClientHeartbeatMessage {
        [JsonProperty("op")]
        public readonly int opCode;
        
        [JsonProperty("d")]
        public readonly int? d;

        public ClientHeartbeatMessage(int opCode, int? d) {
            this.opCode = opCode;
            this.d = d;
        }
    }
}