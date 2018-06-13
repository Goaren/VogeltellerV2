using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace Datalayer.Interfaces
{
    public interface IWaarnemingContext
    {
        Waarneming GetWaarnemingById(int id);
        List<Waarneming> GetAllWaarnemingen();
        List<Waarneming> GetAllWaarnemingenBijGebied(int id);
        Waarneming CreateWaarneming(Waarneming waarneming);
    }
}
