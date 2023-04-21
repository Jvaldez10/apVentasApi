
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_venta_erp.Consultas;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Repositorio
{
    public class VAlmacenRepositorio
    {
        private readonly ILogger<VAlmacenRepositorio> _logger;
        private readonly VAlmacenConsulta  _vAlmacenConsulta;
        private readonly DBContext _dBContext;

        public VAlmacenRepositorio(
            ILogger<VAlmacenRepositorio> logger,
            VAlmacenConsulta vAlmacenConsulta,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._vAlmacenConsulta = vAlmacenConsulta;
            this._dBContext = dBContext;
        }
        public async Task<List<VAlmacen>> ObtenerTodoAlmacenesRepositorio()
        {
            this._logger.LogWarning($"AlmacenesRepositorio/ObtenerTodoAlmacenesRepositorio(): Inizialize...");

            var sql = this._vAlmacenConsulta.ObtenerTodo();
            var resultado = await this._dBContext.valmacen.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"AlmacenesRepositorio/ObtenerTodoAlmacenesRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<List<VAlmacen>> ObtenerUnoAlmacenRepositorio(int id)
        {
            this._logger.LogWarning($"AlmacenesRepositorio/ObtenerUnoAlmacenRepositorio({id}): Inizialize...");
            var sql = this._vAlmacenConsulta.ObtenerUno(id);
            var resultado = await this._dBContext.valmacen.FromSqlRaw(sql).ToListAsync();
            this._logger.LogWarning($"{sql}");
            this._logger.LogWarning($"AlmacenesRepositorio/ObtenerUnoAlmacenRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<int> InsertarAlmacenesRepositorio(
            string codigoAlmacen,
            string dirrecion,
            string nombreAlmacen
        )
        {
            this._logger.LogWarning($"AlmacenesRepositorio/InsertarAlmacenesRepositorio({codigoAlmacen},{dirrecion}, {nombreAlmacen}): Inizialize...");

            var sql = this._vAlmacenConsulta.InsertarUno(
                codigoAlmacen,
                dirrecion,
                nombreAlmacen
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"AlmacenesRepositorio/InsertarAlmacenesRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"AlmacenesRepositorio/InsertarAlmacenesRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> ModificarAlmacenesRepositorio(
            int id,
            string codigoAlmacen,
            string dirrecion,
            string nombreAlmacen
        )
        {
            this._logger.LogWarning($"AlmacenesRepositorio/ModificarAlmacenesRepositorio({id},{codigoAlmacen},{dirrecion}, {nombreAlmacen}): Inizialize...");

            var sql = this._vAlmacenConsulta.ModificarUno(
                id,
                codigoAlmacen,
                dirrecion,
                nombreAlmacen
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"AlmacenesRepositorio/ModificarAlmacenesRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"AlmacenesRepositorio/ModificarAlmacenesRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
        public async Task<int> EliminarAlmacenesRepositorio(
                    int id
                )
        {
            this._logger.LogWarning($"AlmacenesRepositorio/DeleteAlmacenesRepositorio({id}): Inizialize...");

            var sql = this._vAlmacenConsulta.EliminarUno(
                id
            );
            var ejecutar = await this._dBContext.Database.ExecuteSqlRawAsync(sql);
            if (ejecutar > 0)
            {
                this._logger.LogWarning($"AlmacenesRepositorio/DeleteAlmacenesRepositorio SUCCESS => {ejecutar} columnas afectadas");
                return ejecutar;
            }
            else
            {
                this._logger.LogCritical($"AlmacenesRepositorio/DeleteAlmacenesRepositorio ERROR => {sql}");
                return ejecutar;
            }
        }
    }
}