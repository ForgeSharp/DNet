using System;
using System.Threading.Tasks;
using DNet.Structures;
using DotNetEnv;
using Newtonsoft.Json;

namespace DNet
{
    public class Program
    {
        public static readonly Client client = new Client();

        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            Console.WriteLine("Starting ...");

            var startBotTask = Task.Run(Program.StartBot);

            startBotTask.Wait();
        }

        public static async Task StartBot() {
            var handle = Program.client.GetHandle();

            handle.OnMessageCreate += Program.OnMessage;

            // TODO: On disconnected, stop task

            await Program.client.Connect(Environment.GetEnvironmentVariable("TOKEN"));
            await Task.Delay(-1);
        }

        private static void OnMessage(Message message)
        {
            // TODO
            Console.WriteLine("Received message");
            Console.WriteLine(message.content);
        }
    }
}
