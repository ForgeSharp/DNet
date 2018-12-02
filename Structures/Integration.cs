using Newtonsoft.Json;

namespace DNet.Structures
{
    public class Integration
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("syncing")]
        public bool Syncing { get; set; }

        [JsonProperty("role_id")]
        public string RoleId { get; set; }

        [JsonProperty("expire_behaviour")]
        public int ExpireBehaviour { get; set; }

        [JsonProperty("expire_grace_period")]
        public int ExpireGracePeriod { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("account")]
        public IntegrationAccount Account { get; set; }

        [JsonProperty("synced_at")]
        public string SyncedAt { get; set; }
    }
}
