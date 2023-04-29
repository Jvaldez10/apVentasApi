using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class TipoAsiento
    {
        [Key]
        public int id { get; set; }
        public string nombreTipoAsiento { get; set; }
    }
}