using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Vogel : Dier
    {
        private DateTime broedperiodestart;
        private DateTime broedperiodeeinde;
        private int broedpaar;

        public DateTime BroedperiodeStart { get { return broedperiodestart; } set { broedperiodestart = value; } }
        public DateTime BroedperiodeEinde { get { return broedperiodeeinde; } set { broedperiodeeinde = value; } }
        public int Broedpaar { get { return broedpaar; } set { broedpaar = value; } }

        public Vogel(int id, string naam, DateTime broedperiodestart, DateTime broedperiodeeinde, int broedpaar) : base(id, naam)
        {
            this.Id = id;
            this.Naam = naam;
            this.broedperiodestart = broedperiodestart;
            this.broedperiodeeinde = broedperiodeeinde;
            this.broedpaar = broedpaar;
        }
        public Vogel()
        {

        }
    }
}
