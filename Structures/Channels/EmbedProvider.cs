using Newtonsoft.Json;

namespace DNet.Structures.Channels
{
    public struct EmbedProvider
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
