using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class AsientoPlanCuenta
    {
        [Key]
        public int id { get; set; }
        public int VPlanCuentaId { get; set; }
        public int asientoId { get; set; }
        public string rol { get; set; }
    }
}