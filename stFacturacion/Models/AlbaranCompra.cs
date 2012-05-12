using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace stFacturacion.Models
{

    public class AlbaranCompra
    {
            public int albaranCompraId { get; set; }

            [DisplayName("Fecha"),Required]
            public DateTime albaranDate { get; set; }

            [DisplayName("Proveedor"),Required]
            public int proveedorId { get; set; }

            public virtual Proveedor proveedor {get; set;}

            public virtual ICollection<AlbaranCompraDetalle> albarancompradetalle { get; set; }
        
    }
}