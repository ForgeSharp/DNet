using Newtonsoft.Json;

namespace DNet.Structures.Channels
{
    // TODO
    public class TextBasedChannel : Channel
    {
        [JsonProperty("last_message_id")]
        public string LastMessageId { get; set; }

        [JsonProperty("last_pin_timestamp")]
        public string LastPinTimestamp { get; set; }
    }
}
