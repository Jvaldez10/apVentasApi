using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class OrdenCompraProducto
    {
        [Key]
        public int id { get; set; }
        public int VProductoId { get; set; }
        public int cantidad { get; set; }
        public decimal precioCompra { get; set; }
        public decimal precioTotal { get; set; }
        public int ordenCompraId { get; set; }

    }
}