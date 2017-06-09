using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace killerAppSemester2.Models
{
    public class Model: AutoOnderdeel
    {
        
        public string Merk { get; set; }
        public string Filenaam { get; set; }
        public string Beschrijving { get; set; }
        public Model(string Naam, decimal Prijs, string Merk, string beschrijving, string filepath): base(Naam, Prijs)
        {
            this.Merk = Merk;
            this.Filenaam = filepath;
            this.Beschrijving = beschrijving;
        }

        public Model()
        {

        }
    }
}