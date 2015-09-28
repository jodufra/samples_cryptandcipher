using ApplicationLib.Utilities;
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

                var intMsg = Util.ReadStream(stream, BUFFER_SIZE);
                Console.WriteLine("Recebeu Inteiro: " + BitConverter.ToInt32(intMsg, 0));

                var stringMsg = Util.ReadStream(stream, BUFFER_SIZE);
                Console.WriteLine("Recebeu String: " + Encoding.UTF8.GetString(stringMsg));



                Console.Write("Waiting for client disconnect... ");
                Util.ReadStream(stream, BUFFER_SIZE);
                Console.WriteLine("disconnected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                if (stream != null) stream.Dispose();
                if (tcpc != null) tcpc.Close();
                if (tcpl != null) tcpl.Stop();
            }

        }



    }
}
