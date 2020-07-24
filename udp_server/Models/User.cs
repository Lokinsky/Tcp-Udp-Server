using ConsoleApp1.Security;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace udp_server.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public IPEndPoint IP { get; set; }
        public bool isAuth { get; set; }
        public List<string> servers { get; set; }
        
        StateObject sObject;
        TokenSystem tSystem;
        /*
        TcpClient client;
        NetworkStream stream;
        */
        public User()
        {
            sObject = new StateObject(256);
            tSystem = TokenSystem.Instance;
        }

        void GetData()
        {
            
            


        }
        /*
        private void SendGetData(IAsyncResult ar)
        {
            
            stream.EndWrite(ar);
            sObject.buffer = new byte[256];
            int r = stream.Read(sObject.buffer, sObject.offset, sObject.size);

            if (r > 0)
            {
                sObject.size = r;
                IDictionary<string, object> rData = tSystem.VerifyToken(sObject.GetDecoded());
                if (Int16.Parse(rData["status"].ToString()) != -1)
                {
                    this.Role = rData["role"].ToString();
                    this.Name = rData["name"].ToString();
                    isAuth = true;
                }
                else
                {
                    isAuth = false;
                }
            }
            else
            {
                isAuth = false;
            }
            stream.Close();
            client.Close();
            
        }
        */
    }
}
