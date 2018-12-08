using System;
using System.Linq;

namespace DNet.Web
{
    // TODO: Use direct CdnInfo.api/cdn/invite instead of single root
    public sealed class CdnEndpoints
    {
        public static readonly string UserAgent = "DiscordBot (cloudrex.me, 0.0.1) CSharp/7";
        public static readonly int[] AllowedImageSizes = { 16, 32, 64, 128, 256, 512, 1024, 2048 };
        public static readonly string[] AllowedImageFormats = { "webp", "png", "jpg", "gif" };

        private readonly string root;

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
}
