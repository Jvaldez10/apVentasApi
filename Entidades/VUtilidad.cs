using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class VUtilidad
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; }
        public decimal utilidad { get; set; }
    }
}