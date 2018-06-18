using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer.Interfaces;
using Models.Models;

namespace VogelTellerTests.TestContext
{
    class CUDGebiedContext : IGebiedContext
    {
        List<Gebied> gebieden = new List<Gebied>();
        public Gebied CreateGebied(Gebied gebied)
        {
            gebieden.Add(gebied);
            return gebied;
        }

        public bool DeleteGebied(int id)
        {
            Gebied gebied = gebieden.Find(i => i.Id == id);
            gebieden.Remove(gebied);
            return true;
        }
        public bool UpdateGebied(Gebied gebied)
        {
            Gebied oldgebied = gebieden.Find(i => i.Id == gebied.Id);
            int index = gebieden.IndexOf(oldgebied);
            if (index != -1) { gebieden[index] = gebied; }
            return true;
        }
        public List<Gebied> GetAllGebieden()
        {
            throw new NotImplementedException();
        }

        public Gebied GetGebiedById(int id)
        {
            Gebied gebied = gebieden.Find(i => i.Id == id);
            return gebied;
        }
    }
}
