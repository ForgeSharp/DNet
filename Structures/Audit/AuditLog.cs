using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct AuditLog
    {
        [JsonProperty("webhooks")]
        public Webhook[] Webhooks { get; set; }

        [JsonProperty("users")]
        public User[] Users { get; set; }

        [JsonProperty("audit_log_entries")]
        public AuditLogEntry[] Entries { get; set; }
    }
}
