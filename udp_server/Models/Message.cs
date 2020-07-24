using System;
using System.Collections.Generic;
using System.Text;
using udp_server.Models;

namespace udp_server.Models
{
    class Message
    {
        public string SenderName { get; set; }
        public User User { get; set; }
        //public string Data { get; set; }
        public byte[] Data { get; set; }

        public bool isSend { get; set; }
        public Message(string sender,User user, byte[] data)
        {
            SenderName = sender;
            User = user;
            Data = data;
            isSend = false;
        }
        public Message(byte[] data)
        { 
            Data = data;
            isSend = false;
        }
    }
}
