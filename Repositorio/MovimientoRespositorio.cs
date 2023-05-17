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
    public class MovimientoRepositorio
    {
        private readonly ILogger<MovimientoRepositorio> _logger;
        private readonly DBContext _dBContext;

        public MovimientoRepositorio(
            ILogger<MovimientoRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<Movimiento>> ObtenerTodoMovimientoRepositorio()
        {
            this._logger.LogWarning($"MovimientoRepositorio/ObtenerTodoMovimientoRepositorio(): Inizialize...");
            var resultado = await this._dBContext.movimiento.ToListAsync();
            this._logger.LogWarning($"MovimientoRepositorio/ObtenerTodoMovimientoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<Movimiento>> ObtenerUnoMovimientoRepositorio(int id)
        {
            this._logger.LogWarning($"MovimientoRepositorio/ObtenerUnoMovimientoRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.movimiento.Where(x => x.id == id).ToListAsync();
            this._logger.LogWarning($"MovimientoRepositorio/ObtenerUnoMovimientoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<Movimiento> InsertarMovimientoRepositorio(Movimiento movimiento)
        {
            this._logger.LogWarning($"MovimientoRepositorio/InsertarMovimientoRepositorio({JsonConvert.SerializeObject(movimiento, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.movimiento.AddAsync(movimiento);
            await this._dBContext.SaveChangesAsync();
            return movimiento;
        }
        public async Task<int> InsertarMultiple(List<Movimiento> movimiento)
        {
            this._logger.LogWarning($"MovimientoRepositorio/InsertarMovimientoRepositorio({JsonConvert.SerializeObject(movimiento, Formatting.Indented)}): Inizialize...");
            await this._dBContext.movimiento.AddRangeAsync(movimiento);
            var insert = await this._dBContext.SaveChangesAsync();
            return insert;
        }
        public async Task<Movimiento> ModificarMovimientoRepositorio(Movimiento movimiento)
        {
            this._logger.LogWarning($"MovimientoRepositorio/ModificarMovimientoRepositorio({JsonConvert.SerializeObject(movimiento, Formatting.Indented)}): Inizialize...");

            this._dBContext.movimiento.Update(movimiento);
            await this._dBContext.SaveChangesAsync();
            return movimiento;
        }
        public async Task<int> EliminarMovimientoRepositorio(int id)
        {
            this._logger.LogWarning($"MovimientoRepositorio/EliminarMovimientoRepositorio({id}): Inizialize...");
            this._dBContext.movimiento.Remove(new Movimiento { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}