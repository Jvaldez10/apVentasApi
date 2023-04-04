using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class PlanCuentaModulo
    {
        private readonly VPlanCuentasRepositorios _vPlanCuentasRepositorios;
        private readonly ILogger<PlanCuentaModulo> _logger;

        public PlanCuentaModulo(
            VPlanCuentasRepositorios vPlanCuentasRepositorios,
            ILogger<PlanCuentaModulo> logger
        )
        {
            this._vPlanCuentasRepositorios = vPlanCuentasRepositorios;
            this._logger = logger;
        }
        public async Task<List<VPlanCuentas>> ObtenerTodo()
        {
            return await this._vPlanCuentasRepositorios.ObtenerTodoPlanCuentasRepositorio();
        }
        public async Task<VPlanCuentas> ObtenerUno(int id)
        {
            var proveedores = await this._vPlanCuentasRepositorios.ObtenerUnoTodoPlanCuentasRepositorio(id);
            var proveedor = proveedores.FirstOrDefault();
            return proveedor;
        }
        public async Task<string> InsertarUno(planCuentaDto planCuentaDto)
        {
            var insertar = await this._vPlanCuentasRepositorios.InsertarPlanCuentasRepositorio(
                planCuentaDto.codigo,
                planCuentaDto.nombreCuenta,
                planCuentaDto.moneda,
                planCuentaDto.valor,
                planCuentaDto.codigoIdentificador,
                planCuentaDto.nivel,
                planCuentaDto.debe,
                planCuentaDto.haber,
                planCuentaDto.VPlanCuentaId
            );
            if (insertar > 0)
            {
                return $"Plan cuenta registrado correctamente";
            }
            else
            {
                return $"Error no registrado";
            }
        }

        public async Task<string> ModificarUno(int id, planCuentaDto planCuentaDto)
        {
            var modificar = await this._vPlanCuentasRepositorios.ModificarPlanCuentasRepositorio(
                id,
                planCuentaDto.codigo,
                planCuentaDto.nombreCuenta,
                planCuentaDto.moneda,
                planCuentaDto.valor,
                planCuentaDto.codigoIdentificador,
                planCuentaDto.nivel,
                planCuentaDto.debe,
                planCuentaDto.haber,
                planCuentaDto.VPlanCuentaId
           );
            if (modificar > 0)
            {
                return $"Plan cuenta modificado correctamente";
            }
            else
            {
                return $"Error no modificado";
            }
        }

        public async Task<string> EliminarUno(int id)
        {
            var eliminar = await this._vPlanCuentasRepositorios.EliminarPlanCuentasRepositorio(
               id
            );
            if (eliminar > 0)
            {
                return $"Plan cuenta eliminado correctamente";
            }
            else
            {
                return $"Error no eliminado";
            }
        }
    }
}