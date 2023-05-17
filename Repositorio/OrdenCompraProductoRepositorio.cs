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
    public class OrdenCompraProductoRepositorio
    {
        private readonly ILogger<OrdenCompraProductoRepositorio> _logger;
        private readonly DBContext _dBContext;

        public OrdenCompraProductoRepositorio(
            ILogger<OrdenCompraProductoRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<OrdenCompraProducto>> ObtenerTodoOrdenCompraProductoRepositorio()
        {
            this._logger.LogWarning($"OrdenCompraProductoRepositorio/ObtenerTodoOrdenCompraProductoRepositorio(): Inizialize...");
            var resultado = await this._dBContext.ordencompraproducto.ToListAsync();
            this._logger.LogWarning($"OrdenCompraProductoRepositorio/ObtenerTodoOrdenCompraProductoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<OrdenCompraProducto>> ObtenerTodoOrdenCompraIdRepositorio(int ordenCompraId)
        {
            this._logger.LogWarning($"OrdenCompraProductoRepositorio/ObtenerTodoOrdenCompraIdRepositorio({ordenCompraId}): Inizialize...");
            var resultado = await this._dBContext.ordencompraproducto.Where(x => x.ordenCompraId == ordenCompraId).ToListAsync();
            this._logger.LogWarning($"OrdenCompraProductoRepositorio/ObtenerTodoOrdenCompraIdRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<OrdenCompraProducto>> ObtenerUnoOrdenCompraProductoRepositorio(int id)
        {
            this._logger.LogWarning($"OrdenCompraProductoRepositorio/ObtenerUnoOrdenCompraProductoRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.ordencompraproducto.Where(x => x.id == id).ToListAsync();
            this._logger.LogWarning($"OrdenCompraProductoRepositorio/ObtenerUnoOrdenCompraProductoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<OrdenCompraProducto> InsertarOrdenCompraProductoRepositorio(OrdenCompraProducto ordenCompraProducto)
        {
            this._logger.LogWarning($"OrdenCompraProductoRepositorio/InsertarOrdenCompraProductoRepositorio({JsonConvert.SerializeObject(ordenCompraProducto, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.ordencompraproducto.AddAsync(ordenCompraProducto);
            await this._dBContext.SaveChangesAsync();
            return ordenCompraProducto;
        }
        public async Task<OrdenCompraProducto> ModificarOrdenCompraProductoRepositorio(OrdenCompraProducto ordenCompraProducto)
        {
            this._logger.LogWarning($"OrdenCompraProductoRepositorio/ModificarOrdenCompraProductoRepositorio({JsonConvert.SerializeObject(ordenCompraProducto, Formatting.Indented)}): Inizialize...");
            this._dBContext.ordencompraproducto.Update(ordenCompraProducto);
            await this._dBContext.SaveChangesAsync();
            return ordenCompraProducto;
        }
        public async Task<int> EliminarOrdenCompraProductoRepositorio(int id)
        {
            this._logger.LogWarning($"OrdenCompraProductoRepositorio/EliminarClasificacionRepositorio({id}): Inizialize...");
            this._dBContext.ordencompraproducto.Remove(new OrdenCompraProducto { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}