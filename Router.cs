using ConsoleApp1;
using ConsoleApp1.Controllers;
using ConsoleApp3.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    enum EControllers
    {
        Auth = 1,
        Register = 2
    }
    class Router : IRoute
    {
        
        private static Router instance = null;
        private static readonly object padlock = new object();
        private Dictionary<EControllers, IController> controllers;
        private Router()
        {
            controllers = new Dictionary<EControllers, IController>();
            Console.WriteLine("Router thread->" + Thread.CurrentThread.ManagedThreadId);
            
        }
        public static Router Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Router();
                    }
                    return instance;
                }
            }
        }
        public void registerController(EControllers eC, IController c)
        {
            
            controllers.Add(eC, c);
        }

        public void Route(IConnection client, StateObject sObject, EControllers c, JwtPayload payload)
        {

            new Thread(()=> controllers[c].executeController(client, sObject, payload)).Start();
        }
    }
}
