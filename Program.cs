using System;
using System.Threading.Tasks;
using DotNetEnv;

namespace DS
{
    public class Program
    {
        public static readonly Client client;

        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            Console.WriteLine("Starting ...");
            client.Connect();

            while (true) {}
        }
    }
}
