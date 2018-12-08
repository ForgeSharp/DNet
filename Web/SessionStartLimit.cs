using Newtonsoft.Json;

namespace DNet.Web
{
    public struct SessionStartLimit
    {
        [JsonProperty("total")]
        public int Total;

        [JsonProperty("remaining")]
        public int Remaining;

        [JsonProperty("reset_after")]
        public int ResetAfter;
    }
}
