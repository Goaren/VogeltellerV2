﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Models;
using Datalayer.Repositories;
using Datalayer.SQLContext;
using VogeltellerV2.Models;
using System.Web.Script.Serialization;

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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Gebied gebied)
        {
            if (ModelState.IsValid)
            {
                gr.CreateGebied(gebied);
                return RedirectToAction("Index", "Gebied");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            Gebied gebied = gr.GetGebiedById(id);
            if (gebied != null)
            {
                return View(gebied);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Gebied gebied)
        {
            if (ModelState.IsValid)
            {
                gr.UpdateGebied(gebied);
                return RedirectToAction("index", "Gebied");
            }
            return View();
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

        public ActionResult Delete(int id)
        {
            Gebied gebied = gr.GetGebiedById(id);
            if (gebied != null)
            {
                return View(gebied);
            }
            else return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Delete(int id, Gebied gebied)
        {
            try
            {

                gr.DeleteGebied(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Map(int id)
        {
            GebiedWaarnemingViewModel gebied = new GebiedWaarnemingViewModel(id);
            var json = new JavaScriptSerializer().Serialize(gebied);
            ViewBag.jsonObj = json;
            if (gebied != null)
            {
                return View(gebied);
            }
            else return HttpNotFound();
        }
    }
}