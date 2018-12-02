using Newtonsoft.Json;

namespace DNet.Structures.Messages
{
    public struct MessageApplication
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cover_image")]
        public string CoverImageId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string IconId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
