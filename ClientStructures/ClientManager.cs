using DNet.Socket;
using System.Threading.Tasks;

namespace DNet.ClientStructures
{
    public class ClientManager
    {
        public readonly SocketHandle socketHandle;

        private readonly Client client;

        public ClientManager(Client client)
        {
            this.client = client;
            this.socketHandle = new SocketHandle(this.client);
        }

        public Task Connect()
        {
            return this.socketHandle.Connect();
        }
    }
}
