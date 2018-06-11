using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Datalayer.Interfaces;

namespace Datalayer.Repositories
{
    public class DierRepository
    {
        private IDierContext context;

        public DierRepository(IDierContext context)
        {
            this.context = context;
        }
        public List<Vogel> GetAllVogels()
        {
            return context.GetAllVogels();
        }
        public List<Zoogdier> GetAllZoogdieren()
        {
            return context.GetAllZoogdieren();
        }
        public Vogel CreateVogel(Vogel vogel)
        {
            return context.CreateVogel(vogel);
        }
        public Zoogdier CreateZoogdier(Zoogdier zoogdier)
        {
            return context.CreateZoogdier(zoogdier);
        }
    }
}
