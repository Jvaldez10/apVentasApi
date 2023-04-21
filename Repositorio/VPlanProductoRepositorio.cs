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
    public class VPlanProductoRepositorio
    {
        private readonly ILogger<VPlanProductoRepositorio> _logger;
        private readonly VPlanProductosConsulta _vPlanProductosConsulta;
        private readonly DBContext _dBContext;

        public VPlanProductoRepositorio(
            ILogger<VPlanProductoRepositorio> logger,
            VPlanProductosConsulta vPlanProductosConsulta,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._vPlanProductosConsulta = vPlanProductosConsulta;
            this._dBContext = dBContext;
        }
        public async Task<List<VPlanProductos>> ObtenerTodoPlanProductosRepositorio()
        {
            this._logger.LogWarning($"PlanProductosRepositorio/ObtenerTodoPlanProductosRepositorio(): Inizialize...");

            var sql = this._vPlanProductosConsulta.ObtenerTodo();
            var resultado = await this._dBContext.vplanproductos.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"PlanProductosRepositorio/ObtenerTodoPlanProductosRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VPlanProductos>> ObtenerUnoPlanProductosRepositorio(int id)
        {
            this._logger.LogWarning($"PlanProductosRepositorio/ObtenerUnoTodoPlanProductosRepositorio({id}): Inizialize...");
            var sql = this._vPlanProductosConsulta.ObtenerUno(id);
            var resultado = await this._dBContext.vplanproductos.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"{sql}");
            this._logger.LogWarning($"PlanProductosRepositorio/ObtenerUnoTodoPlanProductosRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<int> InsertarPlanProductosRepositorio(
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
            this._logger.LogWarning($"PlanProductosRepositorio/InsertarPlanProductosRepositorio({codigo},{nombreCuenta},{moneda},{valor},{codigoIdentificador},{nivel},{debe},{haber},{VPlanCuentaId}): Inizialize...");

            var sql = this._vPlanProductosConsulta.InsertarUno(
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
                this._logger.LogWarning($"PlanProductosRepositorio/InsertarPlanProductosRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"PlanProductosRepositorio/InsertarPlanProductosRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> ModificarPlanProductosRepositorio(
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
            this._logger.LogWarning($"PlanProductosRepositorio/ModificarPlanProductosRepositorio({id},{codigo},{nombreCuenta},{moneda},{valor},{codigoIdentificador},{nivel},{debe},{haber},{VPlanCuentaId}): Inizialize...");

            var sql = this._vPlanProductosConsulta.ModificarUno(
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
                this._logger.LogWarning($"PlanProductosRepositorio/ModificarPlanProductosRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"PlanProductosRepositorio/ModificarPlanProductosRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> EliminarPlanProductosRepositorio(
                int id
            )
        {
            this._logger.LogWarning($"PlanProductosRepositorio/DeletePlanProductosRepositorio({id}): Inizialize...");

            var sql = this._vPlanProductosConsulta.EliminarUno(
                id
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"PlanProductosRepositorio/DeletePlanProductosRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"PlanProductosRepositorio/DeletePlanProductosRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
    }
}