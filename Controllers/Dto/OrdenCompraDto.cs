using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class OrdenCompraDto
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public string codigoOrden { get; set; }
        public int VProveedoreId { get; set; }
        public string nombreProveedor { get; set; }
        public string montoliteral { get; set; }
        public decimal total { get; set; }
        public int asientoId { get; set; }
        public string usuario { get; set; }
        public string nit { get; set; }
        public string nombreAsiento { get; set; }
        public string telefono { get; set; }
        public List<OrdenCompraProductoDto> productos { get; set; }
    }
    public class OrdenCompraProductoDto
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public decimal precioCompra { get; set; }
        public decimal precioTotal { get; set; }
    }
}