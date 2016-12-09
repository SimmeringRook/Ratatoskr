using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Network.Server;


namespace Ratatoskr_Server
{
    class Program
    {
        private static Server server;
        static void Main(string[] args)
        {
            server = new Server();
            Console.WriteLine("Enter the ip for the server to run on: ");

            string ip = Console.ReadLine();
            server.Run(ip);

            Console.WriteLine("Server has safely Shutdown.");
            Console.ReadLine();
        }
    }
}
