using ConsoleApp1.Security;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WpfApp1.Model
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public List<string> servers { get; set; }
        public bool isAuth { get; set; }
        StateObject sObject;
        TokenSystem tSystem;
        TcpClient client;
        NetworkStream stream;
        public User()
        {

        }
        public User(string login, string password)
        {
            servers = new List<string>();
            this.Login = login;
            this.Password = password;
            sObject = new StateObject(256);
            tSystem = TokenSystem.Instance;
            GetData();
        }

        void GetData()
        {
            client = new TcpClient("192.168.1.103", 55655);
            stream = client.GetStream();
            
            sObject.buffer = sObject.GetBytesData(tSystem.GetToken(new JwtPayload { 
               {"action","auth" }, 
               {"login",Login },
               {"password",Password },
               {"status",0 } 
           }));
            stream.BeginWrite(sObject.buffer, sObject.offset, sObject.size,
                new AsyncCallback(SendGetData),null);
            


        }

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
    }
}
