using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    abstract class ConnectionBuilder
    {
        public abstract IConnection CreateConnection(Socket socket);
    }
}
