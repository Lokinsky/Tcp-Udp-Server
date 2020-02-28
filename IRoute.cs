using System.IdentityModel.Tokens.Jwt;

namespace ConsoleApp3
{
    internal interface IRoute
    {
        void Route(IConnection client, StateObject sObject, EControllers c, JwtPayload payload);
    }
}