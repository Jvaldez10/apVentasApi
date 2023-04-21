using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_venta_erp.Consultas;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Repositorio
{
    public class VPlanCuentasRepositorios
    {
        private readonly ILogger<VPlanCuentasRepositorios> _logger;
        private readonly VPlanCuentaConsulta _vPlanCuentaConsulta;
        private readonly DBContext _dBContext;

        public VPlanCuentasRepositorios(
            ILogger<VPlanCuentasRepositorios> logger,
            VPlanCuentaConsulta vPlanCuentaConsulta,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._vPlanCuentaConsulta = vPlanCuentaConsulta;
            this._dBContext = dBContext;
        }
        public async Task<List<VPlanCuentas>> ObtenerTodoPlanCuentasRepositorio()
        {
            this._logger.LogWarning($"PlanCuentasRepositorio/ObtenerTodoPlanCuentasRepositorio(): Inizialize...");

            var sql = this._vPlanCuentaConsulta.ObtenerTodo();
            var resultado = await this._dBContext.vplancuenta.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"PlanCuentasRepositorio/ObtenerTodoPlanCuentasRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VPlanCuentas>> ObtenerTodoPlanCuentasPorPadreIdRepositorio(int VPlanCuentaId)
        {
            this._logger.LogWarning($"PlanCuentasRepositorio/ObtenerTodoPlanCuentasPorPadreIdRepositorio(): Inizialize...");

            var sql = this._vPlanCuentaConsulta.ObtenerTodoPorPadreID(VPlanCuentaId);
            var resultado = await this._dBContext.vplancuenta.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"PlanCuentasRepositorio/ObtenerTodoPlanCuentasPorPadreIdRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VPlanCuentas>> ObtenerUltimoPlanRepositorio(int nivel)
        {
            this._logger.LogWarning($"PlanCuentasRepositorio/ObtenerUltimoPlanRepositorio(): Inizialize...");

            var sql = this._vPlanCuentaConsulta.ObtenerUltimoPlan(nivel);
            //this._logger.LogWarning($"{sql}");
            var resultado = await this._dBContext.vplancuenta.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"PlanCuentasRepositorio/ObtenerUltimoPlanRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VPlanCuentas>> ObtenerUltimoPlanPadreIdRepositorio(int VPlanCuentaId, int nivel)
        {
            this._logger.LogWarning($"PlanCuentasRepositorio/ObtenerUltimoPlanPadreIdRepositorio({VPlanCuentaId},{nivel}): Inizialize...");

            var sql = this._vPlanCuentaConsulta.ObtenerUltimoPlanPadre(VPlanCuentaId,nivel);
            this._logger.LogWarning($"{sql}");
            var resultado = await this._dBContext.vplancuenta.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"PlanCuentasRepositorio/ObtenerUltimoPlanPadreIdRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VPlanCuentas>> ObtenerUnoRepositorio(int id)
        {
            this._logger.LogWarning($"PlanCuentasRepositorio/ObtenerUnoRepositorio({id}): Inizialize...");
            var sql = this._vPlanCuentaConsulta.ObtenerUno(id);
            var resultado = await this._dBContext.vplancuenta.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"{sql}");
            this._logger.LogWarning($"PlanCuentasRepositorio/ObtenerUnoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<int> InsertarPlanCuentasRepositorio(
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
            this._logger.LogWarning($"PlanCuentasRepositorio/InsertarPlanCuentasRepositorio({codigo},{nombreCuenta},{moneda},{valor},{codigoIdentificador},{nivel},{debe},{haber},{VPlanCuentaId}): Inizialize...");

            var sql = this._vPlanCuentaConsulta.InsertarUno(
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
                this._logger.LogWarning($"PlanCuentasRepositorio/InsertarPlanCuentasRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"PlanCuentasRepositorio/InsertarPlanCuentasRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> ModificarPlanCuentasRepositorio(
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
            this._logger.LogWarning($"PlanCuentasRepositorio/ModificarPlanCuentasRepositorio({id},{codigo},{nombreCuenta},{moneda},{valor},{codigoIdentificador},{nivel},{debe},{haber},{VPlanCuentaId}): Inizialize...");

            var sql = this._vPlanCuentaConsulta.ModificarUno(
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
                this._logger.LogWarning($"PlanCuentasRepositorio/ModificarPlanCuentasRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"PlanCuentasRepositorio/ModificarPlanCuentasRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> EliminarPlanCuentasRepositorio(
                int id
            )
        {
            this._logger.LogWarning($"PlanCuentasRepositorio/DeletePlanCuentasRepositorio({id}): Inizialize...");

            var sql = this._vPlanCuentaConsulta.EliminarUno(
                id
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"PlanCuentasRepositorio/DeletePlanCuentasRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"PlanCuentasRepositorio/DeletePlanCuentasRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
    }
}