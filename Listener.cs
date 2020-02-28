using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp3
{
    
    class Listener
    {
        Socket listener;
        public Listener(Socket sock)
        {
            listener = sock;
            listener.Listen(2);
            listener.BeginAccept(new AsyncCallback(recv), null);
            Console.WriteLine("Listener thread->" + Thread.CurrentThread.ManagedThreadId);


        }
        void recv(IAsyncResult ar)
        {

            new Thread(()=>new TcpClientConnection().CreateConnection(listener.EndAccept(ar))).Start();
            
                
            listener.BeginAccept(new AsyncCallback(recv), null);

        }
    }
}
