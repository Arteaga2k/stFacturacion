using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace stFacturacion.Models
{
    public class Articulo
    {
        public int articuloId { get; set; }
        [DisplayName("Descripción"),Required]
        public string descripcionarticulo { get; set; }
        [DisplayName("Talla"),Required]
        public int tallaId { get; set; }
        [DisplayName("Tarifa"),Required]
        public int tarifaId { get; set; }
        [DisplayName("Tipo de IVA"),Required]
        public int tipoivaId { get; set; }
        [DisplayName("Color")]
        public int colorId { get; set; }
        [DisplayName("Familia"),Required]
        public int familiaId { get; set; }
        [DisplayName("Forma de pago"),Required]
        public int formaPagoid { get; set; }

        public virtual Talla talla { get; set; }
        public virtual Tarifa tarifa { get; set; }
        public virtual TipoIva tipoiva { get; set; }
        public virtual Color color { get; set; }
        public virtual Familia familia { get; set; }
        public virtual FormaPago formapago { get; set; }

        /*public ICollection<AlbaranCompraDetalle> albarancompradetalle { get; set; }*/

    }
}