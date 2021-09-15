using finalproject.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalproject.BUS
{

    class BUS_Login
    {
        DAO_Login daoLogin;
        public BUS_Login()
        {
            daoLogin = new DAO_Login();
        }
        public bool Login (String username, String password)
        {
           
            if (daoLogin.Login(username, password) == true)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public bool Resgister(User u)
        {
            try
            {
                daoLogin.Register(u);
             return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
