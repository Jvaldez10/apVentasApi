using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sistema_venta_erp.Entidades.Querys
{
    [Keyless]
    public class ObtenerTipoAsiento
    {
        public string codigo { get; set; }
        public string nombreCuenta { get; set; }
        public string rol { get; set; }
        public int planCuentaId { get; set; }
        public int id { get; set; }
    }
}