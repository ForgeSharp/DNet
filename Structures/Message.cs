using Newtonsoft.Json;

namespace DNet.Structures
{
    public enum MessageType
    {
        Default,
        RecipientAdd,
        RecipientRemove,
        Call,
        ChannelNameChange,
        ChannelIconChange,
        ChannelPinnedMessage,
        GuildMemberJoin
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
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        // TODO: Resolve to Guild instead
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("author")]
        public User Author { get; set; }

        // TODO: Partial member
        [JsonProperty("member")]
        public GuildMember? Member { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("edited_timestamp")]
        public string EditedTimestamp { get; set; }

        [JsonProperty("tts")]
        public bool TTS { get; set; }

        [JsonProperty("mention_everyone")]
        public bool MentionsEveryone { get; set; }

        [JsonProperty("mentions")]
        public MessageReaction[] Mentions { get; set; }

        [JsonProperty("mention_roles")]
        public MessageReaction[] MentionedRoles { get; set; }
        
        [JsonProperty("attachments")]
        public MessageAttachment[] Attachments { get; set; }

        [JsonProperty("embeds")]
        public Embed[] Embeds { get; set; }

        [JsonProperty("reactions")]
        public MessageReaction?[] Reactions { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("webhook_id")]
        public string WebhookId { get; set; }

        [JsonProperty("type")]
        public MessageType Type { get; set; }

        [JsonProperty("activity")]
        public MessageActivity? Activity { get; set; }

        [JsonProperty("application")]
        public MessageApplication? Application { get; set; }
    }

    public struct MessageActivity
    {
        [JsonProperty("type")]
        public MessageActivityType Type { get; set; }

        [JsonProperty("party_id")]
        public string PartyId { get; set; }
    }

    public enum MessageActivityType
    {
        Join = 1,
        Spectate,
        Listen,
        JoinRequest
    }

    public struct MessageApplication
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cover_image")]
        public string CoverImageId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string IconId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}