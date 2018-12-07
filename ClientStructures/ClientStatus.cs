using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.ClientStructures
{
    public enum ClientState
    {
        Ready,
        Connecting,
        Reconnecting,
        Idle,
        Nearly,
        Disconnected
    }
}
