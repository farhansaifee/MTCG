using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonsterCardGame.Server
{
    class Server
    {

        // Create new HTTP Listener Instance/Object
        static TcpListener listener;
        

        static void Main(string[] args)
        {
            try
            {

                string localhost = "127.0.0.1";
                int port = 8080;
                listener = new TcpListener(IPAddress.Parse(localhost), port);
                listener.Start(); // Start TcpListener
                Console.WriteLine("Server started!");

                while (true)
                {
                    Console.WriteLine("Waiting for connection...");
                    TcpClient client = listener.AcceptTcpClient(); // Clients connect to Server
                    Console.WriteLine("Accepted new Client.");
                    StreamReader reader = new StreamReader(client.GetStream());
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    string s = string.Empty;
                    while ((s != reader.ReadLine()).Equals("Exit") || (s != null))
                    {
                        Console.WriteLine("From Client: " + s);
                        writer.WriteLine("From Server: " + s);
                        writer.Flush();
                    }

                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            

        }

        static void GetResponse()
        {
            
        }

    }
}
