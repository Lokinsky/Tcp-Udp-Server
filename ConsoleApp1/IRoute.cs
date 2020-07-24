using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace ConsoleApp3
{
    internal interface IRoute
    {
        void Route(IConnection client, StateObject sObject, EControllers c, IDictionary<string,object> payload);
    }
}