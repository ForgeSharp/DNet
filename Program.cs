using System;
using DotNetEnv;

namespace DNet
{
    public class Program
    {
        public static readonly Client client = new Client();

        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            Console.WriteLine("Starting ...");
            client.Connect(Environment.GetEnvironmentVariable("TOKEN"));

            while (true) {}
        }
    }
}
