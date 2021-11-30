using HttpServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPServer
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("This is a HTTPServer!");
            Console.CancelKeyPress += (sender, e) => Environment.Exit(0);

            new Server(8080).Run();
        }

    }
}
