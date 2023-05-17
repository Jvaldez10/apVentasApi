using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class EntradaAlmacenDto
    {
        public List<productosDto> productos { get; set; }
    }
    public class productosDto
    {
        public int productoId { get; set; }
        public string lote { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public int almacenId { get; set; }
        public int cantidad { get; set; }
        public string nombreProducto { get; set; }
        public decimal precioCompra { get; set; }
        public decimal precioTotal { get; set; }
    }
}