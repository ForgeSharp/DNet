using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct UnavailableGuild
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("unavailable")]
        public bool Unavailable { get; set; }
    }
}
