using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class ClienteDto
    {
        public int id { get; set; }
        public string codigoCliente { get; set; }
        public string nombreCliente { get; set; }
        public string ci { get; set; }
        public string telefono { get; set; }
        public decimal lineaCredito { get; set; }
        public string correoElectronico { get; set; }
        public string dirrecion { get; set; }
        public int planCuentaId { get; set; }
        public int monedaId { get; set; }
    }
}