using Newtonsoft.Json;

namespace DNet.Structures.Users
{
    public struct ActivityTimestamps
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("end")]
        public int? End { get; set; }
    }
}
