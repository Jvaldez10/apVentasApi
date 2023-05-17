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
    public class VentaRespositorio
    {
        private readonly ILogger<VentaRespositorio> _logger;
        private readonly DBContext _dBContext;

        public VentaRespositorio(
            ILogger<VentaRespositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<Venta>> ObtenerTodoVentaRepositorio()
        {
            this._logger.LogWarning($"VentaRepositorio/ObtenerTodoVentaRepositorio(): Inizialize...");
            var resultado = await this._dBContext.venta.ToListAsync();
            this._logger.LogWarning($"VentaRepositorio/ObtenerTodoVentaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<Venta> ObtenerUnaVentaRepositorio(int id)
        {
            this._logger.LogWarning($"VentaRepositorio/ObtenerUnoproveedorRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.venta.Where(x => x.id == id).FirstOrDefaultAsync();
            this._logger.LogWarning($"VentaRepositorio/ObtenerUnoproveedorRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<Venta> InsertarVentaRepositorio(Venta venta)
        {
            this._logger.LogWarning($"VentaRepositorio/InsertarVentaRepositorio({JsonConvert.SerializeObject(venta, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.venta.AddAsync(venta);
            await this._dBContext.SaveChangesAsync();
            return venta;
        }
        public async Task<Venta> ModificarVentaRepositorio(Venta venta)
        {
            this._logger.LogWarning($"VentaRepositorio/ModificarVentaRepositorio({JsonConvert.SerializeObject(venta, Formatting.Indented)}): Inizialize...");
            this._dBContext.venta.Update(venta);
            await this._dBContext.SaveChangesAsync();
            return venta;
        }
        public async Task<int> EliminarVentaRepositorio(int id)
        {
            this._logger.LogWarning($"VentaRepositorio/EliminarVentaRepositorio({id}): Inizialize...");
            this._dBContext.venta.Remove(new Venta { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
        public async Task<Venta> ObtenerUltimo()
        {
            this._logger.LogWarning($"VentaRepositorio/EliminarVentaRepositorio(): Inizialize...");
            var ultimo = await this._dBContext.venta.OrderByDescending(x => x.id).FirstOrDefaultAsync();
            return ultimo;
        }
       
    }
}