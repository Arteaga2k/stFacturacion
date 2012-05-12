using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace stFacturacion.Models
{
    public class Color
    {
        public int colorId { get; set; }
        [DisplayName("Descripción"), Required(ErrorMessage = "La descripción es requerida")]
        public string descripcioncolor { get; set; }

        public List<Articulo> Articulos { get; set; }

        public ICollection<AlbaranCompraDetalle> albarancompradetalle { get; set; }
    }
}