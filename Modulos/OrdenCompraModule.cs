using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Entidades.Querys;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class OrdenCompraModule
    {
        private readonly ILogger<OrdenCompraModule> logger;
        private readonly TipoAsientoRespositorio _tipoAsientoRespositorio;
        private readonly VPlanCuentasRepositorios _vPlanCuentasRepositorios;

        public OrdenCompraModule(
            ILogger<OrdenCompraModule> logger,
            TipoAsientoRespositorio tipoAsientoRespositorio,
            VPlanCuentasRepositorios vPlanCuentasRepositorios
        )
        {
            this.logger = logger;
            this._tipoAsientoRespositorio = tipoAsientoRespositorio;
            this._vPlanCuentasRepositorios = vPlanCuentasRepositorios;
        }
        public async Task<string> GuardarOrdenCompra(OrdenCompraDto ordenCompraDto)
        {
            var resultado = await this.ProcesoVenta(ordenCompraDto);
            return resultado;
        }
        public async Task<string> ProcesoVenta(OrdenCompraDto ordenCompraDto)
        {
            var obtenerTodoTipoAsiento = await this._tipoAsientoRespositorio.ObtenerAsientoRepositorio(ordenCompraDto.tipoAsientoId);
            foreach (var cuenta in obtenerTodoTipoAsiento)
            {
                //cuenta.planCuentaId
                var planCuenta = await this._vPlanCuentasRepositorios.ObtenerUnoRepositorio(cuenta.planCuentaId);

                PropertyInfo[] propiedades = planCuenta.GetType().GetProperties();
                var modificar = await this._vPlanCuentasRepositorios.ModificarPlanCuentaRepositorio(
                    new VPlanCuentas
                    {
                        codigo = planCuenta.codigo,
                        codigoIdentificador = planCuenta.codigoIdentificador,
                        debe = this.identificarEgresoIngreso(cuenta.rol, propiedades[7].Name, planCuenta.debe, ordenCompraDto.precioTotal),
                        haber = this.identificarEgresoIngreso(cuenta.rol, propiedades[8].Name, planCuenta.haber, ordenCompraDto.precioTotal),
                        id = planCuenta.id,
                        moneda = planCuenta.moneda,
                        nivel = planCuenta.nivel,
                        nombreCuenta = planCuenta.nombreCuenta,
                        valor = planCuenta.valor,
                        VPlanCuentaId = planCuenta.VPlanCuentaId,
                    }
                );
            }
            return "Proceso registrado";
        }
        private decimal identificarEgresoIngreso(string rol, string propiedad, decimal valorAntiguo, decimal valorNuevo)
        {
            if (propiedad == rol)
            {
                return valorAntiguo + valorNuevo;
            }
            else
            {
                return valorAntiguo;
            }
        }
    }
}