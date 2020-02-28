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
        public void Auth()
        {

        }
        public void Route(StateObject sObject)
        {
            
            if (tSystem.ValidateToken(sObject.GetDecoded()))
            {
                JwtPayload payload = tSystem.ReadToken(sObject.GetDecoded());

                route.Route(client, sObject,
                    (EControllers)Enum.Parse(typeof(EControllers), payload["Action"].ToString()),
                    payload);
            }
            else
            {
                //route.Route(client, sObject, EControllers.Auth);
                Console.WriteLine("Connection close;" + sObject.ip.Address+':'+ sObject.ip.Port) ;
                this.client.CloseConnection();
            }
        }
    }
}
