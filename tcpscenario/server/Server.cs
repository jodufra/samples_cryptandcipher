using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        public static readonly int BUFFER_SIZE = 8;

        static void Main(string[] args)
        {
            TcpListener tcpl = null;
            TcpClient tcpc = null;
            NetworkStream stream = null;

            try
            {
                tcpl = new TcpListener(IPAddress.Any, 9999);
                tcpl.Start();
                Console.Write("Waiting for client... ");
                tcpc = tcpl.AcceptTcpClient();
                Console.WriteLine("ok");
                stream = tcpc.GetStream();

                ProtocolSI protocol = new ProtocolSI();
                ProtocolSICmdType command;
                byte[] packet;

                do
                {
                    stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    command = protocol.GetCmdType();

                    switch (protocol.GetCmdType())
                    {
                        case ProtocolSICmdType.NORMAL:
                            Console.WriteLine("inteiro: " + protocol.GetIntFromData().ToString());
                            break;
                        case ProtocolSICmdType.DATA:
                            Console.WriteLine("string: " + protocol.GetStringFromData());
                            break;
                        case ProtocolSICmdType.EOT:
                            Console.WriteLine("end");
                            break;
                        default:
                            Console.WriteLine("not expected");
                            break;
                    }

                } while (command != ProtocolSICmdType.EOT);


                packet = protocol.Make(ProtocolSICmdType.ACK);
                stream.Write(packet, 0, packet.Length);

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
                if (tcpl != null) tcpl.Stop();
            }

        }



    }
}
