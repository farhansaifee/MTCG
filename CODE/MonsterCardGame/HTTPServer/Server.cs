using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace HTTPServer
{
    class Server
    {

        //int port;
        //public Server(int port)
        //{
          //  this.port = port;
        //}

        static void Main(string[] args)
        {

            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 8080); // PORT DOESNT WORK
            listener.Start();

            while(true){

                Console.WriteLine("Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client Accepted!");
                NetworkStream stream = client.GetStream();
                //StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());

                try
                {
                    // Create Buffer to receive Data
                    // Read Bytes in Byte-Array
                    byte[] buffer = new byte[1024];
                    stream.Read(buffer, 0, buffer.Length);
                    int recv = 0;
                    // Count how many Bytes actually are used
                    foreach(byte b in buffer)
                    {
                        if (b != 0)
                        {
                            recv++;
                        }
                    }
                    // Turn back to String
                    string request = Encoding.UTF8.GetString(buffer, 0, recv);
                    Console.WriteLine($"request received: {request}");
                    // To send Feedback to Client 
                    // sw.WriteLine("Test");
                    sw.Flush();
                } catch(Exception e)
                {
                    Console.WriteLine("Something went wrong!");
                    sw.WriteLine(e.ToString());
                }


            }

        }
    }
}
