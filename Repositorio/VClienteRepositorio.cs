using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Repositorio
{
    public class VClienteRepositorio
    {
        private readonly ILogger<VClienteRepositorio> _logger;
        private readonly DBContext _dBContext;

        public VClienteRepositorio(
            ILogger<VClienteRepositorio> logger,
            DBContext dBContext
        )
        {
            this._logger = logger;
            this._dBContext = dBContext;
        }
        public async Task<List<VCliente>> ObtenerTodoClientesRepositorio()
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoClientesRepositorio(): Inizialize...");
            var resultado = await this._dBContext.vcliente.ToListAsync();
            this._logger.LogWarning($"VClienteRepositorio/ObtenerTodoClientesRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VCliente> ObtenerUnoClientesRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoClientesRepositorio({id}): Inizialize...");
            var resultado = await this._dBContext.vcliente.FirstAsync(x => x.id == id);
            this._logger.LogWarning($"VClienteRepositorio/ObtenerUnoTodoClientesRepositorio SUCCESS => {JsonConvert.SerializeObject(resultado, Formatting.Indented)}");
            return resultado;
        }
        public async Task<VCliente> InsertarClientesRepositorio(VCliente vCliente)
        {
            this._logger.LogWarning($"VClienteRepositorio/InsertarClientesRepositorio({JsonConvert.SerializeObject(vCliente, Formatting.Indented)}): Inizialize...");
            var update =new VCliente();
            update= vCliente;
            var insert = await this._dBContext.vcliente.AddAsync(update);
            await this._dBContext.SaveChangesAsync();
            return vCliente;
        }
        public async Task<VCliente> ModificarClientesRepositorio(VCliente vCliente)
        {
            this._logger.LogWarning($"VClienteRepositorio/ModificarClientesRepositorio({JsonConvert.SerializeObject(vCliente, Formatting.Indented)}): Inizialize...");
            this._dBContext.vcliente.Update(vCliente);
            await this._dBContext.SaveChangesAsync();
            return vCliente;
        }
        public async Task<int> EliminarClientesRepositorio(int id)
        {
            this._logger.LogWarning($"VClienteRepositorio/DeleteClientesRepositorio({id}): Inizialize...");
            this._dBContext.vcliente.Remove(new VCliente { id = id });
            await this._dBContext.SaveChangesAsync();
            return id;
        }
    }
}