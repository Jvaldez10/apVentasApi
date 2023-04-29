using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class ConfiguracionInicialModule
    {
        private readonly ILogger<ConfiguracionInicialModule> _logger;
        private readonly ConfiguracionPlanCuentaRepositorio _configuracionPlanCuentaRepositorio;

        public ConfiguracionInicialModule(
            ILogger<ConfiguracionInicialModule> logger,
            ConfiguracionPlanCuentaRepositorio configuracionPlanCuentaRepositorio

        )
        {
            this._logger = logger;
            this._configuracionPlanCuentaRepositorio = configuracionPlanCuentaRepositorio;
        }
        public async Task<bool> ModificarConguracionPlanes(ConfiguracionPlanCuentaDto configuracionPlanCuentaDto)
        {
            var insert = await this._configuracionPlanCuentaRepositorio.ModificarConfiguracionPlanCuentaRepositorio(
                new ConfiguracionPlanCuenta
                {
                    cuentaClientes = configuracionPlanCuentaDto.planCuentaIdCliente,
                    cuentaProducto = configuracionPlanCuentaDto.planCuentaIdProducto,
                    cuentaProveedores = configuracionPlanCuentaDto.planCuentaIdProveedor,
                    cuentaVendedores = configuracionPlanCuentaDto.planCuentaIdVendedor,
                }
            );
            if (insert.id == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> EditarConfiguracionPlanes(ConfiguracionPlanCuentaDto configuracionPlanCuentaDto)
        {
            var insert = await this._configuracionPlanCuentaRepositorio.ModificarConfiguracionPlanCuentaRepositorio(
                new ConfiguracionPlanCuenta
                {
                    cuentaClientes = configuracionPlanCuentaDto.planCuentaIdCliente,
                    cuentaProducto = configuracionPlanCuentaDto.planCuentaIdProducto,
                    cuentaProveedores = configuracionPlanCuentaDto.planCuentaIdProveedor,
                    cuentaVendedores = configuracionPlanCuentaDto.planCuentaIdVendedor,
                }
            );
            if (insert.id == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}