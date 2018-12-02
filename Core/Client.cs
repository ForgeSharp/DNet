using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DNet.Core;
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
        // TODO
        public User? User { get; private set; }

        public static readonly CdnEndpoints endpoints = new CdnEndpoints(DiscordEndpoints.CDN);
        public static readonly HttpClient httpClient = new HttpClient();

        public readonly Dictionary<string, Guild> guilds;
        public readonly Dictionary<string, User> users;
        public readonly ClientToolbox toolbox;

        // TODO: Implement Channel structure
        // public readonly Dictionary<string, Channel> channels;

        private readonly ClientManager manager;

        private string token;

        public Client()
        {
            this.manager = new ClientManager(this);
            this.guilds = new Dictionary<string, Guild>();
            this.users = new Dictionary<string, User>(); ;
            this.toolbox = new ClientToolbox(this);
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