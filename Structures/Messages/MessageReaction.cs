using DNet.Structures.Guilds;
using Newtonsoft.Json;

namespace DNet.Structures.Messages
{
    public struct MessageReaction
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("me")]
        public bool Me { get; set; }

        [JsonProperty("emoji")]
        public Emoji Emoji { get; set; }
    }
}
