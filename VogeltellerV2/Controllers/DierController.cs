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
        public ActionResult EditVogel(int id)
        {
            Vogel vogel = dr.GetVogelById(id);
            if(vogel != null)
            {
                return View(vogel);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditVogel(Vogel vogel)
        {
            if (ModelState.IsValid)
            {
                dr.UpdateVogel(vogel);
                return RedirectToAction("VogelIndex", "Dier");
            }
            return View();
        }
        public ActionResult EditZoogdier(int id)
        {
            Zoogdier zoogdier = dr.GetZoogdierById(id);
            if (zoogdier != null)
            {
                return View(zoogdier);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditZoogdier(Zoogdier zoogdier)
        {
            if (ModelState.IsValid)
            {
                dr.UpdateZoogdier(zoogdier);
                return RedirectToAction("ZoogdierIndex", "Dier");
            }
            return View();
        }
        public ActionResult DeleteVogel(int id)
        {
            Vogel vogel = dr.GetVogelById(id);
            if (vogel != null)
            {
                return View(vogel);
            }
            else return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteVogel(int id, Vogel vogel)
        {
            try
            {
                dr.DeleteVogel(id);
                return RedirectToAction("VogelIndex");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteZoogdier(int id)
        {
            Zoogdier zoogdier = dr.GetZoogdierById(id);
            if (zoogdier != null)
            {
                return View(zoogdier);
            }
            else return HttpNotFound();
        }

        [HttpPost]
        public ActionResult DeleteZoogdier(int id, Zoogdier zoogdier)
        {
            try
            {
                dr.DeleteZoogdier(id);
                return RedirectToAction("ZoogdierIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}