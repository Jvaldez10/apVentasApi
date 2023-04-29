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
    public class ConfiguracionPlanCuentaRepositorio
    {
        private readonly ILogger<ConfiguracionPlanCuentaRepositorio> _logger;
        private readonly DBContext _dBContext;

        public ConfiguracionPlanCuentaRepositorio(
            ILogger<ConfiguracionPlanCuentaRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<ConfiguracionPlanCuenta>> ObtenerTodoConfiguracionPlanCuentaRepositorio()
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoConfiguracionPlanCuentaRepositorio(): Inizialize...");
            var resultado = await this._dBContext.configuracionplancuenta.ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoConfiguracionPlanCuentaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<ConfiguracionPlanCuenta> ObtenerUnoConfiguracionPlanCuentaRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoConfiguracionPlanCuentaRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.configuracionplancuenta.FirstAsync(x => x.id == id);
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoConfiguracionPlanCuentaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<ConfiguracionPlanCuenta> InsertarConfiguracionPlanCuentaRepositorio(ConfiguracionPlanCuenta configuracionPlanCuenta)
        {
            this._logger.LogWarning($"VClienteRepositorio/InsertarConfiguracionPlanCuentaRepositorio({JsonConvert.SerializeObject(configuracionPlanCuenta, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.configuracionplancuenta.AddAsync(configuracionPlanCuenta);
            await this._dBContext.SaveChangesAsync();
            return configuracionPlanCuenta;
        }
        public async Task<ConfiguracionPlanCuenta> ModificarConfiguracionPlanCuentaRepositorio(ConfiguracionPlanCuenta configuracionPlanCuenta)
        {
            this._logger.LogWarning($"VClienteRepositorio/ModificarConfiguracionPlanCuentaRepositorio({JsonConvert.SerializeObject(configuracionPlanCuenta, Formatting.Indented)}): Inizialize...");
            this._dBContext.configuracionplancuenta.Update(configuracionPlanCuenta);
            await this._dBContext.SaveChangesAsync();
            return configuracionPlanCuenta;
        }
        public async Task<int> EliminarConfiguracionPlanCuentaRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/DeleteConfiguracionPlanCuentaRepositorio({id}): Inizialize...");
            this._dBContext.configuracionplancuenta.Remove(new ConfiguracionPlanCuenta { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}