using DNet.Core;
using DNet.Http;
using DNet.Structures;
using DNet.Structures.Channels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DNet.ClientStructures
{
    public class ClientToolbox
    {
        private readonly Client client;

        public ClientToolbox(Client client)
        {
            this.client = client;
        }

        private Message InjectClient(ref Message message)
        {
            message.SetClient(this.client);

            return message;
        }

        // TODO: Return the message
        /// <summary>
        /// Create a message in the specified channel
        /// </summary>
        /// <param name="channelId">The channel in which to send the message</param>
        /// <param name="content">The message's content</param>
        public async Task<Message> CreateMessage(string channelId, string content)
        {
            var response = await ClientToolbox.PostAsync(DiscordAPI.ChannelMessages(channelId), new Dictionary<string, string>() {
                {"content", content}
            });

            if (response.IsSuccessStatusCode)
            {
                Message message = JsonConvert.DeserializeObject<Message>(await response.Content.ReadAsStringAsync());

                // TODO: Should be by reference, Client object may be large
                // Inject client
                return this.InjectClient(ref message);
            }

            return null;
        }

        public static async Task<bool> DeleteMessage(string channelId, string messageId)
        {
            var response = await ClientToolbox.DeleteAsync(DiscordAPI.Message(channelId, messageId));

            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public async Task<Message> EditMessage(string channelId, string messageId, MessageEdit edit)
        {
            if (edit.Content == null && !edit.Embed.HasValue)
            {
                throw new Exception("Expecting MessageEdit to have either content or embed");
            }

            var body = new Dictionary<string, string>();

            if (edit.Content != null)
            {
                body.Add("content", edit.Content);
            }

            if (edit.Embed.HasValue)
            {
                body.Add("embed", JsonConvert.SerializeObject(edit.Embed.Value));
            }

            var response = await ClientToolbox.PatchAsync(DiscordAPI.Message(channelId, messageId), body);

            Console.WriteLine("Response: {0}", await response.Content.ReadAsStringAsync());

            if (response != null && response.IsSuccessStatusCode)
            {
                Message message = JsonConvert.DeserializeObject<Message>(await response.Content.ReadAsStringAsync());

                // TODO: Should be by reference, Client object may be large
                // Inject client
                return this.InjectClient(ref message);
            }

            return null;
        }

        public static async Task<bool> CreateReaction(string channelId, string messageId, SimpleEmoji emoji)
        {
            var response = await ClientToolbox.PostAsync(DiscordAPI.MessageReaction(channelId, messageId, emoji.ToString()));

            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public static async Task<bool> DeleteOwnReaction(string channelId, string messageId, SimpleEmoji emoji)
        {
            var response = await ClientToolbox.DeleteAsync(DiscordAPI.MessageReaction(channelId, messageId, emoji.ToString()));

            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public static async Task<bool> DeleteUserReaction(string channelId, string messageId, SimpleEmoji emoji, string userId)
        {
            var response = await ClientToolbox.DeleteAsync(DiscordAPI.MessageReaction(channelId, messageId, emoji.ToString(), userId));

            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public static async Task<bool> DeleteAllReactions(string channelId, string messageId)
        {
            var response = await ClientToolbox.DeleteAsync(DiscordAPI.Message(channelId, messageId));

            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public Task<ChannelType>GetChannel<ChannelType>(string channelId) where ChannelType : Channel
        {
            // TODO: Need to inject client
            return ClientToolbox.FetchStructure<ChannelType>(DiscordAPI.Channel(channelId));
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

        public static void Request<ResponseType>(string url, HttpMethod method)
        {
            // TODO:
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
