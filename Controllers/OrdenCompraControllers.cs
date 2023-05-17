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
        public async Task<Response> ObtenerTodo()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ObtenerTodo() Inizialize ...");
            try
            {
                var listaOrdenes = await this._ordenCompraModule.DataGrid();
                var resultado = new Response
                {
                    status = 1,
                    message = "Lista de ordenes",
                    data = listaOrdenes
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
        public async Task<Response> Create()
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} Create() Inizialize ...");
            try
            {
                var createOrden = await this._ordenCompraModule.CreateOrdenCompra();
                var resultado = new Response
                {
                    status = 1,
                    message = "apertura de orden",
                    data = createOrden
                };
                this._logger.LogWarning($"Create() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"Create() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPost]
        public async Task<Response> StoreOrdenCompra(OrdenCompraDto ordenCompraDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} nuevaOrdenCompra({JsonConvert.SerializeObject(ordenCompraDto, Formatting.Indented)}) Inizialize ...");
            try
            {
                var nuevaOrdenCompra = await this._ordenCompraModule.GuardarOrdenCompra(ordenCompraDto);
                var resultado = new Response
                {
                    status = 1,
                    message = "Registraso correctamente",
                    data = nuevaOrdenCompra
                };
                this._logger.LogWarning($"nuevaOrdenCompra() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"nuevaOrdenCompra() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpGet("preview-pago/{id}")]
        public async Task<Response> MostrarPago(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} MostrarPago({id}) Inizialize ...");
            try
            {
                var preview = await this._ordenCompraModule.PreviewProcesarPago(id);
                var resultado = new Response
                {
                    status = 1,
                    message = "Preview procesar pago",
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
        public async Task<Response> ProcesarPago(int id, ProcesarPagoDto procesarPagoDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} ProcesarPago({id},{procesarPagoDto.fecha}) Inizialize ...");
            try
            {
                var procesarPago = await this._ordenCompraModule.StoreprocesoPago(id, procesarPagoDto.fecha);
                var resultado = new Response
                {
                    status = 1,
                    message = "Pago procesado correctamente",
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
        [HttpGet("preview-recibir/{id}")]
        public async Task<Response> PreviewRecibir(int id)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} PreviewRecibir({id}) Inizialize ...");
            try
            {
                var preview = await this._ordenCompraModule.PreviewRecibirProducto(id);
                var resultado = new Response
                {
                    status = 1,
                    message = "Preview procesar pago",
                    data = preview
                };
                this._logger.LogWarning($"PreviewRecibir() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"PreviewRecibir() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
        [HttpPost("store-recibir/{id}")]
        public async Task<Response> EntradaAlmacen(int id, [FromBody] EntradaAlmacenDto entradaAlmacenDto)
        {
            this._logger.LogWarning($"{Request.Method}{Request.Path} EntradaAlmacen({id}) Inizialize ...");
            try
            {
                var storeEntradaAlmacen = await this._ordenCompraModule.EntradaAlmacenStore(entradaAlmacenDto, id);
                var resultado = new Response
                {
                    status = 1,
                    message = "Productos registrados correctamente",
                    data = storeEntradaAlmacen
                };
                this._logger.LogWarning($"EntradaAlmacen() SUCCESS=> {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
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
                this._logger.LogError($"EntradaAlmacen() ERROR=> {JsonConvert.SerializeObject(e, Formatting.Indented)}");
                return result;
            }
        }
    }
}