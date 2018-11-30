using Newtonsoft.Json;

namespace DNet.Http.Gateway
{
    public struct GatewayMessage<DataType>
    {
        [JsonProperty("t")]
        public string Type { get; set; }

        [JsonProperty("d")]
        public DataType Data { get; set; }

        [JsonProperty("op")]
        public OpCode OpCode { get; set; }
    }

    public class ClientMessage<DataType>
    {
        [JsonProperty("t")]
        public string Type { get; set; }

        [JsonProperty("d")]
        public dynamic Data { get; set; }

        [JsonProperty("op")]
        public OpCode OpCode { get; set; }
    }

    public struct GatewayHelloMessage
    {
        [JsonProperty("heartbeat_interval")]
        public readonly int heartbeatInterval;
    }
}