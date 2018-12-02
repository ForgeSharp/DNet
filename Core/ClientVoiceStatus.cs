using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Core
{
    public enum ClientVoiceStatus
    {
        Connected,
        Connecting,
        Authenticating,
        Reconnecting,
        Disconnected
    }
}
