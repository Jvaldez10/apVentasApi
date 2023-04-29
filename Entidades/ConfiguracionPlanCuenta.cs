using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class ConfiguracionPlanCuenta
    {
        [Key]
        public int id { get; set; }
        public int cuentaClientes { get; set; }
        public int cuentaProveedores { get; set; }
        public int cuentaProducto { get; set; }
        public int cuentaVendedores { get; set; }
    }
}