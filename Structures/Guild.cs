using DNet.Http.Gateway;
using Newtonsoft.Json;

namespace DNet.Structures
{
    public enum GuildVerificationLevel : int
    {
        None,
        VerifiedEmail,
        RegisteredMoreThanFiveMinutes,
        MemberLongerThanTenMinutes,
        VerifiedPhoneNumber
    }

    public enum GuildNotificationLevel : int
    {
        AllMessages,
        OnlyMentions
    }

    public enum GuildMfaLevel : int
    {
        None,
        Elevated
    }

    public enum GuildExplicitFilterLevel : int
    {
        Disabled,
        MembersWithoutRoles,
        AllMembers
    }

    public struct Guild
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
        public Channel?[] Channels { get; set; }

        [JsonProperty("presences")]
        public PresenceUpdateEvent?[] Presences { get; set; }
    }

    public struct UnavailableGuild
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("unavailable")]
        public bool Unavailable { get; set; }
    }

    public struct Emoji
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roles")]
        public Role[] Roles { get; set; }

        [JsonProperty("user")]
        public User? Author { get; set; }

        [JsonProperty("require_colons")]
        public bool RequiresColons { get; set; }

        [JsonProperty("managed")]
        public bool Managed { get; set; }

        [JsonProperty("animated")]
        public bool Animated { get; set; }
    }

    // TODO:
    public struct Role
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public int Color { get; set; }

        [JsonProperty("hoist")]
        public bool Hoisted { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("permissions")]
        public int Permissions { get; set; }

        [JsonProperty("managed")]
        public bool Managed { get; set; }

        [JsonProperty("mentionable")]
        public bool Mentionable { get; set; }
    }

    public struct GuildMember
    {
        // TODO: Use Role struct
        [JsonProperty("roles")]
        public string[] Roles { get; set; }

        [JsonProperty("nick")]
        public string Nickname { get; set; }

        [JsonProperty("mute")]
        public bool Muted { get; set; }

        [JsonProperty("deaf")]
        public bool Deaf { get; set; }
    }

    public struct GuildBan
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public struct AuditLog
    {
        [JsonProperty("webhooks")]
        public Webhook[] Webhooks { get; set; }

        [JsonProperty("users")]
        public User[] Users { get; set; }

        [JsonProperty("audit_log_entries")]
        public AuditLogEntry[] Entries { get; set; }
    }

    public struct Webhook
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("user")]
        public User? User { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public struct AuditLogEntry
    {
        [JsonProperty("target_Id")]
        public string TargetId { get; set; }

        [JsonProperty("changes")]
        public AuditLogChange[] Changes { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("action_type")]
        public AuditLogEvent ActionType { get; set; }

        [JsonProperty("options")]
        public OptionalAuditEntryInfo Options { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }

    public struct OptionalAuditEntryInfo
    {
        [JsonProperty("delete_member_days")]
        public string DeleteMemberDays { get; set; }

        [JsonProperty("members_removed")]
        public string MembersRemoved { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("role_name")]
        public string RoleName { get; set; }
    }

    public enum AuditLogEvent : int
    {
        GuildUpdate = 1,
        ChannelCreate = 10,
        ChannelUpdate,
        ChannelDelete,
        ChannelOverwriteCreate,
        ChannelOverwriteUpdate,
        ChannelOverwriteDelete,
        MemberKick = 20,
        MemberPrune,
        MemberBanAdd,
        MemberBanRemove,
        MemberUpdate,
        MemberRoleUpdate,
        RoleCreate = 30,
        RoleUpdate,
        RoleDelete,
        InviteCreate = 40,
        InviteUpdate,
        InviteDelete,
        WebhookCreate = 50,
        WebhookUpdate,
        WebhookDelete,
        EmojiCreate = 60,
        EmojiUpdate,
        EmojiDelete,
        MessageDelete = 72
    }

    public struct AuditLogChange
    {
        [JsonProperty("new_value")]
        public dynamic NewValue { get; set; }

        [JsonProperty("old_value")]
        public dynamic OldValue { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }

    // TODO: Missing string enum AuditLogChangeKey

    public struct Invite
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        // TODO: Guild is partial
        [JsonProperty("guild")]
        public Guild? Guild { get; set; }

        // TODO: Channel is partial
        [JsonProperty("channel")]
        public Channel Channel { get; set; }

        [JsonProperty("approximate_presence_count")]
        public int ApproximatePresenceCount { get; set; }

        [JsonProperty("approximate_member_count")]
        public int ApproximateMemberCount { get; set; }
    }

    public struct InviteMetadata
    {
        [JsonProperty("inviter")]
        public User Inviter { get; set; }

        [JsonProperty("uses")]
        public int Uses { get; set; }

        [JsonProperty("max_uses")]
        public int MaxUses { get; set; }

        [JsonProperty("max_age")]
        public int MaxAge { get; set; }

        [JsonProperty("temporary")]
        public bool Temporary { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("revoked")]
        public bool Revoked { get; set; }
    }

    public struct VoiceRegion
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("vip")]
        public bool VIP { get; set; }

        [JsonProperty("optimal")]
        public bool Optimal { get; set; }

        [JsonProperty("deprecated")]
        public bool Deprecated { get; set; }

        [JsonProperty("custom")]
        public bool Custom { get; set; }
    }
}