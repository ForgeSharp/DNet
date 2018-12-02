using System;
using System.Collections.Generic;
using System.Text;

namespace DNet.Core
{
    public struct ClientPresence
    {
        public readonly ClientPresenceGame game;
        public readonly string status;
        public readonly int since;
        public readonly bool afk;

        public ClientPresence(ClientPresenceGame game, string status, int since, bool afk)
        {
            this.game = game;
            this.status = status;
            this.since = since;
            this.afk = afk;
        }
    }
}
