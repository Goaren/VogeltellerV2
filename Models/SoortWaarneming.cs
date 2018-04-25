using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class SoortWaarneming
    {
        private int id;
        private string naam;
        private int punten;

        public int Id { get { return id; } set { id = value; } }
        public string Naam { get { return naam; } set { naam = value; } }
        public int Punten { get { return punten; } set { punten = value; } }

        public SoortWaarneming(int id, string naam, int punten)
        {
            this.id = id;
            this.naam = naam;
            this.punten = punten;
        }
    }
}
