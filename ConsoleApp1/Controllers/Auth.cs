using ConsoleApp1.Security;
using ConsoleApp3;
using ConsoleApp3.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApp1.Controllers
{
    class Auth : IController
    {
        readonly TokenSystem tSystem;
        

        public Auth()
        {
            tSystem = TokenSystem.Instance;
            Console.WriteLine("Contructor Auth thread->" + Thread.CurrentThread.ManagedThreadId);
        }
        public object executeController(IConnection clientObj, StateObject sObject, IDictionary<string, object> payload)
        {
            Console.WriteLine(payload["action"] +".execute thread->" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(payload["action"] + " controller-> "+ payload["login"]+";\n"+sObject.ip.Address.ToString());

            using (User usr = new User())
            {
                if (usr.IsExist(payload["login"].ToString(), payload["password"].ToString()))
                {
                    sObject.buffer = clientObj.SendReceive(
                        Status(sObject,"1",usr.Name,usr.Role)
                        );
                    //Console.WriteLine(sObject.GetDecoded());
                    
                }
                else
                {
                    sObject.buffer = clientObj.SendReceive(Status(sObject, "-1"));
                }
            }
                
            //clientObj.CloseConnection();
            return null;
        }
        private StateObject Status(StateObject sObject,string status)
        {
            sObject.buffer = sObject.GetBytesData(tSystem.GetToken(new JwtPayload { { "action", "auth" }, { "status", status } }));
            return sObject;
        }
        private StateObject Status(StateObject sObject, string status,string name, string role)
        {
            sObject.buffer = sObject.GetBytesData(tSystem.GetToken(new JwtPayload { { "action", "auth" }, { "status", status }, { "name", name }, { "role", role } } ));
            return sObject;
        }
    }
}
