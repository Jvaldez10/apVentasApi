using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class AsientoPlanCuentaDto
    {
        public int id { get; set; }
        public int VPlanCuentaId { get; set; }
        public int asientoId { get; set; }
        public string rol { get; set; }
    }
}