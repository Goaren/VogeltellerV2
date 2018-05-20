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
    public class GebiedController : Controller
    {
        GebiedRepository gr = new GebiedRepository(new GebiedSQLContext());
        // GET: Gebied
        public ActionResult GebiedList()
        {
            List<Gebied> Gebieden = gr.GetAllGebieden();
            return View(Gebieden);
        }

        public ActionResult Map(int id)
        {
            Gebied gebied = gr.GetGebiedById(id);
            if (gebied != null)
            {
                return View(gebied);
            }
            else return HttpNotFound();
        }
    }
}