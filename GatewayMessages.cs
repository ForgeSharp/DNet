using Newtonsoft.Json;

namespace DNet.Http.Gateway
{
    public struct GatewayMessage
    {
        [JsonProperty("d")]
        public readonly dynamic data;

        [JsonProperty("op")]
        public readonly OpCode opCode;
    }

    public class ClientMessage
    {
        [JsonProperty("d")]
        public dynamic data { get; set; }

        [JsonProperty("op")]
        public OpCode opCode { get; set; }
    }

    public struct GatewayHelloMessage
    {
        [JsonProperty("heartbeat_interval")]
        public readonly int heartbeatInterval;
    }
}