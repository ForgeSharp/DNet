using System;
using DNet.Commands;
using DNet.Core;
using DNet.Structures;

namespace DNet.CommandsTest {
    [CommandName("ping")]
    public class PingCommand : Command
    {
        public override string Name => "ping";
        public override string Description => "View the bot's latency";
        public override string Author => "CloudRex <cloudrex@outlook.com>";
        public override string Version => "1.0.0";

        public override void Run(Context context)
        {
            context.Reply("Ping pong!");
        }
    }
}