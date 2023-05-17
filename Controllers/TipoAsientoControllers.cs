using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Modulos;

namespace sistema_venta_erp.Controllers
{
    [ApiController]
    [Route("api/tipo-asiento")]
    public class TipoAsientoControllers : ControllerBase
    {
        private readonly ILogger<TipoAsientoControllers> _logger;
        private readonly TipoAsientoModule _tipoAsientoModule;

        public TipoAsientoControllers(
            ILogger<TipoAsientoControllers> logger,
            TipoAsientoModule tipoAsientoModule
        )
        {
            this._logger = logger;
            this._tipoAsientoModule = tipoAsientoModule;
        }
        [HttpGet]
        public async Task<Response<List<TipoAsiento>>> ObtenerTodo()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerTodo() Inizialize ...");
            try
            {
                var tipoAsientos = await this._tipoAsientoModule.ObtenerTodo();
                var resultado = new Response<List<TipoAsiento>>
                {
                    status = 1,
                    message = "Todo los asientos",
                    data = tipoAsientos
                };
                this._logger.LogWarning($"ObtenerTodo() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response<List<TipoAsiento>>
                {
                    status = 0,
                    message = $"Ocurrio un error inesperado",
                    data = null
                };
                this._logger.LogError($"ObtenerTodo() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPost]
        public async Task<Response<bool?>> Store([FromBody] TipoAsientoDto tipoAsientoDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Store({JsonConvert.SerializeObject(tipoAsientoDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var tipoAsientos = await this._tipoAsientoModule.GuardarUno(tipoAsientoDto);
                var resultado = new Response<bool?>
                {
                    status = 1,
                    message = "Registrado correctamente",
                    data = tipoAsientos
                };
                this._logger.LogWarning($"Store() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response<bool?>
                {
                    status = 0,
                    message = $"Ocurrio un error inesperado",
                    data = null
                };
                this._logger.LogError($"Store() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpGet("editar/{id}")]
        public async Task<Response<TipoAsiento>> Editar(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Editar({id}) Inizialize ...");
            try
            {
                var tipoAsiento = await this._tipoAsientoModule.EditarUno(id);
                var resultado = new Response<TipoAsiento>
                {
                    status = 1,
                    message = "Mostrar Tipo Asiento",
                    data = tipoAsiento
                };
                this._logger.LogWarning($"Editar() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response<TipoAsiento>
                {
                    status = 0,
                    message = $"{e.Message}",
                    data = null
                };
                this._logger.LogError($"Editar() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPut("{id}")]
        public async Task<Response<bool?>> Update(int id, TipoAsientoDto tipoAsientoDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Update({JsonConvert.SerializeObject(tipoAsientoDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var tipoAsientos = await this._tipoAsientoModule.ModificarUno(id, tipoAsientoDto);
                var resultado = new Response<bool?>
                {
                    status = 1,
                    message = "Modificado correctamente",
                    data = null
                };
                this._logger.LogWarning($"Update() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response<bool?>
                {
                    status = 0,
                    message = $"Ocurrio un error inesperado",
                    data = null
                };
                this._logger.LogError($"Update() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpDelete("{id}")]
        public async Task<Response<List<TipoAsiento>>> Eliminar(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Eliminar({id}) Inizialize ...");
            try
            {
                var tipoAsientos = await this._tipoAsientoModule.ObtenerTodo();
                var resultado = new Response<List<TipoAsiento>>
                {
                    status = 1,
                    message = "Eliminado correctamente",
                    data = tipoAsientos
                };
                this._logger.LogWarning($"Eliminar() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response<List<TipoAsiento>>
                {
                    status = 0,
                    message = $"Ocurrio un error inesperado",
                    data = null
                };
                this._logger.LogError($"Eliminar() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
    }
}