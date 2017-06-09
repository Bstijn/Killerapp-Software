using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal_Laag;
using killerAppSemester2.Models;

namespace Logic
{
    public class LoginService
    {
        LoginDal dal = new LoginDal();
        public int Login(string gebruikersnaam, string wachtwoord)
        {
            return dal.Login(gebruikersnaam, wachtwoord);
        }
        public Boolean Registreer(User u)
        {
            if (dal.Registreer(u) == true)
            {
              return dal.MaakAccount(u);
            }
            return false;
        }
    }
}
