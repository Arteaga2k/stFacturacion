using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace stFacturacion.Models
{
    public class localidad
    {
        public int localidadId { get; set; }
        public string nombre { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Proveedor> Proveedor { get; set; }
        public ICollection<Vendedor> Vendedor { get; set; }
    }
        
}