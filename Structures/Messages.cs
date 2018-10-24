using Newtonsoft.Json;

namespace DNet.Structures
{
    public enum MessageType
    {
        Normal
    }

    public struct MessageMention
    {
        // TODO:
    }

    public struct Message
    {
        public MessageType type { get; set; }
        public bool tts { get; set; }
        public bool pinned { get; set; }
        public string nonce { get; set; }
        public MessageMention[] mentions { get; set; }

        [JsonProperty("mention_everyone")]
        public bool mentionsEveryone { get; set; }

        [JsonProperty("mention_roles")]
        public MessageMention[] mentionedRoles { get; set; }

        public string content { get; set; }
        public User author { get; set; }

        // TODO:
        public dynamic[] attachments { get; set; }

        // TODO: Resolve to Guild instead
        [JsonProperty("guild_id")]
        public string guildId { get; set; }

        [JsonProperty("channel_id")]
        public string channelId { get; set; }
    }
}