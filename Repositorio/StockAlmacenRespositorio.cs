using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Repositorio
{
    public class StockAlmacenRespositorio
    {
        private readonly ILogger<StockAlmacenRespositorio> _logger;
        private readonly DBContext _dBContext;

        public StockAlmacenRespositorio(
            ILogger<StockAlmacenRespositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<StockAlmacen>> ObtenerTodo()
        {
            this._logger.LogWarning($"StockAlmacenRespositio/ObtenerTodoEntradaRepositorio(): Inizialize...");
            var resultado = await this._dBContext.stockalmacen.ToListAsync();
            this._logger.LogWarning($"StockAlmacenRespositio/ObtenerTodoEntradaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<StockAlmacen>> ObtenerUno(int id)
        {
            this._logger.LogWarning($"StockAlmacenRespositio/ObtenerUnoEntradaRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.stockalmacen.Where(x => x.id == id).ToListAsync();
            this._logger.LogWarning($"StockAlmacenRespositio/ObtenerUnoEntradaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<StockAlmacen> ObtenerUnoProductoId(int productoId)
        {
            this._logger.LogWarning($"StockAlmacenRespositio/ObtenerUnoEntradaRepositorio({productoId}): Inizialize...");
            var resultado = await this._dBContext.stockalmacen.Where(x => x.VProductoId == productoId).FirstOrDefaultAsync();
            this._logger.LogWarning($"StockAlmacenRespositio/ObtenerUnoEntradaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<StockAlmacen> Insertar(StockAlmacen stockAlmacen)
        {
            this._logger.LogWarning($"StockAlmacenRespositio/InsertarEntradaRepositorio({JsonConvert.SerializeObject(stockAlmacen, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.stockalmacen.AddAsync(stockAlmacen);
            await this._dBContext.SaveChangesAsync();
            return stockAlmacen;
        }
          public async Task<int> InsertarMultiple(List<StockAlmacen> stockAlmacen)
        {
            this._logger.LogWarning($"EntradaAlmacenRespositio/InsertarMultiple({JsonConvert.SerializeObject(stockAlmacen, Formatting.Indented)}): Inizialize...");
            await this._dBContext.stockalmacen.AddRangeAsync(stockAlmacen);
            var insert = await this._dBContext.SaveChangesAsync();
            return insert;
        }
        public async Task<StockAlmacen> Modificar(StockAlmacen stockAlmacen)
        {
            this._logger.LogWarning($"StockAlmacenRespositio/ModificarEntradaRepositorio({JsonConvert.SerializeObject(stockAlmacen, Formatting.Indented)}): Inizialize...");

            this._dBContext.stockalmacen.Update(stockAlmacen);
            await this._dBContext.SaveChangesAsync();
            return stockAlmacen;
        }
        public async Task<int> Eliminar(int id)
        {
            this._logger.LogWarning($"StockAlmacenRespositio/EliminarEntradaRepositorio({id}): Inizialize...");
            this._dBContext.stockalmacen.Remove(new StockAlmacen { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}