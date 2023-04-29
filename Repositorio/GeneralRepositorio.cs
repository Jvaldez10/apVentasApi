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
    public class GeneralRepositorio
    {
        private readonly ILogger<GeneralRepositorio> _logger;
        private readonly DBContext _dBContext;

        public GeneralRepositorio(
            ILogger<GeneralRepositorio> logger,
            DBContext dBContext
            )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<General>> ObtenerTodoGeneralRepositorio()
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoGeneralRepositorio(): Inizialize...");
            var resultado = await this._dBContext.general.ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoGeneralRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<General> ObtenerUnoGeneralRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoGeneralRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.general.FirstAsync(x => x.id == id);
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoGeneralRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<General> InsertarGeneralRepositorio(General general)
        {
            this._logger.LogWarning($"VClienteRepositorio/InsertarGeneralRepositorio({JsonConvert.SerializeObject(general, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.general.AddAsync(general);
            await this._dBContext.SaveChangesAsync();
            return general;
        }
        public async Task<General> ModificarGeneralRepositorio(General general)
        {
            this._logger.LogWarning($"VClienteRepositorio/ModificarGeneralRepositorio({JsonConvert.SerializeObject(general, Formatting.Indented)}): Inizialize...");
            this._dBContext.general.Update(general);
            await this._dBContext.SaveChangesAsync();
            return general;
        }
        public async Task<int> EliminarGeneralRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/DeleteGeneralRepositorio({id}): Inizialize...");
            this._dBContext.general.Remove(new General { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}