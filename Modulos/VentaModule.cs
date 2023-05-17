using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class VentaModule
    {
        private readonly ILogger<VentaModule> _logger;
        private readonly VentaRespositorio _ventaRespositorio;
        private readonly VClienteRepositorio _vClienteRepositorio;
        private readonly EstadoVentaRepositorio _estadoVentaRepositorio;
        private readonly AsientoRespositorio _asientoRespositorio;
        private readonly VProductoRepositorio _vProductoRepositorio;
        private readonly VentaProductoRepositorio _ventaProductoRepositorio;
        private readonly AsientoPlanCuentaRespositorio _asientoPlanCuentaRespositorio;
        private readonly VPlanCuentasRepositorios _vPlanCuentasRepositorios;
        private readonly MovimientoRepositorio _movimientoRepositorio;
        private readonly SalidaAlmacenRepositorio _salidaAlmacenRepositorio;
        private readonly StockAlmacenModule _stockAlmacenModule;

        public VentaModule(
            ILogger<VentaModule> logger,
            VentaRespositorio ventaRespositorio,
            VClienteRepositorio vClienteRepositorio,
            EstadoVentaRepositorio estadoVentaRepositorio,
            AsientoRespositorio asientoRespositorio,
            VProductoRepositorio vProductoRepositorio,
            VentaProductoRepositorio ventaProductoRepositorio,
            AsientoPlanCuentaRespositorio asientoPlanCuentaRespositorio,
            VPlanCuentasRepositorios vPlanCuentasRepositorios,
            MovimientoRepositorio movimientoRepositorio,
            SalidaAlmacenRepositorio salidaAlmacenRepositorio,
            StockAlmacenModule stockAlmacenModule
        )
        {
            this._logger = logger;
            this._ventaRespositorio = ventaRespositorio;
            this._vClienteRepositorio = vClienteRepositorio;
            this._estadoVentaRepositorio = estadoVentaRepositorio;
            this._asientoRespositorio = asientoRespositorio;
            this._vProductoRepositorio = vProductoRepositorio;
            this._ventaProductoRepositorio = ventaProductoRepositorio;
            this._asientoPlanCuentaRespositorio = asientoPlanCuentaRespositorio;
            this._vPlanCuentasRepositorios = vPlanCuentasRepositorios;
            this._movimientoRepositorio = movimientoRepositorio;
            this._salidaAlmacenRepositorio = salidaAlmacenRepositorio;
            this._stockAlmacenModule = stockAlmacenModule;
        }
        public async Task<object> ListaVenta()
        {
            var listaVentas = await this._ventaRespositorio.ObtenerTodoVentaRepositorio();
            var resultado = new List<object>();
            foreach (var venta in listaVentas)
            {
                var cliente = await this._vClienteRepositorio.ObtenerUnoClientesRepositorio(venta.VClienteId);
                var estadoVenta = await this._estadoVentaRepositorio.ObtenerUnoEstadoVentaRepositorio(venta.estadoId);
                var asiento = await this._asientoRespositorio.ObtenerUnoAsientoRepositorio(venta.asientoId);
                resultado.Add(new
                {
                    id = venta.id,
                    codigoVenta = venta.codigoVenta,
                    fechaCreacion = venta.fechaCreacion.ToString("yyyy-MM-DD"),
                    nombreCompleto = $"{cliente.nombreCompletoCliente}",
                    nombreEstadoVenta = estadoVenta.nombreEstadoVenta,
                    nombreAsiento = asiento.nombreAsiento,
                    total = venta.total
                });
            }
            return resultado;
        }
        public async Task<object> CreateVenta()
        {
            var ultimaVenta = await this._ventaRespositorio.ObtenerUltimo();
            var codigo = $"vent001";
            if (ultimaVenta != null)
            {
                codigo = $"vent00{ultimaVenta.id + 1}";
            }
            var listaClientes = await this._vClienteRepositorio.ObtenerTodoClientesRepositorio();
            var listaProductos = await this._vProductoRepositorio.ObtenerTodoProductoRepositorio();
            var listaAsientos = await this._asientoRespositorio.ObtenerTodoAsientoRepositorio();
            var resultado = new
            {
                venta = new
                {
                    codigo = codigo,
                    usuario = "Stiven lovera"
                },
                clientes = listaClientes,
                productos = listaProductos,
                asientos = listaAsientos,
            };
            return resultado;
        }
        public async Task<object> StoreVenta(ventaDto ventaDto)
        {
            var insertVenta = await this._ventaRespositorio.InsertarVentaRepositorio(
                new Venta
                {
                    asientoId = ventaDto.asientoId,
                    codigoVenta = await this.ObtenerCodigoNuevo(),
                    descripcion = ventaDto.descripcion,
                    estadoId = 1,
                    fechaCreacion = ventaDto.fecha,
                    nit = ventaDto.nit,
                    telefono = ventaDto.telefono,
                    total = ventaDto.total,
                    totalLiteral = ventaDto.montoliteral,
                    usuarioId = 1,
                    VClienteId = ventaDto.VClienteId
                }
            );
            var insert = await this.StoreVentaProducto(ventaDto.productos, insertVenta.id);
            if (insert > 0)
            {
                return insertVenta.id;
            }
            else
            {
                throw new Exception("Ocurrio un error inesperado");
            }
        }
        private async Task<string> ObtenerCodigoNuevo()
        {
            var ultimaVenta = await this._ventaRespositorio.ObtenerUltimo();
            var codigo = $"vent001";
            if (ultimaVenta != null)
            {
                codigo = $"vent00{ultimaVenta.id + 1}";
            }
            return codigo;
        }
        private async Task<int> StoreVentaProducto(List<ventaProductoDto> ventaProductoDtos, int ventaId)
        {
            var VentaProducto = new List<VentaProducto>();
            foreach (var producto in ventaProductoDtos)
            {
                VentaProducto.Add(
                    new VentaProducto
                    {
                        cantidad = producto.cantidad,
                        precioTotal = producto.precioTotal,
                        precioUnitario = producto.precioUnitario,
                        ventaId = ventaId,
                        VProductoId = producto.id,
                    }
                );
            }
            var insert = await this._ventaProductoRepositorio.StoreMultipleProducto(VentaProducto);
            return insert;
        }
        public async Task<object> PreviewPagoVenta(int ventaId)
        {
            var venta = await this._ventaRespositorio.ObtenerUnaVentaRepositorio(ventaId);
            var listaProductos = await this._ventaProductoRepositorio.ObtenerTodoVentaIdRepository(ventaId);
            var productos = new List<object>();
            foreach (var ordenProducto in listaProductos)
            {
                var infoProducto = await this._vProductoRepositorio.ObtenerUnoProductoRepositorio(ordenProducto.VProductoId);
                productos.Add(
                    new
                    {
                        productoId = infoProducto.id,
                        nombreProducto = infoProducto.nombreProducto,
                        cantidad = ordenProducto.cantidad,
                        precioUnitario = ordenProducto.precioUnitario,
                        precioTotal = ordenProducto.precioTotal
                    }
                );
            }

            var asiento = await this._asientoRespositorio.ObtenerUnoAsientoRepositorio(venta.asientoId);
            var asientoPlanCuentas = await this._asientoPlanCuentaRespositorio.ObtenerUnoAsientoIdRepositorio(asiento.id);
            var movimiento = new List<object>();

            foreach (var cuentaAsiento in asientoPlanCuentas)
            {
                var cuenta = await this._vPlanCuentasRepositorios.ObtenerUnoRepositorio(cuentaAsiento.VPlanCuentaId);
                movimiento.Add(
                    new
                    {
                        cuenta = cuenta.nombreCuenta,
                        codigo = cuenta.codigo,
                        debe = cuentaAsiento.rol == "debe" ? venta.total : 0,
                        haber = cuentaAsiento.rol == "haber" ? venta.total : 0,
                    }
                );
            }
            var resultado = new
            {
                venta = venta,
                productos = productos,
                contabilidad = movimiento
            };
            return resultado;
        }
        public async Task<string> StoreprocesoPagoVenta(int VentaId, DateTime fecha)
        {
            var venta = await this._ventaRespositorio.ObtenerUnaVentaRepositorio(VentaId);
            var asiento = await this._asientoRespositorio.ObtenerUnoAsientoRepositorio(venta.asientoId);
            venta.estadoId = 2;
            var updateVenta = await this._ventaRespositorio.ModificarVentaRepositorio(venta);
            var asientoCuenta = await this._asientoPlanCuentaRespositorio.ObtenerTodoAsientoPlanCuentaRepositorio(venta.asientoId);
            var cuentas = asientoCuenta.Where(x => x.asientoId == venta.asientoId).ToList();

            var movimientos = new List<Movimiento>();
            foreach (var cuenta in cuentas)
            {
                var cuentaData = await this._vPlanCuentasRepositorios.ObtenerUnoRepositorio(cuenta.VPlanCuentaId);
                movimientos.Add(
                    new Movimiento
                    {
                        asientoId = venta.asientoId,
                        VPlancuentaId = cuenta.VPlanCuentaId,
                        debe = cuenta.rol == "debe" ? venta.total : 0,
                        descripcion = venta.descripcion,
                        haber = cuenta.rol == "haber" ? venta.total : 0,
                        fechaMovimiento = fecha,
                        nombreAsiento = asiento.nombreAsiento,
                        nombrePlanCuenta = cuentaData.nombreCuenta,
                        tipoAsientoId = asiento.tipoasientoId,
                    }
                );
            }
            var status = await this._movimientoRepositorio.InsertarMultiple(movimientos);
            await this.SalidaAlmacenStore(VentaId);
            if (status > 0)
            {
                return "Registrado correctamente";
            }
            else
            {
                return "ocurrio un error";
            }
        }
        public async Task<string> SalidaAlmacenStore(int ventaId)
        {
            var venta = await this._ventaRespositorio.ObtenerUnaVentaRepositorio(ventaId);
            var ventaProductos = await this._ventaProductoRepositorio.ObtenerTodoVentaIdRepository(ventaId);

            var salidaAlmacen = new List<SalidaAlmacen>();

            var stockAlmacen = new List<StockAlmacen>();
            foreach (var ventaProducto in ventaProductos)
            {
                var detalleProducto = await this._vProductoRepositorio.ObtenerUnoProductoRepositorio(ventaProducto.VProductoId);
                salidaAlmacen.Add(new SalidaAlmacen
                {
                    almacenId = 1,
                    ventaId = venta.id,
                    cantidad = ventaProducto.cantidad,
                    lote = "1",
                    precioCompra = detalleProducto.precioCompra,
                    precioTotal = (detalleProducto.precioCompra * ventaProducto.cantidad),
                    VProductoId = ventaProducto.VProductoId,
                    VProveedoreId = detalleProducto.VProveedoreId
                });
                stockAlmacen.Add(
                    new StockAlmacen
                    {
                        precioUnitario = ventaProducto.precioUnitario,
                        VProductoId = ventaProducto.VProductoId,
                        cantidad = ventaProducto.cantidad
                    }
                );
            }
            var insertStockAlmacen = this._stockAlmacenModule.ActualizarStockAlmacen(stockAlmacen, "salida");
            var inserts = await this._salidaAlmacenRepositorio.InsertarMultiple(salidaAlmacen);
            if (inserts > 0)
            {
                return "Entrada registrada correctamente";
            }
            else
            {
                return "Ocurrio un error";
            }
        }
    }
}