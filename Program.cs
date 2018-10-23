using System;
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
            Program.client.Connect(Environment.GetEnvironmentVariable("TOKEN"));

            var handle = Program.client.GetHandle();

            handle.OnMessageCreate += (Message message) => {
                Console.WriteLine("Received message");
                Console.WriteLine("Message", message.content);
            };

            while (true) {}
        }
    }
}
