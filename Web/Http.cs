using DNet.Web;

namespace DNet.Http
{
    public static class DiscordAPI
    {
        public static string BotGateway()
        {
            return $"{CdnInfo.api}/gateway/bot";
        }

        public static string Gateway()
        {
            return $"{CdnInfo.api}/gateway";
        }

        public static string CreateMessage(string channel, string content)
        {
            return $"/channels/{channel}/messages";
        }

        public static string Reaction(string channel, string message, string emoji, string user = "@me")
        {
            return $"/channels/{channel}/messages/{message}/reactions/{emoji}/{user}";
        }

        public static string Message(string channel, string message)
        {
            return $"/channels/{channel}/messages/{message}";
        }
    }
}