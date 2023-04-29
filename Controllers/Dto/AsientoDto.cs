using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class AsientoDto
    {
        public int id { get; set; }
        public string nombreAsiento { get; set; }
        public int tipoAsientoId { get; set; }
        public string nombretipoAsiento { get; set; }
        public List<cuentas> cuentas { get; set; }
    }
    public class cuentas
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombreCuenta { get; set; }
        public int VPlanCuentaId { get; set; }
        public int asientoId { get; set; }
        public string rol { get; set; }
    }
}