using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Modulos;

namespace sistema_venta_erp.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteControllers : ControllerBase
    {
        private readonly ILogger<ClienteControllers> _logger;
        private readonly ClienteModule _clienteModule;

        public ClienteControllers(
           ILogger<ClienteControllers> logger,
           ClienteModule clienteModule
        )
        {
            this._logger = logger;
            this._clienteModule = clienteModule;
        }
        [HttpGet]
        public async Task<Response> ObtenerTodo()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerTodo() Inizialize ...");
            try
            {
                var clientes = await this._clienteModule.ObtenerTodo();
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo los proveedores",
                    data = clientes
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
                this._logger.LogError($"ListaProveedores() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpGet("{id}")]
        public async Task<Response> ObtenerUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} OBtenerUno({id}) Inizialize ...");
            try
            {
                var proveedor = await this._clienteModule.ObtenerUno(id);
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
        [HttpGet("create")]
        public async Task<Response> CrearUno()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} OBtenerUno() Inizialize ...");
            try
            {
                var data = await this._clienteModule.CrearUno();
                var resultado = new Response
                {
                    status = 1,
                    message = "Todo proveedor",
                    data = data
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
        public async Task<Response> InsertarUno([FromBody] ClienteDto clienteDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} InsertarUno({JsonConvert.SerializeObject(clienteDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var insertar = await this._clienteModule.InsertarUno(clienteDto);
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
        [HttpGet("editar/{id}")]
        public async Task<Response> EditarUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} EditarUno({id}) Inizialize ...");
            try
            {
                var obtenerUno = await this._clienteModule.EditarUno(id);
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
        public async Task<Response> ModificarUno(int id, [FromBody] ClienteDto clienteDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ModificarUno({JsonConvert.SerializeObject(clienteDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var modificar = await this._clienteModule.ModificarUno(id,
                    clienteDto
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
                var eliminar = await this._clienteModule.EliminarUno(id);
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