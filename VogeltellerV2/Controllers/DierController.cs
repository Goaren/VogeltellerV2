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
        public ActionResult VogelIndex()
        {
            List<Vogel> Dieren = dr.GetAllVogels();
            return View(Dieren);
        }
        public ActionResult ZoogdierIndex()
        {
            List<Zoogdier> Dieren = dr.GetAllZoogdieren();
            return View(Dieren);
        }
        public ActionResult DierKeuze()
        {
            return View();
        }

        public ActionResult CreateVogel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateVogel(Vogel vogel)
        {
            if (ModelState.IsValid)
            {
                dr.CreateVogel(vogel);
                return RedirectToAction("VogelIndex", "Dier");
            }
            return View();

        }
        public ActionResult CreateZoogdier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateZoogdier(Zoogdier zoogdier)
        {
            if (ModelState.IsValid)
            {
                dr.CreateZoogdier(zoogdier);
                return RedirectToAction("ZoogdierIndex", "Dier");
            }
            return View();

        }
    }
}