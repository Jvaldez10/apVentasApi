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
    public class EstadoVentaRepositorio
    {
        private readonly ILogger<EstadoVentaRepositorio> _logger;
        private readonly DBContext _dBContext;

        public EstadoVentaRepositorio(
            ILogger<EstadoVentaRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<EstadoVenta>> ObtenerTodoEstadoVentaRepositorio()
        {
            this._logger.LogWarning($"EstadoVentaRespositio/ObtenerTodoEstadoVentaRepositorio(): Inizialize...");
            var resultado = await this._dBContext.estadoventa.ToListAsync();
            this._logger.LogWarning($"EstadoVentaRespositio/ObtenerTodoEstadoVentaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<EstadoVenta> ObtenerUnoEstadoVentaRepositorio(int id)
        {
            this._logger.LogWarning($"EstadoVentaRespositio/ObtenerUnoEstadoVentaRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.estadoventa.Where(x => x.id == id).FirstOrDefaultAsync();
            this._logger.LogWarning($"EstadoVentaRespositio/ObtenerUnoEstadoVentaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<EstadoVenta> InsertarEstadoVentaRepositorio(EstadoVenta estadoVenta)
        {
            this._logger.LogWarning($"EstadoVentaRespositio/InsertarEstadoVentaRepositorio({JsonConvert.SerializeObject(estadoVenta, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.estadoventa.AddAsync(estadoVenta);
            await this._dBContext.SaveChangesAsync();
            return estadoVenta;
        }
        public async Task<EstadoVenta> ModificarEstadoVentaRepositorio(EstadoVenta estadoVenta)
        {
            this._logger.LogWarning($"EstadoVentaRespositio/ModificarEstadoVentaRepositorio({JsonConvert.SerializeObject(estadoVenta, Formatting.Indented)}): Inizialize...");
            this._dBContext.estadoventa.Update(estadoVenta);
            await this._dBContext.SaveChangesAsync();
            return estadoVenta;
        }
        public async Task<int> EliminarEstadoVentaRepositorio(int id)
        {
            this._logger.LogWarning($"EstadoVentaRespositio/EliminarEstadoVentaRepositorio({id}): Inizialize...");
            this._dBContext.estadoventa.Remove(new EstadoVenta { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}