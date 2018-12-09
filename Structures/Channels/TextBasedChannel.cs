using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DNet.Structures.Channels
{
    public class TextBasedChannel : Channel
    {
        [JsonProperty("last_message_id")]
        public string LastMessageId { get; set; }

        [JsonProperty("last_pin_timestamp")]
        public string LastPinTimestamp { get; set; }

        public Task<Message> Send(string content)
        {
            // TODO: Add a way to check if can send messages first
            return this.Client.toolbox.CreateMessage(this.Id, content);
        }
    }
}
