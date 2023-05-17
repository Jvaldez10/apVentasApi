using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sistema_venta_erp.Controllers.Dto;

namespace sistema_venta_erp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioControllers : ControllerBase
    {
        private readonly ILogger<UsuarioControllers> _logger;

        public UsuarioControllers(
            ILogger<UsuarioControllers> logger
        )
        {
            this._logger = logger;
        }
         [HttpPost("Login")]
        public async Task<Response<string>> Login([FromBody] AutenticacionDto autenticacionDto)
        {
            return new Response<string>
            {
                data = "Hola mundo",
                message = "Hola mundo",
                status = 200
            };
        }
    }
}