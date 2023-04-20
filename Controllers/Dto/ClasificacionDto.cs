using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class ClasificacionDto
    {
        public int id { get; set; }
        public string nombreClasificacion { get; set; }
        public string caracteristicas { get; set; } = "";
        public int clasificacionId { get; set; }
    }
}