using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct OptionalAuditEntryInfo
    {
        [JsonProperty("delete_member_days")]
        public string DeleteMemberDays { get; set; }

        [JsonProperty("members_removed")]
        public string MembersRemoved { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("role_name")]
        public string RoleName { get; set; }
    }
}
