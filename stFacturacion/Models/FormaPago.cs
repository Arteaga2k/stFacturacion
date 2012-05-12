using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace stFacturacion.Models
{
    public class FormaPago
    {
        public int formaPagoid { get; set; }
        [DisplayName("Forma de pago"), Required(ErrorMessage = "Eliga una forma de pago")]
        public string descripcionformapago { get; set; }

        public List<Cliente> Clientes { get; set; }
        public List<Proveedor> Proveedor { get; set; }

    }
}