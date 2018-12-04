using DNet.Core;
using Newtonsoft.Json;

namespace DNet.Http.Gateway
{
    public struct GatewayMessage<DataType> where DataType : new()
    {
        [JsonProperty("t")]
        public string Type { get; set; }

        [JsonProperty("d")]
        public DataType Data { get; set; }

        [JsonProperty("op")]
        public OpCode OpCode { get; set; }
    }
}