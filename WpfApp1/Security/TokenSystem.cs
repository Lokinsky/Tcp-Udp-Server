using JWT;
using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace ConsoleApp1.Security
{
    class TokenSystem
    {
        readonly JwtHeader header;
        readonly TokenOptions tokenOptions;
        readonly JwtSecurityTokenHandler handler;
        private static TokenSystem instance = null;
        private static readonly object padlock = new object();
        private TokenSystem()
        {

            tokenOptions = new TokenOptions();
            //  Finally create a Token
            header = new JwtHeader(tokenOptions.Credentials);
            handler = new JwtSecurityTokenHandler();
            //handler.TokenLifetimeInMinutes = tokenOptions.LIFETIME;
            // And finally when  you received token from client
            // you can  either validate it or try to  read

        }
        public static TokenSystem Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TokenSystem();
                    }
                    return instance;
                }
            }
        }
        public string GetToken(JwtPayload payload)
        {
            try
            {

                /*
                 .AddClaim("username", payload["username"])
                     .AddClaim("role", payload["role"])
                     .AddClaim("action", payload["action"])
                     .AddClaim("status", payload["status"])*/

                return new JwtBuilder()
                     .WithAlgorithm(new HMACSHA256Algorithm())
                     .WithSecret(tokenOptions.KEY)
                     .AddClaims(payload)
                     .Encode();
            }catch(Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public IDictionary<string, object> VerifyToken(string token)
        {
            try
            {


                return new JwtBuilder()
                     .WithSecret(tokenOptions.KEY)
                     .WithAlgorithm(new HMACSHA256Algorithm())
                     .MustVerifySignature()
                     .Decode<IDictionary<string, object>>(token);
            }
            catch (SignatureVerificationException ex)
            {
                Console.WriteLine(ex.Message);

                return new Dictionary<string, object>() { {"status",-1 },{"error",ex.HResult } };
            }
        }

    }
}
