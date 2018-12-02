namespace DNet.API
{
    public enum ApiErrors : int
    {
        UnknownAccount = 10001,
        UnknownApplication = 10002,
        UnknownChannel = 10003,
        UnknownGuild = 10004,
        UnknownIntegration = 10005,
        UnknownInvite = 10006,
        UnknownMember = 10007,
        UnknownMessage = 10008,
        UnknownOverwrite = 10009,
        UnknownProvider = 10010,
        UnknownRole = 10011,
        UnknownToken = 10012,
        UnknownUser = 10013,
        UnknownEmoji = 10014,
        UnknownWebhook = 10015,
        BotProhibitedEndpoint = 20001,
        BotOnlyEndpoint = 20002,
        MaximumGuilds = 30001,
        MaximumFriends = 30002,
        MaximumPins = 30003,
        MaximumRoles = 30005,
        MaximumReactions = 30010,
        Unauthorized = 40001,
        MissingAccess = 50001,
        InvalidAccountType = 50002,
        CannotExecuteOnDm = 50003,
        EmbedDisabled = 50004,
        CannotEditMessageByOther = 50005
        // ...
    }
}
