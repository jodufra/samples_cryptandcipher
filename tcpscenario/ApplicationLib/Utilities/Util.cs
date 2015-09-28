using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLib.Utilities
{
    public static class Util
    {

        public static byte[] Clone(byte[] array, int length)
        {
            byte[] rv = new byte[length];
            System.Buffer.BlockCopy(array, 0, rv, 0, length);
            return rv;
        }

        public static byte[] Combine(byte[] firstArray, byte[] secArray)
        {
            return Combine(firstArray, firstArray.Length, secArray, secArray.Length);
        }

        public static byte[] Combine(byte[] firstArray, byte[] secArray, int secArrayLength)
        {
            return Combine(firstArray, firstArray.Length, secArray, secArrayLength);
        }

        public static byte[] Combine(byte[] firstArray, int firstArrayLength, byte[] secArray, int secArrayLength)
        {
            byte[] rv = new byte[firstArrayLength + secArrayLength];
            System.Buffer.BlockCopy(firstArray, 0, rv, 0, firstArrayLength);
            System.Buffer.BlockCopy(secArray, 0, rv, firstArrayLength, secArrayLength);
            return rv;
        }

        public static byte[] Combine(params byte[][] arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                System.Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            if (bytes == null) return "<null>";
            return GetString(bytes, bytes.Length);
        }

        public static string GetString(byte[] bytes, int length)
        {
            if (bytes == null) return "<null>";
            char[] chars = new char[length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, length);
            return new string(chars);
        }


        public static byte[] ReadStream(NetworkStream stream, int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            int bufferLength;
            string ok = "ok";
            byte[] msg = null;

            while ((bufferLength = stream.Read(buffer, 0, bufferSize)) > 0)
            {
                msg = (msg == null ? Util.Clone(buffer, bufferLength) : Util.Combine(msg, buffer, bufferLength));
                stream.Write(Encoding.UTF8.GetBytes(ok), 0, Encoding.UTF8.GetByteCount(ok));
            }
            return msg;
        }

        /*
        public static byte[] WriteStream(NetworkStream stream, int bufferSize, byte[] content)
        {
            byte[] buffer = new byte[bufferSize];
            int bufferLength;
            string ok = "ok";
            byte[] msg = null;

            while ((bufferLength = stream.Read(buffer, 0, bufferSize)) > 0)
            {
                msg = (msg == null ? Util.Copy(buffer, bufferLength) : Util.Combine(msg, buffer, bufferLength));
                stream.Read(Encoding.UTF8.GetBytes(ok), 0, Encoding.UTF8.GetByteCount(ok));
            }
            return msg;
        }*/


    }
}
