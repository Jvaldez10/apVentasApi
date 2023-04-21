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
    public class VMonedaRepositorio
    {
        private readonly ILogger<VMonedaRepositorio> _logger;
        private readonly VMonedaConsulta _vMonedaConsulta;
        private readonly DBContext _dBContext;

        public VMonedaRepositorio(
            ILogger<VMonedaRepositorio> logger,
            VMonedaConsulta vMonedaConsulta,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._vMonedaConsulta = vMonedaConsulta;
            this._dBContext = dBContext;
        }
        public async Task<List<VMoneda>> ObtenerTodoMonedaRepositorio()
        {
            this._logger.LogWarning($"MonedaRepositorio/ObtenerTodoMonedaRepositorio(): Inizialize...");

            var sql = this._vMonedaConsulta.ObtenerTodo();
            var resultado = await this._dBContext.vmoneda.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"MonedaRepositorio/ObtenerTodoMonedaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VMoneda>> ObtenerUnoMonedaRepositorio(int id)
        {
            this._logger.LogWarning($"MonedaRepositorio/ObtenerUnoAlmacenRepositorio({id}): Inizialize...");
            var sql = this._vMonedaConsulta.ObtenerUno(id);
            var resultado = await this._dBContext.vmoneda.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"{sql}");
            this._logger.LogWarning($"MonedaRepositorio/ObtenerUnoAlmacenRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<int> InsertarMonedaRepositorio(
            string nombreMoneda
        )
        {
            this._logger.LogWarning($"MonedaRepositorio/InsertarMonedaRepositorio({nombreMoneda}): Inizialize...");

            var sql = this._vMonedaConsulta.InsertarUno(
                nombreMoneda
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"MonedaRepositorio/InsertarMonedaRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"MonedaRepositorio/InsertarMonedaRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> ModificarMonedaRepositorio(
            int id,
            string nombreMoneda
        )
        {
            this._logger.LogWarning($"MonedaRepositorio/ModificarMonedaRepositorio({id},{nombreMoneda}): Inizialize...");

            var sql = this._vMonedaConsulta.ModificarUno(
                id,
                nombreMoneda
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"MonedaRepositorio/ModificarMonedaRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"MonedaRepositorio/ModificarMonedaRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> EliminarMonedaRepositorio(
                    int id
                )
        {
            this._logger.LogWarning($"MonedaRepositorio/DeleteMonedaRepositorio({id}): Inizialize...");

            var sql = this._vMonedaConsulta.EliminarUno(
                id
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"MonedaRepositorio/DeleteMonedaRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"MonedaRepositorio/DeleteMonedaRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
    }
}