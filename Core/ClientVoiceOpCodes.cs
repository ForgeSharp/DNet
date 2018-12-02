using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Core
{
    public enum ClientVoiceOpCodes
    {
        Identify,
        SelectProtocol,
        Ready,
        Heartbeat,
        SessionDescription,
        Speaking,
        Hello,
        ClientConnect,
        ClientDisconnect
    }
}
