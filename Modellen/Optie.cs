using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace killerAppSemester2.Models
{
    public class Optie: Extra
    {

        public Optie(string Naam, decimal Prijs, string filepath, string beschrijving) : base(Naam, Prijs,filepath, beschrijving)
        {

        }
        public Optie()
        {

        }
    }
}