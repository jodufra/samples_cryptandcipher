using ApplicationLib.Utilities;
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

                int intVal = 123;
                byte[] intMsg = BitConverter.GetBytes(intVal);
                stream.Write(intMsg, 0, intMsg.Length);
                Console.WriteLine("Sent: " + intVal);

                string stringVal = "Hello Server";
                byte[] stringMsg = Encoding.UTF8.GetBytes(stringVal);
                stream.Write(stringMsg, 0, stringMsg.Length);
                Console.WriteLine("Sent: " + stringVal);

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
            }

        }
    }
}
