using System;
using System.Collections.Generic;

namespace NetHttp
{
    class HttpRequest
    { 
        public HttpRequest(HttpStream stream)
        {
            var first = stream.ReadLine().Split(' '); // Request First Line
            Method = first[0];
            //Url = new Uri(first[1]);
            Url = first[1];
            Version = first[2];

            Headers = new Dictionary<string, string>();
            while(!stream.IsEnd) // Request Header
            {
                var line = stream.ReadLine();
                if (line == "") break; // Check Empty line to recognize end of header part

                var spl = line.Split(':'); // split header's key, value
                var key = spl[0].TrimEnd();
                var value = spl[1].TrimStart();

                if (key == "Content-Length")
                    this.ContentLength = int.Parse(value);

                Headers.Add(key, value);
            }

            if (!stream.IsEnd && ContentLength != 0) // if Request Body exists
                Body = stream.Read(ContentLength);
        }

        public string Method { get; private set; }
        public string Url { get; private set; }
        public string Version { get; private set; }
        public Dictionary<string, string> Headers { get; private set; }

        public int ContentLength { get; private set; }
        public byte[] Body { get; private set; }
    }
}
