using System;
using System.IO;
using System.Net.Sockets;

namespace NetHttp
{
    class HttpStream
    {
        // ASCII Based

        const int BufferSize = 1024;
        const int CR = 13; // Http Protocol define NewLine as CRLF.
        const int LF = 10; // but some clients request only LF.

        public HttpStream(NetworkStream ns)
        {
            this.stream = ns;
        }

        public bool IsEnd { get; private set; } = false;
        NetworkStream stream;

        public string ReadLine()
        {
            string line = "";
            char[] buffer = new char[BufferSize];

            IsEnd = true;

            int index = 0;
            int value;
            while((value = stream.ReadByte()) != -1)
            {
                if (value == CR)
                    continue;

                if (value == LF)
                {
                    IsEnd = false;
                    break;
                }

                buffer[index] = (char)value;

                if (index == BufferSize - 1)
                {
                    index = 0;
                    line += new string(buffer);
                }
                else
                    index++;
            }
            line += new string(buffer, 0, index);

            return line;
        }

        public byte[] Read(int count)
        {
            var data = new byte[count];
            stream.Read(data, 0, count);
            return data;
        }
    }
}
