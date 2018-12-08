using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DNet.API;
using DNet.ClientStructures.Toolbox;
using DNet.Structures;
using DNet.Structures.Guilds;
using DNet.Web;
using Newtonsoft.Json;

namespace DNet.ClientStructures
{
    // Discord Event Handler Delegates
    public delegate void MessageCreateHandler(dynamic message);

    public sealed class Client : IDisposable
    {
        public User? User { get; set; }
        
        // TODO
        private string SessionId;

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

        public InjectableType Inject<InjectableType>(ref InjectableType injectable) where InjectableType : ClientInjectable
        {
            injectable.SetClient(this);

            return injectable;
        }

        public StructureType CreateStructure<StructureType>(StructureType structure) where StructureType : ClientInjectable {
            return this.Inject(ref structure);
        }

        public StructureType CreateStructure<StructureType>(string structure) where StructureType : ClientInjectable
        {
            return this.CreateStructure<StructureType>(JsonConvert.DeserializeObject<StructureType>(structure));
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

        public void SetSessionId(string sessionid)
        {
            this.SessionId = sessionid;
        }
    }
}
