namespace DNet.ClientStructures
{
    public enum ClientVoiceOpCodes
    {
        Identify,
        SelectProtocol,
        Ready,
        Heartbeat,
        SessionDescription,
        Speaking,
        Hello,
        ClientConnect,
        ClientDisconnect
    }
}
