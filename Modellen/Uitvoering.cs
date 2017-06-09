using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace killerAppSemester2.Models
{
    public class Uitvoering: AutoOnderdeel
    {
        public string Beschrijving { get; set; }
        public Uitvoering(string naam, decimal prijs, string beschrijving): base(naam, prijs)
        {
            this.Beschrijving = beschrijving;
        }
        public Uitvoering()
        {

        }
    }
}