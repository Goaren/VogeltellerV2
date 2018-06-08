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
    public class DierController : Controller
    {
        DierRepository dr = new DierRepository(new DierSQLContext());
        // GET: Dier
        public ActionResult Index()
        {
            List<Dier> Dieren = dr.GetAllDieren();
            return View(Dieren);
        }
    }
}