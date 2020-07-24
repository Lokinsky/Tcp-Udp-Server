using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace udp_server.Models
{
    abstract class Channel
    {
        public ChannelType Type { get; set; }
        public  string Name { get; set; }
        public  IPEndPoint IP { get; set; }
        public Channel(string name, ChannelType type, IPEndPoint ip)
        {
            Name = name;
            Type = type;
            IP = ip;
        }


    }
}
