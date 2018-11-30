using Newtonsoft.Json;

namespace DNet.Structures
{
    public enum MessageType
    {
        Normal
    }

    public struct MessageReaction
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("me")]
        public bool Me { get; set; }

        [JsonProperty("emoji")]
        public Emoji Emoji { get; set; }
    }

    public struct MessageAttachment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("proxy_url")]
        public string ProxyUrl { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }
    }

    public struct Message
    {
        public MessageType Type { get; set; }

        public bool TTS { get; set; }

        public bool Pinned { get; set; }

        public string Nonce { get; set; }

        public MessageReaction[] Mentions { get; set; }

        [JsonProperty("mention_everyone")]
        public bool MentionsEveryone { get; set; }

        [JsonProperty("mention_roles")]
        public MessageReaction[] MentionedRoles { get; set; }

        public string Content { get; set; }

        public User Author { get; set; }

        // TODO:
        public dynamic[] Attachments { get; set; }

        // TODO: Resolve to Guild instead
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }
}