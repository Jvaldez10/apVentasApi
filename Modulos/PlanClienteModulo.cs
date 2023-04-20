using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class PlanClienteModulo
    {
        private readonly ILogger<PlanClienteModulo> _logger;
        private readonly VPlanClienteRepositorio _vPlanClienteRepositorio;

        public PlanClienteModulo(
            ILogger<PlanClienteModulo> logger,
            VPlanClienteRepositorio vPlanClienteRepositorio
        )
        {
            this._logger = logger;
            this._vPlanClienteRepositorio = vPlanClienteRepositorio;
        }


        public async Task<VPlanClientes> ObtenerUno(int id)
        {
            return await this._vPlanClienteRepositorio.ObtenerUnoPlanClientesRepositorio(id);
        }
       
    }
}