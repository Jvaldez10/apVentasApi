using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{

    public class ProveedoresModulo
    {
        private readonly ProveedoresRepositorio _proveedoresRepositorio;
        private readonly PlanProveedoresModulo _planProveedoresModulo;
        private readonly PlanCuentaModulo _planCuentaModulo;
        private readonly VPlanCuentasRepositorios _vPlanCuentasRepositorios;
        private readonly MonedaModule _monedaModule;
        private readonly VPlanProveedoresRepositorio _vPlanProveedoresRepositorio;
        private readonly ConfiguracionPlanCuentaRepositorio _configuracionPlanCuentaRepositorio;

        public ProveedoresModulo(
            ProveedoresRepositorio proveedoresRepositorio,
            PlanProveedoresModulo planProveedoresModulo,
            PlanCuentaModulo planCuentaModulo,
            VPlanCuentasRepositorios vPlanCuentasRepositorios,
            MonedaModule monedaModule,
            VPlanProveedoresRepositorio vPlanProveedoresRepositorio,
            ConfiguracionPlanCuentaRepositorio configuracionPlanCuentaRepositorio
        )
        {
            this._proveedoresRepositorio = proveedoresRepositorio;
            this._planProveedoresModulo = planProveedoresModulo;
            this._planCuentaModulo = planCuentaModulo;
            this._vPlanCuentasRepositorios = vPlanCuentasRepositorios;
            this._monedaModule = monedaModule;
            this._vPlanProveedoresRepositorio = vPlanProveedoresRepositorio;
            this._configuracionPlanCuentaRepositorio = configuracionPlanCuentaRepositorio;
        }
        public async Task<List<VProveedor>> ObtenerTodo()
        {
            return await this._proveedoresRepositorio.ObtenerTodoProveedoresRepositorio();
        }
        public async Task<VProveedor> ObtenerUno(int id)
        {
            var proveedor = await this._proveedoresRepositorio.ObtenerUnoproveedorRepositorio(id);
            return proveedor;
        }
        public async Task<CreateProveedorDto> CrearUno()
        {
            var proveedores = await this._proveedoresRepositorio.ObtenerTodoProveedoresRepositorio();
            var codigo = $"prov-00";
            if (proveedores.Count > 0)
            {
                var ultimo = proveedores.Last();
                codigo = $"prov-0{ultimo.id}";
            }
            var resultado = new CreateProveedorDto
            {
                codigo = codigo,
            };
            return resultado;
        }
        public async Task<string> InsertarUno(ProveedorDto proveedorDto)
        {
            var insertar = await this._proveedoresRepositorio.InsertarProveedoresRepositorio(
                new VProveedor
                {
                    codigoProveedor = proveedorDto.codigoProveedor,
                    contacto = proveedorDto.contacto,
                    dirrecion = proveedorDto.dirrecion,
                    id = proveedorDto.id,
                    nombreProveedor = proveedorDto.nombreProveedor,
                    planCuentaId = proveedorDto.planCuentaId,
                    telefono = proveedorDto.telefono.ToString()
                }
            );
            var planCuenta = await this.obtenerConfigPlanProveedores();
            var obtenerConfigProveedor = await this._configuracionPlanCuentaRepositorio.ObtenerUnoConfiguracionPlanCuentaRepositorio(1);
            var nuevoPlanProveedor = await this.InsertarPlanProveedor(
                proveedorDto.nombreProveedor,
                1,
                planCuenta.id,
                0,
                planCuenta.codigo,
                insertar.id.ToString()
            );
            return $"Proveedor registrado correctamente";
        }
        public async Task<EditarDto> EditarUno(int id)
        {
            var proveedor = await this.ObtenerUno(id);
            var planProveedores = await this._vPlanProveedoresRepositorio.ObtenerTodoPlanProveedoresRepositorio();
            var planProveedor = planProveedores.Where(x => x.id == id).FirstOrDefault();
            var monedas = await this._monedaModule.ObtenerTodo();
            int planId = 5; // DATA QUEMADA
            var planCuentas = await this._planCuentaModulo.ObtenerTodoPorVPlanCuentaId(planId);

            var resultado = new EditarDto
            {
                proveedor = new
                {
                    codigoProveedor = proveedor.codigoProveedor,
                    contacto = proveedor.contacto,
                    dirrecion = proveedor.dirrecion,
                    id = proveedor.id,
                    nombreProveedor = proveedor.nombreProveedor,
                    planCuentaId = proveedor.planCuentaId,
                    telefono = proveedor.telefono,
                },
                monedas = monedas,
                planCuentas = planCuentas,
            };
            return resultado;
        }
        private async Task<string> InsertarPlanProveedor(
            string nombre,
            int moneda,
            int VPlanCuentaId,
            int nivel,
            string codigo,
            string identificador
            )
        {
            PlanProveedorDto planProveedorDto = new PlanProveedorDto()
            {
                codigo = $"{codigo}.{identificador}",
                codigoIdentificador = identificador,
                debe = 0,
                haber = 0,
                moneda = "1",
                nivel = nivel + 1,
                nombreCuenta = nombre,
                valor = 0,
                VPlanCuentaId = VPlanCuentaId,
            };
            var planProveedor = await this._planProveedoresModulo.InsertarUno(planProveedorDto);
            return planProveedor;
        }
        public async Task<string> ModificarUno(int id, ProveedorDto proveedorDto)
        {
            var deletePlanProveedor = await this._planProveedoresModulo.EliminarUno(proveedorDto.planCuentaId);
            var proveedor = await this._planCuentaModulo.ObtenerUno(proveedorDto.planCuentaId);
            var ultimoProveedor = await this._planProveedoresModulo.ObtenerUltimo(proveedorDto.planCuentaId);
            ///si no existe
            var codigoIdentificador = 1;
            if (ultimoProveedor != null)
            {
                codigoIdentificador = Convert.ToInt32(ultimoProveedor.CodigoIdentificador) + 1;
            }
            var nuevoPlanProveedor = await this.InsertarPlanProveedor(
                proveedorDto.nombreProveedor,
                1,
                proveedorDto.planCuentaId,
                proveedor.nivel,
                proveedor.codigo,
                codigoIdentificador.ToString()
            );
            var planProveedor = await this._planProveedoresModulo.ObtenerUltimo(proveedorDto.planCuentaId);
            var modificar = await this._proveedoresRepositorio.ModificarProveedoresRepositorio(
                new VProveedor
                {
                    codigoProveedor = proveedorDto.codigoProveedor,
                    contacto = proveedorDto.contacto,
                    dirrecion = proveedorDto.dirrecion,
                    id = id,
                    nombreProveedor = proveedorDto.nombreProveedor,
                    planCuentaId = proveedorDto.planCuentaId,
                    telefono = proveedorDto.telefono.ToString()
                }
            );
            return $"Proveedor registrado correctamente";
        }

        public async Task<string> EliminarUno(int id)
        {
            var eliminar = await this._proveedoresRepositorio.EliminarProveedoresRepositorio(
               id
            );
            if (eliminar > 0)
            {
                return $"Proveedor eliminado correctamente";
            }
            else
            {
                return $"Error no eliminado";
            }
        }
        private async Task<VPlanCuentas> obtenerConfigPlanProveedores()
        {
            var obtenerConfig = await this._configuracionPlanCuentaRepositorio.ObtenerUnoConfiguracionPlanCuentaRepositorio(1);
            var plancuenta = await this._vPlanCuentasRepositorios.ObtenerUnoRepositorio(obtenerConfig.cuentaProveedores);
            return plancuenta;
        }
    }

    public class CreateProveedorDto
    {
        public string codigo { get; set; }
        public List<VMoneda> monedas { get; set; }
        public List<VPlanCuentas> planCuentas { get; set; }
    }
    public class EditarDto
    {
        public object proveedor { get; set; }
        public List<VMoneda> monedas { get; set; }
        public List<VPlanCuentas> planCuentas { get; set; }
    }
}