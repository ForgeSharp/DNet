using Newtonsoft.Json;

namespace DNet.API.Gateway
{
    public struct GatewayHelloMessage
    {
        [JsonProperty("heartbeat_interval")]
        public readonly int heartbeatInterval;
    }
}
