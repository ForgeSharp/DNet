using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Core
{
    public struct ClientPresenceGame
    {
        public readonly string name;
        public readonly int type;

        public ClientPresenceGame(string name, int type)
        {
            this.name = name;
            this.type = type;
        }
    }
}
