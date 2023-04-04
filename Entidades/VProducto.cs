using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class VProducto
    {
        [Key]
        public int id { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string lote { get; set; }
        public int stockInicial { get; set; }
        public decimal precioCompra { get; set; }
        public decimal precioVenta { get; set; }
        public int VAlmacenId { get; set; }
        public int VCategoriaId { get; set; }
        public int VProveedoreId { get; set; }
        public int VUnidadMedidaId { get; set; }
        public int VUtilidadId { get; set; }
    }
}