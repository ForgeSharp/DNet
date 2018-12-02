using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DNet.Core;
using DNet.Http;
using DNet.Socket;
using DNet.Structures;
using DNet.Structures.Guilds;
using DNet.Web;

namespace DNet
{
    // Discord Event Handler Delegates
    public delegate void MessageCreateHandler(dynamic message);

    public class Client : IDisposable
    {
        public static readonly CdnEndpoints endpoints = new CdnEndpoints(CdnInfo.cdn);
        public static readonly HttpClient httpClient = new HttpClient();

        public readonly Dictionary<string, Guild> guilds;
        public readonly Dictionary<string, User> users;

        // TODO: Implement Channel structure
        // public readonly Dictionary<string, Channel> channels;

        private readonly ClientManager manager;

        private string token;

        public Client()
        {
            this.manager = new ClientManager(this);
            this.guilds = new Dictionary<string, Guild>();
            this.users = new Dictionary<string, User>(); ;
        }

        // TODO: Check if already connected, if so, disconnect THEN connect new session
        /// <summary>
        /// Initiate connection the client to Discord's gateway
        /// </summary>
        public Task Connect(string token)
        {
            this.token = token;
            Client.httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bot", this.token);

            return this.manager.Connect();
        }

        public string GetToken()
        {
            return this.token;
        }

        /// <summary>
        /// Get the socket handle for event handling
        /// </summary>
        public SocketHandle GetHandle()
        {
            return this.manager.socketHandle;
        }

        // TODO: Return the message
        /// <summary>
        /// Create a message in the specified channel
        /// </summary>
        /// <param name="channel">The channel in which to send the message</param>
        /// <param name="content">The message's content</param>
        public async Task<bool> CreateMessage(string channel, string content)
        {
            var response = await Client.PostAsync(DiscordAPI.CreateMessage(channel, content), new Dictionary<string, string>() {
                {"content", content}
            });

            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Send an asynchronous POST-request
        /// </summary>
        public static Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> values)
        {
            return Client.httpClient.PostAsync(url, new FormUrlEncodedContent(values));
        }

        /// <summary>
        /// Dispose used resources
        /// </summary>
        public void Dispose()
        {
            this.users.Clear();
            this.guilds.Clear();
        }
    }
}