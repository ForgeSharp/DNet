using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Core
{
    public enum OpCode
    {
        Dispatch,
        Heartbeat,
        Identify,
        StatusUpdate,
        VoiceStateUpdate,
        VoiceGuildPing,
        Resume,
        Reconnect,
        RequestGuildMembers,
        InvalidSession,
        Hello,
        HeartbeatAck
    }
}
