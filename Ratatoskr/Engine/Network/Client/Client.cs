using System.Net.Sockets;

namespace Engine.Network.Client
{
    public class Client
    {
        public Socket client { get; private set; }

        public Client()
        {
            client = new Socket(new SocketInformation());
        }
    }
}
