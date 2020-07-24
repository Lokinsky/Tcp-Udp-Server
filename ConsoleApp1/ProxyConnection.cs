using ConsoleApp1.Security;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1
{
    class ProxyConnection
    {
        TokenSystem tSystem;
        IConnection client;
        IRoute route;
        public ProxyConnection(IConnection client)
        {
            this.client = client;
            route = Router.Instance;
            tSystem = TokenSystem.Instance;
        }
        public void Route(StateObject sObject)
        {
            

                Console.WriteLine(sObject.GetDecoded().Length);
                IDictionary<string, object> recD = tSystem.VerifyToken(sObject.GetDecoded());
                if (recD.Count > 0 && Int32.Parse(recD["status"].ToString()) != -1)
                {


                    route.Route(client, sObject,
                        (EControllers)Enum.Parse(typeof(EControllers), recD["action"].ToString()),
                        recD);
                }
                else
                {
                    //route.Route(client, sObject, EControllers.Auth);
                    Console.WriteLine("Connection close;" + sObject.ip.Address + ':' + sObject.ip.Port);
                    this.client.CloseConnection();
                }
            
        }
    }
}
