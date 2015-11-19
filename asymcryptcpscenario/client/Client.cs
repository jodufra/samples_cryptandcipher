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

namespace Client
{
    class Client
    {
        public static readonly int BUFFER_SIZE = 1024;
        static void Main(string[] args)
        {
            Console.WriteLine("CLIENT\n");
            TcpClient tcpc = null;
            NetworkStream stream = null;
            TripleDESCryptoServiceProvider crypt3des = null;
            SymmetricsSI symmetrics = null;
            RSACryptoServiceProvider rsaClient = null;
            RSACryptoServiceProvider rsaServer = null;

            try
            {
                tcpc = new TcpClient();
                tcpc.Connect("", 9999);
                stream = tcpc.GetStream();

                ProtocolSI protocol = new ProtocolSI();
                byte[] packet;

                crypt3des = new TripleDESCryptoServiceProvider();
                symmetrics = new SymmetricsSI(crypt3des);
                rsaClient = new RSACryptoServiceProvider();
                string privateAndPublicKeyFilename = "clientpvpbkey.txt";
                rsaServer = new RSACryptoServiceProvider();
                if (File.Exists(privateAndPublicKeyFilename)) rsaClient.FromXmlString(File.ReadAllText(privateAndPublicKeyFilename));
                else File.WriteAllText(privateAndPublicKeyFilename, rsaClient.ToXmlString(true));

                var ack = protocol.Make(ProtocolSICmdType.ACK);

                // Send key
                Console.WriteLine("sending for client public key");
                packet = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, rsaClient.ToXmlString(false));
                stream.Write(packet, 0, packet.Length);
                Console.WriteLine("ok");

                Console.WriteLine("waiting for server public key");
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                stream.Write(ack, 0, ack.Length);
                rsaServer.FromXmlString(protocol.GetStringFromData());
                Console.WriteLine("ok");
                Console.WriteLine("SERVER PUBLIC KEY: " + rsaServer.ToXmlString(false));

                Console.WriteLine("waiting for 3des key");
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                stream.Write(ack, 0, ack.Length);
                crypt3des.Key = rsaServer.Decrypt(protocol.GetData(), false);
                Console.WriteLine("ok");
                Console.WriteLine("3DES KEY: " + crypt3des.Key.ToString());

                Console.WriteLine("waiting for 3des iv");
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                stream.Write(ack, 0, ack.Length);
                crypt3des.IV = rsaServer.Decrypt(protocol.GetData(), false);
                Console.WriteLine("ok");
                Console.WriteLine("3DES IV: " + crypt3des.IV.ToString());

                Console.WriteLine("waiting for 3des padding");
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                stream.Write(ack, 0, ack.Length);
                crypt3des.Padding = (PaddingMode)BitConverter.ToInt32(rsaServer.Decrypt(protocol.GetData(), false), 0);
                Console.WriteLine("ok");
                Console.WriteLine("3DES PADDING: " + crypt3des.Padding.ToString());

                Console.WriteLine("waiting for 3des mode");
                stream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                stream.Write(ack, 0, ack.Length);
                crypt3des.Mode = (CipherMode)BitConverter.ToInt32(rsaServer.Decrypt(protocol.GetData(), false), 0);
                Console.WriteLine("ok");
                Console.WriteLine("3DES MODE: " + crypt3des.Mode.ToString());




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
                if (crypt3des != null) crypt3des.Dispose();
                if (symmetrics != null) crypt3des.Dispose();
                if (rsaClient != null) rsaClient.Dispose();
                if (rsaServer != null) rsaServer.Dispose();
            }

        }
    }
}
