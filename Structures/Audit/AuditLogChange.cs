using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct AuditLogChange
    {
        [JsonProperty("new_value")]
        public dynamic NewValue { get; set; }

        [JsonProperty("old_value")]
        public dynamic OldValue { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
