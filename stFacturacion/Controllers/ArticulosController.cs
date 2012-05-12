using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stFacturacion.Models;
using stFacturacion.ViewModels;

namespace stFacturacion.Controllers
{
    [Authorize]
    public class ArticulosController : Controller
    {
        private FacturacionDBContext db = new FacturacionDBContext();

        private void SetTallaTarifaIvaColorFamiliaPago(int? tallaId = null, int? tarifaId = null,
           int? tipoivaId = null, int? colorId = null, int? familiaId = null, int? formapagoId = null)
        {
            if (tallaId == null)
                ViewBag.tallas = new SelectList(db.Tallas, "tallaId", "descripciontalla");
            else
                ViewBag.tallas = new SelectList(db.Tallas.ToArray(), "tallaId", "descripciontalla", tallaId);

            if (tarifaId == null)
                ViewBag.tarifas = new SelectList(db.Tarifa, "tarifaId", "descripcion");
            else
                ViewBag.tarifas = new SelectList(db.Tarifa.ToArray(), "tarifaId", "descripcion", tarifaId);

            if (tipoivaId == null)
                ViewBag.tipoiva = new SelectList(db.TipoIva, "tipoivaId", "descripcion");
            else
                ViewBag.tipoiva = new SelectList(db.TipoIva.ToArray(), "tipoivaId", "descripcion", tipoivaId);

            if (colorId == null)
                ViewBag.colores = new SelectList(db.Color, "colorId", "descripcioncolor");
            else
                ViewBag.colores = new SelectList(db.Color.ToArray(), "colorId", "descripcioncolor", colorId);

            if (familiaId == null)
                ViewBag.familias = new SelectList(db.Familia, "familiaId", "descripcionfamilia");
            else
                ViewBag.familias = new SelectList(db.Familia.ToArray(), "familiaId", "descripcionfamilia", familiaId);

            if (formapagoId == null)
                ViewBag.formapagos = new SelectList(db.FormaPago, "formapagoId", "descripcionformapago");
            else
                ViewBag.formapagos = new SelectList(db.FormaPago.ToArray(), "formapagoId", "descripcionformapago", familiaId);


        }

        //
        // GET: /Articulos/

        public ViewResult Index()
        {
            var articulo = db.Articulo.Include(a => a.talla).Include(a => a.tarifa).Include(a => a.tipoiva).Include(a => a.color).Include(a => a.familia).Include(a => a.formapago);
            return View(articulo.ToList());
        }

        //
        // GET: /Articulos/Details/5

        public ViewResult Details(int id)
        {
            Articulo articulo = db.Articulo.Find(id);
            return View(articulo);
        }

        //
        // GET: /Articulos/Create

        public ActionResult Create()
        {
            SetTallaTarifaIvaColorFamiliaPago();
            return View();
        } 

        //
        // POST: /Articulos/Create

        [HttpPost]
        public ActionResult Create(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulo.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
        
            SetTallaTarifaIvaColorFamiliaPago(articulo.tallaId, articulo.tarifaId, articulo.tipoivaId,
                articulo.colorId,articulo.familiaId,articulo.formaPagoid);
            return View(articulo);
        }
        
        //
        // GET: /Articulos/Edit/5
 
        public ActionResult Edit(int id)
        {
            Articulo articulo = db.Articulo.Find(id);
            SetTallaTarifaIvaColorFamiliaPago(articulo.tallaId, articulo.tarifaId, articulo.tipoivaId,
                 articulo.colorId, articulo.familiaId, articulo.formaPagoid);
            return View(articulo);
        }

        //
        // POST: /Articulos/Edit/5

        [HttpPost]
        public ActionResult Edit(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tallaId = new SelectList(db.Tallas, "tallaId", "tallaId", articulo.tallaId);
            ViewBag.tarifaId = new SelectList(db.Tarifa, "tarifaId", "descripcion", articulo.tarifaId);
            ViewBag.tipoivaId = new SelectList(db.TipoIva, "tipoivaId", "descripcion", articulo.tipoivaId);
            ViewBag.colorId = new SelectList(db.Color, "colorId", "descripcioncolor", articulo.colorId);
            ViewBag.familiaId = new SelectList(db.Familia, "familiaId", "descripcionfamilia", articulo.familiaId);
            ViewBag.formaPagoid = new SelectList(db.FormaPago, "formaPagoid", "descripcionformapago", articulo.formaPagoid);
            return View(articulo);
        }

        //
        // GET: /Articulos/Delete/5 
        public ActionResult Delete(int id)
        {
            Articulo articulo = db.Articulo.Find(id);
            return View(articulo);
        }

        //
        // POST: /Articulos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Articulo articulo = db.Articulo.Find(id);
            db.Articulo.Remove(articulo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //
        // GET: /Articulos/EditVM/5

        public ActionResult EditVM(int id)
        {
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
                return HttpNotFound();

            ArticuloSelectListViewModel aslvm = new ArticuloSelectListViewModel(articulo, db.Tallas, db.Tarifa,
                db.TipoIva,db.Color,db.Familia,db.FormaPago);
            return View(aslvm);
        }
    }
}