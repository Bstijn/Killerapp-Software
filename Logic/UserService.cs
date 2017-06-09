using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using killerAppSemester2.Models;
using Dal_Laag;

namespace Logic
{
    public class UserService
    {
        UserDal dal = new UserDal();
        public List<Auto> geefAlleAutosVan(int userid)
        {
            return dal.geefAlleAutosVan(userid);
        }
        public Auto geefAllesVanAuto(int autoid)
        {
            Auto a = dal.geefAllesVanAuto(autoid);
            
            a.opties = dal.GeefOptiesVan(autoid);
            return a;
        }
        public List<Merk> GeefAlleMerken()
        {
            return dal.GeefAlleMerken();
        }
        public List<Model> GeefModellenvan (string mnaam)
        {
            return dal.GeefModellenvan(mnaam);
        }
        public List<Uitvoering> GeefAlleUivoeringen(string naam)
        {
            return dal.GeefAlleUivoeringen(naam);
        }
        public List<MotorTransmissie> GeefAlleMTS(string naam)
        {
            return dal.GeefAlleMTS(naam);
        }
        public void VerwijderAuto(int id)
        {
            dal.VerwijderAuto(id);
        }
        public void VoegNieuweAutoToe(Auto auto)
        {
            dal.VoegNieuweAutoToe(auto);
        }
        public List<string> GeefAlleKleuren()
        {
            return dal.GeefAlleKleuren();
        }
        public List<Optie> GeefAlleOptiesVoor(int autoid)
        {
            return dal.GeefAlleOptiesVoor(autoid);
        }
        public void VoegOptieToe(int idoptie, int autoid)
        {
            dal.VoegOptieToe(idoptie, autoid);
        }
        public List<Optie> GeefAlleOptiesVan(int v)
        {
            return dal.GeefAlleOptiesVan(v);
        }
        public void VerwijderOptie(int optieid, int autoid)
        {
            dal.VerwijderOptie(optieid, autoid);
        }
        public List<Optie> GeefAlleOptiesVanUitvoering(int id)
        {
            return dal.GeefAlleOptiesVanUitvoering(id);
        }
    }
}
