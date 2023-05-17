using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class AsientoModule
    {
        private readonly ILogger<AsientoModule> _logger;
        private readonly AsientoRespositorio _asientoRespositorio;
        private readonly TipoAsientoRespositorio _tipoAsientoRespositorio;
        private readonly VPlanCuentasRepositorios _vPlanCuentasRepositorios;
        private readonly AsientoPlanCuentaRespositorio _asientoPlanCuentaRespositorio;

        public AsientoModule(
            ILogger<AsientoModule> logger,
            AsientoRespositorio asientoRespositorio,
            TipoAsientoRespositorio tipoAsientoRespositorio,
            VPlanCuentasRepositorios vPlanCuentasRepositorios,
            AsientoPlanCuentaRespositorio asientoPlanCuentaRespositorio
        )
        {
            this._logger = logger;
            this._asientoRespositorio = asientoRespositorio;
            this._tipoAsientoRespositorio = tipoAsientoRespositorio;
            this._vPlanCuentasRepositorios = vPlanCuentasRepositorios;
            this._asientoPlanCuentaRespositorio = asientoPlanCuentaRespositorio;
        }
        public async Task<List<ListaAsiento>> ObtenerTodoAsiento()
        {
            var listaAsiento = await this._asientoRespositorio.ObtenerTodoAsientoRepositorio();
            var tipoAsiento = await this._tipoAsientoRespositorio.ObtenerTodoTipoAsientoRepositorio();
            var resultado = new List<ListaAsiento>();
            foreach (var asiento in listaAsiento)
            {
                resultado.Add(
                    new ListaAsiento
                    {
                        asientoId = asiento.id,
                        nombreAsiento = asiento.nombreAsiento,
                        nombreTipoAsiento = tipoAsiento.Where(x => x.id == asiento.tipoasientoId).FirstOrDefault().nombreTipoAsiento,
                        tipoAsientoId = asiento.tipoasientoId
                    });
            }
            return resultado;
        }
        public async Task<object> CreateAsiento()
        {
            var listTipoAsiento = await this._tipoAsientoRespositorio.ObtenerTodoTipoAsientoRepositorio();
            var tipoAsiento = listTipoAsiento.Select(x => new
            {
                id = x.id,
                nombreTipoAsiento = x.nombreTipoAsiento
            }).ToList();
            var listaPlanCuenta = await this._vPlanCuentasRepositorios.ObtenerTodoPlanCuentasRepositorio();
            var PlanCuenta = listaPlanCuenta.Select(x => new
            {
                id = x.id,
                nombreCuenta = x.nombreCuenta,
                codigo = x.codigo
            }).ToList();
            var rol = new List<object>(){
                new {
                    id="haber",
                    rol="haber"
                },
                new {
                    id="debe",
                    rol="debe"
                }
            };
            var resultado = new
            {
                tipoAsiento = tipoAsiento,
                planCuenta = PlanCuenta,
                rol = rol
            };
            return resultado;
        }
        public async Task<string> StoreAsiento(AsientoDto asientoDto)
        {
            var insert = await this._asientoRespositorio.InsertarAsientoRepositorio(new Asiento
            {
                nombreAsiento = asientoDto.nombreAsiento,
                tipoasientoId = asientoDto.tipoAsientoId
            });
            if (asientoDto.cuentas.Count > 0)
            {
                if (this.validador(asientoDto.cuentas) != "")
                {
                    throw new Exception(this.validador(asientoDto.cuentas));
                }
            }
            else
            {
                throw new Exception("Error debe registrar un plan de cuenta");
            }
            if (insert.id == 0)
            {
                throw new Exception("Error al crear Asiento");
            }

            //insert plan cuentas
            foreach (var cuenta in asientoDto.cuentas)
            {
                await this._asientoPlanCuentaRespositorio.InsertarAsientoPlanCuentaRepositorio(
                new AsientoPlanCuenta
                {
                    asientoId = insert.id,
                    rol = cuenta.rol,
                    VPlanCuentaId = cuenta.VPlanCuentaId
                });
            }
            return "Asiento añadido correctamente";
        }
        private string validador(List<cuentasDto> cuentas)
        {
            string resultado = "";
            foreach (var cuenta in cuentas)
            {
                if (cuenta.VPlanCuentaId == 0)
                {
                    resultado = "Error selecione una cuenta";
                }
                else
                {
                    resultado = "";
                }
            }
            return resultado;
        }
    }
    public class ListaAsiento
    {
        public int tipoAsientoId { get; set; }
        public int asientoId { get; set; }
        public string nombreTipoAsiento { get; set; }
        public string nombreAsiento { get; set; }
    }
}