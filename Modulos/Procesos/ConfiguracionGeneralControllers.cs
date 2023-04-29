using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sistema_venta_erp.Modulos.Procesos
{
    [ApiController]
    [Route("api/configuracion-general")]
    public class ConfiguracionGeneralControllers : ControllerBase
    {
        private readonly ILogger<ConfiguracionGeneralControllers> _logger;

        public ConfiguracionGeneralControllers(
            ILogger<ConfiguracionGeneralControllers> logger
        )
        {
            this._logger = logger;
        }
      
    }
}