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
            var resultado = await this._dBContext.vproveedor.ToListAsync();
            this._logger.LogWarning($"ProveedoresRepositorio/ObtenerTodoProveedoresRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VProveedor> ObtenerUnoproveedorRepositorio(int id)
        {
            this._logger.LogWarning($"ProveedoresRepositorio/ObtenerUnoproveedorRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.vproveedor.Where(x => x.id == id).FirstOrDefaultAsync();
            this._logger.LogWarning($"ProveedoresRepositorio/ObtenerUnoproveedorRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VProveedor> InsertarProveedoresRepositorio(VProveedor vProveedor)
        {
            this._logger.LogWarning($"ProveedoresRepositorio/InsertarProveedoresRepositorio({JsonConvert.SerializeObject(vProveedor, Formatting.Indented)}): Inizialize...");
            var insert = await this._dBContext.vproveedor.AddAsync(vProveedor);
            await this._dBContext.SaveChangesAsync();
            return vProveedor;
        }
        public async Task<VProveedor> ModificarProveedoresRepositorio(VProveedor vProveedor)
        {
            this._logger.LogWarning($"ProveedoresRepositorio/ModificarProveedoresRepositorio({JsonConvert.SerializeObject(vProveedor, Formatting.Indented)}): Inizialize...");

            this._dBContext.vproveedor.Update(vProveedor);
            await this._dBContext.SaveChangesAsync();
            return vProveedor;
        }
        public async Task<int> EliminarProveedoresRepositorio(int id)
        {
            this._logger.LogWarning($"ProveedoresRepositorio/EliminarClasificacionRepositorio({id}): Inizialize...");
            this._dBContext.vproveedor.Remove(new VProveedor { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}