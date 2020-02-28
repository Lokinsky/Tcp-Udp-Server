using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ConsoleApp1.Controllers;

namespace ConsoleApp3
{
    class Startup
    {
        public Startup()
        {
            Configure config = Configure.Instance;
            Socket socket = new Socket(
                config.GetConfig().ADDRESSFAMILY,
                config.GetConfig().SOCKETTYPE,
                config.GetConfig().PROTOCOLTYPE);
            IPEndPoint iPEndPoint = 
                new IPEndPoint(
                    IPAddress.Parse(config.GetConfig().IP), 
                    config.GetConfig().PORT);
            socket.Bind(iPEndPoint);
            Router router = Router.Instance;
            router.registerController(EControllers.Auth, new Auth());
            new Listener(socket);
            
        }
    }
}
