using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace killerAppSemester2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public User(string gebruikersnaam, string wachtwoord)
        {
            this.Gebruikersnaam = gebruikersnaam;
            this.Wachtwoord = wachtwoord;
        }
        public User()
        {

        }
    }
}