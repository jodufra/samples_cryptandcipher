using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
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
            TripleDESCryptoServiceProvider crypto = null;
            SymmetricsSI symmetrics = null;

            try
            {
                Console.Write("A ligar ao servidor... ");
                tcpc = new TcpClient();
                tcpc.Connect("", 9999);
                Console.WriteLine("ok");
                stream = tcpc.GetStream();

                ProtocolSI protocol = new ProtocolSI();
                byte[] packet;

                crypto = new TripleDESCryptoServiceProvider();
                symmetrics = new SymmetricsSI(crypto);

                // Send key

                packet = protocol.Make(ProtocolSICmdType.PADDING, (int)crypto.Padding);
                stream.Write(packet, 0, packet.Length);
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

                packet = protocol.Make(ProtocolSICmdType.IV, crypto.IV);
                stream.Write(packet, 0, packet.Length);
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

                packet = protocol.Make(ProtocolSICmdType.MODE, (int)crypto.Mode);
                stream.Write(packet, 0, packet.Length);
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

                packet = protocol.Make(ProtocolSICmdType.SECRET_KEY, crypto.Key);
                stream.Write(packet, 0, packet.Length);
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

                packet = protocol.Make(ProtocolSICmdType.EOF);
                stream.Write(packet, 0, packet.Length);
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);


                var message = symmetrics.Encrypt(Encoding.UTF8.GetBytes("HelloWorld"));
                packet = protocol.Make(ProtocolSICmdType.SYM_CIPHER_DATA, message);
                stream.Write(packet, 0, packet.Length);

                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                if (protocol.GetCmdType() != ProtocolSICmdType.ACK)
                    throw new Exception("Server could not decrypt");

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
                if (crypto != null) crypto.Dispose();
                if (symmetrics != null) crypto.Dispose();
            }

        }
    }
}
