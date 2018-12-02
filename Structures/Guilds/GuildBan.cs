using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct GuildBan
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
