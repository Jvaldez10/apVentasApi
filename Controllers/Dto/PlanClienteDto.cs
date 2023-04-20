using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class PlanClienteDto
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombreCuenta { get; set; }
        public string moneda { get; set; }
        public decimal valor { get; set; }
        public string codigoIdentificador { get; set; }
        public int nivel { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public int VPlanCuentaId { get; set; }
    }
}