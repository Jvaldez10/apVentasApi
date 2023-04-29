using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Modulos;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Controllers
{
    [ApiController]
    [Route("api/asiento-plan-cuenta")]
    public class AsientoPlanCuentaControllers : ControllerBase
    {
        private readonly ILogger<AsientoPlanCuentaControllers> _logger;
        private readonly TipoAsientoModule tipoAsientoModule;
        private readonly AsientoPlanCuentaModule _asientoPlanCuentaModule;

        public AsientoPlanCuentaControllers(
            ILogger<AsientoPlanCuentaControllers> logger,
            TipoAsientoModule tipoAsientoRespositorio,
            AsientoPlanCuentaModule asientoPlanCuentaModule
        )
        {
            this._logger = logger;
            this._asientoPlanCuentaModule = asientoPlanCuentaModule;
        }
        [HttpGet]
        public async Task<Response> ObtenerTodo([FromQuery] int tipoAsientoId)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerTodo() Inizialize ...");
            try
            {
                var asientos = await this._asientoPlanCuentaModule.ObtenerTodoAsientoPlanCuenta(tipoAsientoId);
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo los asientos",
                    data = asientos
                };
                this._logger.LogWarning($"ObtenerTodo() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response
                {
                    status = 0,
                    message = $"Ocurrio un error inesperado",
                    data = null
                };
                this._logger.LogError($"ObtenerTodo() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
    }
}