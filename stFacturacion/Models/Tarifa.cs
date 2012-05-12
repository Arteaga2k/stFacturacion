using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stFacturacion.Models
{
    public class Tarifa
    {
        public int tarifaId { get; set; }
        public string descripcion { get; set; }
        public decimal porcentaje { get; set; }

        public List<Articulo> Articulos { get; set; }
    }
}