using ConsoleApp1.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using ConsoleApp1;
using System.Threading;

namespace ConsoleApp3
{
    class TcpConnectionHandler : IConnection
    {
        private StateObject sObject;
        private Socket client;
        private ProxyConnection proxy;
        public TcpConnectionHandler(Socket client)
        {
            Console.WriteLine("TcpHandlerConnection thread->" + Thread.CurrentThread.ManagedThreadId);
            this.sObject = new StateObject(size: 512, client.RemoteEndPoint);
            this.client = client;
            proxy = new ProxyConnection(this);
            BeginReceive();


        }
      

        public void BeginReceive()
        {
            try
            {
                this.client.BeginReceive(sObject.buffer, sObject.offset, sObject.size, SocketFlags.None,
                    new AsyncCallback(EndReceive), null);
                

            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void EndReceive(IAsyncResult ar)
        {
            int r = client.EndReceive(ar);
            if (r > 0)
            {
                sObject.size = r-1;
                proxy.Route(sObject);
                //BeginSend();
                
            }
            else
            {
                Console.WriteLine("Socket close");
                client.Close();
                
            }
            
            
        }

        public byte[] SendReceive(StateObject sObject)
        {
            try
            {
                int s = this.client.Send(sObject.buffer, 
                    sObject.offset, sObject.size, SocketFlags.None);
                sObject.buffer = new byte[sObject.size];
                sObject.size = 0;
                Console.WriteLine("R send->" + s);
                sObject.size = this.client.Receive(sObject.buffer, sObject.offset, sObject.size, SocketFlags.None);
                if (sObject.size == 0)
                {
                    CloseConnection();
                    Console.WriteLine("ClosedConn");
                    return null;
                }else
                    return  sObject.buffer;
            }
            catch (SocketException ex)
            {
                
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void EndSend(IAsyncResult ar)
        {
            int r = client.EndSend(ar);
            
            //client.BeginReceive(sObject.buffer, sObject.offset, sObject.size, SocketFlags.None, new AsyncCallback(EndReceive), null);
        }
        public void CloseConnection()
        {
            this.client.Close();
        }
    }
}
