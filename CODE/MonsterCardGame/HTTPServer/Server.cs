using HTTPServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpServer
{
    public class Server
    {
        protected int port;
        TcpListener listener;

        public Server(int port)
        {
            this.port = port;
        }

        public void Run()
        {
            listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start(5);
            while (true)
            {
                TcpClient s = listener.AcceptTcpClient();
                Processor processor = new Processor(s, this);
                new Thread(processor.Process).Start();
                Thread.Sleep(1);
            }
        }
    }
}