using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Network.Server
{
    public class Server
    {
        public IPAddress ServerAddress { get; private set; }
        public TcpListener Listener { get; private set; }
        private List<Socket> ActiveConnections;
        public Server(string hostIP)
        {
            ServerAddress = IPAddress.Parse(hostIP);
            /* Initializes the Listener */
            Listener = new TcpListener(ServerAddress, 8001);
        }

        public void Intialize()
        {
            try
            {
                ActiveConnections = new List<Socket>();
                /* Start Listeneting at the specified port */
                Listener.Start();

                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is: " +
                                  Listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection...");

                Socket s = Listener.AcceptSocket();
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
                ActiveConnections.Add(s);

                BuildPlayer();

                s.Close();
                Listener.Stop();

                ActiveConnections.RemoveAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("!! Error: " + e.StackTrace);
            }
        }

        private void BuildPlayer()
        {
            Socket s = ActiveConnections[0];
            byte[] b = new byte[100];
            int k = s.Receive(b);
            Console.WriteLine("Recieved...");

            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(b[i]));

            ASCIIEncoding asen = new ASCIIEncoding();
            s.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\nSent Acknowledgement");
            //http://stackoverflow.com/questions/15012549/send-typed-objects-through-tcp-or-sockets
        }

        public void Run(string ip)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine("!! Error: " + e.StackTrace);
            }
        }

        public static Message Serialize(object anySerializableObject)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, anySerializableObject);
                return new Message { Data = memoryStream.ToArray() };
            }
        }

        public static object Deserialize(Message message)
        {
            using (var memoryStream = new MemoryStream(message.Data))
                return (new BinaryFormatter()).Deserialize(memoryStream);
        }
    }
}
