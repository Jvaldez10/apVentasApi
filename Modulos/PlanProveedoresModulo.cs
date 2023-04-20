using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class PlanProveedoresModulo
    {
        private readonly VPlanProveedoresRepositorio _vPlanProveedoresRepositorio;

        public PlanProveedoresModulo(
            VPlanProveedoresRepositorio vPlanProveedoresRepositorio
        )
        {
            this._vPlanProveedoresRepositorio = vPlanProveedoresRepositorio;
        }
        public async Task<List<VPlanProveedores>> ObtenerTodo()
        {
            return await this._vPlanProveedoresRepositorio.ObtenerTodoPlanProveedoresRepositorio();
        }
        public async Task<VPlanProveedores> ObtenerUno(int id)
        {
            var planProveedores = await this._vPlanProveedoresRepositorio.ObtenerUnoPlanProveedoresRepositorio(id);
            var planProveedor = planProveedores.FirstOrDefault();
            return planProveedor;
        }
        public async Task<VPlanProveedores> ObtenerUltimo(int VPlanCuentaId)
        {
            var planProveedores = await this._vPlanProveedoresRepositorio.ObtenerUltimoPlanProveedoresRepositorio(VPlanCuentaId);
            var planProveedor = planProveedores.FirstOrDefault();
            return planProveedor;
        }
        public async Task<string> CrearUno()
        {
            var planProveedores = await this._vPlanProveedoresRepositorio.ObtenerTodoPlanProveedoresRepositorio();

            if (planProveedores.Count > 0)
            {
                var proveedor = planProveedores.Last();
                return $"prov-0{proveedor.id}";
            }
            else
            {
                return $"prov-00";
            }
        }
        public async Task<string> InsertarUno(PlanProveedorDto planProveedorDto)
        {
            var insertar = await this._vPlanProveedoresRepositorio.InsertarPlanProveedoresRepositorio(
                planProveedorDto.codigo,
                planProveedorDto.nombreCuenta,
                planProveedorDto.moneda,
                planProveedorDto.valor,
                planProveedorDto.codigoIdentificador,
                planProveedorDto.nivel,
                planProveedorDto.debe,
                planProveedorDto.haber,
                planProveedorDto.VPlanCuentaId
            );
            if (insertar > 0)
            {
                return $"Cuenta registrado correctamente";
            }
            else
            {
                return $"Error no registrado";
            }
        }

        public async Task<string> ModificarUno(int id, PlanProveedorDto planProveedorDto)
        {
            var modificar = await this._vPlanProveedoresRepositorio.ModificarPlanProveedoresRepositorio(
                id,
                planProveedorDto.codigo,
                planProveedorDto.nombreCuenta,
                planProveedorDto.moneda,
                planProveedorDto.valor,
                planProveedorDto.codigoIdentificador,
                planProveedorDto.nivel,
                planProveedorDto.debe,
                planProveedorDto.haber,
                planProveedorDto.VPlanCuentaId
           );
            if (modificar > 0)
            {
                return $"Cuenta modificado correctamente";
            }
            else
            {
                return $"Error no modificado";
            }
        }

        public async Task<string> EliminarUno(int id)
        {
            var eliminar = await this._vPlanProveedoresRepositorio.EliminarPlanProveedoresRepositorio(
               id
            );
            if (eliminar > 0)
            {
                return $"cuenta eliminado correctamente";
            }
            else
            {
                return $"Error no eliminado";
            }
        }
    }
}