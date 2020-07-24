using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ConsoleApp1.Security
{
    public class TokenOptions
    {
        public const string ISSUER = "AuthServer"; // издатель токена
        public const string AUDIENCE = "AuthClient"; // потребитель токена
        public string KEY = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b372742" +
                "9090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1s";   // ключ для шифрации
        public  int LIFETIME = 30; // время жизни токена - 30 минута
        public SigningCredentials Credentials { get; private set; }
        public TokenOptions()
        {
            Credentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature);
        }
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}

