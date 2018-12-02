using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct AuditLogEntry
    {
        [JsonProperty("target_Id")]
        public string TargetId { get; set; }

        [JsonProperty("changes")]
        public AuditLogChange[] Changes { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("action_type")]
        public AuditLogEvent ActionType { get; set; }

        [JsonProperty("options")]
        public OptionalAuditEntryInfo Options { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
