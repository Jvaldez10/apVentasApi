using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class ClienteModule
    {
        private readonly ILogger<ClienteModule> logger;
        private readonly VClienteRepositorio _vClienteRepositorio;
        private readonly VPlanClienteRepositorio _vPlanClienteRepositorio;
        private readonly PlanCuentaModulo _planCuentaModulo;
        private readonly MonedaModule _monedaModule;

        public ClienteModule(
            ILogger<ClienteModule> logger,
            VClienteRepositorio vClienteRepositorio,
            VPlanClienteRepositorio vPlanClienteRepositorio,
            PlanCuentaModulo planCuentaModulo,
            MonedaModule monedaModule
        )
        {
            this.logger = logger;
            this._vClienteRepositorio = vClienteRepositorio;
            this._vPlanClienteRepositorio = vPlanClienteRepositorio;
            this._planCuentaModulo = planCuentaModulo;
            this._monedaModule = monedaModule;
        }
        public async Task<List<VCliente>> ObtenerTodo()
        {
            var clientes = await this._vClienteRepositorio.ObtenerTodoClientesRepositorio();
            return clientes;
        }
        public async Task<VCliente> ObtenerUno(int id)
        {
            var clientes = await this._vClienteRepositorio.ObtenerUnoClientesRepositorio(id);
            return clientes;
        }
        public async Task<object> CrearUno()
        {
            var planCUentaCliente = 5;
            var planCuentas = await this._planCuentaModulo.ObtenerTodoPorVPlanCuentaId(planCUentaCliente);
            var monedas = await this._monedaModule.ObtenerTodo();
            var clientes = await this._vClienteRepositorio.ObtenerTodoClientesRepositorio();

            var resultado = new ClienteCreateDto
            {
                codigo = this.generateCodigo(clientes),
                monedas = monedas,
                planCuentas = planCuentas
            };
            return resultado;
        }
        private string generateCodigo(List<VCliente> vClientes)
        {
            this.logger.LogWarning($"ClienteModule/generateCodigo() Inizialize ...");
            if (vClientes.Count > 0)
            {
                var cliente = vClientes.Last();
                this.logger.LogWarning($"ClienteModule/generateCodigo()  => SUCESS {cliente.id.ToString()}");
                return $"cli-{cliente.id}";
            }
            else
            {
                this.logger.LogWarning($"ClienteModule/generateCodigo() => SUCESS {0}");
                return "cli-0";
            }
        }
        public async Task<string> InsertarUno(ClienteDto clienteDto)
        {
            var planCuenta = await this._planCuentaModulo.ObtenerUno(clienteDto.planCuentaId);
            var planClientes = await this._vPlanClienteRepositorio.ObtenerTodoPlanClientesRepositorio();

            var codigo = 0;
            if (planClientes.Count > 0)
            {
                var planCliente = planClientes.Last();
                codigo = codigo + planCliente.id;
            }
            var insertPlanCLiente = await this._vPlanClienteRepositorio.InsertarPlanClientesRepositorio(new VPlanClientes
            {
                codigo = $"{planCuenta.codigo}.{codigo}",
                CodigoIdentificador = codigo.ToString(),
                debe = 0,
                haber = 0,
                id = 0,
                monedaId = clienteDto.monedaId,
                nivel = planCuenta.nivel,
                nombreCuenta = clienteDto.nombreCliente,
                valor = 0,
                VPlanCuentaId = planCuenta.id
            });

            var insert = new VCliente
            {
                ci = clienteDto.ci,
                codigoCliente = clienteDto.codigoCliente,
                correoElectronico = clienteDto.correoElectronico,
                credito = clienteDto.lineaCredito,
                dirrecion = clienteDto.dirrecion,
                id = clienteDto.id,
                nombreCompletoCliente = clienteDto.nombreCliente,
                PlanCuentaId = insertPlanCLiente.id,
                telefono = clienteDto.telefono
            };
            var insertarCliente = await this._vClienteRepositorio.InsertarClientesRepositorio(insert);
            return "Cliente registrado correctamente";
        }
        public async Task<ClienteEditarDto> EditarUno(int id)
        {
            var cliente = await this._vClienteRepositorio.ObtenerUnoClientesRepositorio(id);

            var planClientes = await this._vPlanClienteRepositorio.ObtenerTodoPlanClientesRepositorio();
            var planCliente = planClientes.Where(pc => pc.id == cliente.PlanCuentaId).FirstOrDefault();

            var monedas = await this._monedaModule.ObtenerTodo();
            var clientes = await this._vClienteRepositorio.ObtenerTodoClientesRepositorio();
            var planCuentas = await this._planCuentaModulo.ObtenerTodoPorVPlanCuentaId(5);
            var resultado = new ClienteEditarDto
            {
                cliente = new ClienteDto
                {
                    ci = cliente.ci,
                    codigoCliente = cliente.codigoCliente,
                    correoElectronico = cliente.correoElectronico,
                    dirrecion = cliente.dirrecion,
                    id = cliente.id,
                    lineaCredito = cliente.credito,
                    nombreCliente = cliente.nombreCompletoCliente,
                    planCuentaId = planCliente.VPlanCuentaId,
                    telefono = cliente.telefono,
                    monedaId = planCliente.monedaId
                },
                monedas = monedas,
                planCuentas = planCuentas
            };
            return resultado;
        }
        public async Task<string> ModificarUno(int id, ClienteDto clienteDto)
        {
            var planCuenta = await this._planCuentaModulo.ObtenerUno(clienteDto.planCuentaId);

            var ObtenerCliente = await this._vClienteRepositorio.ObtenerUnoClientesRepositorio(id);
            var planClienteEliminar = await this._vPlanClienteRepositorio.EliminarPlanClientesRepositorio(ObtenerCliente.PlanCuentaId);

            var planClientes = await this._vPlanClienteRepositorio.ObtenerTodoPlanClientesRepositorio();
            var codigo = 0;
            if (planClientes.Count > 0)
            {
                var planCliente = planClientes.Last();
                codigo = codigo + planCliente.id;
            }
            var insertPlanCLiente = await this._vPlanClienteRepositorio.ModificarPlanClientesRepositorio(new VPlanClientes
            {
                codigo = $"{planCuenta.codigo}.{codigo}",
                CodigoIdentificador = codigo.ToString(),
                debe = clienteDto.monedaId,
                haber = 0,
                id = 0,
                monedaId = clienteDto.monedaId,
                nivel = planCuenta.nivel,
                nombreCuenta = clienteDto.nombreCliente,
                valor = 0,
                VPlanCuentaId = planCuenta.id
            });

            var update = new VCliente
            {
                ci = clienteDto.ci,
                codigoCliente = clienteDto.codigoCliente,
                correoElectronico = clienteDto.correoElectronico,
                credito = clienteDto.lineaCredito,
                dirrecion = clienteDto.dirrecion,
                id = clienteDto.id,
                nombreCompletoCliente = clienteDto.nombreCliente,
                PlanCuentaId = insertPlanCLiente.id,
                telefono = clienteDto.telefono
            };
            var insertarCliente = await this._vClienteRepositorio.ModificarClientesRepositorio(update);
            return $"Modificado correctamente";
        }
        public async Task<string> EliminarUno(int id)
        {
            var cliente = await this._vClienteRepositorio.EliminarClientesRepositorio(id);
            return $"Cliente eliminado correctamente";
        }
    }
    public class ClienteCreateDto
    {
        public string codigo { get; set; }
        public List<VMoneda> monedas { get; set; }
        public List<VPlanCuentas> planCuentas { get; set; }
    }
    public class ClienteEditarDto
    {
        public object cliente { get; set; }
        public List<VMoneda> monedas { get; set; }
        public List<VPlanCuentas> planCuentas { get; set; }
    }
}