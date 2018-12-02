using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Web
{
    public struct SessionStartLimit
    {
        public readonly int total;
        public readonly int remaining;

        [JsonProperty("reset_after")]
        public readonly int resetAfter;
    }
}
