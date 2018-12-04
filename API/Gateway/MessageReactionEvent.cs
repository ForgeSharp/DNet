using DNet.Structures.Guilds;
using Newtonsoft.Json;

namespace DNet.API.Gateway
{
    public class MessageReactionEvent : MessageReactionRemoveAllEvent
    {
        [JsonProperty("user_id")]
        public string UserId { get; }

        // TODO: Partial emoji
        [JsonProperty("emoji")]
        public Emoji Emoji { get; }
    }
}
