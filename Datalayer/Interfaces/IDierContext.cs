using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace Datalayer.Interfaces
{
    public interface IDierContext
    {
        Vogel GetVogelById(int id);
        Zoogdier GetZoogdierById(int id);
        List<Vogel> GetAllVogels();
        List<Zoogdier> GetAllZoogdieren();
        Vogel CreateVogel(Vogel vogel);
        Zoogdier CreateZoogdier(Zoogdier zoogdier);
        bool UpdateVogel(Vogel vogel);
        bool UpdateZoogdier(Zoogdier zoogdier);
        bool DeleteVogel(int id);
        bool DeleteZoogdier(int id);
    }
}
