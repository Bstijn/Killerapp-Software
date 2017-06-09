using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using killerAppSemester2.Models;


namespace KillerApp.Controllers
{
    public class HomeController : Controller
    {
        static LoginService ls = new LoginService();
        static UserService us = new UserService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult OverzichtMerk()
        {
            List <Merk> merken = us.GeefAlleMerken();
            return View(merken);
        }
        public ActionResult OverzichtModel(string naam)
        {
            List<Model> modellen = us.GeefModellenvan(naam);
            return View(modellen);
        }
        public ActionResult OverzichtUitvoering(string naam)
        {
            List<Uitvoering> uitv = us.GeefAlleUivoeringen(naam);
            return View(uitv);
        }
        public ActionResult OverzichtMT(string naam)
        {
            List<MotorTransmissie> mts = us.GeefAlleMTS(naam);
            return View(mts);
        }
        [HttpGet]
        public ActionResult Registreer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registreer(User u)
        {
            //gaat na of de gebruikersnaam en wachtwoord goed is en geef boolean terug en dat bepaald waar je heen navigeert.
            if(ls.Registreer(u) == true)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("GefaaldeLogin", "Home");
            }
            
        }
        public ActionResult GefaaldeLogin()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            return RedirectToAction("Index","Home");
        }
        public ActionResult OverzichtKleuren()
        {
            List<string> kleuren = us.GeefAlleKleuren();
            return View(kleuren);
        }
        public ActionResult OverzichtOpties(int id)
        {
            List<Optie> opties = us.GeefAlleOptiesVanUitvoering(id);
            return View(opties);
        }
    }
}