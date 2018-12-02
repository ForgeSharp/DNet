﻿using Newtonsoft.Json;

namespace DNet.Structures.Users
{
    public struct ActivitySecrets
    {
        [JsonProperty("join")]
        public string Join { get; set; }

        [JsonProperty("spectate")]
        public string Spectate { get; set; }

        [JsonProperty("match")]
        public string Match { get; set; }
    }
}
