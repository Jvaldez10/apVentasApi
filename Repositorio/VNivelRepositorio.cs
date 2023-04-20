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
    public class VNivelRepositorio
    {
        private readonly ILogger<VNivelRepositorio> _logger;
        private readonly VNivelConsulta _vNivelConsulta;
        private readonly DBContext _dBContext;

        public VNivelRepositorio(
            ILogger<VNivelRepositorio> logger,
            VNivelConsulta vNivelConsulta,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._vNivelConsulta = vNivelConsulta;
            this._dBContext = dBContext;
        }
        public async Task<List<VNivel>> ObtenerTodoNivelRepositorio()
        {
            this._logger.LogWarning($"NivelRepositorio/ObtenerTodoNivelRepositorio(): Inizialize...");

            var sql = this._vNivelConsulta.ObtenerTodo();
            var resultado = await this._dBContext.VNivel.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"NivelRepositorio/ObtenerTodoNivelRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VNivel>> ObtenerUnoAlmacenRepositorio(int id)
        {
            this._logger.LogWarning($"NivelRepositorio/ObtenerUnoAlmacenRepositorio({id}): Inizialize...");
            var sql = this._vNivelConsulta.ObtenerUno(id);
            var resultado = await this._dBContext.VNivel.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"{sql}");
            this._logger.LogWarning($"NivelRepositorio/ObtenerUnoAlmacenRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<int> InsertarNivelRepositorio(
            string nombreNivel
        )
        {
            this._logger.LogWarning($"NivelRepositorio/InsertarNivelRepositorio({nombreNivel}): Inizialize...");

            var sql = this._vNivelConsulta.InsertarUno(
                nombreNivel
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"NivelRepositorio/InsertarNivelRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"NivelRepositorio/InsertarNivelRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> ModificarNivelRepositorio(
            int id,
            string nombreNivel
        )
        {
            this._logger.LogWarning($"NivelRepositorio/ModificarNivelRepositorio({id},{nombreNivel}): Inizialize...");

            var sql = this._vNivelConsulta.ModificarUno(
                id,
                nombreNivel
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"NivelRepositorio/ModificarNivelRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"NivelRepositorio/ModificarNivelRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> EliminarNivelRepositorio(
                    int id
                )
        {
            this._logger.LogWarning($"NivelRepositorio/DeleteNivelRepositorio({id}): Inizialize...");

            var sql = this._vNivelConsulta.EliminarUno(
                id
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"NivelRepositorio/DeleteNivelRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"NivelRepositorio/DeleteNivelRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
    }
}