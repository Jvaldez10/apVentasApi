using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sistema_venta_erp.Controllers
{
    [ApiController]
    [Route("api/plan-cuenta-inicial")]
    public class PlandeCuentaInicialControllers : ControllerBase
    {
        private readonly ILogger<PlandeCuentaInicialControllers> logger;

        public PlandeCuentaInicialControllers(
            ILogger<PlandeCuentaInicialControllers> logger
        )
        {
            this.logger = logger;
        }
        
    }
}