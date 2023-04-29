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
    public class AsientoRespositorio
    {
        private readonly ILogger<AsientoRespositorio> _logger;
        private readonly DBContext _dBContext;

        public AsientoRespositorio(
            ILogger<AsientoRespositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<Asiento>> ObtenerTodoAsientoRepositorio()
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoAsientoRepositorio(): Inizialize...");
            var resultado = await this._dBContext.asiento.ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoAsientoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<Asiento> ObtenerUnoAsientoRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoAsientoRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.asiento.FirstOrDefaultAsync(x => x.id == id);
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoAsientoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<Asiento> InsertarAsientoRepositorio(Asiento asiento)
        {
            this._logger.LogWarning($"VClienteRepositorio/InsertarAsientoRepositorio({JsonConvert.SerializeObject(asiento, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.asiento.AddAsync(asiento);
            await this._dBContext.SaveChangesAsync();
            return asiento;
        }
        public async Task<Asiento> ModificarAsientoRepositorio(Asiento asiento)
        {
            this._logger.LogWarning($"VClienteRepositorio/ModificarAsientoRepositorio({JsonConvert.SerializeObject(asiento, Formatting.Indented)}): Inizialize...");
            this._dBContext.asiento.Update(asiento);
            await this._dBContext.SaveChangesAsync();
            return asiento;
        }
        public async Task<int> EliminarAsientoRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/DeleteAsientoRepositorio({id}): Inizialize...");
            this._dBContext.asiento.Remove(new Asiento { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}