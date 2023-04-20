using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class ProductoDto
    {
        public int id { get; set; }
        public string codigoProducto { get; set; }
        public string codigoBarra { get; set; }
        public string nombreProducto { get; set; }
        public string unidadMedida { get; set; }
        public int cantidad { get; set; }
        public int stockActual { get; set; }
        public int stockMinimo { get; set; }
        public decimal precioCompra { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public decimal utilidadMin { get; set; }
        public decimal precioVentaMin { get; set; }
        public decimal utilidadMax { get; set; }
        public decimal precioVentaMax { get; set; }
        public string lote { get; set; }
        public int proveedoreId { get; set; }
        public int clasificacionId { get; set; }
        public List<string> imagenes { get; set; }
    }
    
}