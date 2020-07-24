using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    class User : IDisposable
    {

        //Socket client; s
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public TokenModel Token { get; set; }
        List<JwtPayload> users = new List<JwtPayload>()
        {
            new JwtPayload { { "login","admin" },{"password","admin" },{"role","admin"}, {"name","kek"} },
            new JwtPayload { { "login", "moderator" }, { "password", "moderator" }, { "role", "moderator" }, { "name", "moderlol" } }
        };
        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        public bool IsExist(string login, string password)
        {
            bool existing = false;
            //[query to db]
            foreach (JwtPayload user in users)
            {
                if (user["login"].Equals(login))
                {
                    Role = user["role"].ToString();
                    Name = user["name"].ToString();
                    existing = true;
                }
            }
            if (existing)
            {
                //filling the fields from query

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
