using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using killerAppSemester2.Models;

namespace KillerApp.Controllers
{
    public class UserController : Controller
    {
        static LoginService ls = new LoginService();
        static UserService us = new UserService();
        //als je naam en wachtwoord juist zijn dan ga je na de lijst anders opnieuw proberen
        [HttpPost]
        public ActionResult Login(User user)
        {
            user.Id = ls.Login(user.Gebruikersnaam, user.Wachtwoord);
            if (user.Id == 0)
            {
                return View();
            }
            else
            {
                Session["user"] = user;
                return RedirectToAction("Index");
            }
        }
        //ziet lijst van auto's van de user na dat hij is ingelogd d.m.v. user sessie
        public ActionResult Index()
        {
            
            List<Auto> autos = new List<Auto>();
            autos = us.geefAlleAutosVan((Session["user"] as User).Id);
            return View(autos);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //laat details zien van één auto kan ook opties toevoegen en dingen aanpassen vanaf details view
        public ActionResult Details(int id)
        {
            Auto auto =us.geefAllesVanAuto(id);
            Session["autoid"] = id;
            return View(auto);
        }
        //..
        public ActionResult Verwijder(int id)
        {
            us.VerwijderAuto(id);
            return RedirectToAction("Index");
        }
        //gaat naar de controller samenstellen waar je een auto kan samenstellen
        public ActionResult NieuweAuto()
        {
            return RedirectToAction("KiesMerk","Samenstellen");
        }
        //maakt sessie autoid aan
        public ActionResult VoegExtrasToe()
        {
            return View();
        }
        //weergeeft de view voor het kiezen van accesoires
        public ActionResult VOpties()
        {
            
            List<Optie> opties = us.GeefAlleOptiesVoor(Convert.ToInt32(Session["autoid"]));
            return View(opties);
        }
        //voegt optie toe aan auto
        public ActionResult VOptie(int id)
        {
            
            us.VoegOptieToe(id, Convert.ToInt32(Session["autoid"]));
            return RedirectToAction("Index");
        }

        //verwijdert sessie en gaat terug na lijst van auto's
        public ActionResult Stop()
        {
            Session.Remove("autoid");
            return RedirectToAction("Index");
        }
        public ActionResult VerwijderOpties()
        {
            List<Optie> opts = us.GeefAlleOptiesVan(Convert.ToInt32(Session["autoid"]));
            return View(opts);
        }
        public ActionResult VerwijderOptie(int id)
        {
            us.VerwijderOptie(id, Convert.ToInt32(Session["autoid"]));
            return RedirectToAction("Index");
        }
        public ActionResult KiesWatAanpassen()
        {
            int autoid = Convert.ToInt32(Session["autoid"]);
            return View();
        }
    }
}