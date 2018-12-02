namespace DNet.Structures.Guilds
{
    public enum GuildVerificationLevel : int
    {
        None,
        VerifiedEmail,
        RegisteredMoreThanFiveMinutes,
        MemberLongerThanTenMinutes,
        VerifiedPhoneNumber
    }
}
