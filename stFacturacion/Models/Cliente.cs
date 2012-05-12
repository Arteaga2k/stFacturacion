using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace stFacturacion.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; } 
        [DisplayName("Nombre"),Required(ErrorMessage="El nombre es requerido")]
        public string nombre { get; set; }
        [DisplayName("Dirección"),Required(ErrorMessage="La dirección es requerido")]
        public string direccion { get; set; }
        [DisplayName("Código Postal"),Required(ErrorMessage="El código postal es requerido")]
        public int cp { get; set; }
        [DisplayName("Ciudad"),Required(ErrorMessage="La ciudad es requeridad")]
        public string ciudad { get; set; }
        [DisplayName("País"),Required(ErrorMessage="El país es requerido")]
        public string pais { get; set; } 
        [DisplayName("Localidad"),Required(ErrorMessage="La localidad es requerida")]
        public int localidadId { get; set; } 
        [DisplayName("NIF"),Required(ErrorMessage="El nif es obligatorio")]
        public string nif { get; set; }
        [DisplayName("Teléfono")]
        public int tlf { get; set; }
        [DisplayName("Móvil")]
        public int tlfmov { get; set; }
        [DisplayName("Fax")]
        public int fax { get; set; }
        [DisplayName("Web")]
        public string web { get; set; }
        [DisplayName("E-mail"), Required(ErrorMessage = "Introduce un email válido"),      
        RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage="Email no válido")]
        public string email { get; set; }
        public string contacto { get; set; }
        [DisplayName("Facturar sin IVA")]
        public bool Iva { get; set; }
        [DisplayName("Aplicar RE(recargo de equivalencia)")]
        public bool Recargo {get; set;}
        [DisplayName("Forma de Pago"), Required(ErrorMessage = "La forma de pago es requerida")]
        public int formaPagoid { get; set; }
      
       

        public virtual localidad Localidad { get; set; }
        public virtual FormaPago formaPago { get; set; }

    }

   
}