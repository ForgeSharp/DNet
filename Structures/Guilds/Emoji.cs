using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct Emoji
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roles")]
        public Role[] Roles { get; set; }

        [JsonProperty("user")]
        public User? Author { get; set; }

        [JsonProperty("require_colons")]
        public bool RequiresColons { get; set; }

        [JsonProperty("managed")]
        public bool Managed { get; set; }

        [JsonProperty("animated")]
        public bool Animated { get; set; }
    }
}
