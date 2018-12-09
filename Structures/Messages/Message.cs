using DNet.Structures.Channels;
using DNet.Structures.Guilds;
using DNet.Structures.Messages;
using Newtonsoft.Json;

namespace DNet.Structures
{
    public class Message : GenericMessage
    {
        public Guild Guild
        {
            get
            {
                if (this.Client == null)
                {
                    return null;
                }

                return this.Client.guilds[this.GuildId];
            }
        }

        public TextChannel Channel
        {
            get
            {
                if (this.Client == null)
                {
                    return null;
                }

                return (TextChannel)this.Client.channels[this.ChannelId];
            }
        }

        // TODO: Partial member
        [JsonProperty("member")]
        public GuildMember? Member { get; set; }

        [JsonProperty("tts")]
        public bool TTS { get; set; }

        [JsonProperty("mention_roles")]
        public MessageReaction[] MentionedRoles { get; set; }

        // TODO: Resolve to Guild instead
        [JsonProperty("guild_id")]
        public string GuildId { get; set; }
    }
}