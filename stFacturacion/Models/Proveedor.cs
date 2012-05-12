using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace stFacturacion.Models
{
    public class Proveedor
    {
        public int proveedorId { get; set; }
        [DisplayName("Nombre"), Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }
        
        [DisplayName("NIF"), Required(ErrorMessage = "El nif es obligatorio")]
        public string nif { get; set; }
        [DisplayName("Localidad"), Required(ErrorMessage = "La localidad es requerida")]
        public int localidadId { get; set; } 
        [DisplayName("Provincia"), Required(ErrorMessage = "La provincia es obligatoria")]
        public string provincia { get; set; }
        [DisplayName("Código Postal"), Required(ErrorMessage = "El código postal es obligatorio")]
        public int cp { get; set; }
        [DisplayName("Teléfono"), Required(ErrorMessage = "El teléfono es obligatorio")]
        public int tlf { get; set; }
        [DisplayName("Móvil"), Required(ErrorMessage = "El teléfono móvil es obligatorio")]
        public int tlfmov { get; set; }
        public int fax { get; set; }
        public string contacto { get; set; }
        [DisplayName("Email"), Required(ErrorMessage = "El email es obligatorio")]
        public string email { get; set; }
        [DisplayName("Facturar sin IVA")]
        public bool Iva { get; set; }
        [DisplayName("Aplicar RE(recargo de equivalencia)")]
        public bool Recargo { get; set; }
        [DisplayName("Forma de Pago"), Required(ErrorMessage = "La forma de pago es requerida")]
        public int formaPagoid { get; set; }
        public int diapago { get; set; }
        [Required]
        public string banco { get; set; }
        [Required]
        public int ccc { get; set; }


        public virtual localidad localidad { get; set; }
        public virtual FormaPago formapago { get; set; }

       
    }
}