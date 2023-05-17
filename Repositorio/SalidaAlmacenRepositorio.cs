using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Repositorio
{
    public class SalidaAlmacenRepositorio
    {
        private readonly ILogger<SalidaAlmacenRepositorio> _logger;
        private readonly DBContext _dBContext;

        public SalidaAlmacenRepositorio(
            ILogger<SalidaAlmacenRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<SalidaAlmacen>> ObtenerTodoEntradaRepositorio()
        {
            this._logger.LogWarning($"SalidaAlmacenRespositio/ObtenerTodoEntradaRepositorio(): Inizialize...");
            var resultado = await this._dBContext.salidaalmacen.ToListAsync();
            this._logger.LogWarning($"SalidaAlmacenRespositio/ObtenerTodoEntradaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<SalidaAlmacen>> ObtenerUnoEntradaRepositorio(int id)
        {
            this._logger.LogWarning($"SalidaAlmacenRespositio/ObtenerUnoEntradaRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.salidaalmacen.Where(x => x.id == id).ToListAsync();
            this._logger.LogWarning($"SalidaAlmacenRespositio/ObtenerUnoEntradaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<SalidaAlmacen> InsertarEntradaRepositorio(SalidaAlmacen SalidaAlmacen)
        {
            this._logger.LogWarning($"SalidaAlmacenRespositio/InsertarEntradaRepositorio({JsonConvert.SerializeObject(SalidaAlmacen, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.salidaalmacen.AddAsync(SalidaAlmacen);
            await this._dBContext.SaveChangesAsync();
            return SalidaAlmacen;
        }
          public async Task<int> InsertarMultiple(List<SalidaAlmacen> salidaAlmacens)
        {
            this._logger.LogWarning($"EntradaAlmacenRespositio/InsertarMultiple({JsonConvert.SerializeObject(salidaAlmacens, Formatting.Indented)}): Inizialize...");
            await this._dBContext.salidaalmacen.AddRangeAsync(salidaAlmacens);
            var insert = await this._dBContext.SaveChangesAsync();
            return insert;
        }
        public async Task<SalidaAlmacen> ModificarEntradaRepositorio(SalidaAlmacen SalidaAlmacen)
        {
            this._logger.LogWarning($"SalidaAlmacenRespositio/ModificarEntradaRepositorio({JsonConvert.SerializeObject(SalidaAlmacen, Formatting.Indented)}): Inizialize...");

            this._dBContext.salidaalmacen.Update(SalidaAlmacen);
            await this._dBContext.SaveChangesAsync();
            return SalidaAlmacen;
        }
        public async Task<int> EliminarEntradaRepositorio(int id)
        {
            this._logger.LogWarning($"SalidaAlmacenRespositio/EliminarEntradaRepositorio({id}): Inizialize...");
            this._dBContext.salidaalmacen.Remove(new SalidaAlmacen { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}