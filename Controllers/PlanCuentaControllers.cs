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
    [Route("api/plan-cuenta")]
    public class PlanCuentaControllers : ControllerBase
    {
        private readonly ILogger<PlanCuentaControllers> _logger;
        private readonly PlanCuentaModulo _planCuentaModulo;

        public PlanCuentaControllers(
            ILogger<PlanCuentaControllers> logger,
            PlanCuentaModulo planCuentaModulo
        )
        {
            this._logger = logger;
            this._planCuentaModulo = planCuentaModulo;
        }
        [HttpGet]
        public async Task<Response> ObtenerTodo()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerTodo() Inizialize ...");
            try
            {
                var proveedoresLista = await this._planCuentaModulo.ObtenerTodo();
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo los proveedores",
                    data = proveedoresLista
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
        [HttpGet("create")]
        public async Task<Response> CreateUno([FromQuery] int nivel, int padre)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} CreateUno({nivel},{padre}) Inizialize ...");
            try
            {
                var codigo = await this._planCuentaModulo.CreateUno(nivel, padre);
                var resultado = new Response
                {
                    status = 1,
                    message = "Create nivel",
                    data = codigo
                };
                this._logger.LogWarning($"CreateUno() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"CreateUno() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpGet("{id}")]
        public async Task<Response> ObtenerUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerUno({id}) Inizialize ...");
            try
            {
                var proveedor = await this._planCuentaModulo.ObtenerUno(id);
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo proveedor",
                    data = proveedor
                };
                this._logger.LogWarning($"ObtenerUno() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"OBtenerUno() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpGet("editar/{id}")]
        public async Task<Response> EditarUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerUno({id}) Inizialize ...");
            try
            {
                var proveedor = await this._planCuentaModulo.ObtenerUno(id);
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo proveedor",
                    data = proveedor
                };
                this._logger.LogWarning($"ObtenerUno() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"OBtenerUno() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPost]
        public async Task<Response> InsertarUno([FromBody] planCuentaDto planCuentaDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} InsertarUno({JsonConvert.SerializeObject(planCuentaDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var insertar = await this._planCuentaModulo.InsertarUno(planCuentaDto);
                var resultado = new Response
                {
                    status = 1,
                    message = insertar,
                    data = null
                };
                this._logger.LogWarning($"InsertarUno() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"InsertarUno() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPut("{id}")]
        public async Task<Response> ModificarUno(int id, [FromBody] planCuentaDto planCuentaDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ModificarUno({JsonConvert.SerializeObject(planCuentaDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var modificar = await this._planCuentaModulo.ModificarUno(id,
                    planCuentaDto
                );
                var resultado = new Response
                {
                    status = 1,
                    message = modificar,
                    data = null
                };
                this._logger.LogWarning($"ModificarUno() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"ModificarUno() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpDelete("{id}")]
        public async Task<Response> EliminarUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} EliminarUno({id}) Inizialize ...");
            try
            {
                var eliminar = await this._planCuentaModulo.EliminarUno(id);
                var resultado = new Response
                {
                    status = 1,
                    message = eliminar,
                    data = null
                };
                this._logger.LogWarning($"EliminarUno() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"EliminarUno() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
    }
}