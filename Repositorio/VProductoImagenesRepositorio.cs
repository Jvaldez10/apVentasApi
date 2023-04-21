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
    public class VProductoImagenesRepositorio
    {
        private readonly ILogger<VProductoImagenesRepositorio> _logger;
        private readonly DBContext dBContext;

        public VProductoImagenesRepositorio(
            ILogger<VProductoImagenesRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this.dBContext = dBContext;
        }
        public async Task<List<VProductoImagenes>> ObtenerTodoProductoImagenesRepositorio()
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoProductoImagenesRepositorio(): Inizialize...");
            var resultado = await this.dBContext.vproductoimagenes.ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoProductoImagenesRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VProductoImagenes> ObtenerUnoProductoImagenesRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoProductoImagenesRepositorio({id}): Inizialize...");
            var resultado = await this.dBContext.vproductoimagenes.FirstOrDefaultAsync(x => x.id == id);
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoProductoImagenesRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VProductoImagenes> InsertarProductoImagenesRepositorio(VProductoImagenes VProductoImagenes)
        {
            this._logger.LogWarning($"VClienteRepositorio/InsertarProductoImagenesRepositorio({JsonConvert.SerializeObject(VProductoImagenes, Formatting.Indented)}): Inizialize...");
            var insert = await this.dBContext.vproductoimagenes.AddAsync(VProductoImagenes);
            await this.dBContext.SaveChangesAsync();
            return VProductoImagenes;
        }
        public async Task<VProductoImagenes> ModificarProductoImagenesRepositorio(VProductoImagenes VProductoImagenes)
        {
            this._logger.LogWarning($"VClienteRepositorio/ModificarProductoImagenesRepositorio({JsonConvert.SerializeObject(VProductoImagenes, Formatting.Indented)}): Inizialize...");
            this.dBContext.vproductoimagenes.Update(VProductoImagenes);
            await this.dBContext.SaveChangesAsync();
            return VProductoImagenes;
        }
        public async Task<int> EliminarProductoImagenesRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/DeleteProductoImagenesRepositorio({id}): Inizialize...");
            this.dBContext.vproductoimagenes.Remove(new VProductoImagenes { id = id });
            await this.dBContext.SaveChangesAsync();
            return id;
        }
    }
}