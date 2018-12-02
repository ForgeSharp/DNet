using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct GuildMember
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("nick")]
        public string Nickname { get; set; }

        [JsonProperty("roles")]
        public string[] Roles { get; set; }

        [JsonProperty("joined_at")]
        public string JoinedAt { get; set; }

        [JsonProperty("deaf")]
        public bool Deaf { get; set; }

        [JsonProperty("mute")]
        public bool Muted { get; set; }
    }
}
