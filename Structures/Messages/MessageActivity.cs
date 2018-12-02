using Newtonsoft.Json;

namespace DNet.Structures.Messages
{
    public struct MessageActivity
    {
        [JsonProperty("type")]
        public MessageActivityType Type { get; set; }

        [JsonProperty("party_id")]
        public string PartyId { get; set; }
    }
}
