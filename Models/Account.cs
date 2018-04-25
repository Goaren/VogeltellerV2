using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Account
    {
        private int id;
        private string email;
        private string voornaam;
        private string achternaam;
        private string wachtwoord;
        private List<Waarneming> waarnemingen = new List<Waarneming>();

        public int Id { get { return id; } set { id = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Voornaam { get { return voornaam; } set { voornaam = value; } }
        public string Achternaam { get { return achternaam; } set { achternaam = value; } }
        public string Wachtwoord { get { return wachtwoord; } set { wachtwoord = value; } }

        public Account(int id, string email, string voornaam, string achternaam, string wachtwoord)
        {
            this.id = id;
            this.email = email;
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.wachtwoord = wachtwoord;
        }

        public void MakeWaarneming(Waarneming waarneming)
        {
            waarnemingen.Add(waarneming);
        }
    }
}
