using DNet.Structures.Channels;
using Newtonsoft.Json;

namespace DNet.Core
{
    public struct MessageEdit
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("embed")]
        public Embed? Embed { get; set; }
    }
}
