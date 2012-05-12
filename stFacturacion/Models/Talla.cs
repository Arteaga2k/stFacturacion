using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace stFacturacion.Models
{
    public class Talla
    {
        public int tallaId { get; set; }
        [DisplayName("Descripción"), Required(ErrorMessage = "La descripción es requerida")]
        public int descripciontalla { get; set; }

        public List<Articulo> Articulos { get; set; }

        public ICollection<AlbaranCompraDetalle> albarancompradetalle { get; set; }
    }
}