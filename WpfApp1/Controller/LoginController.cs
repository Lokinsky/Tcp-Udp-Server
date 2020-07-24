using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Model;

namespace WpfApp1.Controller
{
     class LoginController
    {

        public LoginController()
        {

        }
        public  object TryLogin(string login, string password)
        {
            User usr = new User(login, password);

            if (usr.isAuth)
            {
                return usr;
            }
            else
            {
                return (object)"fail auth";
            }
            
        }
    }
}
