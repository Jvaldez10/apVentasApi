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
    public class OrdenCompraRepositorio
    {
        private readonly ILogger<OrdenCompraRepositorio> _logger;
        private readonly DBContext _dBContext;

        public OrdenCompraRepositorio(
            ILogger<OrdenCompraRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<OrdenCompra>> ObtenerTodoOrdenCompraRepositorio()
        {
            this._logger.LogWarning($"OrdenCompraRepositorio/ObtenerTodoOrdenCompraRepositorio(): Inizialize...");
            var resultado = await this._dBContext.ordencompra.ToListAsync();
            this._logger.LogWarning($"OrdenCompraRepositorio/ObtenerTodoOrdenCompraRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<OrdenCompra> ObtenerUnoOrdenCompraRepositorio(int id)
        {
            this._logger.LogWarning($"OrdenCompraRepositorio/ObtenerUnoproveedorRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.ordencompra.Where(x => x.id == id).FirstOrDefaultAsync();
            this._logger.LogWarning($"OrdenCompraRepositorio/ObtenerUnoproveedorRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<OrdenCompra> InsertarOrdenCompraRepositorio(OrdenCompra ordenCompra)
        {
            this._logger.LogWarning($"OrdenCompraRepositorio/InsertarOrdenCompraRepositorio({JsonConvert.SerializeObject(ordenCompra, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.ordencompra.AddAsync(ordenCompra);
            await this._dBContext.SaveChangesAsync();
            return ordenCompra;
        }
        public async Task<OrdenCompra> ModificarOrdenCompraRepositorio(OrdenCompra ordenCompra)
        {
            this._logger.LogWarning($"OrdenCompraRepositorio/ModificarOrdenCompraRepositorio({JsonConvert.SerializeObject(ordenCompra, Formatting.Indented)}): Inizialize...");

            this._dBContext.ordencompra.Update(ordenCompra);
            await this._dBContext.SaveChangesAsync();
            return ordenCompra;
        }
        public async Task<int> EliminarOrdenCompraRepositorio(int id)
        {
            this._logger.LogWarning($"OrdenCompraRepositorio/EliminarClasificacionRepositorio({id}): Inizialize...");
            this._dBContext.ordencompra.Remove(new OrdenCompra { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}