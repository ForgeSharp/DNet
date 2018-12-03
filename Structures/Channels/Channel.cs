using DNet.ClientStructures;
using Newtonsoft.Json;

namespace DNet.Structures.Channels
{
    public class Channel : ClientInjectable
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public ChannelType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
