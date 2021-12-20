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

        static void Main(string[] args)
        {
            Console.WriteLine("A simple server running...\n");

            TcpListener serverListener = new TcpListener(IPAddress.Loopback, 8000);
            serverListener.Start(5);

            while (true)
            {
                TcpClient clientSocket = serverListener.AcceptTcpClient();
                new Task(() =>
                {
                    try
                    {
                        var writer = new StreamWriter(clientSocket.GetStream());
                        var reader = new StreamReader(clientSocket.GetStream());

                        writer.WriteLine("Welcome to my server!");
                        writer.WriteLine("Please enter your commands...");
                        writer.Flush();

                        string message;
                        do
                        {
                            message = reader.ReadLine();
                            Console.WriteLine($"received: {message}");
                        } while (message != "quit");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"error occured {e.Message}");
                    }
                }).Start();
            }
        }

    }
}
