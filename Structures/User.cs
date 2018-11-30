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

    public enum NitroSubscription
    {
        NitroClassic = 1,
        Nitro
    }

    public enum ActivityType
    {
        Playing,
        Streaming,
        Listening,
        Watching
    }

    public struct ActivityTimestamps
    {
        [JsonProperty("start")]
        public int? Start { get; set; }

        [JsonProperty("end")]
        public int? End { get; set; }
    }

    public struct ActivityParty
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("size")]
        public int?[] Size { get; set; }
    }

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

    public struct ActivitySecrets
    {
        [JsonProperty("join")]
        public string Join { get; set; }

        [JsonProperty("spectate")]
        public string Spectate { get; set; }

        [JsonProperty("match")]
        public string Match { get; set; }
    }

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