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
    [Route("api/orden-compra")]
    public class OrdenCompraControllers : ControllerBase
    {
        private readonly ILogger<OrdenCompraControllers> _logger;
        private readonly OrdenCompraModule _ordenCompraModule;

        public OrdenCompraControllers(
            ILogger<OrdenCompraControllers> logger,
            OrdenCompraModule ordenCompraModule

            )
        {
            this._logger = logger;
            this._ordenCompraModule = ordenCompraModule;
        }
        [HttpGet]
        public string ObtenerTodo(string parameter)
        {
            return "";
        }
        [HttpPost]
        public async Task<Response> GuardarOrden(OrdenCompraDto ordenCompraDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Update({JsonConvert.SerializeObject(ordenCompraDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var guardarCompra = await this._ordenCompraModule.GuardarOrdenCompra(ordenCompraDto);
                var resultado = new Response
                {
                    status = 1,
                    message = guardarCompra,
                    data = null
                };
                this._logger.LogWarning($"Update() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"Update() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
    }
}