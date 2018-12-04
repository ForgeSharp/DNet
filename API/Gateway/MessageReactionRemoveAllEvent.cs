using Newtonsoft.Json;

namespace DNet.API.Gateway
{
    public class MessageReactionRemoveAllEvent
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; }

        [JsonProperty("message_id")]
        public string MessageId { get; }

        [JsonProperty("guild_id")]
        public string GuildId { get; }
    }
}
