using Newtonsoft.Json;

namespace DNet.Structures
{
    // TODO:
    public struct Role
    {
        public string id { get; set; }
    }

    public struct GuildMember
    {
        // TODO: Use Role struct
        public string[] roles { get; set; }

        [JsonProperty("nick")]
        public string nickname { get; set; }

        [JsonProperty("mute")]
        public bool muted { get; set; }

        [JsonProperty("deaf")]
        public bool deaf { get; set; }
    }
}