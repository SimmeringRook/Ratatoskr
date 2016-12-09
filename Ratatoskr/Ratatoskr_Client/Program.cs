using Engine.Network.Client;

namespace Ratatoskr_Client
{
    class Program
    {
        private static Client client;
        static void Main(string[] args)
        {
            client = new Client();
        }
    }
}
