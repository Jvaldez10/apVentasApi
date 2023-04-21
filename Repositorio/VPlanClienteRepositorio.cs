using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_venta_erp.Consultas;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Repositorio
{
    public class VPlanClienteRepositorio
    {
         private readonly ILogger<VPlanClienteRepositorio> _logger;
        private readonly DBContext _dBContext;

        public VPlanClienteRepositorio(
            ILogger<VPlanClienteRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<VPlanClientes>> ObtenerTodoPlanClientesRepositorio()
        {
            this._logger.LogWarning($"PlanClientesRepositorio/ObtenerTodoPlanClientesRepositorio(): Inizialize...");
            var resultado = await this._dBContext.vplanclientes.ToListAsync();
            this._logger.LogWarning($"PlanClientesRepositorio/ObtenerTodoPlanClientesRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VPlanClientes> ObtenerUnoPlanClientesRepositorio(int id)
        {
            this._logger.LogWarning($"PlanClientesRepositorio/ObtenerUnoTodoPlanClientesRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.vplanclientes.FirstAsync(x => x.id == id);
            this._logger.LogWarning($"PlanClientesRepositorio/ObtenerUnoTodoPlanClientesRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VPlanClientes> InsertarPlanClientesRepositorio(VPlanClientes VPlanClientes)
        {
            this._logger.LogWarning($"PlanClientesRepositorio/InsertarPlanClientesRepositorio({JsonConvert.SerializeObject(VPlanClientes, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.vplanclientes.AddAsync(VPlanClientes);
            await this._dBContext.SaveChangesAsync();
            return VPlanClientes;
        }
        public async Task<VPlanClientes> ModificarPlanClientesRepositorio(VPlanClientes VPlanClientes)
        {
            this._logger.LogWarning($"PlanClientesRepositorio/ModificarPlanClientesRepositorio({JsonConvert.SerializeObject(VPlanClientes, Formatting.Indented)}): Inizialize...");
            var sql = this._dBContext.vplanclientes.Update(VPlanClientes);
            await this._dBContext.SaveChangesAsync();
            return VPlanClientes;
        }
        public async Task<int> EliminarPlanClientesRepositorio(int id)
        {
            this._logger.LogWarning($"PlanClientesRepositorio/DeletePlanClientesRepositorio({id}): Inizialize...");
            this._dBContext.Remove(new VPlanClientes { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}