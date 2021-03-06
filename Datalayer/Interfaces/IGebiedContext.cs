﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace Datalayer.Interfaces
{
    public interface IGebiedContext
    {
        Gebied GetGebiedById(int id);
        List<Gebied> GetAllGebieden();
        Gebied CreateGebied(Gebied gebied);
        bool UpdateGebied(Gebied gebied);
        bool DeleteGebied(int id);
    }   
}
