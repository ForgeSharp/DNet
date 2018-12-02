using DNet.Structures.Guilds;
using Newtonsoft.Json;

namespace DNet.Structures.Channels
{
    public struct Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public ChannelType Type { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("permission_overwrites")]
        public PermissionOverwrite[] PermissionOverwrites { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("nsfw")]
        public bool NSFW { get; set; }

        [JsonProperty("last_message_id")]
        public string LastMessageId { get; set; }

        [JsonProperty("bitrate")]
        public int Bitrate { get; set; }

        [JsonProperty("user_limit")]
        public int UserLimit { get; set; }

        [JsonProperty("rate_limit_per_user")]
        public int RateLimitPerUser { get; set; }

        [JsonProperty("recipients")]
        public User[] Recipients { get; set; }

        [JsonProperty("icon")]
        public string IconHash { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("last_pin_timestamp")]
        public string LastPinTimestamp { get; set; }

        // Source
        [JsonIgnore]
        private Client Client { get; set; }

        // Resolvables
        public Guild Guild => this.Client.guilds[this.GuildId];
    }
}
