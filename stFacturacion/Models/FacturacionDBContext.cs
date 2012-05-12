using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace stFacturacion.Models
{
    public class FacturacionDBContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<localidad> Localidades { get; set; }
        public DbSet<FormaPago> FormaPago { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<TipoIva> TipoIva { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public DbSet<Tarifa> Tarifa { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Fecha> Fecha { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Vendedor> Vendedor { get; set; }

        public DbSet<AlbaranCompra> AlbaranCompra { get; set; }
        public DbSet<AlbaranCompraDetalle> AlbaranCompraDetalle { get; set; }
        
       


    }
}