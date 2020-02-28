using ConsoleApp1.Security;
using ConsoleApp3;
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
        TokenSystem tSystem;
        public Auth()
        {
            tSystem = TokenSystem.Instance;
            Console.WriteLine("Contructor Auth thread->" + Thread.CurrentThread.ManagedThreadId);
        }
        public object executeController(IConnection clientObj, StateObject sObject, JwtPayload payload)
        {
            Console.WriteLine("Auth.execute thread->" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Auth controller-> "+ payload["Body"]+';'+sObject.ip.Address.ToString());
            sObject = Status(sObject);
            
            sObject.buffer = clientObj.SendReceive(sObject);
            //clientObj.CloseConnection();
            return null;
        }
        private StateObject Status(StateObject sObject)
        {
            sObject.buffer = sObject.GetBytesData(tSystem.GetToken(new JwtPayload { { "Action", "BackFist" }, { "Body", "Pucnh him" } }));
            return sObject;
        }
    }
}
