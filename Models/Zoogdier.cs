using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Zoogdier : Dier
    {
        private string familie;

        public string Familie { get { return familie; } set { familie = value; } }

        public Zoogdier(int id, string naam, string familie) : base(id, naam)
        {
            this.Id = id;
            this.Naam = naam;
            this.familie = familie;
        }
        public Zoogdier()
        {

        }
    }
}
