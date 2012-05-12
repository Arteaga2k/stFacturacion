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
    public class VendedorController : Controller
    {
        private FacturacionDBContext db = new FacturacionDBContext();

        //
        // GET: /Vendedor/

        public ViewResult Index()
        {
            var vendedor = db.Vendedor.Include(v => v.localidad);
            return View(vendedor.ToList());
        }

        //
        // GET: /Vendedor/Details/5

        public ViewResult Details(int id)
        {
            Vendedor vendedor = db.Vendedor.Find(id);
            return View(vendedor);
        }

        //
        // GET: /Vendedor/Create

        public ActionResult Create()
        {
            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre");
            return View();
        } 

        //
        // POST: /Vendedor/Create

        [HttpPost]
        public ActionResult Create(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                db.Vendedor.Add(vendedor);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre", vendedor.localidadId);
            return View(vendedor);
        }
        
        //
        // GET: /Vendedor/Edit/5
 
        public ActionResult Edit(int id)
        {
            Vendedor vendedor = db.Vendedor.Find(id);
            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre", vendedor.localidadId);
            return View(vendedor);
        }

        //
        // POST: /Vendedor/Edit/5

        [HttpPost]
        public ActionResult Edit(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre", vendedor.localidadId);
            return View(vendedor);
        }

        //
        // GET: /Vendedor/Delete/5
 
        public ActionResult Delete(int id)
        {
            Vendedor vendedor = db.Vendedor.Find(id);
            return View(vendedor);
        }

        //
        // POST: /Vendedor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Vendedor vendedor = db.Vendedor.Find(id);
            db.Vendedor.Remove(vendedor);
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