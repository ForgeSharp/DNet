using System;
using System.Threading.Tasks;

namespace DS
{
    public class Program
    {
        public static readonly Client client = new Client(Environment.GetEnvironmentVariable("TOKEN"));

        public static void Main(string[] args)
        {
            Console.WriteLine("Starting ...");
            client.Connect();

            while (true) {}
        }
    }
}
