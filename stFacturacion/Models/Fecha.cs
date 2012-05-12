using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace stFacturacion.Models
{
    public class Fecha
    {
        public int fechaId { get; set; }

        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
    }
}