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

        [Description("channelCreate")]
        ChannelCreate,

        [Description("channelDelete")]
        ChannelDelete,

        [Description("channelUpdate")]
        ChannelUpdate,

        ChannelPinsUpdate,

        [Description("messageCreate")]
        MessageCreate,

        [Description("messageDelete")]
        MessageDelete,

        [Description("messageUpdate")]
        MessageUpdate,

        [Description("messageBulkDelete")]
        MessageBulkDelete,

        [Description("messageReactionAdd")]
        MessageReactionAdd,

        [Description("messageReactionRemove")]
        MessageReactionRemove,

        MessageReactionRemoveAll,

        [Description("userUpdate")]
        UserUpdate,

        UserNoteUpdate,

        UserSettingsUpdate,

        PresenceUpdate,

        VoiceStateUpdate,

        VoiceBroadcastSubscribe,

        VoiceBroadcastUnsubscribe,

        [Description("typingStart")]
        TypingStart,

        [Description("typingStop")]
        TypingStop,

        WebhooksUpdate,

        Disconnect,

        Reconnecting,

        Error,

        Warn,

        Debug

    }
}
