using DNet.Structures.Channels;
using DNet.Structures.Guilds;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace DNet
{
    public static class Utils
    {
        public static async void SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();
            SetInterval(action, timeout);
        }

        public static Type DetermineChannelType(Channel channel)
        {
            switch (channel.Type)
            {
                case ChannelType.Category:
                    {
                        return typeof(CategoryChannel);
                    }

                case ChannelType.DM:
                    {
                        return typeof(DmChannel);
                    }

                case ChannelType.Group:
                    {
                        return typeof(GroupDmChannel);
                    }

                case ChannelType.Text:
                    {
                        return typeof(TextChannel);
                    }

                case ChannelType.Voice:
                    {
                        return typeof(VoiceChannel);
                    }

                default:
                    {
                        throw new InvalidOperationException("Invalid channel type");
                    }
            }
        }

        // TODO: Should use JObject to cast?
        [Obsolete]
        public static T CastChannel<T>(Channel channel) where T : Channel, new()
        {
            if (Utils.DetermineChannelType(channel) == typeof(T))
            {
                return (T)channel;
            }

            return null;
        }
    }
}