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
        List<Vogel> GetAllVogels();
        List<Zoogdier> GetAllZoogdieren();
        Vogel CreateVogel(Vogel vogel);
        Zoogdier CreateZoogdier(Zoogdier zoogdier);
    }
}
