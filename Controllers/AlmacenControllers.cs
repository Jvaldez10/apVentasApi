
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Modulos;

namespace sistema_venta_erp.Controllers
{
    [ApiController]
    [Route("api/almacen")]
    public class AlmacenControllers : ControllerBase
    {
        private readonly ILogger<ProveedoresControllers> _logger;
        private readonly AlmacenModulo _almacenModulo;

        public AlmacenControllers(
           ILogger<ProveedoresControllers> logger,
           AlmacenModulo almacenModulo
        )
        {
            this._logger = logger;
            this._almacenModulo = almacenModulo;
        }
        [HttpGet]
        public async Task<Response> ObtenerTodo()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerTodo() Inizialize ...");
            try
            {
                var proveedoresLista = await this._almacenModulo.ObtenerTodo();
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo los almacenes",
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
        [HttpGet("{id}")]
        public async Task<Response> ObtenerUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} OBtenerUno({id}) Inizialize ...");
            try
            {
                var proveedor = await this._almacenModulo.ObtenerUno(id);
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo almacen",
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
                this._logger.LogError($"ObtenerUno() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        
        [HttpPost]
        public async Task<Response> InsertarUno([FromBody] AlmacenDto almacenDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} InsertarUno({JsonConvert.SerializeObject(almacenDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var insertar = await this._almacenModulo.InsertarUno(almacenDto);
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
        public async Task<Response> ModificarUno(int id, [FromBody] AlmacenDto almacenDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ModificarUno({JsonConvert.SerializeObject(almacenDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var modificar = await this._almacenModulo.ModificarUno(id,
                    almacenDto
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
                var eliminar = await this._almacenModulo.EliminarUno(id);
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