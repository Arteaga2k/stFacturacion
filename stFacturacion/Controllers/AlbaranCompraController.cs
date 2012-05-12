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
    public class AlbaranCompraController : Controller
    {
        private FacturacionDBContext db = new FacturacionDBContext();

        // probando

        public ActionResult Prueba()
        {
            return View(new Prueba());
        } 

        //
        // GET: /AlbaranCompra/

        public ViewResult Index()
        {
            var albarancompra = db.AlbaranCompra.Include(a => a.proveedor);
            return View(albarancompra.ToList());
        }

        //
        // GET: /AlbaranCompra/Details/5

        public ViewResult Details(int id)
        {
            AlbaranCompra albarancompra = db.AlbaranCompra.Find(id);
            return View(albarancompra);
        }

        //
        // GET: /AlbaranCompra/Create

        public ActionResult Create()
        {
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "nombre");
            return View();
        }

        // POST: /Sales/Create
        /// <summary>
        /// This method is used for Creating and Updating  Sales Information 
        /// (Sales Contains: 1.SalesMain and *SalesSub )
        /// </summary>
        /// <param name="albarancompra">
        /// </param>
        /// <returns>
        /// Returns Json data Containing Success Status, New Sales ID and Exeception 
        /// </returns>
        [HttpPost]
        public JsonResult Create(AlbaranCompra albarancompra)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // If sales main has SalesID then we can understand we have existing sales Information
                    // So we need to Perform Update Operation

                    // Perform Update
                    if (albarancompra.albaranCompraId > 0)
                    {
                        var CurrentsAlbaraneSUb = db.AlbaranCompraDetalle.Where(p => p.albaranCompraId == albarancompra.albaranCompraId);

                        foreach (AlbaranCompraDetalle ss in CurrentsAlbaraneSUb)
                            db.AlbaranCompraDetalle.Remove(ss);

                        foreach (AlbaranCompraDetalle ss in albarancompra.albarancompradetalle)
                            db.AlbaranCompraDetalle.Add(ss);

                        db.Entry(albarancompra).State = EntityState.Modified;
                    }
                    //Perform Save
                    else
                    {
                        db.AlbaranCompra.Add(albarancompra);
                    }

                    db.SaveChanges();

                    // If Sucess== 1 then Save/Update Successfull else there it has Exception
                    return Json(new { Success = 1, albaranCompraId = albarancompra.albaranCompraId, ex = "" });
                }
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }
        
        //
        // GET: /AlbaranCompra/Edit/5
 
        public ActionResult Edit(int id)
        {
            AlbaranCompra albarancompra = db.AlbaranCompra.Find(id);
            ViewBag.proveedorId = new SelectList(db.Proveedores, "proveedorId", "nombre", albarancompra.proveedorId);

            //Call Create View            
            return View("Create", albarancompra);
        }
        

        //
        // GET: /AlbaranCompra/Delete/5
 
        public ActionResult Delete(int id)
        {
            AlbaranCompra albarancompra = db.AlbaranCompra.Find(id);
            return View(albarancompra);
        }

        //
        // POST: /AlbaranCompra/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            AlbaranCompra albarancompra = db.AlbaranCompra.Find(id);
            db.AlbaranCompra.Remove(albarancompra);
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