using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using udp_server.DataStructures;
using udp_server.Models;

namespace udp_server
{
    class Handler
    {
        Socket sock;
        IPEndPoint hostIP;
        int byteRcv;
        Connections connections;
        ChatChannel Chat;
        public Handler()
        {
            hostIP = new IPEndPoint(IPAddress.Parse("192.168.1.103"), 55565);
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connections = Connections.Instance;
            new Thread(()=> new ChatChannel(
                "kkek", 
                    new IPEndPoint(
                    IPAddress.Parse(
                        "192.168.1.103"),
                        55556)
                )).Start();
            sock.Bind(hostIP);
            sock.Listen(10);

            sock.BeginAccept(byteRcv, new AsyncCallback(Accepted), null);
        }

        private void Accepted(IAsyncResult ar)
        {

            connections.Add(new Connection(sock.EndAccept(ar)));

            sock.BeginAccept(byteRcv, new AsyncCallback(Accepted), null);
        }
    }
}
