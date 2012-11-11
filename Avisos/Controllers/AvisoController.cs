using System;
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
        private AvisoContext db = new AvisoContext();

        //
        // GET: /Aviso/

        public ActionResult Index()
        {
            return View(db.Avisos.ToList());
        }

        //
        // GET: /Aviso/Details/5

        public ActionResult Details(int id = 0)
        {
            Aviso aviso = db.Avisos.Find(id);
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
            var avisos = db.Avisos.ToList();
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
                db.Avisos.Add(aviso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aviso);
        }

        //
        // GET: /Aviso/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Aviso aviso = db.Avisos.Find(id);
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
                db.Entry(aviso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aviso);
        }

        //
        // GET: /Aviso/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Aviso aviso = db.Avisos.Find(id);
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
            Aviso aviso = db.Avisos.Find(id);
            db.Avisos.Remove(aviso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}