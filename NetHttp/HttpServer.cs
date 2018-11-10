using System;
using System.Net.Sockets;
using System.Net;

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

        public void Start()
        {
            server.Start();
            while(true)
            {
                var client = server.AcceptTcpClient();
                clients.NewConnection(client);
            }
        }

        public void Stop()
        {
            server.Stop();
            clients.DisconnectAll();
        }
    }
}
