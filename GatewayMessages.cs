using Newtonsoft.Json;

namespace DNet.Http.Gateway
{
    public struct GatewayMessage
    {
        [JsonProperty("t")]
        public readonly string type;
        
        [JsonProperty("d")]
        public readonly string data;

        [JsonProperty("op")]
        public readonly OpCode opCode;
    }

    public class ClientMessage
    {
        [JsonProperty("t")]
        public string type {get;set;}

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