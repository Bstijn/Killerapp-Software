using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;
using killerAppSemester2.Models;

namespace KillerApp.Controllers
{
    public class AanpassenController : Controller
    {
        static AanpassingService serv = new AanpassingService();
        static UserService us = new UserService();
        // GET: Aanpassen
        public ActionResult Back()
        {
            return RedirectToAction("Details","User", new { @id = Convert.ToInt32(Session["autoid"]) });
        }
        public ActionResult OptiesAanpassen()
        {
            return View();
        }
        public ActionResult MTAanpassen(List<MotorTransmissie> mts)
        {
            if (mts == null)
            {
                int x = Convert.ToInt32(Session["autoid"]);
                List<MotorTransmissie> Mts = serv.GeefMtsVoorAanpassing(Convert.ToInt32(Session["autoid"]));
                return View(Mts);
            }
            return View(mts);
        }
        public ActionResult UitvoeringAanpassen(List<Uitvoering> uvs)
        {
            if(uvs == null) { 
            List<Uitvoering> uitvoeringen = serv.GeefUvsVoorUitvoeringen(Convert.ToInt32(Session["autoid"]));
            return View(uitvoeringen);
            }
            return View(uvs);
        }
        public ActionResult ModelAanpassen()
        {
            List<Model> Ms = serv.GeefMsVoorAanpassing(Convert.ToInt32(Session["autoid"]));
            return View(Ms);
        }
        public ActionResult VervangeMT(int MTID)
        {
            serv.VervangMt(MTID, Convert.ToInt32(Session["autoid"]));
            return RedirectToAction("Details", "User", new { @id = Convert.ToInt32(Session["autoid"]) });
        }
        public ActionResult VervangUV(string UVNaam)
        {
            List<MotorTransmissie> Mts = us.GeefAlleMTS(UVNaam);
            return RedirectToAction("MTAanpassen", Mts);
        }
        public ActionResult VervangM(string MNaam)
        {
            List<Uitvoering> UVs = us.GeefAlleUivoeringen(MNaam);
            return RedirectToAction("UitvoeringAanpassen", UVs);
        }
    }
}