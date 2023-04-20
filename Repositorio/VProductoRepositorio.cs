
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Repositorio
{
    public class VProductoRepositorio
    {
        private readonly ILogger<VProductoRepositorio> _logger;
        private readonly DBContext _dBContext;

        public VProductoRepositorio(
            ILogger<VProductoRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<VProducto>> ObtenerTodoProductoRepositorio()
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoProductoRepositorio(): Inizialize...");
            var resultado = await this._dBContext.VProducto.ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoProductoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VProducto> ObtenerUnoProductoRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoProductoRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.VProducto.FirstOrDefaultAsync(x => x.id == id);
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoProductoRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VProducto> InsertarProductoRepositorio(VProducto vProducto)
        {
            this._logger.LogWarning($"VClienteRepositorio/InsertarProductoRepositorio({JsonConvert.SerializeObject(vProducto, Formatting.Indented)}): Inizialize...");
            var update = new VProducto();
            update = vProducto;
            var insert = await this._dBContext.VProducto.AddAsync(update);
            await this._dBContext.SaveChangesAsync();
            return vProducto;
        }
        public async Task<VProducto> ModificarProductoRepositorio(VProducto vProducto)
        {
            this._logger.LogWarning($"VClienteRepositorio/ModificarProductoRepositorio({JsonConvert.SerializeObject(vProducto, Formatting.Indented)}): Inizialize...");
            this._dBContext.VProducto.Update(vProducto);
            await this._dBContext.SaveChangesAsync();
            return vProducto;
        }
        public async Task<int> EliminarProductoRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/DeleteProductoRepositorio({id}): Inizialize...");
            this._dBContext.VProducto.Remove(new VProducto { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}