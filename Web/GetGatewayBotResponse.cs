using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Web
{
    public struct GetGatewayBotResponse
    {
        public readonly string url;
        public readonly int shards;

        [JsonProperty("session_start_limit")]
        public readonly SessionStartLimit sessionStartLimit;
    }
}
