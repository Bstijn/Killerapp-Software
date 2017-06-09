using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace killerAppSemester2.Models
{
    public class MotorTransmissie: AutoOnderdeel
    {
        public int Paardenkracht { get; set; }
        public decimal LiterPer100 { get; set; }
        public MotorTransmissie(string Naam, decimal Prijs): base(Naam, Prijs)
        {

        }
        public MotorTransmissie()
        {

        }
    }
}