using DNet.API.Gateway;
using DNet.ClientStructures;
using DNet.Structures.Channels;
using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public class Guild : ClientInjectable
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("splash")]
        public string SplashHash { get; set; }

        [JsonProperty("owner")]
        public bool? Owner { get; set; }

        [JsonProperty("permissions")]
        public int? Permissions { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("afk_channel_id")]
        public string AfkChannelId { get; set; }

        [JsonProperty("afk_timeout")]
        public int AfkTimeout { get; set; }

        [JsonProperty("embed_enabled")]
        public bool? EmbedEnabled { get; set; }

        [JsonProperty("embed_channel_id")]
        public string EmbedChannelId { get; set; }

        [JsonProperty("verification_level")]
        public GuildVerificationLevel VerificationLevel { get; set; }

        [JsonProperty("default_message_notifications")]
        public GuildNotificationLevel DefaultMessageNotifications { get; set; }

        [JsonProperty("explicit_content_filter")]
        public GuildExplicitFilterLevel ExplicitFilterLevel { get; set; }

        [JsonProperty("roles")]
        public Role[] Roles { get; set; }

        [JsonProperty("emojis")]
        public Emoji[] Emojis { get; set; }

        [JsonProperty("features")]
        public string[] Features { get; set; }

        [JsonProperty("mfa_level")]
        public GuildMfaLevel MfaLevel { get; set; }

        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }

        [JsonProperty("widget_enabled")]
        public bool? WidgetEnabled { get; set; }

        [JsonProperty("widget_channel_id")]
        public string WidgetChannelId { get; set; }

        [JsonProperty("system_channel_id")]
        public string SystemChannelId { get; set; }

        [JsonProperty("joined_at")]
        public string JoinedAt { get; set; }

        [JsonProperty("large")]
        public bool? Large { get; set; }

        [JsonProperty("unavailable")]
        public bool? Unavailable { get; set; }

        [JsonProperty("member_count")]
        public int? MemberCount { get; set; }

        [JsonProperty("members")]
        public GuildMember?[] Members { get; set; }

        // TODO: Not added: voice_states (see at https://discordapp.com/developers/docs/resources/guild#guild-object)

        [JsonProperty("channels")]
        public GuildChannel[] Channels { get; set; }

        [JsonProperty("presences")]
        public PresenceUpdateEvent?[] Presences { get; set; }
    }

    // TODO: Missing string enum AuditLogChangeKey
}