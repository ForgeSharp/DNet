using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
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

        public SocketHandle GetHandle()
        {
            return this.manager.socketHandle;
        }

        public async void CreateMessage(string channel, string content)
        {
            var response = await Client.PostAsync(DiscordAPI.CreateMessage(channel, content), new Dictionary<string, string>() {
                {"content", content}
            });

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine($"Could not create message: {response.StatusCode}");
            }
        }

        public static Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> values)
        {
            return Client.httpClient.PostAsync(url, new FormUrlEncodedContent(values));
        }

        public void Dispose()
        {
            this.users.Clear();
            this.guilds.Clear();
        }
    }
}