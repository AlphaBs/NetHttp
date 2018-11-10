using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetHttp;

namespace NetHttp.Program
{
    class Program
    {
        public static void Main(string [] args)
        {
            c("\n ========== NET HTTP ========== \n", ConsoleColor.Green);
            c("Server IP : 127.0.0.1:80");
            c("Starting Server");

            var server = new HttpServer("127.0.0.1", 80);
            server.Start();

            c("Server is started!" , ConsoleColor.Green);

            while(true)
            {
                var input = Console.ReadLine();
                var spl = input.Split(' ');
                var cmd = spl[0].ToLower();

                switch (cmd)
                {
                    case "":
                        break;
                    case "stop":
                        c("Stopping Server");
                        server.Stop();
                        c("Server is stopped!",  ConsoleColor.Green);
                        goto end;
                    default:
                        c("Unknown Command.", ConsoleColor.Gray);
                        break;
                }
            }

            end:;
            c("Program is stopped", ConsoleColor.Gray);
            Console.ReadLine();
        }

        static void c(string m)
        {
            Console.WriteLine(m);
        }

        static void c(string m, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(m);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
