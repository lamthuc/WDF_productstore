using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalproject.DAO
{
    class DAO_Login
    {
        saledbEntities db;
        public DAO_Login()
        {
            db = new saledbEntities();
        }
        public bool Login(String username, String password)
        {
            var ds = (from s in db.Users
                      where s.Username == username && s.Password == password
                      select s);
            if (ds.FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Register(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }
    }
}
