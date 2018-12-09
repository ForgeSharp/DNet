using DNet.Structures.Channels;

namespace DNet.Structures.Messages
{
    public class DmMessage : GenericMessage
    {
        public TextBasedChannel Channel
        {
            get
            {
                if (this.Client == null)
                {
                    return null;
                }

                return (TextBasedChannel)this.Client.channels[this.ChannelId];
            }
        }
    }
}
