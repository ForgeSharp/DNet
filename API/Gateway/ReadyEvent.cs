using DNet.Structures;
using DNet.Structures.Guilds;
using Newtonsoft.Json;
using System;

namespace DNet.API.Gateway
{
    public class ReadyEvent : EventArgs
    {
        [JsonProperty("v")]
        public int GatewayVersion { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("guilds")]
        public UnavailableGuild[] Guilds { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }
    }
}
