using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Entidades.Querys;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class AsientoPlanCuentaModule
    {
        private readonly ILogger<AsientoPlanCuentaModule> _logger;
        private readonly AsientoPlanCuentaRespositorio _asientoPlanCuentaRespositorio;
        private readonly TipoAsientoRespositorio _tipoAsientoRespositorio;

        public AsientoPlanCuentaModule(
            ILogger<AsientoPlanCuentaModule> logger,
            AsientoPlanCuentaRespositorio asientoPlanCuentaRespositorio,
            TipoAsientoRespositorio tipoAsientoRespositorio
        )
        {
            this._logger = logger;
            this._asientoPlanCuentaRespositorio = asientoPlanCuentaRespositorio;
            this._tipoAsientoRespositorio = tipoAsientoRespositorio;
        }
        public async Task<List<ObtenerTipoAsiento>> ObtenerTodoAsientoPlanCuenta(int TipoAsientoId)
        {
            var listaAsiento = await this._tipoAsientoRespositorio.ObtenerAsientoRepositorio(TipoAsientoId);

            return listaAsiento;
        }
        public async Task<List<ListaAsiento>> CreateAsientoPlanCuenta()
        {
            var listTipoAsiento = await this._tipoAsientoRespositorio.ObtenerTodoTipoAsientoRepositorio();
            var tipoAsiento = listTipoAsiento.Select(x => new
            {
                id = x.id,
                nombreTipoAsiento = x.nombreTipoAsiento
            }).ToList();
            var resultado = new List<ListaAsiento>();
            return resultado;
        }
        public async Task<string> StoreAsientoPlanCuenta(AsientoPlanCuentaDto asientoPlanCuentaDto)
        {
            var insert = await this._asientoPlanCuentaRespositorio.InsertarAsientoPlanCuentaRepositorio(
                new AsientoPlanCuenta
                {
                    rol = asientoPlanCuentaDto.rol,
                    asientoId = asientoPlanCuentaDto.asientoId,
                    VPlanCuentaId = asientoPlanCuentaDto.VPlanCuentaId
                });
            if (insert.id != 0)
            {
                return "Cuentas configurada correctamente";
            }
            else
            {
                return "A ocurrido un error";
            }
        }
    }
}