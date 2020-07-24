using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace ConsoleApp3
{
    
    class Listener
    {
        readonly Socket listener;
        public Listener(Socket sock)
        {
            listener = sock;
            listener.Listen(100);
            listener.BeginAccept(new AsyncCallback(CallbackAsync), null);
            Console.WriteLine("Listener thread->" + Thread.CurrentThread.ManagedThreadId);


        }
        void CallbackAsync(IAsyncResult ar)
        {
            long s = DateTime.Now.Millisecond;
            try
            {


                new Thread(() => new TcpClientConnection().CreateConnection(listener.EndAccept(ar))) 
                {
                    IsBackground = true, 
                    Name = DateTime.Now.Ticks+""
                }.Start();


                listener.BeginAccept(new AsyncCallback(CallbackAsync), null);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            long res = DateTime.Now.Millisecond - s;
            Console.WriteLine("Time for execute-> " + res+ " <-Millisecond");
        }
    }
}
