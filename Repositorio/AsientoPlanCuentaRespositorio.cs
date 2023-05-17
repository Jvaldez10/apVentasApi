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
    public class AsientoPlanCuentaRespositorio
    {
        private readonly ILogger<AsientoPlanCuentaRespositorio> _logger;
        private readonly DBContext _dBContext;

        public AsientoPlanCuentaRespositorio(
            ILogger<AsientoPlanCuentaRespositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<AsientoPlanCuenta>> ObtenerTodoAsientoPlanCuentaRepositorio(int asientoId)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoAsientoPlanCuentaRepositorio(): Inizialize...");
            var resultado = await this._dBContext.asientovplancuenta.Where(x => x.asientoId == asientoId).ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoAsientoPlanCuentaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<AsientoPlanCuenta> ObtenerUnoAsientoPlanCuentaRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoAsientoPlanCuentaRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.asientovplancuenta.FirstOrDefaultAsync(x => x.id == id);
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoAsientoPlanCuentaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
         public async Task<List<AsientoPlanCuenta>> ObtenerUnoAsientoIdRepositorio(int asientoId)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoAsientoPlanCuentaRepositorio({asientoId}): Inizialize...");
            var resultado = await this._dBContext.asientovplancuenta.Where(X=>X.asientoId==asientoId).ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoAsientoPlanCuentaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<AsientoPlanCuenta> InsertarAsientoPlanCuentaRepositorio(AsientoPlanCuenta asientoPlanCuenta)
        {
            this._logger.LogWarning($"VClienteRepositorio/InsertarAsientoPlanCuentaRepositorio({JsonConvert.SerializeObject(asientoPlanCuenta, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.asientovplancuenta.AddAsync(asientoPlanCuenta);
            await this._dBContext.SaveChangesAsync();
            return asientoPlanCuenta;
        }
        public async Task<AsientoPlanCuenta> ModificarAsientoPlanCuentaRepositorio(AsientoPlanCuenta asientoPlanCuenta)
        {
            this._logger.LogWarning($"VClienteRepositorio/ModificarAsientoPlanCuentaRepositorio({JsonConvert.SerializeObject(asientoPlanCuenta, Formatting.Indented)}): Inizialize...");
            this._dBContext.asientovplancuenta.Update(asientoPlanCuenta);
            await this._dBContext.SaveChangesAsync();
            return asientoPlanCuenta;
        }
        public async Task<int> EliminarAsientoPlanCuentaRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/DeleteAsientoPlanCuentaRepositorio({id}): Inizialize...");
            this._dBContext.asientovplancuenta.Remove(new AsientoPlanCuenta { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}