using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace killerAppSemester2.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public User User { get; private set; } = new User();
        public Model Model { get; private set; } = new Model();
        public Uitvoering Uitvoering { get; private set; } = new Uitvoering();
        public MotorTransmissie MotorTransmissie { get; private set; } = new MotorTransmissie();
        public Merk merk { get; set; } = new Merk();
        public List<Optie> opties { get; set; } = new List<Optie>();
        public string Kleur { get; set; }
        public decimal Prijs { get; set; }
    }
}