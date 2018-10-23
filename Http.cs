using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DNet.Http
{
    public enum FetchAuthorizationType
    {
        [Description("Bot")]
        Bot
        // TODO: User
    }

    public struct FetchAuthorization
    {
        public readonly string type;
    }

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
                client.DefaultRequestHeaders.Add("authorization", "Bot " + token);

                return await client.GetStringAsync(url);
            }
        }

        public static async Task<ResponseType> GetJsonAsyncAuthorized<ResponseType>(string url, string token)
        {
            return JsonConvert.DeserializeObject<ResponseType>(await Fetch.GetAsyncAuthorized(url, token));
        }
    }

    public struct SessionStartLimit
    {
        public readonly int total;
        public readonly int remaining;

        [JsonProperty("reset_after")]
        public readonly int resetAfter;
    }

    public struct GetGatewayBotResponse
    {
        public readonly string url;
        public readonly int shards;

        [JsonProperty("session_start_limit")]
        public readonly SessionStartLimit sessionStartLimit;
    }

    public static class CdnInfo
    {
        public static int version = 7;
        public static string api = "https://discordapp.com/api";
        public static string cdn = "https://cdn.discordapp.com";
        public static string invite = "https://discord.gg";
    }

    // TODO: Use direct CdnInfo.api/cdn/invite instead of single root
    public class CdnEndpoints
    {
        public static readonly string UserAgent = "DiscordBot (cloudrex.me, 0.0.1) CSharp/7";
        public static readonly int[] AllowedImageSizes = { 16, 32, 64, 128, 256, 512, 1024, 2048 };
        public static readonly string[] AllowedImageFormats = { "webp", "png", "jpg", "gif" };

        private string root;

        public CdnEndpoints(string root)
        {
            this.root = root;
        }

        private string MakeImageUrl(string root, int size, string format = "webp")
        {
            if (!CdnEndpoints.AllowedImageFormats.Contains(format))
            {
                throw new System.IndexOutOfRangeException("IMAGE_FORMAT");
            }

            if (size != 0 && !CdnEndpoints.AllowedImageSizes.Contains(size))
            {
                throw new System.IndexOutOfRangeException("IMAGE_SIZE");
            }

            string query = size != 0 ? $"?size={size}" : "";

            return $"{this.root}.{format}{query}";
        }

        public string Emoji(string emojiId, string format = "png")
        {
            return $"{this.root}/emojis/{emojiId}.{format}";
        }

        public string Asset(string name)
        {
            return $"{this.root}/assets/{name}";
        }

        public string DefaultAvatar(int number)
        {
            return $"{this.root}/embed/avatars/{number}.png";
        }

        public string Avatar(string userId, string hash, int size, string format = "default")
        {
            string finalFormat = format;

            if (finalFormat == "default")
            {
                finalFormat = hash.StartsWith("a_") ? "gif" : "webp";
            }

            return this.MakeImageUrl($"{this.root}/avatars/{userId}/{hash}", size, format);
        }

        public string Icon(string guildId, string hash, int size, string format = "webp")
        {
            return this.MakeImageUrl($"{root}/icons/{guildId}/{hash}", size, format);
        }

        public string AppIcon(string clientId, string hash, int size, string format = "webp")
        {
            return this.MakeImageUrl($"{root}/app-icons/{clientId}/{hash}", size, format);
        }

        public string AppAsset(string clientId, string hash, int size, string format = "webp")
        {
            return this.MakeImageUrl($"{root}/app-assets/{clientId}/{hash}", size, format);
        }

        public string GdmIcon(string channelId, string hash, int size, string format = "webp")
        {
            return this.MakeImageUrl($"{root}/channel-icons/{channelId}/{hash}", size, format);
        }

        public string Splash(string guildId, string hash, int size, string format = "webp")
        {
            return this.MakeImageUrl($"{root}/splashes/{guildId}/{hash}", size, format);
        }

        public string Invite(string code)
        {
            return $"{this.root}/{code}";
        }
    }

    public static class ApiEndpoints
    {
        public static string BotGateway()
        {
            return $"{CdnInfo.api}/gateway/bot";
        }
    }
}