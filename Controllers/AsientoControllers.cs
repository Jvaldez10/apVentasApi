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
    [Route("api/asiento")]
    public class AsientoControllers : ControllerBase
    {
        private readonly ILogger<AsientoControllers> _logger;
        private readonly AsientoModule _asientoModule;

        public AsientoControllers(
            ILogger<AsientoControllers> logger,
            AsientoModule asientoModule
        )
        {
            this._logger = logger;
            this._asientoModule = asientoModule;
        }
        [HttpGet]
        public async Task<Response> ObtenerTodo()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerTodo() Inizialize ...");
            try
            {
                var asientos = await this._asientoModule.ObtenerTodoAsiento();
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
       /*  [HttpGet("{id}")]
        public async Task<Response> ObtenerUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerUno({id}) Inizialize ...");
            try
            {
                var clasificacion = await this._clasificacionModule.ObtenerUno(id);
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo proveedor",
                    data = clasificacion
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
        [HttpGet("clasificacion-padre/{id}")]
        public async Task<Response> ObtenerUnoPadreId(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerUnoPadreId({id}) Inizialize ...");
            try
            {
                var clasificacion = await this._clasificacionModule.ObtenerUnoPadreId(id);
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo clasificacion Padre id",
                    data = clasificacion
                };
                this._logger.LogWarning($"ObtenerUnoPadreId() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"ObtenerUnoPadreId() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        } */
        [HttpGet("create")]
        public async Task<Response> CrearUno()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerUno() Inizialize ...");
            try
            {
                var create = await this._asientoModule.CreateAsiento();
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo proveedor",
                    data = create
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
                this._logger.LogError($"ObtenerUno() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPost]
        public async Task<Response> InsertarUno([FromBody] AsientoDto asientoDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} InsertarUno({JsonConvert.SerializeObject(asientoDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var insertar = await this._asientoModule.StoreAsiento(asientoDto);
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
                    message = e.Message,
                    data = null
                };
                this._logger.LogError($"InsertarUno() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        /* [HttpGet("editar/{id}")]
        public async Task<Response> EditarUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} EditarUno({id}) Inizialize ...");
            try
            {
                var obtenerUno = await this._clasificacionModule.EditarUno(id);
                var resultado = new Response
                {
                    status = 1,
                    message = "Editar",
                    data = obtenerUno
                };
                this._logger.LogWarning($"EditarUno() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"EditarUno() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPut("{id}")]
        public async Task<Response> ModificarUno(int id, [FromBody] ClasificacionDto ClasificacionDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ModificarUno({JsonConvert.SerializeObject(ClasificacionDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var modificar = await this._clasificacionModule.ModificarUno(id,
                    ClasificacionDto
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
                var eliminar = await this._clasificacionModule.EliminarUno(id);
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
        } */ 
    }
}