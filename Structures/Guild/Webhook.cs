using Newtonsoft.Json;

namespace DNet.Structures.Guilds
{
    public struct Webhook
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("guild_id")]
        public string GuildId { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("user")]
        public User? User { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
