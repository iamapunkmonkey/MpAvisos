﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Avisos.Models;
using Avisos.Dal;

namespace Avisos.Controllers
{
    public class AvisoController : Controller
    {

        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Aviso/

        public ActionResult Index()
        {
            return View(unitOfWork.AvisoRepository.GetAll().ToList());
        }

        //
        // GET: /Aviso/Details/5

        public ActionResult Details(int id = 0)
        {
            Aviso aviso = unitOfWork.AvisoRepository.Get(id);
            if (aviso == null)
            {
                return HttpNotFound();
            }
            return View(aviso);
        }

        //
        // GET: /Aviso/Create

        public ActionResult Create()
        {
            var avisos = unitOfWork.AvisoRepository.GetAll().ToList();
            Aviso aviso = new Aviso() { Created = DateTime.Now, Publish = DateTime.Now };
            CreatePageAvisos model = new CreatePageAvisos() { Avisos = avisos, Aviso = aviso};
            return View(model);
        }

        //
        // POST: /Aviso/Create

        [HttpPost]
        public ActionResult Create(Aviso aviso)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.AvisoRepository.Add(aviso);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(aviso);
        }

        //
        // GET: /Aviso/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Aviso aviso = unitOfWork.AvisoRepository.Get(id);
            if (aviso == null)
            {
                return HttpNotFound();
            }
            aviso.SendSMS = false;
            return View(aviso);
        }

        //
        // POST: /Aviso/Edit/5

        [HttpPost]
        public ActionResult Edit(Aviso aviso)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.AvisoRepository.Update(aviso);
                return RedirectToAction("Index");
            }
            return View(aviso);
        }

        //
        // GET: /Aviso/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Aviso aviso = unitOfWork.AvisoRepository.Get(id);
            if (aviso == null)
            {
                return HttpNotFound();
            }
            return View(aviso);
        }

        //
        // POST: /Aviso/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.AvisoRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}