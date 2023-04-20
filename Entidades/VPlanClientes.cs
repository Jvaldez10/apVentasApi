using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class VPlanClientes
    {
        [Key]
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombreCuenta { get; set; }
        public int monedaId { get; set; }
        public decimal valor { get; set; }
        public string CodigoIdentificador { get; set; }
        public int nivel { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public int VPlanCuentaId { get; set; }

    }
}