using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class PlanProductoModulo
    {
        private readonly VPlanProductoRepositorio _vPlanProductoRepositorio;

        public PlanProductoModulo(
            VPlanProductoRepositorio vPlanProductoRepositorio
        )
        {
            this._vPlanProductoRepositorio = vPlanProductoRepositorio;
        }
        public async Task<List<VPlanProductos>> ObtenerTodo()
        {
            return await this._vPlanProductoRepositorio.ObtenerTodoPlanProductosRepositorio();
        }
        public async Task<VPlanProductos> ObtenerUno(int id)
        {
            var planProductos = await this._vPlanProductoRepositorio.ObtenerUnoPlanProductosRepositorio(id);
            var planProducto = planProductos.FirstOrDefault();
            return planProducto;
        }
        public async Task<string> CrearUno()
        {
            var planProveedores = await this._vPlanProductoRepositorio.ObtenerTodoPlanProductosRepositorio();

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
        public async Task<string> InsertarUno(PlanProductoDto planProductoDto)
        {
            var insertar = await this._vPlanProductoRepositorio.InsertarPlanProductosRepositorio(
                planProductoDto.codigo,
                planProductoDto.nombreCuenta,
                planProductoDto.moneda,
                planProductoDto.valor,
                planProductoDto.codigoIdentificador,
                planProductoDto.nivel,
                planProductoDto.debe,
                planProductoDto.haber,
                planProductoDto.VPlanCuentaId
            );
            if (insertar > 0)
            {
                return $"Cuenta producto registrado correctamente";
            }
            else
            {
                return $"Error no registrado";
            }
        }

        public async Task<string> ModificarUno(int id, PlanProductoDto planProductoDto)
        {
            var modificar = await this._vPlanProductoRepositorio.ModificarPlanProductosRepositorio(
                id,
                planProductoDto.codigo,
                planProductoDto.nombreCuenta,
                planProductoDto.moneda,
                planProductoDto.valor,
                planProductoDto.codigoIdentificador,
                planProductoDto.nivel,
                planProductoDto.debe,
                planProductoDto.haber,
                planProductoDto.VPlanCuentaId
           );
            if (modificar > 0)
            {
                return $"Cuenta producto modificado correctamente";
            }
            else
            {
                return $"Error no modificado";
            }
        }

        public async Task<string> EliminarUno(int id)
        {
            var eliminar = await this._vPlanProductoRepositorio.EliminarPlanProductosRepositorio(
               id
            );
            if (eliminar > 0)
            {
                return $"cuenta producto eliminado correctamente";
            }
            else
            {
                return $"Error no eliminado";
            }
        }
    }
}