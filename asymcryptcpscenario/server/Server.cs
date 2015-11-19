using EI.SI;
using System;
using System.Collections.Generic;
using System.IO;
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
            TripleDESCryptoServiceProvider crypt3des = null;
            SymmetricsSI symmetrics = null;
            RSACryptoServiceProvider rsaClient = null;
            RSACryptoServiceProvider rsaServer = null;

            try
            {
                Console.WriteLine("SERVER\n");
                tcpl = new TcpListener(IPAddress.Any, 9999);
                tcpl.Start();
                tcpc = tcpl.AcceptTcpClient();
                stream = tcpc.GetStream();

                ProtocolSI protocol = new ProtocolSI();
                ProtocolSICmdType command;
                byte[] packet = protocol.Make(ProtocolSICmdType.ACK);

                crypt3des = new TripleDESCryptoServiceProvider();
                symmetrics = new SymmetricsSI(crypt3des);
                rsaClient = new RSACryptoServiceProvider();
                rsaServer = new RSACryptoServiceProvider();
                string privateAndPublicKeyFilename = "serverpvpbkey.txt";
                if (File.Exists(privateAndPublicKeyFilename)) rsaServer.FromXmlString(File.ReadAllText(privateAndPublicKeyFilename));
                else File.WriteAllText(privateAndPublicKeyFilename, rsaServer.ToXmlString(true));


                Console.WriteLine("waiting for client public key");
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                rsaClient.FromXmlString(protocol.GetStringFromData());
                Console.WriteLine("ok");
                Console.WriteLine("CLIENT PUBLIC KEY: " + rsaServer.ToXmlString(false));

                Console.WriteLine("sending for server public key");
                packet = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, rsaServer.ToXmlString(false));
                stream.Write(packet, 0, packet.Length);
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok");

                Console.WriteLine("sending for 3des key");
                packet = protocol.Make(ProtocolSICmdType.SECRET_KEY, rsaServer.Encrypt(crypt3des.Key, false));
                stream.Write(packet, 0, packet.Length);
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok");

                Console.WriteLine("sending for 3des iv");
                packet = protocol.Make(ProtocolSICmdType.IV, rsaServer.Encrypt(crypt3des.IV, false));
                stream.Write(packet, 0, packet.Length);
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok");

                Console.WriteLine("sending for 3des padding");
                packet = protocol.Make(ProtocolSICmdType.IV, rsaServer.Encrypt(BitConverter.GetBytes((int)crypt3des.Padding), false));
                stream.Write(packet, 0, packet.Length);
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok");

                Console.WriteLine("sending for 3des mode");
                packet = protocol.Make(ProtocolSICmdType.MODE, rsaServer.Encrypt(BitConverter.GetBytes((int)crypt3des.Mode), false));
                stream.Write(packet, 0, packet.Length);
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok");




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
