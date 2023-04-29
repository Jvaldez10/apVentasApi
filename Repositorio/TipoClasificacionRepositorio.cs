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
    public class TipoClasificacionRepositorio
    {
        private readonly ILogger<TipoClasificacionRepositorio> _logger;
        private readonly DBContext _dBContext;

        public TipoClasificacionRepositorio(
            ILogger<TipoClasificacionRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<TipoClasificacion>> ObtenerTodoTipoClasificacionRepositorio()
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoTipoClasificacionRepositorio(): Inizialize...");
            var resultado = await this._dBContext.tipoclasificacion.ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoTipoClasificacionRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<TipoClasificacion> ObtenerUnoTipoClasificacionRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoTipoClasificacionRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.tipoclasificacion.FirstAsync(x => x.id == id);
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoTipoClasificacionRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<TipoClasificacion> InsertarTipoClasificacionRepositorio(TipoClasificacion tipoClasificacion)
        {
            this._logger.LogWarning($"VClienteRepositorio/InsertarTipoClasificacionRepositorio({JsonConvert.SerializeObject(tipoClasificacion, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.tipoclasificacion.AddAsync(tipoClasificacion);
            await this._dBContext.SaveChangesAsync();
            return tipoClasificacion;
        }
        public async Task<TipoClasificacion> ModificarTipoClasificacionRepositorio(TipoClasificacion tipoClasificacion)
        {
            this._logger.LogWarning($"VClienteRepositorio/ModificarTipoClasificacionRepositorio({JsonConvert.SerializeObject(tipoClasificacion, Formatting.Indented)}): Inizialize...");
            this._dBContext.tipoclasificacion.Update(tipoClasificacion);
            await this._dBContext.SaveChangesAsync();
            return tipoClasificacion;
        }
        public async Task<int> EliminarTipoClasificacionRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/DeleteTipoClasificacionRepositorio({id}): Inizialize...");
            this._dBContext.tipoclasificacion.Remove(new TipoClasificacion { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}