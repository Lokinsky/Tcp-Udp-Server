using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace udp_server.Models
{
    class Connection
    {
        public IPEndPoint IP { get; set; }
        Socket client;
        StateObject sObject;

        public Connection(Socket client)
        {
            Console.WriteLine(client.RemoteEndPoint);
            this.client = client;
            sObject = new StateObject(512, this.IP);
        }
        public void SendData(string data)
        {
            sObject.buffer = sObject.GetBytesData(data);
            int r = client.Send(sObject.buffer);
            //int r = server.SendTo(sObject.buffer,IP);
            if (r == sObject.size)
            {
                Console.WriteLine(r + "  s  " + sObject.size);
            }
        }

    }
}
