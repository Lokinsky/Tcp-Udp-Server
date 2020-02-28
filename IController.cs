using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1
{
    interface IController
    {
        object executeController(IConnection clientObj, StateObject sObject,JwtPayload payload);
    }
}
