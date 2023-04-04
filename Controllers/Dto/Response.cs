using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Controllers.Dto
{
    public class Response
    {
        public int status { get; set; }
        public string message { get; set; }
        public object data { get; set; } = null;
    }
}