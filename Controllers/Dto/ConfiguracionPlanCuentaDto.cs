using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class ConfiguracionPlanCuentaDto
    {
        public int planCuentaIdCliente { get; set; }
        public string nombrePlanCuentaIdCliente { get; set; }
        public int planCuentaIdProveedor { get; set; }
        public string nombrePlanCuentaIdProveedor { get; set; }
        public int planCuentaIdProducto { get; set; }
        public string nombrePlanCuentaIdProducto { get; set; }
        public int planCuentaIdVendedor { get; set; }
        public string nombrePlanCuentaIdVendedor { get; set; }

    }
}