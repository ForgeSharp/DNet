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
            return $"{CdnInfo.api}/channels/{channel}/messages";
        }
    }
}