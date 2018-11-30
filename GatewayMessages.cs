using System;
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

        public static explicit operator GatewayMessage<DataType>(GatewayMessage<dynamic> value)
        {
            return (GatewayMessage<DataType>)value;
        }
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