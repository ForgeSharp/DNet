using Newtonsoft.Json;

namespace DNet.ClientStructures
{
    public class ClientInjectable
    {
        // TODO: Should be set by ref?
        [JsonIgnore]
        protected Client Client { get; set; }

        // TODO: Getting called twice, check the ping command (on edit?)
        public void SetClient(Client client)
        {
            if (this.Client == null)
            {
                this.Client = client;
            }
        }
    }
}
