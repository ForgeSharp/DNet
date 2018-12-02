using Newtonsoft.Json;

namespace DNet.Structures.Users
{
    public struct ActivityParty
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("size")]
        public int?[] Size { get; set; }
    }
}
