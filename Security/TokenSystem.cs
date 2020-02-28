using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ConsoleApp1.Security
{
    class TokenSystem
    {
        JwtHeader header;
        AuthOptions authOptions;
        JwtSecurityTokenHandler handler;
        private static TokenSystem instance = null;
        private static readonly object padlock = new object();
        private TokenSystem()
        {

            authOptions = new AuthOptions();
            //  Finally create a Token
            header = new JwtHeader(authOptions.credentials);
            handler = new JwtSecurityTokenHandler();


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
            JwtSecurityToken secToken = new JwtSecurityToken(header, payload);

            // Token to String so you can use it in your client
            
            return handler.WriteToken(secToken);
        }
        public JwtPayload ReadToken(string tokenString)
        {
            return handler.ReadJwtToken(tokenString).Payload;
        }
        public bool ValidateToken(string tokenString)
        {
            if (handler.CanReadToken(tokenString))
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
