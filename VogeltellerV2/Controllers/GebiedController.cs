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

        public ActionResult Index()
        {
            List<Gebied> Gebieden = gr.GetAllGebieden();
            return View(Gebieden);
        }
        public ActionResult Edit(int id)
        {
            Gebied gebied = gr.GetGebiedById(id);
            if(gebied != null)
            {
                return View(gebied);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Gebied gebied = new Gebied(collection["Naam"], Convert.ToDouble(collection["X"]), Convert.ToDouble(collection["Y"]), Convert.ToInt32(collection["Zoom"]));
                gr.UpdateGebied(gebied);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            Gebied gebied = gr.GetGebiedById(id);
            if (gebied != null)
            {
                return View(gebied);
            }
            else return HttpNotFound();
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