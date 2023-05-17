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
    public class VentaProductoRepositorio
    {
        private readonly ILogger<VentaProductoRepositorio> _logger;
        private readonly DBContext _dBContext;

        public VentaProductoRepositorio(
            ILogger<VentaProductoRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<VentaProducto>> ObtenerTodoVentaProductoRepositorio()
        {
            this._logger.LogWarning($"VentaProductoRepositorio/ObtenerTodoVentaProductoRepositorio(): Inizialize...");
            var resultado = await this._dBContext.ventaproducto.ToListAsync();
            this._logger.LogWarning($"VentaProductoRepositorio/ObtenerTodoVentaProductoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VentaProducto>> ObtenerTodoVentaIdRepository(int ventaId)
        {
            this._logger.LogWarning($"VentaProductoRepositorio/ObtenerTodoVentaProductoRepositorio({ventaId}): Inizialize...");
            var resultado = await this._dBContext.ventaproducto.Where(x => x.ventaId == ventaId).ToListAsync();
            this._logger.LogWarning($"VentaProductoRepositorio/ObtenerTodoVentaProductoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VentaProducto> ObtenerUnoproveedorRepositorio(int id)
        {
            this._logger.LogWarning($"VentaProductoRepositorio/ObtenerUnoproveedorRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.ventaproducto.Where(x => x.id == id).FirstOrDefaultAsync();
            this._logger.LogWarning($"VentaProductoRepositorio/ObtenerUnoproveedorRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VentaProducto> InsertarVentaProductoRepositorio(VentaProducto ventaProducto)
        {
            this._logger.LogWarning($"VentaProductoRepositorio/InsertarVentaProductoRepositorio({JsonConvert.SerializeObject(ventaProducto, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.ventaproducto.AddAsync(ventaProducto);
            await this._dBContext.SaveChangesAsync();
            return ventaProducto;
        }
        public async Task<VentaProducto> ModificarVentaProductoRepositorio(VentaProducto ventaProducto)
        {
            this._logger.LogWarning($"VentaProductoRepositorio/ModificarVentaProductoRepositorio({JsonConvert.SerializeObject(ventaProducto, Formatting.Indented)}): Inizialize...");

            this._dBContext.ventaproducto.Update(ventaProducto);
            await this._dBContext.SaveChangesAsync();
            return ventaProducto;
        }
        public async Task<int> EliminarVentaProductoRepositorio(int id)
        {
            this._logger.LogWarning($"VentaProductoRepositorio/EliminarVentaProductoRepositorio({id}): Inizialize...");
            this._dBContext.ventaproducto.Remove(new VentaProducto { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
        public async Task<VentaProducto> ObtenerUltimo()
        {
            this._logger.LogWarning($"VentaProductoRepositorio/EliminarVentaProductoRepositorio(): Inizialize...");
            var ultimo = await this._dBContext.ventaproducto.OrderByDescending(x => x.id).FirstOrDefaultAsync();
            return ultimo;
        }
        public async Task<int> StoreMultipleProducto(List<VentaProducto> ventaProductos)
        {
            this._logger.LogWarning($"VentaRepositorio/EliminarVentaRepositorio({JsonConvert.SerializeObject(ventaProductos, Formatting.Indented)}): Inizialize...");
            await this._dBContext.ventaproducto.AddRangeAsync(ventaProductos);
            var aux = await this._dBContext.SaveChangesAsync();
            return aux;
        }
    }
}