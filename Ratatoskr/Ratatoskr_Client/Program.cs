using Engine.Network.Client;
using System;

namespace Ratatoskr_Client
{
    class Program
    {
        private static Client client;
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the ip address of the server: ");
            string serverIP = Console.ReadLine();

            client = new Client(serverIP);
            client.Run();

            Console.WriteLine("Ending client.");
            Console.ReadLine();
        }
    }
}
