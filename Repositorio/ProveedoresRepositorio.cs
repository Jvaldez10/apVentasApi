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
    public class ProveedoresRepositorio
    {
        private readonly ILogger<ProveedoresRepositorio> _logger;
        private readonly ProveedoresConsulta _proveedoresConsulta;
        private readonly DBContext _dBContext;

        public ProveedoresRepositorio(
            ILogger<ProveedoresRepositorio> logger,
            ProveedoresConsulta proveedoresConsulta,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._proveedoresConsulta = proveedoresConsulta;
            this._dBContext = dBContext;
        }
        public async Task<List<VProveedor>> ObtenerTodoProveedoresRepositorio()
        {
            this._logger.LogWarning($"ProveedoresRepositorio/ObtenerTodoProveedoresRepositorio(): Inizialize...");

            var sql = this._proveedoresConsulta.ObtenerTodo();
            var resultado = await this._dBContext.VProveedor.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"ProveedoresRepositorio/ObtenerTodoProveedoresRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VProveedor>> ObtenerUnoproveedorRepositorio(int id)
        {
            this._logger.LogWarning($"ProveedoresRepositorio/ObtenerUnoproveedorRepositorio({id}): Inizialize...");
            var sql = this._proveedoresConsulta.ObtenerUno(id);
            var resultado = await this._dBContext.VProveedor.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"{sql}");
            this._logger.LogWarning($"ProveedoresRepositorio/ObtenerUnoproveedorRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<int> InsertarProveedoresRepositorio(
            string codigoProveedor,
            string nombreProveedor,
            string dirrecion,
            decimal credito,
            int telefono,
            int planCuentaId
        )
        {
            this._logger.LogWarning($"ProveedoresRepositorio/InsertarProveedoresRepositorio({codigoProveedor},{nombreProveedor}, {dirrecion},{credito},{telefono}): Inizialize...");

            var sql = this._proveedoresConsulta.InsertarUno(
                codigoProveedor,
                nombreProveedor,
                dirrecion,
                credito,
                telefono,
                planCuentaId
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"ProveedoresRepositorio/InsertarProveedoresRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"ProveedoresRepositorio/InsertarProveedoresRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> ModificarProveedoresRepositorio(
            int id,
            string codigoProveedor,
            string nombreProveedor,
            string dirrecion,
            decimal credito,
            int telefono,
            int planCuentaId
        )
        {
            this._logger.LogWarning($"ProveedoresRepositorio/ModificarProveedoresRepositorio({id},{codigoProveedor},{nombreProveedor}, {dirrecion},{credito},{telefono}): Inizialize...");

            var sql = this._proveedoresConsulta.ModificarUno(
                id,
                codigoProveedor,
                nombreProveedor,
                dirrecion,
                credito,
                telefono,
                planCuentaId
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"ProveedoresRepositorio/ModificarProveedoresRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"ProveedoresRepositorio/ModificarProveedoresRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> EliminarProveedoresRepositorio(
                    int id
                )
        {
            this._logger.LogWarning($"ProveedoresRepositorio/DeleteProveedoresRepositorio({id}): Inizialize...");

            var sql = this._proveedoresConsulta.EliminarUno(
                id
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"ProveedoresRepositorio/DeleteProveedoresRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"ProveedoresRepositorio/DeleteProveedoresRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
    }
}