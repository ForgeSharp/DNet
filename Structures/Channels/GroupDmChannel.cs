using Newtonsoft.Json;

namespace DNet.Structures.Channels
{
    public class GroupDmChannel : DmBasedChannel
    {
        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("icon")]
        public string IconHash { get; set; }

        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }
    }
}
