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
        public async Task<List<VPlanCuentas>> ObtenerTodoPorVPlanCuentaId(int VPlanCuentaId)
        {
            return await this._vPlanCuentasRepositorios.ObtenerTodoPlanCuentasPorPadreIdRepositorio(VPlanCuentaId);
        }
        public async Task<VPlanCuentas> ObtenerUno(int id)
        {
            var plancuenta = await this._vPlanCuentasRepositorios.ObtenerUnoRepositorio(id);
            return plancuenta;
        }
        public async Task<GeneracionCodigo> CreateUno(int nivel, int padre)
        {
            if (padre == 0)
            {
                return await this.CreateUnoPadre(nivel, padre);
            }
            else
            {
                return await this.CreateUnoHijo(nivel, padre);
            }
        }
        public async Task<GeneracionCodigo> CreateUnoPadre(int nivel, int padre)
        {
            var plancuentas = new List<VPlanCuentas>();
            plancuentas = await this._vPlanCuentasRepositorios.ObtenerUltimoPlanRepositorio(nivel);
            var plancuenta = plancuentas.FirstOrDefault();
            var resultado = new GeneracionCodigo();
            if (plancuenta == null)
            {
                resultado.codigo = "1000000";
                resultado.nivel = nivel;
            }
            else
            {
                resultado.codigo = this.IdentificarNivel(Convert.ToInt32(plancuenta.codigo), nivel);
                resultado.nivel = nivel;
            }
            return resultado;
        }
        public async Task<GeneracionCodigo> CreateUnoHijo(int nivel, int padre)
        {
            nivel = nivel + 1;
            var plancuentas = await this._vPlanCuentasRepositorios.ObtenerUltimoPlanPadreIdRepositorio(padre, nivel);
            var plancuenta = plancuentas.FirstOrDefault();
            var resultado = new GeneracionCodigo();
            if (plancuenta == null)
            {
                var nuevo = await this.ObtenerUno(padre);
                resultado.codigo = this.IdentificarNivel(Convert.ToInt32(nuevo.codigo), nivel);
                resultado.nivel = nivel;
            }
            else
            {

                resultado.codigo = this.IdentificarNivel(Convert.ToInt32(plancuenta.codigo), nivel);
                resultado.nivel = nivel;
            }
            return resultado;
        }
        private string IdentificarNivel(int valor, int nivel)
        {
            int resultado = 1000000;
            switch (nivel)
            {
                case 0:
                    resultado = valor + 1000000;
                    break;
                case 1:
                    resultado = valor + 100000;
                    break;
                case 2:
                    resultado = valor + 10000;
                    break;
                case 3:
                    resultado = valor + 1000;
                    break;
                case 4:
                    resultado = valor + 1;
                    break;
                default:
                    break;
            }
            return resultado.ToString();
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
    public class GeneracionCodigo
    {
        public string codigo { get; set; }
        public int nivel { get; set; }
    }
}