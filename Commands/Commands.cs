using System;
using DNet.Core;
using DNet.Fragments;
using DNet.Structures;

namespace DNet.Commands
{
    public abstract class GenericCommand : IPackage, IDisposable
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string Author { get; }
        public abstract string Version { get; }

        protected readonly Bot Bot;
        protected readonly Message Message;
        protected readonly Message Msg;

        protected GenericCommand(Bot bot, Message message)
        {
            this.Bot = bot;
            this.Message = message;
            this.Msg = this.Message;
        }

        public abstract void Run(IContext context);

        public virtual bool MayRun()
        {
            return true;
        }

        public virtual void Dispose()
        {
            return;
        }
    }

    public abstract class Command : GenericCommand
    {
        protected Command(Bot bot, Message message) : base(bot, message)
        {
            //
        }
    }
}