using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DNet.Web
{
    public static class Fetch
    {
        public static async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task<ResponseType> GetJsonAsync<ResponseType>(string uri)
        {
            return JsonConvert.DeserializeObject<ResponseType>(await Fetch.GetAsync(uri));
        }

        public static async Task<string> GetAsyncAuthorized(string url, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("authorization", $"Bot {token}");

                return await client.GetStringAsync(url);
            }
        }

        public static async Task<ResponseType> GetJsonAsyncAuthorized<ResponseType>(string url, string token)
        {
            return JsonConvert.DeserializeObject<ResponseType>(await Fetch.GetAsyncAuthorized(url, token));
        }
    }
}
