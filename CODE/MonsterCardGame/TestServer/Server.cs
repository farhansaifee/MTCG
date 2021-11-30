using System;
using System.Net;
using System.Text;
using System.Threading;

namespace TestServer
{
    class Server
    {
        // Create new HTTP Listener Instance/Object
        static HttpListener listener = new HttpListener();

        static void Main(string[] args)
        {

            Console.WriteLine("Starting server...");
            listener.Prefixes.Add("http://localhost:5000/"); // add prefix "http://localhost:5000/"
            listener.Start(); // start server (Run application as Administrator!)
            Console.WriteLine("Server started.");
            Thread responseThread = new Thread(GetResponse);
            responseThread.Start(); // start the response thread

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
