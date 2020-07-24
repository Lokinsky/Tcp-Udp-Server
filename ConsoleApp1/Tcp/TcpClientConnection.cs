using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class TcpClientConnection : ConnectionBuilder
    {
        public override IConnection CreateConnection(Socket socket)
        {
            return new TcpConnectionHandler(socket);
        }
    }
}
