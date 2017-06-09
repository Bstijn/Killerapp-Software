using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace killerAppSemester2.Models
{
    public abstract class AutoOnderdeel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        

        public AutoOnderdeel(string Naam, decimal Prijs)
        {
            this.Naam = Naam;
            this.Prijs = Prijs;
            
        }
        public AutoOnderdeel()
        {

        }
            
    }
}