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

        DbConn dbc = new DbConn();

        // Main method
        public static void Main()
        {

            Server hs = new Server();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Server Started!");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Waiting for Requests...");
            Console.WriteLine("-----------------------");

            IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener listener = new TcpListener(ipAddress, 8080);
            listener.Start();


            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread t = new Thread(hs.StartServer);
                t.Start(client);
            }
        }

        public void StartServer(object argument)
        {

        }

    }
}
