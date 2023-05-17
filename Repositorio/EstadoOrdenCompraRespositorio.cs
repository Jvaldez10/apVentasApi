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
    public class EstadoOrdenCompraRespositorio
    {
        private readonly ILogger<EstadoOrdenCompraRespositorio> _logger;
        private readonly DBContext _dBContext;

        public EstadoOrdenCompraRespositorio(
            ILogger<EstadoOrdenCompraRespositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<EstadoOrdenCompra>> ObtenerTodoEstadoOrdenCompraRepositorio()
        {
            this._logger.LogWarning($"EstadoOrdenCompraRespositio/ObtenerTodoEstadoOrdenCompraRepositorio(): Inizialize...");
            var resultado = await this._dBContext.estadoordencompra.ToListAsync();
            this._logger.LogWarning($"EstadoOrdenCompraRespositio/ObtenerTodoEstadoOrdenCompraRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<EstadoOrdenCompra> ObtenerUnoEstadoOrdenCompraRepositorio(int id)
        {
            this._logger.LogWarning($"EstadoOrdenCompraRespositio/ObtenerUnoEstadoOrdenCompraRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.estadoordencompra.Where(x => x.id == id).FirstOrDefaultAsync();
            this._logger.LogWarning($"EstadoOrdenCompraRespositio/ObtenerUnoEstadoOrdenCompraRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<EstadoOrdenCompra> InsertarEstadoOrdenCompraRepositorio(EstadoOrdenCompra estadoOrdenCompra)
        {
            this._logger.LogWarning($"EstadoOrdenCompraRespositio/InsertarEstadoOrdenCompraRepositorio({JsonConvert.SerializeObject(estadoOrdenCompra, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.estadoordencompra.AddAsync(estadoOrdenCompra);
            await this._dBContext.SaveChangesAsync();
            return estadoOrdenCompra;
        }
        public async Task<EstadoOrdenCompra> ModificarEstadoOrdenCompraRepositorio(EstadoOrdenCompra estadoOrdenCompra)
        {
            this._logger.LogWarning($"EstadoOrdenCompraRespositio/ModificarEstadoOrdenCompraRepositorio({JsonConvert.SerializeObject(estadoOrdenCompra, Formatting.Indented)}): Inizialize...");
            this._dBContext.estadoordencompra.Update(estadoOrdenCompra);
            await this._dBContext.SaveChangesAsync();
            return estadoOrdenCompra;
        }
        public async Task<int> EliminarEstadoOrdenCompraRepositorio(int id)
        {
            this._logger.LogWarning($"EstadoOrdenCompraRespositio/EliminarEstadoOrdenCompraRepositorio({id}): Inizialize...");
            this._dBContext.estadoordencompra.Remove(new EstadoOrdenCompra { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}