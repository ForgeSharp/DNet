using Newtonsoft.Json;

namespace DNet.Structures.Channels
{
    public class VoiceChannel : GuildChannel
    {
        [JsonProperty("bitrate")]
        public int Bitrate { get; set; }

        [JsonProperty("user_limit")]
        public int UserLimit { get; set; }
    }
}
