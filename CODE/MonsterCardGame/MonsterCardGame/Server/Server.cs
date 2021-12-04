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
<<<<<<< HEAD
        static HttpListener listener = new HttpListener();

        static void Main(string[] args)
        {

            Console.WriteLine("Starting server...");
            listener.Prefixes.Add("http://localhost:5000/"); // add prefix "http://localhost:5000/"
            listener.Start(); // start server (Run application as Administrator!)
            Console.WriteLine("Server started.");
            Thread responseThread = new Thread(GetResponse);
            responseThread.Start(); // start the response thread
=======
        static TcpListener server = null;
        

        static void Main(string[] args)
        {
            
            try
            {
                // Set the TcpListener on port 5050.
                Int32 port = 8080;
                IPAddress localhost = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localhost, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[1024];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        //data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        //Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        //data = data.ToUpper();

                        //byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        //stream.Write(msg, 0, msg.Length);
                        //Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();

>>>>>>> 6c82fa566911ac286e4321a21154b9a11cdd0b96

        }

        static void GetResponse()
        {
            while (true)
            {
                HttpListenerContext context = listener.GetContext(); // get a context
                                                                     // Now, you'll find the request URL in context.Request.Url
                byte[] _responseArray = Encoding.UTF8.GetBytes("<html><head><title>Localhost server -- port 5000</title></head>" +
                "<body>Welcome to the <strong>Localhost server</strong> -- <em>port 5000!</em></body></html>"); // get the bytes to response
                context.Response.OutputStream.Write(_responseArray, 0, _responseArray.Length); // write bytes to the output stream
                context.Response.KeepAlive = false; // set the KeepAlive bool to false
                context.Response.Close(); // close the connection
                Console.WriteLine("Respone given to a request.");
            }
        }

    }
}
