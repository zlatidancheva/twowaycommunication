using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace client
{
    public class ClientSocket
    {
        private Socket clientSocket;
        private int port;

        public ClientSocket(int port)
        {
            this.port = port;
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void start()
        {
            Console.WriteLine("Starting client socket");
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                clientSocket.Connect(serverEndPoint);

                Console.WriteLine("Enter some data to send to server");

                String data = Console.ReadLine();

                byte[] bytes = Encoding.Unicode.GetBytes(data);

                clientSocket.Send(bytes);

                Console.WriteLine("Closing connection");

                clientSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while connectiong to server {}", e.Message);
            }
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            ClientSocket clientSocket = new ClientSocket(1234);
            clientSocket.start();

        }
    }
}
