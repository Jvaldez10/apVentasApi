using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class Response<Tipo>
    {
        public int status { get; set; }
        public string message { get; set; }
        public Tipo data { get; set; } = default;
    }
}