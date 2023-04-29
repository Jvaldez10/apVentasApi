using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_venta_erp.Consultas;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Entidades.Querys;

namespace sistema_venta_erp.Repositorio
{
    public class TipoAsientoRespositorio
    {
        private readonly ILogger<TipoAsientoRespositorio> _logger;
        private readonly DBContext _dBContext;
        private readonly VentasConsulta _ventasConsulta;

        public TipoAsientoRespositorio(
            ILogger<TipoAsientoRespositorio> logger,
            DBContext dBContext,
            VentasConsulta ventasConsulta
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
            this._ventasConsulta = ventasConsulta;
        }
        public async Task<List<TipoAsiento>> ObtenerTodoTipoAsientoRepositorio()
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoTipoAsientoRepositorio(): Inizialize...");
            var resultado = await this._dBContext.tipoasiento.ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoTipoAsientoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<TipoAsiento> ObtenerUnoTipoAsientoRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoTipoAsientoRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.tipoasiento.FirstOrDefaultAsync(x => x.id == id);
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoTipoAsientoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<TipoAsiento> InsertarTipoAsientoRepositorio(TipoAsiento tipoAsiento)
        {
            this._logger.LogWarning($"VClienteRepositorio/InsertarTipoAsientoRepositorio({JsonConvert.SerializeObject(tipoAsiento, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.tipoasiento.AddAsync(tipoAsiento);
            await this._dBContext.SaveChangesAsync();
            return tipoAsiento;
        }
        public async Task<TipoAsiento> ModificarTipoAsientoRepositorio(TipoAsiento tipoAsiento)
        {
            this._logger.LogWarning($"VClienteRepositorio/ModificarTipoAsientoRepositorio({JsonConvert.SerializeObject(tipoAsiento, Formatting.Indented)}): Inizialize...");
            this._dBContext.tipoasiento.Update(tipoAsiento);
            await this._dBContext.SaveChangesAsync();
            return tipoAsiento;
        }
        public async Task<int> EliminarTipoAsientoRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/DeleteTipoAsientoRepositorio({id}): Inizialize...");
            this._dBContext.tipoasiento.Remove(new TipoAsiento { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
        public async Task<List<ObtenerTipoAsiento>> ObtenerAsientoRepositorio(int tipoAsientoId)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerAsientoRepositorio({tipoAsientoId}): Inizialize...");
            var sql = this._ventasConsulta.OntenerAsientos(tipoAsientoId);
            var tipoAsientos = await this._dBContext.ObtenerTipoAsiento.FromSqlRaw(sql).ToListAsync();
            return tipoAsientos;
        }
    }
}