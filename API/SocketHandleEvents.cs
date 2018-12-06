using DNet.API.Gateway;
using DNet.Structures.Guilds;
using System;

namespace DNet.API
{
    public partial class SocketHandle
    {
        // TODO
        // Discord Events
        public event EventHandler OnRateLimit;
        public event EventHandler<ReadyEvent> OnReady;
        public event EventHandler OnResumed;
        public event EventHandler<Guild> OnGuildCreate;
        public event EventHandler<Guild> OnGuildUpdate;
        public event EventHandler<UnavailableGuild> OnGuildDelete;
        //public event EventHandler<UnavailableGuild> OnGuildUnavailable;
        //public event EventHandler<Guild> OnGuildAvailable;
        public event EventHandler OnGuildMemberAdd;
        public event EventHandler OnGuildMemberRemove;
        public event EventHandler OnGuildMemberUpdate;
        public event EventHandler OnGuildMemberAvailable;
        public event EventHandler OnGuildMemberSpeaking;
        public event EventHandler OnGuildMembersChunk;
        public event EventHandler OnGuildIntegrationsUpdate;
        // ...
        public event EventHandler<Structures.Message> OnMessageCreate;
        public event EventHandler<MessageDeleteEvent> OnMessageDelete;
        public event EventHandler<MessageDeleteBulkEvent> OnMessageDeleteBulk;
        public event EventHandler<Structures.Message> OnMessageUpdate;
        public event EventHandler<MessageReactionEvent> OnMessageReactionAdd;
        public event EventHandler<MessageReactionEvent> OnMessageReactionRemove;
        public event EventHandler<MessageReactionRemoveAllEvent> OnMessageReactionRemoveAll;
        // ...
        public event EventHandler<PresenceUpdateEvent> OnPresenceUpdate;

        public event EventHandler<TypingStartEvent> OnTypingStart;

        public event EventHandler<UserUpdateEvent> OnUserUpdate;
    }
}
