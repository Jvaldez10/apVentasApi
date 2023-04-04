using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class ProveedorDto
    {
        public int id { get; set; }
        public string codigoProveedor { get; set; }
        public string nombreProveedor { get; set; }
        public string dirrecion { get; set; }
        public string credito { get; set; }
        public string telefono { get; set; }
    }
}