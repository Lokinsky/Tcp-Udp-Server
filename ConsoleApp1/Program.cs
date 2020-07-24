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
            //string s = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhY3Rpb24iOiJhdXRoIiwic3RhdHVzIjoiMSIsImJvZHkiOnsibmFtZSI6ImtlayIsInJvbGUiOiJhZG1pbiJ9fQ.Lr-eaLOa5IJSSVPQs3HBCVss7UDnHyzLAUnnn";
            //Console.WriteLine(s.Length);
            //Console.WriteLine(s);
            //Console.WriteLine(tS.VerifyToken(Encoding.UTF8.GetString(Decode(s)))["login"]);//-> eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VybmFtZSI6IktlayIsInJvbGUiOiJsb2xsZXIiLCJhY3Rpb24iOiJsb2xsZXIifQ.nF-FET4YYhUcA79KQ4x_jzHQwNwrf3mi94bV-Y5xUw8
            //Console.WriteLine(tS.ReadToken("eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJBY3Rpb24iOiJBdXRoIiwiQm9keSI6IkhlbGxvLCBrZWsifQ.jeqI1kTvyo9vhJ-nrenYBFRP1j4M6wqUgXHiupvFnxM")["Action"]);
            Console.ReadKey();

        }
        
    }

}

