using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace NetHttp
{
    class HttpClientManager
    {
        public HttpClientManager()
        {
            Clients = new List<TcpClient>();
        }

        public List<TcpClient> Clients { get; private set; }

        public void NewConnection(TcpClient client)
        {
            var th = new Thread(new ThreadStart(delegate
            {
                Process(client);
            }));
            th.Start();

            Clients.Add(client);
        }

        public void DisconnectAll()
        {
            foreach(var client in Clients)
            {
                client.Close();
                client.Dispose();
            }
        }



        private void Process(TcpClient client)
        {
            var protocol = new HttpProtocol(client);
            protocol.Process();
        }
    }
}
