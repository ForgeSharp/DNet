using Newtonsoft.Json;

namespace DNet.Structures.Users
{
    public struct ActivityAssets
    {
        [JsonProperty("large_image")]
        public string LargeImageId { get; set; }

        [JsonProperty("large_text")]
        public string LargeText { get; set; }

        [JsonProperty("small_image")]
        public string SmallImageId { get; set; }

        [JsonProperty("small_text")]
        public string SmallText { get; set; }
    }
}
