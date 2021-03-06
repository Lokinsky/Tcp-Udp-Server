﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Security
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthServer"; // издатель токена
        public const string AUDIENCE = "AuthClient"; // потребитель токена
        const string KEY = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b372742" +
                "9090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";   // ключ для шифрации
        public const int LIFETIME = 30; // время жизни токена - 1 минута
        public SigningCredentials credentials { get; private set; }
        public AuthOptions()
        {
            credentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature);
        }
        SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

