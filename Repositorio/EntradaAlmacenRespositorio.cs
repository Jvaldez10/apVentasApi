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
    public class EntradaAlmacenRespositorio
    {
        private readonly ILogger<EntradaAlmacenRespositorio> _logger;
        private readonly DBContext _dBContext;

        public EntradaAlmacenRespositorio(
            ILogger<EntradaAlmacenRespositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<EntradaAlmacen>> ObtenerTodoEntradaRepositorio()
        {
            this._logger.LogWarning($"EntradaAlmacenRespositio/ObtenerTodoEntradaRepositorio(): Inizialize...");
            var resultado = await this._dBContext.entradaalmacen.ToListAsync();
            this._logger.LogWarning($"EntradaAlmacenRespositio/ObtenerTodoEntradaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<EntradaAlmacen>> ObtenerUnoEntradaRepositorio(int id)
        {
            this._logger.LogWarning($"EntradaAlmacenRespositio/ObtenerUnoEntradaRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.entradaalmacen.Where(x => x.id == id).ToListAsync();
            this._logger.LogWarning($"EntradaAlmacenRespositio/ObtenerUnoEntradaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<EntradaAlmacen> InsertarEntradaRepositorio(EntradaAlmacen entradaAlmacen)
        {
            this._logger.LogWarning($"EntradaAlmacenRespositio/InsertarEntradaRepositorio({JsonConvert.SerializeObject(entradaAlmacen, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.entradaalmacen.AddAsync(entradaAlmacen);
            await this._dBContext.SaveChangesAsync();
            return entradaAlmacen;
        }
        public async Task<int> InsertarMultiple(List<EntradaAlmacen> entradaAlmacens)
        {
            this._logger.LogWarning($"EntradaAlmacenRespositio/InsertarMultiple({JsonConvert.SerializeObject(entradaAlmacens, Formatting.Indented)}): Inizialize...");
            await this._dBContext.entradaalmacen.AddRangeAsync(entradaAlmacens);
            var insert = await this._dBContext.SaveChangesAsync();
            return insert;
        }
        public async Task<EntradaAlmacen> ModificarEntradaRepositorio(EntradaAlmacen entradaalmacen)
        {
            this._logger.LogWarning($"EntradaAlmacenRespositio/ModificarEntradaRepositorio({JsonConvert.SerializeObject(entradaalmacen, Formatting.Indented)}): Inizialize...");

            this._dBContext.entradaalmacen.Update(entradaalmacen);
            await this._dBContext.SaveChangesAsync();
            return entradaalmacen;
        }
        public async Task<int> EliminarEntradaRepositorio(int id)
        {
            this._logger.LogWarning($"EntradaAlmacenRespositio/EliminarEntradaRepositorio({id}): Inizialize...");
            this._dBContext.entradaalmacen.Remove(new EntradaAlmacen { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}