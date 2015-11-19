using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
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
            TripleDESCryptoServiceProvider crypto = null;
            SymmetricsSI symmetrics = null;

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

                byte[] packet = protocol.Make(ProtocolSICmdType.ACK);
                crypto = new TripleDESCryptoServiceProvider();
                symmetrics = new SymmetricsSI(crypto);

                do
                {
                    stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    command = protocol.GetCmdType();

                    switch (command)
                    {
                        case ProtocolSICmdType.IV:
                            crypto.IV = protocol.GetData();
                            Console.WriteLine("Got IV");
                            break;
                        case ProtocolSICmdType.MODE:
                            crypto.Mode = (CipherMode) protocol.GetIntFromData();
                            Console.WriteLine("Got MODE");
                            break;
                        case ProtocolSICmdType.PADDING:
                            crypto.Padding = (PaddingMode)protocol.GetIntFromData();
                            Console.WriteLine("Got PADDING");
                            break;
                        case ProtocolSICmdType.SECRET_KEY:
                            crypto.Key = protocol.GetData();
                            Console.WriteLine("Got SECRET_KEY");
                            break;
                        default:
                            break;
                    }

                    stream.Write(packet, 0, packet.Length);

                } while (command != ProtocolSICmdType.EOF);



                command = ProtocolSICmdType.ACK;
                try
                {
                    stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    if (protocol.GetCmdType() != ProtocolSICmdType.SYM_CIPHER_DATA)
                        throw new Exception("Was expecting SYM_CIPHER_DATA");
                    var message = Encoding.UTF8.GetString(symmetrics.Decrypt(protocol.GetData()));
                    Console.WriteLine(message);
                }
                catch (Exception)
                {
                    command = ProtocolSICmdType.NACK;
                }
                finally
                {
                    packet = protocol.Make(command);
                    stream.Write(packet, 0, packet.Length);
                }

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
