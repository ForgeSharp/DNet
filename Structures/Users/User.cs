using DNet.Structures.Users;
using Newtonsoft.Json;

namespace DNet.Structures
{
    public struct User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [JsonProperty("avatar")]
        public string AvatarHash { get; set; }

        [JsonProperty("bot")]
        public bool? Bot { get; set; }

        [JsonProperty("mfa_enabled")]
        public bool? MfaEnabled { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("verified")]
        public bool? VerifiedEmail { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("flags")]
        public int Flags { get; set; }

        [JsonProperty("premium_type")]
        public NitroSubscription? Subscription { get; set; }
    }
}