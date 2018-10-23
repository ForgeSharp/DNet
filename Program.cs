using System;
using DotNetEnv;

namespace DNet
{
    public class Program
    {
        public static Client client;

        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            Program.client = new Client(Environment.GetEnvironmentVariable("TOKEN"));
            Console.WriteLine("Starting ...");
            client.Connect();

            while (true) {}
        }
    }
}
