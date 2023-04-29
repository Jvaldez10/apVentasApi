using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class OrdenCompraDto
    {
        public int id { get; set; }
        public int precioTotal { get; set; }
        public int tipoAsientoId { get; set; }
    }
}