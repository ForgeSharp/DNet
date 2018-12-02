using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Structures.Guilds
{
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
}
