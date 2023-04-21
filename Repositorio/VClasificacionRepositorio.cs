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
    public class VClasificacionRepositorio
    {
        private readonly ILogger<VClasificacionRepositorio> _logger;
        private readonly DBContext _dBContext;

        public VClasificacionRepositorio(
            ILogger<VClasificacionRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<VClasificacion>> ObtenerTodoClasificacionRepositorio()
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoClasificacionRepositorio(): Inizialize...");
            var resultado = await this._dBContext.vclasificacion.ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoClasificacionRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VClasificacion> ObtenerUnoClasificacionRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoClasificacionRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.vclasificacion.FirstOrDefaultAsync(x => x.id == id);
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoClasificacionRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VClasificacion> InsertarClasificacionRepositorio(VClasificacion vClasificacion)
        {
            this._logger.LogWarning($"VClienteRepositorio/InsertarClasificacionRepositorio({JsonConvert.SerializeObject(vClasificacion, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.vclasificacion.AddAsync(vClasificacion);
            await this._dBContext.SaveChangesAsync();
            return vClasificacion;
        }
        public async Task<VClasificacion> ModificarClasificacionRepositorio(VClasificacion vClasificacion)
        {
            this._logger.LogWarning($"VClienteRepositorio/ModificarClasificacionRepositorio({JsonConvert.SerializeObject(vClasificacion, Formatting.Indented)}): Inizialize...");
            this._dBContext.vclasificacion.Update(vClasificacion);
            await this._dBContext.SaveChangesAsync();
            return vClasificacion;
        }
        public async Task<int> EliminarClasificacionRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/DeleteClasificacionRepositorio({id}): Inizialize...");
            this._dBContext.vclasificacion.Remove(new VClasificacion { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}