using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Models;
using Datalayer.Repositories;
using Datalayer.SQLContext;

namespace VogeltellerV2.Controllers
{
    public class BezoekController : Controller
    {
        private BezoekRepository br = new BezoekRepository(new BezoekSQLContext());
        // GET: Bezoek
        public ActionResult Index()
        {
            List<Bezoek> BezoekList = br.GetAllBezoeken();
            return View(BezoekList);
        }
    }
}