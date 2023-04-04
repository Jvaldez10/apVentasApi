using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class VAlmacen
    {
        [Key]
        public int id { get; set; }
        public string codigoAlmacen { get; set; }
        public string dirrecion { get; set; }
        public string nombreAlmacen { get; set; }
    }

}