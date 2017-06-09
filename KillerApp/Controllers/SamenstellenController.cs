using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using killerAppSemester2.Models;
using Logic;

namespace KillerApp.Controllers
{
    public class SamenstellenController : Controller
    {
        static UserService us = new UserService();
        public ActionResult KiesMerk()
        {
            List<Merk> merken = us.GeefAlleMerken();
            return View(merken);
        }
        public ActionResult KiesModel(string naam)
        {
            Session["Merk"] = naam;
            List<Model> modellen = us.GeefModellenvan(naam);
            return View(modellen);
        }
        public ActionResult KiesUitvoering(string naam)
        {
            Session["Model"] = naam;
            List<Uitvoering> uits = us.GeefAlleUivoeringen(naam);
            return View(uits);
        }
        public ActionResult KiesMT(string naam)
        {
            Session["Uitvoering"] = naam;
            List<MotorTransmissie> mts = us.GeefAlleMTS(naam);
            return View(mts);

        }
        public ActionResult KiesKleur (string naam)
        {
            Session["MT"] = naam;
            List<string> kleuren = us.GeefAlleKleuren();
            return View(kleuren);

        }
        [HttpGet]
        public ActionResult VoerNaamIn(string naam)
        {
            Session["Kleur"] = naam;
            return View();
        }
        [HttpPost]
        public ActionResult VoerNaamIn(Auto a)
        {
            Session["Naam"] = a.Naam;
            return RedirectToAction("Confirm");
        }
        public ActionResult Confirm()
        {
            Auto a = new Auto();
            a.Naam = Session["Naam"] as string;
            a.merk.Naam = Session["Merk"] as string;
            a.Model.Naam = Session["Model"] as string;
            a.Uitvoering.Naam = Session["Uitvoering"] as string;
            a.MotorTransmissie.Naam = Session["MT"] as string;
            a.Kleur = Session["Kleur"] as string;
            a.User.Id = (Session["user"] as User).Id;
            us.VoegNieuweAutoToe(a);
            return RedirectToAction("Cancel");

        }
        public ActionResult Cancel()
        {
            Session.Remove("Merk");
            Session.Remove("Model");
            Session.Remove("Uitvoering");
            Session.Remove("MT");
            Session.Remove("Kleur");
            Session.Remove("Naam");
            return RedirectToAction("Index", "User");
        }
    }
}