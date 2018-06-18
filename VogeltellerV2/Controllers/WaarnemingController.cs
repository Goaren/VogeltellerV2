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
    public class WaarnemingController : Controller
    {
        WaarnemingRepository wr = new WaarnemingRepository(new WaarnemingSQLContext());
        // GET: Waarneming
        public ActionResult DierToevoegenKeuze()
        {
            return View();
        }
        public ActionResult CreateWaarnemingWithVogel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateWaarnemingWithVogel(Waarneming waarneming)
        {
            if (ModelState.IsValid)
            {
                wr.CreateWaarneming(waarneming);
                return RedirectToAction("GebiedList", "Gebied");
            }
            return View();
        }
        public ActionResult CreateWaarnemingWithZoogdier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateWaarnemingWithZoogdier(Waarneming waarneming)
        {
            if (ModelState.IsValid)
            {
                wr.CreateWaarneming(waarneming);
                return RedirectToAction("GebiedList", "Gebied");
            }
            return View();
        }
    }
}