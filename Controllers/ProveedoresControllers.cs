using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Modulos;

namespace sistema_venta_erp.Controllers
{
    [ApiController]
    [Route("api/proveedor")]
    public class ProveedoresControllers : ControllerBase
    {
        private readonly ILogger<ProveedoresControllers> _logger;
        private readonly ProveedoresModulo _proveedoresModulo;

        public ProveedoresControllers(
           ILogger<ProveedoresControllers> logger,
           ProveedoresModulo proveedoresModulo
        )
        {
            this._logger = logger;
            this._proveedoresModulo = proveedoresModulo;
        }
        [HttpGet]
        public async Task<Response<List<VProveedor>>> ObtenerTodo()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerTodo() Inizialize ...");
            try
            {
                var proveedoresLista = await this._proveedoresModulo.ObtenerTodo();
                var resultado = new Response<List<VProveedor>>
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
                var result = new Response<List<VProveedor>>
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
        public async Task<Response<VProveedor>> ObtenerUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} OBtenerUno({id}) Inizialize ...");
            try
            {
                var proveedor = await this._proveedoresModulo.ObtenerUno(id);
                var resultado = new Response<VProveedor>
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
                var result = new Response<VProveedor>
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
        public async Task<Response<CreateProveedorDto>> CrearUno()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} OBtenerUno() Inizialize ...");
            try
            {
                var data = await this._proveedoresModulo.CrearUno();
                var resultado = new Response<CreateProveedorDto>
                {
                    status = 1,
                    message = "Proveedore nuevo",
                    data = data
                };
                this._logger.LogWarning($"ObtenerUno() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response<CreateProveedorDto>
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
        public async Task<Response<string>> InsertarUno([FromBody] ProveedorDto proveedorDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} InsertarUno({JsonConvert.SerializeObject(proveedorDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var insertar = await this._proveedoresModulo.InsertarUno(proveedorDto);
                var resultado = new Response<string>
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
                var result = new Response<string>
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
        public async Task<Response<EditarDto>> EditarUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} EditarUno({id}) Inizialize ...");
            try
            {
                var obtenerUno = await this._proveedoresModulo.EditarUno(id);
                var resultado = new Response<EditarDto>
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
                var result = new Response<EditarDto>
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
        public async Task<Response<string>> ModificarUno(int id, [FromBody] ProveedorDto proveedorDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ModificarUno({JsonConvert.SerializeObject(proveedorDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var modificar = await this._proveedoresModulo.ModificarUno(id,
                    proveedorDto
                );
                var resultado = new Response<string>
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
                var result = new Response<string>
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
        public async Task<Response<string>> EliminarUno(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} EliminarUno({id}) Inizialize ...");
            try
            {
                var eliminar = await this._proveedoresModulo.EliminarUno(id);
                var resultado = new Response<string>
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
                var result = new Response<string>
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