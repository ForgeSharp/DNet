using DNet.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.API.Gateway
{
    public struct ClientMessage<DataType>
    {
        [JsonProperty("t")]
        public string Type { get; set; }

        [JsonProperty("d")]
        public dynamic Data { get; set; }

        [JsonProperty("op")]
        public OpCode OpCode { get; set; }
    }
}
