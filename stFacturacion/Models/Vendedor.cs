using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace stFacturacion.Models
{
    public class Vendedor
    {
        public int vendedorId { get; set; }
        [DisplayName("Nombre"),Required(ErrorMessage="El nombre es obligatorio")]
        public string nombre { get; set; }
        [DisplayName("Dirección"), Required(ErrorMessage = "La dirección es obligatorio")]
        public string direccion { get; set; }
        [DisplayName("Código Postal"), Required(ErrorMessage = "El código postal es obligatorio")]
        public int cp { get; set; }
        [DisplayName("Ciudad"), Required(ErrorMessage = "La ciudad es obligatorio")]
        public string ciudad { get; set; }
        [DisplayName("País"), Required(ErrorMessage = "El país es obligatorio")]
        public string pais { get; set; }
        [DisplayName("Localidad"), Required(ErrorMessage = "La localidad es requerida")]
        public int localidadId { get; set; }
        [DisplayName("Teléfono")]
        public int tlf { get; set; }
        [DisplayName("Móvil")]
        public int movil { get; set; }
        [DisplayName("Web")]
        public string web { get; set; }
        [DisplayName("Fax")]
        public int fax { get; set; }
        [DisplayName("E-mail"), Required(ErrorMessage = "Introduce un email válido"),
        RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email no válido")]
        public string email { get; set; }
        [DisplayName("Comisión")]
        public decimal comision { get; set; }


        public virtual localidad localidad { get; set; }

    }
}