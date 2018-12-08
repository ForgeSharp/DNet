using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
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

        public static async Task<T> GetJsonAsync<T>(string uri) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(await Fetch.GetAsync(uri));
        }

        public static async Task<string> GetAsyncAuthorized(string url, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("authorization", $"Bot {token}");

                return await client.GetStringAsync(url);
            }
        }

        public static async Task<T> GetJsonAsyncAuthorized<T>(string url, string token) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(await Fetch.GetAsyncAuthorized(url, token));
        }
    }
}
