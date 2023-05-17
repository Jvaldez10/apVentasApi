using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class Movimiento
    {
        [Key]
        public int id { get; set; }
        public string nombreAsiento { get; set; }
        public int asientoId { get; set; }
        public DateTime fechaMovimiento { get; set; }
        public int tipoAsientoId { get; set; }
        public int VPlancuentaId { get; set; }
        public string nombrePlanCuenta { get; set; }
        public string descripcion { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
    }
}