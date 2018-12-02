using Newtonsoft.Json;

namespace DNet.Structures.Users
{
    public struct Activity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public ActivityType Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("timestampts")]
        public ActivityTimestamps? Timestampts { get; set; }

        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("party")]
        public ActivityParty? Party { get; set; }

        [JsonProperty("assets")]
        public ActivityAssets? Assets { get; set; }

        [JsonProperty("secrets")]
        public ActivitySecrets? Secrets { get; set; }

        [JsonProperty("instance")]
        public bool? Instance { get; set; }

        [JsonProperty("flags")]
        public int? Flags { get; set; }
    }
}
