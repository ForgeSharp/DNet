using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using DNet.ClientMessages;
using DNet.Http;
using DNet.Http.Gateway;
using DNet.Structures;
using Newtonsoft.Json;
using PureWebSockets;

namespace DNet.Socket
{
    // Discord Event Handler Delegates
    public delegate void MessageCreateHandler(DNet.Structures.Message message);

    public class SocketHandle
    {
        // Discord Events
        public event EventHandler OnRateLimit;
        public event EventHandler OnReady;
        public event EventHandler OnResumed;
        public event EventHandler OnGuildCreate;
        public event EventHandler OnGuildDelete;
        public event EventHandler OnGuildUpdate;
        public event EventHandler OnGuildUnavailable;
        public event EventHandler OnGuildAvailable;
        public event EventHandler OnGuildMemberAdd;
        public event EventHandler OnGuildMemberRemove;
        public event EventHandler OnGuildMemberUpdate;
        public event EventHandler OnGuildMemberAvailable;
        public event EventHandler OnGuildMemberSpeaking;
        public event EventHandler OnGuildMembersChunk;
        public event EventHandler OnGuildIntegrationsUpdate;
        // ...
        public event MessageCreateHandler OnMessageCreate;
        public event EventHandler OnMessageDelete;
        public event EventHandler OnMessageUpdate;

        private readonly Client client;

        private Nullable<int> heartbeatLastSequence = null;
        private PureWebSocket socket;

        public SocketHandle(Client client)
        {
            this.client = client;
        }

        public async Task Connect()
        {
            Console.WriteLine($"Authenticating using token '{this.client.GetToken()}'");

            // TODO: Use response
            var response = await Fetch.GetJsonAsyncAuthorized<GetGatewayBotResponse>(API.BotGateway(), this.client.GetToken());
            var convertedResponse = JsonConvert.SerializeObject(response);
            var connectionUrl = (string)JsonConvert.DeserializeObject<dynamic>(await Fetch.GetAsync(API.Gateway())).url;

            this.socket = new PureWebSocket(connectionUrl, new PureWebSocketOptions() { });

            // Events
            this.socket.OnMessage += this.WS_OnMessage;
            this.socket.OnClosed += this.WS_OnClosed;

            // Connect
            this.socket.Connect();

            // TODO: Debugging
            Console.WriteLine($"GOT url => {convertedResponse}");
        }

        private void WS_OnMessage(string messageString)
        {
            // TODO: Debugging
            // Console.WriteLine($"WS Received => {messageString}");

            GatewayMessage<dynamic> message = JsonConvert.DeserializeObject<GatewayMessage<dynamic>>(messageString);

            Console.WriteLine($"WS Handling message with OPCODE '{message.OpCode}'");

            Console.WriteLine(messageString);

            switch (message.OpCode)
            {
                case OpCode.Hello:
                    {
                        GatewayHelloMessage helloMessage = (GatewayHelloMessage)JsonConvert.DeserializeObject<GatewayHelloMessage>(JsonConvert.SerializeObject(message.Data));

                        Console.WriteLine($"WS Acknowledged heartbeat at {helloMessage.heartbeatInterval}ms interval");

                        // TODO: To know when to stop, pass CONNECTED or similar BY REFERENCE
                        Utils.SetInterval(() =>
                        {
                            this.Send(OpCode.Heartbeat, new ClientHeartbeatMessage(1, this.heartbeatLastSequence));
                        }, TimeSpan.FromMilliseconds(helloMessage.heartbeatInterval));

                        var dat = new ClientIdentifyMessage(
                            this.client.GetToken(),

                            new ClientIdentifyMessageProperties(
                                "Linux",
                                "disco",
                                "disco"
                            ),

                            false,

                            250,

                            // TODO: Hard-coded
                            new int[] { 0, 1 },

                            new ClientPresence(
                                new ClientPresenceGame("Sometg", 0),

                                "dnd",

                                91879201,
                                false
                            )
                        );

                        Console.WriteLine("Sending ...");

                        this.Send(OpCode.Identify, dat);

                        break;
                    }

                case OpCode.Dispatch:
                    {
                        switch (message.Type)
                        {
                            case "MESSAGE_CREATE":
                                {
                                    this.OnMessageCreate(JsonConvert.DeserializeObject<DNet.Structures.Message>(JsonConvert.SerializeObject(message.Data)));

                                    break;
                                }

                            case "GUILD_CREATE":
                                {
                                    message = (GatewayMessage<Guild>)message;
                                    if (this.client.guilds.ContainsKey(message.Data.))

                                    break;
                                }

                            default:
                                {
                                    Console.WriteLine($"Unknown dispatch message type: {message.Type}");

                                    break;
                                }
                        }

                        break;
                    }

                default:
                    {
                        Console.WriteLine($"WS Unable to handle OPCODE '{message.OpCode}' (Not implemented)");

                        break;
                    }
            }
        }

        private void WS_OnClosed(WebSocketCloseStatus reason)
        {
            Console.WriteLine($"WS Socket closed => {reason.ToString()}");
        }

        private void Send<DataType>(OpCode opCode, DataType data)
        {
            var message = new ClientMessage<DataType>()
            {
                Data = data,
                OpCode = opCode
            };

            var serializedMessage = JsonConvert.SerializeObject(message);

            this.socket.Send(serializedMessage);
            Console.WriteLine($"WS Sent => {serializedMessage}");
        }
    }
}