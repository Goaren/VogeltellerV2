using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Datalayer.Interfaces;

namespace Datalayer.Repositories
{
    public class BezoekRepository
    {
        private IBezoekContext context;

        public BezoekRepository(IBezoekContext context)
        {
            this.context = context;
        }
        public List<Bezoek> GetAllBezoeken()
        {
            return context.GetAllBezoeken();
        }
    }
}
