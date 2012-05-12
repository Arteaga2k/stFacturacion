using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace stFacturacion.Models
{
    public class AlbaranCompraDetalle
    {
        [Key]
        public int albaranCompraId { get; set; }

        public int codarticulo { get; set; }
        public int codbarra { get; set; }
        public int colorId { get; set; }
        public int tallaId { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }


        public virtual AlbaranCompra albarancompra { get; set; }
        public virtual Color color { get; set; }
        public Talla talla { get; set; }
        
    }
}