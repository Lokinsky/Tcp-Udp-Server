using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    class ConfigModel
    {
        public string IP { get; set; }
        public int PORT { get; set; }
        private AddressFamily _addressfamily = 0;
        private ProtocolType _protocoltype = 0;
        private SocketType _sockettype = 0;
        public byte buffer { get; set; }
        public AddressFamily ADDRESSFAMILY
        {
            get => _addressfamily;

            set => _addressfamily = (AddressFamily)Enum.Parse(typeof(AddressFamily),
               Enum.GetName(typeof(AddressFamily), value));
        }
        public ProtocolType PROTOCOLTYPE
        {
            get => _protocoltype;

            set => _protocoltype = (ProtocolType)Enum.Parse(typeof(ProtocolType),
               Enum.GetName(typeof(ProtocolType), value));
        }
        public SocketType SOCKETTYPE
        {
            get => _sockettype;

            set => _sockettype = (SocketType)Enum.Parse(typeof(SocketType),
               Enum.GetName(typeof(SocketType), value));
        }

    }
}
