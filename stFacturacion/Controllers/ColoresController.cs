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
    public class ColoresController : Controller
    {
        private FacturacionDBContext db = new FacturacionDBContext();       

        [HttpGet]
        public ActionResult Create()
        {
            // Don't allow this method to be called directly.
            if (this.HttpContext.Request.IsAjaxRequest() != true)
                return RedirectToAction("Index", "Articulos");

            return PartialView("_CreateColor");
        }

        [HttpPost]
        public ActionResult Create(Color color)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    db.Color.Add(color);
                    db.SaveChanges();

                    var dbColor = db.Color.Where(g => g.descripcioncolor == color.descripcioncolor).SingleOrDefault();
                    return Json(new { Color = dbColor, Error = string.Empty });
                }
                else
                {
                    //TODO: better error messages
                    string errMsg = "Something failed, probably validation";
                    var er = ModelState.Values.FirstOrDefault();
                    if (er != null && er.Value != null && !String.IsNullOrEmpty(er.Value.AttemptedValue))
                        errMsg = "\"" + er.Value.AttemptedValue + "\" Does not validate";
                    // return Json(new { Error = ModelState.Values.FirstOrDefault() });
                    return Json(new { Error = errMsg });
                }
            }
            catch (InvalidOperationException ioex)
            {
                if (ioex.Message.Contains("Sequence contains more than one element"))
                    return Json(new { Error = "Value provided exists in DB, enter a unique value" });
#if DEBUG
                return Json(new { Error = ioex.Message });
#else
                return Json(new { Error = "Internal Error with input provided" });
#endif

            }
            catch (Exception ex)
            {
#if DEBUG
                return Json(new { Error = ex.Message });
#else
                return Json(new { Error = "Internal Error with input provided" });
#endif

            }
        }
    }
}