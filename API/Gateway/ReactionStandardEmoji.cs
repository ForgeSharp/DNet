using Newtonsoft.Json;

namespace DNet.API.Gateway
{
    public struct ReactionStandardEmoji
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
