using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Models;
using Datalayer.Repositories;
using Datalayer.SQLContext;

namespace VogeltellerV2.Models
{
    public class GebiedWaarnemingViewModel
    {
        private GebiedRepository gr = new GebiedRepository(new GebiedSQLContext());
        private WaarnemingRepository wr = new WaarnemingRepository(new WaarnemingSQLContext());
        public List<Waarneming> waarnemingen { get; set; } = new List<Waarneming>();
        public Gebied gebied;
        public GebiedWaarnemingViewModel(int id)
        {
            gebied = gr.GetGebiedById(id);
            waarnemingen = wr.GetAllWaarnemingenBijGebied(id);
        }
    }
}