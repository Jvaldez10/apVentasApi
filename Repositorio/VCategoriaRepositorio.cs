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
    public class VCategoriaRepositorio
    {
        private readonly ILogger<VCategoriaRepositorio> _logger;
        private readonly VCategoriaConsulta _vCategoriaConsulta;
        private readonly DBContext _dBContext;

        public VCategoriaRepositorio(
            ILogger<VCategoriaRepositorio> logger,
            VCategoriaConsulta vCategoriaConsulta,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._vCategoriaConsulta = vCategoriaConsulta;
            this._dBContext = dBContext;
        }
        public async Task<List<VCategoria>> ObtenerTodoCategoriaRepositorio()
        {
            this._logger.LogWarning($"CategoriaRepositorio/ObtenerTodoCategoriaRepositorio(): Inizialize...");

            var sql = this._vCategoriaConsulta.ObtenerTodo();
            var resultado = await this._dBContext.VCategoria.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"CategoriaRepositorio/ObtenerTodoCategoriaRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VCategoria>> ObtenerUnoAlmacenRepositorio(int id)
        {
            this._logger.LogWarning($"CategoriaRepositorio/ObtenerUnoAlmacenRepositorio({id}): Inizialize...");
            var sql = this._vCategoriaConsulta.ObtenerUno(id);
            var resultado = await this._dBContext.VCategoria.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"{sql}");
            this._logger.LogWarning($"CategoriaRepositorio/ObtenerUnoAlmacenRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<int> InsertarCategoriaRepositorio(
            string nombreCategoria,
            string descripcion,
            string estado
        )
        {
            this._logger.LogWarning($"CategoriaRepositorio/InsertarCategoriaRepositorio({nombreCategoria},{descripcion}, {estado}): Inizialize...");

            var sql = this._vCategoriaConsulta.InsertarUno(
                nombreCategoria,
                descripcion,
                estado
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"CategoriaRepositorio/InsertarCategoriaRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"CategoriaRepositorio/InsertarCategoriaRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> ModificarCategoriaRepositorio(
            int id,
             string nombreCategoria,
            string descripcion,
            string estado
        )
        {
            this._logger.LogWarning($"CategoriaRepositorio/ModificarCategoriaRepositorio({id},{nombreCategoria},{descripcion}, {estado}): Inizialize...");

            var sql = this._vCategoriaConsulta.ModificarUno(
                id,
                nombreCategoria,
                descripcion,
                estado
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"CategoriaRepositorio/ModificarCategoriaRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"CategoriaRepositorio/ModificarCategoriaRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> EliminarCategoriaRepositorio(
                    int id
                )
        {
            this._logger.LogWarning($"CategoriaRepositorio/DeleteCategoriaRepositorio({id}): Inizialize...");

            var sql = this._vCategoriaConsulta.EliminarUno(
                id
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"CategoriaRepositorio/DeleteCategoriaRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"CategoriaRepositorio/DeleteCategoriaRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
    }
}