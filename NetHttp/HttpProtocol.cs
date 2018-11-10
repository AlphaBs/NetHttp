using System;
using System.Net.Sockets;

namespace NetHttp
{
    class HttpProtocol
    {
        public HttpProtocol(TcpClient tc)
        {
            this.client = tc;
        }

        TcpClient client;

        public void Process()
        {

        }
    }
}
