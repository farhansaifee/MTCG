using System;
using System.Net.Sockets;

namespace HTTPServer
{
    class Server
    {
        static void Main(string[] args)
        {

            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 8080);

        }
    }
}
