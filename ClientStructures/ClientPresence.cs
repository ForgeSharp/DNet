using Newtonsoft.Json;

namespace DNet.ClientStructures
{
    public struct ClientPresence
    {
        [JsonProperty("game")]
        public ClientPresenceGame Game { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("since")]
        public int Since { get; set; }

        [JsonProperty("afk")]
        public bool AFK { get; set; }
    }
}
