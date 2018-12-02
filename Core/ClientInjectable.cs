using Newtonsoft.Json;

namespace DNet.Core
{
    public class ClientInjectable
    {
        // TODO: Should be set by ref?
        [JsonIgnore]
        protected Client Client { get; set; }
    }
}
