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
        private readonly MonedaModule _monedaModule;

        public ProveedoresModulo(
            ProveedoresRepositorio proveedoresRepositorio,
            PlanProveedoresModulo planProveedoresModulo,
            PlanCuentaModulo planCuentaModulo,
            MonedaModule monedaModule
        )
        {
            this._proveedoresRepositorio = proveedoresRepositorio;
            this._planProveedoresModulo = planProveedoresModulo;
            this._planCuentaModulo = planCuentaModulo;
            this._monedaModule = monedaModule;
        }
        public async Task<List<VProveedor>> ObtenerTodo()
        {
            return await this._proveedoresRepositorio.ObtenerTodoProveedoresRepositorio();
        }
        public async Task<VProveedor> ObtenerUno(int id)
        {
            var proveedores = await this._proveedoresRepositorio.ObtenerUnoproveedorRepositorio(id);
            var proveedor = proveedores.FirstOrDefault();
            return proveedor;
        }
        public async Task<CreateDto> CrearUno()
        {
            var proveedores = await this._proveedoresRepositorio.ObtenerTodoProveedoresRepositorio();
            var monedas = await this._monedaModule.ObtenerTodo();
            int planId = 5; // DATA QUEMADA
            var planCuentas = await this._planCuentaModulo.ObtenerTodoPorVPlanCuentaId(planId);
            var codigo = $"prov-00";
            if (proveedores.Count > 0)
            {
                var ultimo = proveedores.Last();
                codigo = $"prov-0{ultimo.id}";
            }
            var resultado = new CreateDto
            {
                codigo = codigo,
                monedas = monedas,
                planCuentas = planCuentas,
            };
            return resultado;
        }
        public async Task<string> InsertarUno(ProveedorDto proveedorDto)
        {

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
                proveedorDto.moneda,
                proveedorDto.planCuentaId,
                proveedor.nivel,
                proveedor.codigo,
                codigoIdentificador.ToString()
            );
            var planProveedor = await this._planProveedoresModulo.ObtenerUltimo(proveedorDto.planCuentaId);
            var insertar = await this._proveedoresRepositorio.InsertarProveedoresRepositorio(
                proveedorDto.codigoProveedor,
                proveedorDto.nombreProveedor,
                proveedorDto.dirrecion,
                proveedorDto.credito,
                proveedorDto.telefono,
                planProveedor.id
            );
            return $"Proveedor registrado correctamente";
        }
        public async Task<EditarDto> EditarUno(int id)
        {
            var proveedor = await this.ObtenerUno(id);
            var planProveedor = await this._planProveedoresModulo.ObtenerUno(proveedor.planCuentaId);

            var monedas = await this._monedaModule.ObtenerTodo();
            int planId = 5; // DATA QUEMADA
            var planCuentas = await this._planCuentaModulo.ObtenerTodoPorVPlanCuentaId(planId);

            var resultado = new EditarDto
            {
                proveedor = new
                {
                    codigoProveedor = proveedor.codigoProveedor,
                    credito = proveedor.credito,
                    dirrecion = proveedor.dirrecion,
                    id = proveedor.id,
                    nombreProveedor = proveedor.nombreProveedor,
                    planCuentaId = proveedor.planCuentaId,
                    telefono = proveedor.telefono,
                    moneda = planProveedor.moneda
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
                moneda = moneda.ToString(),
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
                proveedorDto.moneda,
                proveedorDto.planCuentaId,
                proveedor.nivel,
                proveedor.codigo,
                codigoIdentificador.ToString()
            );
            var planProveedor = await this._planProveedoresModulo.ObtenerUltimo(proveedorDto.planCuentaId);
            var modificar = await this._proveedoresRepositorio.ModificarProveedoresRepositorio(
                id,
                proveedorDto.codigoProveedor,
                proveedorDto.nombreProveedor,
                proveedorDto.dirrecion,
                proveedorDto.credito,
                proveedorDto.telefono,
                planProveedor.id
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
    }
    public class CreateDto
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