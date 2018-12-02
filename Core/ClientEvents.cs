using System.ComponentModel;

namespace DNet.Core
{
    public enum ClientEvents
    {
        [Description("rateLimit")]
        RateLimit,

        [Description("ready")]
        Ready,

        [Description("resumed")]
        Resumed,

        [Description("guildCreate")]
        GuildCreate,

        [Description("guildDelete")]
        GuildDelete,

        [Description("guildUpdate")]
        GuildUpdate,

        [Description("guildUnavailable")]
        GuildUnavailable,

        [Description("guildAvailable")]
        GuildAvailable,

        [Description("guildMemberAdd")]
        GuildMemberAdd,

        [Description("guildMemberRemove")]
        GuildMemberRemove,

        [Description("guildMemberUpdate")]
        GuildMemberUpdate,

        [Description("guildMemberAvailable")]
        GuildMemberAvailable,

        [Description("guildMemberSpeaking")]
        GuildMemberSpeaking,

        GuildMembersChunk,

        GuildIntegrationsUpdate,

        GuildRoleCreate,

        GuildRoleDelete,

        GuildRoleUpdate,

        GuildEmojiCreate,

        GuildEmojiDelete,

        GuildEmojiUpdate,

        GuildBanAdd,

        GuildBanRemove,

        ChannelCreate,

        ChannelDelete,

        ChannelUpdate,

        ChannelPinsUpdate,

        [Description("messageCreate")]
        MessageCreate,

        [Description("messageDelete")]
        MessageDelete,

        MessageUpdate,

        MessageBulkDelete,

        MessageReactionAdd,

        MessageReactionRemove,

        MessageReactionRemoveAll,

        UserUpdate,

        UserNoteUpdate,

        UserSettingsUpdate,

        PresenceUpdate,

        VoiceStateUpdate,

        VoiceBroadcastSubscribe,

        VoiceBroadcastUnsubscribe,

        TypingStart,

        TypingStop,

        WebhooksUpdate,

        Disconnect,

        Reconnecting,

        Error,

        Warn,

        Debug

    }
}
