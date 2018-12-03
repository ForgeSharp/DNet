using DNet.Structures.Channels;
using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct Invite
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        // TODO: Guild is partial
        [JsonProperty("guild")]
        public Guild Guild { get; set; }

        // TODO: Channel is partial
        [JsonProperty("channel")]
        public Channel Channel { get; set; }

        [JsonProperty("approximate_presence_count")]
        public int ApproximatePresenceCount { get; set; }

        [JsonProperty("approximate_member_count")]
        public int ApproximateMemberCount { get; set; }
    }
}
