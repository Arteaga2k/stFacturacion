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
    public class ClientesController : Controller
    {
        private FacturacionDBContext db = new FacturacionDBContext();

        //
        // GET: /Clientes/

        public ViewResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Localidad).Include(c => c.formaPago);
            return View(clientes.ToList());
        }

        //
        // GET: /Clientes/Details/5

        public ViewResult Details(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            return View(cliente);
        }

        //
        // GET: /Clientes/Create

        public ActionResult Create()
        {
            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre");
            ViewBag.formaPagoid = new SelectList(db.FormaPago, "formaPagoid", "descripcionformapago");
            return View();
        } 

        //
        // POST: /Clientes/Create

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre", cliente.localidadId);
            ViewBag.formaPagoid = new SelectList(db.FormaPago, "formaPagoid", "descripcionformapago", cliente.formaPagoid);
            return View(cliente);
        }
        
        //
        // GET: /Clientes/Edit/5
 
        public ActionResult Edit(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre", cliente.localidadId);
            ViewBag.formaPagoid = new SelectList(db.FormaPago, "formaPagoid", "descripcionformapago", cliente.formaPagoid);
            return View(cliente);
        }

        //
        // POST: /Clientes/Edit/5

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.localidadId = new SelectList(db.Localidades, "localidadId", "nombre", cliente.localidadId);
            ViewBag.formaPagoid = new SelectList(db.FormaPago, "formaPagoid", "descripcionformapago", cliente.formaPagoid);
            return View(cliente);
        }

        //
        // GET: /Clientes/Delete/5
 
        public ActionResult Delete(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            return View(cliente);
        }

        //
        // POST: /Clientes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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