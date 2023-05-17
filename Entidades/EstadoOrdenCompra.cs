using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class EstadoOrdenCompra
    {
        [Key]
        public int id { get; set; }
        public string nombreEstadoOrdenCompra { get; set; }
    }
}