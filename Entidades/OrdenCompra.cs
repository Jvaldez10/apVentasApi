using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class OrdenCompra
    {
        [Key]
        public int id { get; set; }
        public string codigoOrden { get; set; }
        public string descripcion { get; set; }
        public int VProveedoreId { get; set; }
        public string totalLiteral { get; set; }
        public decimal total { get; set; }
        public DateTime fechaCreacion { get; set; }
        public int usuarioId { get; set; }
        public string nit { get; set; }
        public string telefono { get; set; }
        public int asientoId { get; set; }
        public int estadoId { get; set; }
    }
}