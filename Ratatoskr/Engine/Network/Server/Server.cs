using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Network.Server
{
    public class Server
    {
        public IPAddress ServerAddress { get; private set; }
        public TcpListener Listener { get; private set; } 

        public void Run(string ip)
        {
            try
            {
                ServerAddress = IPAddress.Parse(ip);
                // use local m/c IP address, and 
                // use the same in the client

                /* Initializes the Listener */
                Listener = new TcpListener(ServerAddress, 8001);

                /* Start Listeneting at the specified port */
                Listener.Start();

                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is  :" +
                                  Listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");

                Socket s = Listener.AcceptSocket();
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                byte[] b = new byte[100];
                int k = s.Receive(b);
                Console.WriteLine("Recieved...");
                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(b[i]));

                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");
                /* clean up */
                s.Close();
                Listener.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }
}
