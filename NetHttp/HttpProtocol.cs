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
            var ns = client.GetStream();
            var stream = new HttpStream(ns);

            var request = new HttpRequest(stream);

            Console.WriteLine("{0} = {1} = {2}", request.Method, request.Url, request.Version);
            foreach (var item in request.Headers)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }
            if (request.Body != null)
                Console.WriteLine(System.Text.Encoding.ASCII.GetString(request.Body));


        }
    }
}
