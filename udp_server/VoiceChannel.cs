using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using udp_server.Models;

namespace udp_server
{
    class VoiceChannel : Channel
    {
        private Socket connection;
        public VoiceChannel(string name, IPEndPoint ip):base(name,ChannelType.Voice,ip)
        {
            connection = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            connection.Bind(base.IP);
        }
    }
}
