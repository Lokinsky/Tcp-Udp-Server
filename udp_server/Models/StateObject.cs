using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class StateObject
    {
        public byte[] buffer { get; set; }
        byte[] data { get; set; }
        public byte offset { get; set; }
        public int size { get; set; }
        public IPEndPoint ip;
        public StateObject(int size, EndPoint ip)
        {
            this.ip = (IPEndPoint)ip;
            this.size = size;
            buffer = new byte[size];
            offset = 0;
        }
        public StateObject(int size)
        {
            this.size = size;
            buffer = new byte[size];
            offset = 0;
        }
        public string GetDecoded()
        {
            return Encoding.ASCII.GetString(buffer.ToList<byte>().GetRange(0,size).ToArray());
        }
        public byte[] GetBytesData(string data)
        {
            if (data != null)
            {
                size = data.Length;
                buffer = new byte[size];
                return Encoding.UTF8.GetBytes(data.ToCharArray());
            }
            else
            {
                return null;
            }
            
        }
        public byte[] GetBytesData()
        {
            return buffer.ToList<byte>().GetRange(0, size).ToArray();
        }

    }
}
