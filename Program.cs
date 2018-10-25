using System;
using System.Threading.Tasks;
using DNet.CommandsTest;
using DNet.Core;
using DNet.Http;
using DNet.Structures;
using DotNetEnv;
using Newtonsoft.Json;

namespace DNet
{
    public class Program
    {
        public static Bot Bot;

        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            Console.WriteLine("Starting ...");

            var startBotTask = Task.Run(Program.StartBot);

            startBotTask.Wait();
        }

        public static async Task StartBot() {
            Program.Bot = new Bot(Environment.GetEnvironmentVariable("TOKEN"), new BotOptions() {
                Prefix = Environment.GetEnvironmentVariable("PREFIX")
            });

            Program.RegisterCommands();

            var handle = Program.Bot.Client.GetHandle();

            handle.OnMessageCreate += Program.OnMessage;

            // TODO: On disconnected, stop task

            await Program.Bot.Connect();
            await Task.Delay(-1);
        }

        public static void RegisterCommands()
        {
            Program.Bot.CommandHandler
                .RegisterCommand(typeof(PingCommand));
        }

        private static void OnMessage(Message message)
        {
            Console.WriteLine(message.channelId);

            if (message.content == "hello") {
                Program.Bot.Client.CreateMessage(message.channelId, "Hello from C#!");
            }

            Console.WriteLine(message.content);
        }
    }
}
