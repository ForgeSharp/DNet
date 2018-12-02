using DNet.Web;

namespace DNet.Http
{
    public static class DiscordAPI
    {
        public static string BotGateway()
        {
            return $"{DiscordAPI.Gateway()}/bot";
        }

        public static string Gateway()
        {
            return $"{DiscordEndpoints.API}/gateway";
        }

        public static string Channel(string channel)
        {
            return $"{DiscordEndpoints.API}/channels/{channel}";
        }

        public static string ChannelMessages(string channel)
        {
            return $"{DiscordAPI.Channel(channel)}/messages";
        }

        public static string MessageReactions(string channel, string message)
        {
            return $"{DiscordAPI.ChannelMessages(channel)}/{message}/reactions";
        }

        public static string MessageReaction(string channel, string message, string emoji, string user = "@me")
        {
            return $"{DiscordAPI.MessageReactions(channel, message)}/{emoji}/{user}";
        }

        public static string Message(string channel, string message)
        {
            return $"{DiscordAPI.ChannelMessages(channel)}/{message}";
        }
    }
}