using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Entidades.Querys;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class OrdenCompraModule
    {
        private readonly ILogger<OrdenCompraModule> logger;
        private readonly TipoAsientoRespositorio _tipoAsientoRespositorio;
        private readonly VPlanCuentasRepositorios _vPlanCuentasRepositorios;
        private readonly ProveedoresRepositorio _proveedoresRepositorio;
        private readonly AsientoRespositorio _asientoRespositorio;
        private readonly OrdenCompraRepositorio _ordenCompraRepositorio;
        private readonly OrdenCompraProductoRepositorio _ordenCompraProductoRepositorio;
        private readonly MovimientoRepositorio _movimientoRepositorio;
        private readonly VProductoRepositorio _vProductoRepositorio;
        private readonly AsientoPlanCuentaRespositorio _asientoPlanCuentaRespositorio;
        private readonly VAlmacenRepositorio _vAlmacenRepositorio;
        private readonly EntradaAlmacenRespositorio _entradaAlmacenRespositorio;
        private readonly EstadoOrdenCompraRespositorio _estadoOrdenCompraRespositorio;
        private readonly StockAlmacenModule _stockAlmacenModule;

        public OrdenCompraModule(
            ILogger<OrdenCompraModule> logger,
            TipoAsientoRespositorio tipoAsientoRespositorio,
            VPlanCuentasRepositorios vPlanCuentasRepositorios,
            ProveedoresRepositorio proveedoresRepositorio,
            AsientoRespositorio asientoRespositorio,
            OrdenCompraRepositorio ordenCompraRepositorio,
            OrdenCompraProductoRepositorio ordenCompraProductoRepositorio,
            MovimientoRepositorio movimientoRepositorio,
            VProductoRepositorio vProductoRepositorio,
            AsientoPlanCuentaRespositorio asientoPlanCuentaRespositorio,
            VAlmacenRepositorio vAlmacenRepositorio,
            EntradaAlmacenRespositorio entradaAlmacenRespositorio,
            EstadoOrdenCompraRespositorio estadoOrdenCompraRespositorio,
            StockAlmacenModule stockAlmacenModule
        )
        {
            this.logger = logger;
            this._tipoAsientoRespositorio = tipoAsientoRespositorio;
            this._vPlanCuentasRepositorios = vPlanCuentasRepositorios;
            this._proveedoresRepositorio = proveedoresRepositorio;
            this._asientoRespositorio = asientoRespositorio;
            this._ordenCompraRepositorio = ordenCompraRepositorio;
            this._ordenCompraProductoRepositorio = ordenCompraProductoRepositorio;
            this._movimientoRepositorio = movimientoRepositorio;
            this._vProductoRepositorio = vProductoRepositorio;
            this._asientoPlanCuentaRespositorio = asientoPlanCuentaRespositorio;
            this._vAlmacenRepositorio = vAlmacenRepositorio;
            this._entradaAlmacenRespositorio = entradaAlmacenRespositorio;
            this._estadoOrdenCompraRespositorio = estadoOrdenCompraRespositorio;
            this._stockAlmacenModule = stockAlmacenModule;
        }
        public async Task<List<object>> DataGrid()
        {
            var ListaOrdenCompra = await this._ordenCompraRepositorio.ObtenerTodoOrdenCompraRepositorio();
            var resultado = new List<object>();
            foreach (var ordenCompra in ListaOrdenCompra)
            {
                var proveedor = await this._proveedoresRepositorio.ObtenerUnoproveedorRepositorio(ordenCompra.VProveedoreId);
                var asiento = await this._asientoRespositorio.ObtenerUnoAsientoRepositorio(ordenCompra.asientoId);
                var estado = await this._estadoOrdenCompraRespositorio.ObtenerUnoEstadoOrdenCompraRepositorio(ordenCompra.estadoId);
                resultado.Add(new
                {
                    codigoCompra = ordenCompra.codigoOrden,
                    fechaCreacion = ordenCompra.fechaCreacion,
                    usuario = "Stiven Lovera",
                    Proveedor = proveedor.nombreProveedor,
                    total = ordenCompra.total,
                    asientoNombre = asiento.nombreAsiento,
                    id = ordenCompra.id,
                    nombreEstado = estado.nombreEstadoOrdenCompra
                });
            }
            return resultado;
        }
        public async Task<int> GuardarOrdenCompra(OrdenCompraDto ordenCompraDto)
        {
            if (ordenCompraDto.productos == null || ordenCompraDto.productos.Count < 0)
            {
                throw new Exception("Error no hay productos registrado");
            }
            var insertOrdenCompra = await this._ordenCompraRepositorio.InsertarOrdenCompraRepositorio(
                new OrdenCompra
                {
                    asientoId = ordenCompraDto.asientoId,
                    codigoOrden = await this.ObtenerUltimaOrden(),
                    descripcion = ordenCompraDto.descripcion,
                    fechaCreacion = ordenCompraDto.fecha,
                    nit = ordenCompraDto.nit,
                    telefono = ordenCompraDto.telefono,
                    total = ordenCompraDto.total,
                    totalLiteral = ordenCompraDto.montoliteral,
                    usuarioId = 1,
                    estadoId = 1,
                    VProveedoreId = ordenCompraDto.VProveedoreId
                }
            );
            //insertando producto
            foreach (var producto in ordenCompraDto.productos)
            {
                await this._ordenCompraProductoRepositorio.InsertarOrdenCompraProductoRepositorio(
                    new OrdenCompraProducto
                    {
                        cantidad = producto.cantidad,
                        ordenCompraId = insertOrdenCompra.id,
                        precioCompra = producto.precioCompra,
                        precioTotal = producto.precioTotal,
                        VProductoId = producto.id
                    }
                );
            }
            //insert movimiento
            /* var asiento = await this._asientoRespositorio.ObtenerUnoAsientoRepositorio(ordenCompraDto.asientoId);
            var asientoCuenta = await this._asientoPlanCuentaRespositorio.ObtenerTodoAsientoPlanCuentaRepositorio(ordenCompraDto.asientoId);
            var cuentas = asientoCuenta.Where(x => x.asientoId == ordenCompraDto.asientoId).ToList();
            foreach (var cuenta in cuentas)
            {
                var cuentaData = await this._vPlanCuentasRepositorios.ObtenerUnoRepositorio(cuenta.VPlanCuentaId);
                await this._movimientoRepositorio.InsertarMovimientoRepositorio(
                    new Movimiento
                    {
                        asientoId = ordenCompraDto.asientoId,
                        VPlancuentaId = cuenta.VPlanCuentaId,
                        debe = cuenta.rol == "debe" ? ordenCompraDto.total : 0,
                        descripcion = ordenCompraDto.descripcion,
                        haber = cuenta.rol == "haber" ? ordenCompraDto.total : 0,
                        fechaMovimiento = ordenCompraDto.fecha,
                        nombreAsiento = asiento.nombreAsiento,
                        nombrePlanCuenta = cuentaData.nombreCuenta,
                        tipoAsientoId = asiento.tipoasientoId,
                    }
                );
            } */
            return insertOrdenCompra.id;
        }

        public async Task<string> ProcesoVenta(OrdenCompraDto ordenCompraDto)
        {
            var obtenerTodoTipoAsiento = await this._tipoAsientoRespositorio.ObtenerAsientoRepositorio(ordenCompraDto.asientoId);
            foreach (var cuenta in obtenerTodoTipoAsiento)
            {
                //cuenta.planCuentaId
                var planCuenta = await this._vPlanCuentasRepositorios.ObtenerUnoRepositorio(cuenta.planCuentaId);

                PropertyInfo[] propiedades = planCuenta.GetType().GetProperties();
                var modificar = await this._vPlanCuentasRepositorios.ModificarPlanCuentaRepositorio(
                    new VPlanCuentas
                    {
                        codigo = planCuenta.codigo,
                        codigoIdentificador = planCuenta.codigoIdentificador,
                        debe = this.identificarEgresoIngreso(cuenta.rol, propiedades[7].Name, planCuenta.debe, ordenCompraDto.total),
                        haber = this.identificarEgresoIngreso(cuenta.rol, propiedades[8].Name, planCuenta.haber, ordenCompraDto.total),
                        id = planCuenta.id,
                        moneda = planCuenta.moneda,
                        nivel = planCuenta.nivel,
                        nombreCuenta = planCuenta.nombreCuenta,
                        valor = planCuenta.valor,
                        VPlanCuentaId = planCuenta.VPlanCuentaId,
                    }
                );
            }
            return "Proceso registrado";
        }
        private decimal identificarEgresoIngreso(string rol, string propiedad, decimal valorAntiguo, decimal valorNuevo)
        {
            if (propiedad == rol)
            {
                return valorAntiguo + valorNuevo;
            }
            else
            {
                return valorAntiguo;
            }
        }
        public async Task<object> CreateOrdenCompra()
        {
            var todoProveedores = await this._proveedoresRepositorio.ObtenerTodoProveedoresRepositorio();
            var proveedores = todoProveedores.Select(x => new
            {
                id = x.id,
                nombreProveedor = x.nombreProveedor,
                contacto = x.contacto
            }).ToList();

            var todoAsientos = await this._asientoRespositorio.ObtenerTodoAsientoRepositorio();
            var asientos = todoAsientos.Select(X => new
            {
                id = X.id,
                nombreAsiento = X.nombreAsiento
            }).ToList();

            var ListaProducto = await this._vProductoRepositorio.ObtenerTodoProductoRepositorio();
            var productos = ListaProducto.Select(x => new
            {
                id = x.id,
                nombreProducto = x.nombreProducto,
                codigoProducto = x.codigoProducto,
                precioCompra = x.precioCompra,
            }).ToList();

            var resultado = new
            {
                ordenCompra = new
                {
                    codigoOrden = await this.ObtenerUltimaOrden(),
                    usuario = "Stiven lovera"
                },
                proveedores = proveedores,
                asientos = asientos,
                productos = productos
            };
            return resultado;
        }
        private async Task<string> ObtenerUltimaOrden()
        {
            var ordenes = await this._ordenCompraRepositorio.ObtenerTodoOrdenCompraRepositorio();
            var ultimaOrden = ordenes.OrderByDescending(x => x.id).FirstOrDefault();
            string codigo = "OC#1";
            if (ultimaOrden != null)
            {
                codigo = $"OC#{ultimaOrden.id}";
            }
            return codigo;
        }
        public async Task<object> PreviewProcesarPago(int ordenCompraId)
        {
            var ordenCompra = await this._ordenCompraRepositorio.ObtenerUnoOrdenCompraRepositorio(ordenCompraId);
            var listaProductos = await this._ordenCompraProductoRepositorio.ObtenerTodoOrdenCompraIdRepositorio(ordenCompraId);
            var productos = new List<object>();
            foreach (var ordenProducto in listaProductos)
            {
                var infoProducto = await this._vProductoRepositorio.ObtenerUnoProductoRepositorio(ordenProducto.VProductoId);
                productos.Add(
                    new
                    {
                        nombreProducto = infoProducto.nombreProducto,
                        cantidad = ordenProducto.cantidad,
                        precioCompra = ordenProducto.precioCompra,
                        precioTotal = ordenProducto.precioTotal
                    }
                );
            }

            var asiento = await this._asientoRespositorio.ObtenerUnoAsientoRepositorio(ordenCompra.asientoId);
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
                        debe = cuentaAsiento.rol == "debe" ? ordenCompra.total : 0,
                        haber = cuentaAsiento.rol == "haber" ? ordenCompra.total : 0,
                    }
                );
            }
            var resultado = new
            {
                orderCompra = ordenCompra,
                productos = productos,
                contabilidad = movimiento
            };
            return resultado;
        }

        public async Task<object> PreviewRecibirProducto(int ordenCompraId)
        {
            var ordenCompra = await this._ordenCompraRepositorio.ObtenerUnoOrdenCompraRepositorio(ordenCompraId);
            var listaProductos = await this._ordenCompraProductoRepositorio.ObtenerTodoOrdenCompraIdRepositorio(ordenCompraId);
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
                        precioCompra = ordenProducto.precioCompra,
                        precioTotal = ordenProducto.precioTotal
                    }
                );
            }

            var asiento = await this._asientoRespositorio.ObtenerUnoAsientoRepositorio(ordenCompra.asientoId);
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
                        debe = cuentaAsiento.rol == "debe" ? ordenCompra.total : 0,
                        haber = cuentaAsiento.rol == "haber" ? ordenCompra.total : 0,
                    }
                );
            }
            var almacenes = await this._vAlmacenRepositorio.ObtenerTodoAlmacenesRepositorio();
            var resultado = new
            {
                orderCompra = ordenCompra,
                productos = productos,
                contabilidad = movimiento,
                almacenes = almacenes
            };
            return resultado;
        }

        public async Task<string> StoreprocesoPago(int ordenCompraId, DateTime fecha)
        {
            var ordenCompra = await this._ordenCompraRepositorio.ObtenerUnoOrdenCompraRepositorio(ordenCompraId);
            var asiento = await this._asientoRespositorio.ObtenerUnoAsientoRepositorio(ordenCompra.asientoId);
            ordenCompra.estadoId = 2;
            var updateOrden = await this._ordenCompraRepositorio.ModificarOrdenCompraRepositorio(ordenCompra);

            var asientoCuenta = await this._asientoPlanCuentaRespositorio.ObtenerTodoAsientoPlanCuentaRepositorio(ordenCompra.asientoId);
            var cuentas = asientoCuenta.Where(x => x.asientoId == ordenCompra.asientoId).ToList();
            foreach (var cuenta in cuentas)
            {
                var cuentaData = await this._vPlanCuentasRepositorios.ObtenerUnoRepositorio(cuenta.VPlanCuentaId);
                await this._movimientoRepositorio.InsertarMovimientoRepositorio(
                    new Movimiento
                    {
                        asientoId = ordenCompra.asientoId,
                        VPlancuentaId = cuenta.VPlanCuentaId,
                        debe = cuenta.rol == "debe" ? ordenCompra.total : 0,
                        descripcion = ordenCompra.descripcion,
                        haber = cuenta.rol == "haber" ? ordenCompra.total : 0,
                        fechaMovimiento = fecha,
                        nombreAsiento = asiento.nombreAsiento,
                        nombrePlanCuenta = cuentaData.nombreCuenta,
                        tipoAsientoId = asiento.tipoasientoId,
                    }
                );
            }
            /*Update precio compra */
            var ordenCompraProductos = await this._ordenCompraProductoRepositorio.ObtenerTodoOrdenCompraIdRepositorio(ordenCompraId);
            foreach (var ordenCompraProducto in ordenCompraProductos)
            {
                var producto = await this._vProductoRepositorio.ObtenerUnoProductoRepositorio(ordenCompraProducto.VProductoId);
                producto.precioCompra = ordenCompraProducto.precioCompra;
                var updateProducto = await this._vProductoRepositorio.ModificarProductoRepositorio(producto);
            }
            return "Pago realizado correctamente";
        }
        public async Task<string> EntradaAlmacenStore(EntradaAlmacenDto entradaAlmacenDto, int id)
        {
            var ordenCompra = await this._ordenCompraRepositorio.ObtenerUnoOrdenCompraRepositorio(id);
            ordenCompra.estadoId = 3;
            var updateOrdenCompra = await this._ordenCompraRepositorio.ModificarOrdenCompraRepositorio(ordenCompra);
            var orderCompraProductos = await this._ordenCompraProductoRepositorio.ObtenerTodoOrdenCompraIdRepositorio(id);

            var stockAlmacen = new List<StockAlmacen>();
            foreach (var producto in entradaAlmacenDto.productos)
            {
                var detalleProducto = await this._vProductoRepositorio.ObtenerUnoProductoRepositorio(producto.productoId);
                var entradaStore = await this._entradaAlmacenRespositorio.InsertarEntradaRepositorio(
                new EntradaAlmacen
                {
                    almacenId = producto.almacenId,
                    ordenCompraId = id,
                    cantidad = producto.cantidad,
                    fechaVencimiento = producto.fechaVencimiento,
                    lote = producto.lote,
                    precioCompra = producto.precioCompra,
                    precioTotal = producto.precioTotal,
                    VProductoId = producto.productoId,
                    VProveedoreId = ordenCompra.VProveedoreId
                });
                stockAlmacen.Add(
                    new StockAlmacen
                    {
                        cantidad = producto.cantidad,
                        VProductoId = producto.productoId,
                        VProveedoreId = ordenCompra.VProveedoreId,
                        precioUnitario = producto.precioCompra,
                        precioTotal = producto.precioTotal,
                        stockAlert = detalleProducto.stockMinimo
                    }
                );
            }
            var insertStockAlmacen = await this._stockAlmacenModule.ActualizarStockAlmacen(stockAlmacen, "entrada");

            return "Entrada registrada correctamente";
        }
    }
}