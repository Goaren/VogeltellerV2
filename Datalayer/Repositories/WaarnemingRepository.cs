using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Datalayer.Interfaces;

namespace Datalayer.Repositories
{
    public class WaarnemingRepository
    {
        private IWaarnemingContext context;

        public WaarnemingRepository(IWaarnemingContext context)
        {
            this.context = context;
        }
        public Waarneming GetWaarnemingById(int id)
        {
            return context.GetWaarnemingById(id);
        }
        public List<Waarneming> GetAllWaarnemingen()
        {
            return context.GetAllWaarnemingen();
        }
        public List<Waarneming> GetAllWaarnemingenBijGebied(int id)
        {
            return context.GetAllWaarnemingenBijGebied(id);
        }
        public Waarneming CreateWaarneming(Waarneming waarneming)
        {
            return context.CreateWaarneming(waarneming);
        }
    }
}
