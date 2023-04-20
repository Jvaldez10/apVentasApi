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
    public class VPlanProveedoresRepositorio
    {
        private readonly ILogger<VPlanProveedoresRepositorio> _logger;
        private readonly VPlanProveedoresConsulta _vPlanProveedoresConsulta;
        private readonly DBContext _dBContext;

        public VPlanProveedoresRepositorio(
            ILogger<VPlanProveedoresRepositorio> logger,
            VPlanProveedoresConsulta vPlanProveedoresConsulta,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._vPlanProveedoresConsulta = vPlanProveedoresConsulta;
            this._dBContext = dBContext;
        }
        public async Task<List<VPlanProveedores>> ObtenerTodoPlanProveedoresRepositorio()
        {
            this._logger.LogWarning($"PlanProveedoresRepositorio/ObtenerTodoPlanProveedoresRepositorio(): Inizialize...");

            var sql = this._vPlanProveedoresConsulta.ObtenerTodo();
            var resultado = await this._dBContext.VPlanProveedores.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"PlanProveedoresRepositorio/ObtenerTodoPlanProveedoresRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VPlanProveedores>> ObtenerUltimoPlanProveedoresRepositorio(int VPlanCuentaId)
        {
            this._logger.LogWarning($"PlanProveedoresRepositorio/ObtenerUltimoPlanProveedoresRepositorio({VPlanCuentaId}): Inizialize...");

            var sql = this._vPlanProveedoresConsulta.ObtenerUltimoPlan(VPlanCuentaId);
            var resultado = await this._dBContext.VPlanProveedores.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"PlanProveedoresRepositorio/ObtenerUltimoPlanProveedoresRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VPlanProveedores>> ObtenerUnoPlanProveedoresRepositorio(int id)
        {
            this._logger.LogWarning($"PlanProveedoresRepositorio/ObtenerUnoTodoPlanProveedoresRepositorio({id}): Inizialize...");
            var sql = this._vPlanProveedoresConsulta.ObtenerUno(id);
            var resultado = await this._dBContext.VPlanProveedores.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"{sql}");
            this._logger.LogWarning($"PlanProveedoresRepositorio/ObtenerUnoTodoPlanProveedoresRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<int> InsertarPlanProveedoresRepositorio(
            string codigo,
            string nombreCuenta,
            string moneda,
            decimal valor,
            string codigoIdentificador,
            int nivel,
            decimal debe,
            decimal haber,
            int VPlanCuentaId
        )
        {
            this._logger.LogWarning($"PlanProveedoresRepositorio/InsertarPlanProveedoresRepositorio({codigo},{nombreCuenta},{moneda},{valor},{codigoIdentificador},{nivel},{debe},{haber},{VPlanCuentaId}): Inizialize...");

            var sql = this._vPlanProveedoresConsulta.InsertarUno(
                codigo,
                nombreCuenta,
                moneda,
                valor,
                codigoIdentificador,
                nivel,
                debe,
                haber,
                VPlanCuentaId
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"PlanProveedoresRepositorio/InsertarPlanProveedoresRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"PlanProveedoresRepositorio/InsertarPlanProveedoresRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> ModificarPlanProveedoresRepositorio(
            int id,
            string codigo,
            string nombreCuenta,
            string moneda,
            decimal valor,
            string codigoIdentificador,
            int nivel,
            decimal debe,
            decimal haber,
            int VPlanCuentaId
        )
        {
            this._logger.LogWarning($"PlanProveedoresRepositorio/ModificarPlanProveedoresRepositorio({id},{codigo},{nombreCuenta},{moneda},{valor},{codigoIdentificador},{nivel},{debe},{haber},{VPlanCuentaId}): Inizialize...");

            var sql = this._vPlanProveedoresConsulta.ModificarUno(
                id,
                codigo,
                nombreCuenta,
                moneda,
                valor,
                codigoIdentificador,
                nivel,
                debe,
                haber,
                VPlanCuentaId
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"PlanProveedoresRepositorio/ModificarPlanProveedoresRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"PlanProveedoresRepositorio/ModificarPlanProveedoresRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> EliminarPlanProveedoresRepositorio(
                int id
            )
        {
            this._logger.LogWarning($"PlanProveedoresRepositorio/DeletePlanProveedoresRepositorio({id}): Inizialize...");

            var sql = this._vPlanProveedoresConsulta.EliminarUno(
                id
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"PlanProveedoresRepositorio/DeletePlanProveedoresRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"PlanProveedoresRepositorio/DeletePlanProveedoresRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
    }
}