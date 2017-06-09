using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace killerAppSemester2.Models
{
    public abstract class Extra
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public string Filepath { get; set; }
        public string Beschrijving { get; set; }
        
        public Extra(string naam, decimal prijs, string filepath, string beschrijving)
        {
            this.Naam = Naam;
            this.Prijs = Prijs;
            this.Filepath = filepath;
            this.Beschrijving = beschrijving;
        }
        public Extra()
        {

        }
    }
}