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
    [Route("api/producto")]
    public class ProductoControllers : ControllerBase
    {
        private readonly ILogger<ProductoControllers> _logger;
        private readonly ProductoModule _productoModule;

        public ProductoControllers(
            ILogger<ProductoControllers> logger,
            ProductoModule productoModule

        )
        {
            this._logger = logger;
            this._productoModule = productoModule;
        }
        [HttpGet]
        public async Task<Response<object>> ObtenerTodo()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerTodo() Inizialize ...");
            try
            {
                var clientes = await this._productoModule.ObtenerTodo();
                var resultado = new Response<object>
                {
                    status = 1,
                    message = "Todo los productos",
                    data = clientes
                };
                this._logger.LogWarning($"ObtenerTodo() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response<object>
                {
                    status = 0,
                    message = $"Ocurrio un error inesperado",
                    data = null
                };
                this._logger.LogError($"ListaProveedores() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpGet("create")]
        public async Task<Response<object>> Create()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Create() Inizialize ...");
            try
            {
                var clientes = await this._productoModule.Create();
                var resultado = new Response<object>
                {
                    status = 1,
                    message = "crear un producto",
                    data = clientes
                };
                this._logger.LogWarning($"Create() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response<object>
                {
                    status = 0,
                    message = $"Ocurrio un error inesperado",
                    data = null
                };
                this._logger.LogError($"ListaProveedores() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPost]
        public async Task<Response<string>> Insert(ProductoDto productoDto)
        {

            this._logger.LogWarning($"{Request.Method}{Request.Path} Insert({JsonConvert.SerializeObject(productoDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var clientes = await this._productoModule.Insert(productoDto);
                var resultado = new Response<string>
                {
                    status = 1,
                    message = "Producto creado correctamente",
                    data = clientes
                };
                this._logger.LogWarning($"Insert() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"ListaProveedores() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpGet("editar/{id}")]
        public async Task<Response<object>> Editar(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Editar() Inizialize ...");
            try
            {
                var clientes = await this._productoModule.Editar(id);
                var resultado = new Response<object>
                {
                    status = 1,
                    message = "crear un producto",
                    data = clientes
                };
                this._logger.LogWarning($"Create() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response<object>
                {
                    status = 0,
                    message = $"Ocurrio un error inesperado",
                    data = null
                };
                this._logger.LogError($"ListaProveedores() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPut("update/{id}")]
        public async Task<Response<string>> Update(int id, [FromBody] ProductoDto productoDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Update({id}) Inizialize ...");
            try
            {
                var clientes = await this._productoModule.Update(id,productoDto);
                var resultado = new Response<string>
                {
                    status = 1,
                    message = "Producto modificado correctamente",
                    data = clientes
                };
                this._logger.LogWarning($"Update() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"Update() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
    }
}