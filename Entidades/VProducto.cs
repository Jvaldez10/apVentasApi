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
        public string codigoBarra { get; set; }
        public string nombreProducto { get; set; }
        public string unidadMedida { get; set; }
        public int stockMinimo { get; set; }
        public decimal precioCompra { get; set; }
        public decimal utilidadMin { get; set; }
        public decimal precioVentaMin { get; set; }
        public decimal utilidadMax { get; set; }
        public decimal precioVentaMax { get; set; }
        public int VProveedoreId { get; set; }
        public int VClasificacionId { get; set; }
    }
}