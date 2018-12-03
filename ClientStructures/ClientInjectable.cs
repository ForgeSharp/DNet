using Newtonsoft.Json;
using System;

namespace DNet.ClientStructures
{
    public class ClientInjectable
    {
        // TODO: Should be set by ref?
        [JsonIgnore]
        protected Client Client { get; set; }

        public void SetClient(Client client)
        {
            if (this.Client == null)
            {
                this.Client = client;
            }
            else
            {
                throw new Exception("Client was already set");
            }
        }
    }
}
