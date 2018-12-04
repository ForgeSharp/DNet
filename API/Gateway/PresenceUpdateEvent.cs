using DNet.Structures;
using DNet.Structures.Users;
using Newtonsoft.Json;

namespace DNet.API.Gateway
{
    public struct PresenceUpdateEvent
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("roles")]
        public string[] RoleIds { get; set; }

        [JsonProperty("game")]
        public Activity? Game { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        // TODO: String enum
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("activities")]
        public Activity[] Activities { get; set; }
    }
}
