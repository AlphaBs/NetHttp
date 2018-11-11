using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace NetHttp
{
    class HttpServer
    {
        public HttpServer(string ip, int port)
        {
            server = new TcpListener(IPAddress.Parse(ip), port);
            clients = new HttpClientManager();
        }

        TcpListener server;
        HttpClientManager clients;
        Thread AcceptThread;

        public void Start()
        {
            server.Start();
            AcceptThread = new Thread(new ThreadStart(delegate
            {
                while (true)
                {
                    var client = server.AcceptTcpClient();
                    clients.NewConnection(client);
                }
            }));
            AcceptThread.Start();
        }

        public void Stop()
        {
            server.Stop();
            AcceptThread.Abort();
            AcceptThread = null;
            clients.DisconnectAll();
        }
    }
}
