using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Structures.Messages
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
}
