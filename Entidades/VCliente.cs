using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class VCliente
    {
        [Key]
        public int id { get; set; }
        public string ci { get; set; }
        public string codigoCliente { get; set; }
        public string nombreCompletoCliente { get; set; }
        public string correoElectronico { get; set; }
        public string dirrecion { get; set; }
        public string telefono { get; set; }
        public decimal credito { get; set; }
        public int PlanCuentaId { get; set; }
    }
}