using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class StockAlmacenModule
    {
        private readonly ILogger<StockAlmacenModule> stockAlmacenModule;
        private readonly StockAlmacenRespositorio _stockAlmacenRespositorio;

        public StockAlmacenModule(
            ILogger<StockAlmacenModule> StockAlmacenModule,
            StockAlmacenRespositorio stockAlmacenRespositorio
        )
        {
            stockAlmacenModule = StockAlmacenModule;
            this._stockAlmacenRespositorio = stockAlmacenRespositorio;
        }
        public async Task<Boolean> ActualizarStockAlmacen(List<StockAlmacen> stockAlmacens, string tipoAlmacen)
        {
            foreach (var productoStock in stockAlmacens)
            {
                var stock = await this._stockAlmacenRespositorio.ObtenerUnoProductoId(productoStock.VProductoId);
                if (stock == null)
                {
                    await this._stockAlmacenRespositorio.Insertar(productoStock);
                }
                else
                {
                    if (tipoAlmacen == "entrada")
                    {
                        stock.cantidad = stock.cantidad + productoStock.cantidad;
                        stock.precioUnitario= productoStock.precioUnitario;
                        stock.precioTotal = stock.precioTotal + (productoStock.precioUnitario * productoStock.cantidad);
                        await this._stockAlmacenRespositorio.Modificar(stock);
                    }
                    else
                    {
                        stock.cantidad = stock.cantidad - productoStock.cantidad;
                        stock.precioUnitario= stock.precioUnitario;
                        stock.precioTotal = stock.precioTotal - (stock.precioUnitario * productoStock.cantidad);
                        await this._stockAlmacenRespositorio.Modificar(stock);
                    }
                }
            }
            return true;
        }
    }
}