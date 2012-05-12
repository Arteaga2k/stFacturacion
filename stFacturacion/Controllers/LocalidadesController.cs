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
    [Authorize]
    public class LocalidadesController : Controller
    {
        private FacturacionDBContext db = new FacturacionDBContext();

        //
        // GET: /Localidades/

        public ViewResult Index()
        {
            return View(db.Localidades.ToList());
        }

        //
        // GET: /Localidades/Details/5

        public ViewResult Details(int id)
        {
            localidad localidad = db.Localidades.Find(id);
            return View(localidad);
        }

        //
        // GET: /Localidades/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Localidades/Create

        [HttpPost]
        public ActionResult Create(localidad localidad)
        {
            if (ModelState.IsValid)
            {
                db.Localidades.Add(localidad);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(localidad);
        }
        
        //
        // GET: /Localidades/Edit/5
 
        public ActionResult Edit(int id)
        {
            localidad localidad = db.Localidades.Find(id);
            return View(localidad);
        }

        //
        // POST: /Localidades/Edit/5

        [HttpPost]
        public ActionResult Edit(localidad localidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localidad);
        }

        //
        // GET: /Localidades/Delete/5
 
        public ActionResult Delete(int id)
        {
            localidad localidad = db.Localidades.Find(id);
            return View(localidad);
        }

        //
        // POST: /Localidades/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            localidad localidad = db.Localidades.Find(id);
            db.Localidades.Remove(localidad);
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