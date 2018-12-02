using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct VoiceRegion
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("vip")]
        public bool VIP { get; set; }

        [JsonProperty("optimal")]
        public bool Optimal { get; set; }

        [JsonProperty("deprecated")]
        public bool Deprecated { get; set; }

        [JsonProperty("custom")]
        public bool Custom { get; set; }
    }
}
