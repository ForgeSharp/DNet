using DNet.ClientStructures;
using Newtonsoft.Json;

namespace DNet.Structures.Channels
{
    public class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public ChannelType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        // TODO: Only needs source if it's text-based
        // Source
        [JsonIgnore]
        protected Client Client { get; set; }
    }
}
