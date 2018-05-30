using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Datalayer.Interfaces;

namespace Datalayer.Repositories
{
    public class GebiedRepository
    {
        private IGebiedContext context;

        public GebiedRepository(IGebiedContext context)
        {
            this.context = context;
        }
        public Gebied GetGebiedById(int id)
        {
            return context.GetGebiedById(id);
        }
        public List<Gebied> GetAllGebieden()
        {
            return context.GetAllGebieden();
        }
        public Gebied CreateGebied(Gebied gebied)
        {
            return context.CreateGebied(gebied);
        }
        public bool UpdateGebied(Gebied gebied)
        {
            return context.UpdateGebied(gebied);
        }
        public bool DeleteGebied(int id)
        {
            return context.DeleteGebied(id);
        }
    }
}
