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
        public Vogel GetVogelById(int id)
        {
            return context.GetVogelById(id);
        }
        public Zoogdier GetZoogdierById(int id)
        {
            return context.GetZoogdierById(id);
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
        public bool UpdateVogel(Vogel vogel)
        {
            return context.UpdateVogel(vogel);
        }
        public bool UpdateZoogdier(Zoogdier zoogdier)
        {
            return context.UpdateZoogdier(zoogdier);
        }
        public bool DeleteVogel(int id)
        {
            return context.DeleteVogel(id);
        }
        public bool DeleteZoogdier(int id)
        {
            return context.DeleteZoogdier(id);
        }
    }
}
