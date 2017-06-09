using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal_Laag;
using killerAppSemester2.Models;

namespace Logic
{
    
    public class AanpassingService
    {
        static AanpassingDal dal = new AanpassingDal();

        public List<MotorTransmissie> GeefMtsVoorAanpassing(int autoid)
        {
            return dal.GeefMtsVorAanpassing(autoid);

        }

        public void VervangMt(int mTID, int v)
        {
           dal.VervangMt(mTID, v);
        }

        public List<Uitvoering> GeefUvsVoorUitvoeringen(int v)
        {
            return dal.GeefUvsVoorUitvoering(v);
        }

        public List<Model> GeefMsVoorAanpassing(int v)
        {
            return dal.GeefMsVoorAanpassing(v);
        }
    }
}
