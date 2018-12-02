using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Core
{
    public enum ClientStatus
    {
        Ready,
        Connecting,
        Reconnecting,
        Idle,
        Nearly,
        Disconnected
    }
}
