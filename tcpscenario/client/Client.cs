using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        public static readonly int BUFFER_SIZE = 1024;
        static void Main(string[] args)
        {
            TcpClient tcpc = null;
            NetworkStream stream = null;

            try
            {
                Console.Write("A ligar ao servidor... ");
                tcpc = new TcpClient();
                tcpc.Connect("", 9999);
                Console.WriteLine("ok");
                stream = tcpc.GetStream();

                ProtocolSI protocol = new ProtocolSI();
                byte[] packet;
                char key;
                var random = new Random();

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Send Integer");
                    Console.WriteLine("2 - Send Date");
                    Console.WriteLine("0 - End Transmission");
                    key = Console.ReadKey().KeyChar;

                    switch (key)
                    {
                        case '1':
                            packet = protocol.Make(ProtocolSICmdType.NORMAL, random.Next());
                            break;
                        case '2':
                            packet = protocol.Make(ProtocolSICmdType.DATA, DateTime.Now.ToString());
                            break;
                        case '0':
                            packet = protocol.Make(ProtocolSICmdType.EOT);
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Invalid Key!!!");
                            continue;
                    }

                    stream.Write(packet, 0, packet.Length);

                } while (key != '0');

                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("disconnected");
                if (stream != null) stream.Dispose();
                if (tcpc != null) tcpc.Close();
            }

        }
    }
}
