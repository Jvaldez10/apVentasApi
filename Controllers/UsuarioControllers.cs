using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Modulos;

namespace sistema_venta_erp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioControllers : ControllerBase
    {
        private readonly ILogger<UsuarioControllers> _logger;
        private readonly AutenticacionModulo _autenticacionModulo;

        public UsuarioControllers(
            ILogger<UsuarioControllers> logger,
            AutenticacionModulo autenticacionModulo
        )
        {
            this._logger = logger;
            _autenticacionModulo = autenticacionModulo;
        }
         [HttpPost("Login")]
        public async Task<Response<TokenDto>> Login([FromBody] AutenticacionDto autenticacionDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path}  Inizialize ...");
            try
            {
                var data = await _autenticacionModulo.Login(autenticacionDto.usuario, autenticacionDto.password);
                var resultado = new Response<TokenDto>
                {
                    data = data,
                    message = "Login correcto",
                    status = 200
                };
                this._logger.LogWarning($"Login() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response<TokenDto>
                {
                    status = 0,
                    message = $"Ocurrio un error inesperado",
                    data = null
                };
                this._logger.LogError($"Login() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
    }
}
           
