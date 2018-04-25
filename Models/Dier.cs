using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Dier
    {
        private int id;
        private string naam;

        public int Id { get { return id; } set { id = value; } }
        public string Naam { get { return naam; } set { naam = value; } }

        public Dier(int id, string naam)
        {
            this.id = id;
            this.naam = naam;
        }


    }
}
