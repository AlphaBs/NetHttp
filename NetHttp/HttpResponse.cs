using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace NetHttp
{
    class HttpResponse
    {
        public string ProtocolVersion { get; set; } = "HTTP/1.1";
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public string StatusMessage { get; set; }

        public Dictionary<string, string> Headers = new Dictionary<string, string>();

        public byte[] Body;

        public void WriteStream(HttpStream stream)
        {

        }
    }
}
