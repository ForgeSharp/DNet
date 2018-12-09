using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DNet.ClientStructures.Toolbox
{
    public partial class ClientToolbox
    {
        public delegate void ActionCallback<ResultType>(ResultType result);

        public static readonly uint maxRequests = 120;
        public static readonly uint safetyMargin = 3;
        public static readonly uint resetTimeInSeconds = 60;

        private readonly Client client;
        private readonly Queue<ToolboxAction> queue;

        private uint requests;

        public ClientToolbox(Client client)
        {
            this.client = client;
            this.queue = new Queue<ToolboxAction>();
            this.requests = 0;
        }

        // TODO: Clear requests interval (every resetTimeInSeconds seconds) should run regardless
        private void ProcessQueue()
        {
            while (this.queue.Count > 0)
            {
                if (this.requests >= (ClientToolbox.maxRequests - ClientToolbox.safetyMargin))
                {
                    Task.Delay((int)ClientToolbox.resetTimeInSeconds);
                    this.requests = 0;
                }

                ToolboxAction action = this.queue.Peek();

                action.Action.DynamicInvoke(action.Parameters);
                this.requests++;
                this.queue.Dequeue();
            }
        }

        private InjectableType InjectClient<InjectableType>(ref InjectableType injectable) where InjectableType : ClientInjectable
        {
            return this.client.InjectByReference(ref injectable);
        }

        public void Enqueue<ResultType>(ToolboxAction action, ActionCallback<ResultType> callback)
        {
            action.Callback += (object result) => {
                callback((ResultType)result);
            };

            this.queue.Enqueue(action);
            this.ProcessQueue();
        }

        public static async Task<StructureType>FetchStructure<StructureType>(string url)
        {
            var response = await ClientToolbox.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                StructureType result = JsonConvert.DeserializeObject<StructureType>(await response.Content.ReadAsStringAsync());

                return result;
            }

            return default(StructureType);
        }

        public async Task<StructureType>FetchInjectableStructure<StructureType>(string url) where StructureType : ClientInjectable
        {
            var response = await ClientToolbox.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                StructureType result = this.client.CreateStructure<StructureType>(await response.Content.ReadAsStringAsync());

                return result;
            }

            return default(StructureType);
        }

        public static ResponseType Request<ResponseType>(string url, HttpMethod method)
        {
            // TODO:
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Send an asynchronous POST-request
        /// </summary>
        public static Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> values = null)
        {
            return Client.httpClient.PostAsync(url, values != null ? new FormUrlEncodedContent(values) : null);
        }

        /// <summary>
        /// Send an asynchronous GET-request
        /// </summary>
        public static Task<HttpResponseMessage> GetAsync(string url)
        {
            return Client.httpClient.GetAsync(url);
        }

        /// <summary>
        /// Send an asynchronous PUT-request
        /// </summary>
        public static Task<HttpResponseMessage> PutAsync(string url, Dictionary<string, string> values = null)
        {
            return Client.httpClient.PutAsync(url, values != null ? new FormUrlEncodedContent(values) : null);
        }

        // TODO: Cleanup inconsistency/mess
        /// <summary>
        /// Send an asynchronous PATCH-request
        /// </summary>
        public static Task<HttpResponseMessage> PatchAsync(string url, Dictionary<string, string> values = null)
        {
            var body = values != null ? new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json") : null;

            if (body != null)
            {
                body.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }

            return Client.httpClient.PatchAsync(url, body);
        }

        /// <summary>
        /// Send an asynchronous DELETE-request
        /// </summary>
        public static Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return Client.httpClient.DeleteAsync(url);
        }
    }
}
