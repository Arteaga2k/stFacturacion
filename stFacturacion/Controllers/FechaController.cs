using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stFacturacion.Models;

namespace stFacturacion.Controllers
{ 
    public class FechaController : Controller
    {
        private FacturacionDBContext db = new FacturacionDBContext();

        //
        // GET: /Fecha/

        public ViewResult Index()
        {
            return View(db.Fecha.ToList());
        }

        //
        // GET: /Fecha/Details/5

        public ViewResult Details(int id)
        {
            Fecha fecha = db.Fecha.Find(id);
            return View(fecha);
        }

        //
        // GET: /Fecha/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Fecha/Create

        [HttpPost]
        public ActionResult Create(Fecha fecha)
        {
            if (ModelState.IsValid)
            {
                db.Fecha.Add(fecha);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(fecha);
        }
        
        //
        // GET: /Fecha/Edit/5
 
        public ActionResult Edit(int id)
        {
            Fecha fecha = db.Fecha.Find(id);
            return View(fecha);
        }

        //
        // POST: /Fecha/Edit/5

        [HttpPost]
        public ActionResult Edit(Fecha fecha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fecha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fecha);
        }

        //
        // GET: /Fecha/Delete/5
 
        public ActionResult Delete(int id)
        {
            Fecha fecha = db.Fecha.Find(id);
            return View(fecha);
        }

        //
        // POST: /Fecha/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Fecha fecha = db.Fecha.Find(id);
            db.Fecha.Remove(fecha);
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