using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ConsoleApp3.Model;
using ConsoleApp1.Security;
using System.Text;
using System.Diagnostics;
using System.Threading;
using ConsoleApp1.Controllers;

namespace ConsoleApp3
{
    class Program
    {
     
        static void Main(string[] args)
        {

            new Startup();
            //TokenSystem tS = TokenSystem.Instance;
            //string s = tS.GetToken(new JwtPayload { { "Action", "Auth" }, { "Body", "Hello, kek" } });
            //Console.WriteLine(s);
            Console.ReadKey();

        }
       

    }
}
