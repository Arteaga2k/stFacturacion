using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace stFacturacion.Models
{
    public class Familia
    {
        public int familiaId { get; set; }
        [DisplayName("Familia"),Required(ErrorMessage="El tipo de familia es requerido")]
        public string descripcionfamilia { get; set; }

        public List<Articulo> Articulos { get; set; }


    }
}