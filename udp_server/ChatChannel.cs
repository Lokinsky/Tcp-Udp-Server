using ConsoleApp1.Security;
using ConsoleApp3;
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
    class ChatChannel : Channel
    {
        Socket sock;
        StateObject sObject;
        TokenSystem tSystem;
        static Messages messages;
        bool isBroadcasting = false;

        public ChatChannel(string name, IPEndPoint ip) : base(name, ChannelType.Voice, ip)
        {
            sObject = new StateObject(1024);
            tSystem = TokenSystem.Instance;
            messages = new Messages();
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.Bind(base.IP);
            isBroadcasting = true;
            sock.BeginReceive(sObject.buffer, sObject.offset, sObject.size, SocketFlags.None,
                new AsyncCallback(ReceiveBroadcast), null);
            new Thread(() => Broadcast()) { Name = DateTime.Now.Ticks+""}.Start();
        }

        private void ReceiveBroadcast(IAsyncResult ar)
        {
            int r = sock.EndReceive(ar);
            Console.WriteLine(r);
            if (r > 0)
            {
                
                sObject.size = r;
                IDictionary<string, object> rData = tSystem.VerifyToken(sObject.GetDecoded());
                
                if (Int32.Parse(rData["status"]+"") == 0)
                {
                    messages.Add((Message)rData["message"]);
                }
                sObject.buffer = null;
                sObject.size = 1024;

            }
            sock.BeginReceive(sObject.buffer, sObject.offset, sObject.size, SocketFlags.None,
                new AsyncCallback(ReceiveBroadcast), null);

        }
        private void Broadcast()
        {
            while (isBroadcasting)
            {
                if(Connections.Instance.Count>0 && messages.Count>0)
                    foreach(Message message in messages)
                    {
                        foreach(Connection client in Connections.Instance)
                        {
                            if (client.IP != message.User.IP && message.isSend)
                            {
                                client.SendData(tSystem.GetToken(
                                new System.IdentityModel.Tokens.Jwt.JwtPayload
                                {
                                    {"action" , "chat" },
                                    {"body" , message },
                                    {"status", 0 }
                                }));
                            }
                        }
                        message.isSend = true;
                    }
            }
        }
    }
}
