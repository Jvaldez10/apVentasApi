using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class VCategoria
    {
        [Key]
        public int id { get; set; }
        public string nombreCategoria { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }

    }
}