using Newtonsoft.Json;

namespace DNet.Structures.Channels
{
    public class DmBasedChannel : TextBasedChannel
    {
        [JsonProperty("recipients")]
        public User[] Recipients { get; set; }
    }
}
