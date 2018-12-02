using Newtonsoft.Json;

namespace DNet.Structures
{
    public struct IntegrationAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
