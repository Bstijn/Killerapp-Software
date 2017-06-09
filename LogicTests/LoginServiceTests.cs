using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using killerAppSemester2.Models;
using Dal_Laag;

namespace Logic.Tests
{
    [TestClass()]
    public class LoginServiceTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            //assemble
            int x = 0;
            LoginService serv = new LoginService();

            //act
            x = serv.Login("iemand", "Iemand1");
            //assert
            Assert.AreEqual(1,x);
        }
        [TestMethod]
        public void Test()
        {
            //assemble
            bool b;
            LoginDal dal = new LoginDal();
            User u = new User();
            u.Gebruikersnaam = "gehadasdf";
            u.Wachtwoord = "Something2132";
            //act
            b = dal.Registreer(u);
            //assert
            Assert.AreEqual(true, b);
        }
    }
}