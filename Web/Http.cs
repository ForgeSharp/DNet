using DNet.Web;

namespace DNet.Http
{
    public static class DiscordAPI
    {
        public static string BotGateway()
        {
            return $"{DiscordEndpoints.API}/gateway/bot";
        }

        public static string Gateway()
        {
            return $"{DiscordEndpoints.API}/gateway";
        }

        public static string CreateMessage(string channel, string content)
        {
            return $"{DiscordEndpoints.API}/channels/{channel}/messages";
        }

        public static string Reaction(string channel, string message, string emoji, string user = "@me")
        {
            return $"{DiscordEndpoints.API}/channels/{channel}/messages/{message}/reactions/{emoji}/{user}";
        }

        public static string Message(string channel, string message)
        {
            return $"{DiscordEndpoints.API}/channels/{channel}/messages/{message}";
        }
    }
}