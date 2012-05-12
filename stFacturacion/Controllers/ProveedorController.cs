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
    public class ProveedorController : Controller
    {
        private FacturacionDBContext db = new FacturacionDBContext();

        //
        // GET: /Proveedor/

        public ViewResult Index()
        {
            var proveedores = db.Proveedores.Include(p => p.localidad).Include(p => p.formapago);
            return View(proveedores.ToList());
        }

        //
        // GET: /Proveedor/Details/5

        public ViewResult Details(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            return View(proveedor);
        }

        //
        // GET: /Proveedor/Create

        public ActionResult Create()
        {
            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre");
            ViewBag.formaPagoid = new SelectList(db.FormaPago, "formaPagoid", "descripcionformapago");
            return View();
        } 

        //
        // POST: /Proveedor/Create

        [HttpPost]
        public ActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Proveedores.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre", proveedor.localidadId);
            ViewBag.formaPagoid = new SelectList(db.FormaPago, "formaPagoid", "descripcionformapago", proveedor.formaPagoid);
            return View(proveedor);
        }
        
        //
        // GET: /Proveedor/Edit/5
 
        public ActionResult Edit(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre", proveedor.localidadId);
            ViewBag.formaPagoid = new SelectList(db.FormaPago, "formaPagoid", "descripcionformapago", proveedor.formaPagoid);
            return View(proveedor);
        }

        //
        // POST: /Proveedor/Edit/5

        [HttpPost]
        public ActionResult Edit(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre", proveedor.localidadId);
            ViewBag.formaPagoid = new SelectList(db.FormaPago, "formaPagoid", "descripcionformapago", proveedor.formaPagoid);
            return View(proveedor);
        }

        //
        // GET: /Proveedor/Delete/5
 
        public ActionResult Delete(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            return View(proveedor);
        }

        //
        // POST: /Proveedor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Proveedor proveedor = db.Proveedores.Find(id);
            db.Proveedores.Remove(proveedor);
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