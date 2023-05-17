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
    [Route("api/venta")]
    public class VentaControllers : ControllerBase
    {
        private readonly ILogger<VentaControllers> _logger;
        private readonly VentaModule _ventaModule;

        public VentaControllers(
            ILogger<VentaControllers> logger,
            VentaModule ventaModule
        )
        {
            this._logger = logger;
            this._ventaModule = ventaModule;
        }
        [HttpGet]
        public async Task<Response> Lista()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Lista() Inizialize ...");
            try
            {
                var listaVenta = await this._ventaModule.ListaVenta();
                var resultado = new Response
                {
                    status = 1,
                    message = "Lista de ventas",
                    data = listaVenta
                };
                this._logger.LogWarning($"Lista() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"Lista() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpGet("create")]
        public async Task<Response> Create()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Create() Inizialize ...");
            try
            {
                var createVenta = await this._ventaModule.CreateVenta();
                var resultado = new Response
                {
                    status = 1,
                    message = "Crear cliente",
                    data = createVenta
                };
                this._logger.LogWarning($"Create() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
                return resultado;
            }
            catch (System.Exception e)
            {
                var result = new Response
                {
                    status = 0,
                    message = $"Ocurrio un error",
                    data = null
                };
                this._logger.LogError($"Create() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPost("store")]
        public async Task<Response> Store([FromBody] ventaDto ventaDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Lista({JsonConvert.SerializeObject(ventaDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var createVenta = await this._ventaModule.StoreVenta(ventaDto);
                var resultado = new Response
                {
                    status = 1,
                    message = "Creado correctamente",
                    data = createVenta
                };
                this._logger.LogWarning($"Lista() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"Lista() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpGet("preview-pago/{id}")]
        public async Task<Response> MostrarPago(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} MostrarPago({id}) Inizialize ...");
            try
            {
                var preview = await this._ventaModule.PreviewPagoVenta(id);
                var resultado = new Response
                {
                    status = 1,
                    message = "Preview pago Venta",
                    data = preview
                };
                this._logger.LogWarning($"MostrarPago() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"MostrarPago() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPost("procesar-pago/{id}")]
        public async Task<Response> ProcesarPago(int id, [FromBody] ProcesarPagoDto procesarPagoDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ProcesarPago({id},{procesarPagoDto.fecha}) Inizialize ...");
            try
            {
                var procesarPago = await this._ventaModule.StoreprocesoPagoVenta(id, procesarPagoDto.fecha);
                var resultado = new Response
                {
                    status = 1,
                    message = "Pago de venta procesado correctamente",
                    data = procesarPago
                };
                this._logger.LogWarning($"ProcesarPago() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"ProcesarPago() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
    }
}