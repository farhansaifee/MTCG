using HttpServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTPServer
{
    class Processor
    {

        private TcpClient socket;
        private Server httpServer;

        public string Method { get; private set; }
        public string Path { get; private set; }
        public string Version { get; private set; }

        public Dictionary<string, string> Headers { get; set; }

        public Processor(TcpClient s, Server httpServer)
        {
            this.socket = s;
            this.httpServer = httpServer;

            Method = null;
            Headers = new();
        }

        public void Process()
        {
            var writer = new StreamWriter(socket.GetStream()) { AutoFlush = true };
            var reader = new StreamReader(socket.GetStream());
            Console.WriteLine();

            // read (and handle) the full HTTP-request
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                if (line.Length == 0)
                    break;  // empty line means next comes the content (which is currently skipped)

                // handle first line of HTTP
                if (Method == null)
                {
                    var parts = line.Split(' ');
                    Method = parts[0];
                    Path = parts[1];
                    Version = parts[2];
                }
                // handle HTTP headers
                else
                {
                    var parts = line.Split(": ");
                    Headers.Add(parts[0], parts[1]);
                }
            }

            // write the full HTTP-response
            string content = $"<html><head></head><body>This is just a test </body></html>";

            Console.WriteLine();

            writer.WriteLine();
            writer.Flush();
            writer.Close();
        }

        private void WriteLine(StreamWriter writer, string s)
        {
            Console.WriteLine(s);
            writer.WriteLine(s);
        }

    }
}
