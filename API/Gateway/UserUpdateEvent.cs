using DNet.Structures;
using Newtonsoft.Json;

namespace DNet.API.Gateway
{
    public struct UserUpdateEvent
    {
        [JsonProperty("old_user")]
        public User? OldUser { get; set; }

        [JsonProperty("updated_user")]
        public User UpdatedUser { get; set; }
    }
}
