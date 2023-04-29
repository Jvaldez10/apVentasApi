using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class TipoAsientoModule
    {
        private readonly ILogger<TipoAsientoModule> _logger;
        private readonly TipoAsientoRespositorio _tipoAsientoRespositorio;

        public TipoAsientoModule(
            ILogger<TipoAsientoModule> logger,
            TipoAsientoRespositorio tipoAsientoRespositorio
        )
        {
            this._logger = logger;
            this._tipoAsientoRespositorio = tipoAsientoRespositorio;
        }
        public async Task<List<TipoAsiento>> ObtenerTodo()
        {
            var tipoAsiento = await this._tipoAsientoRespositorio.ObtenerTodoTipoAsientoRepositorio();
            return tipoAsiento;
        }
        public async Task<List<TipoAsiento>> CrearUno()
        {
            var tipoAsiento = await this._tipoAsientoRespositorio.ObtenerTodoTipoAsientoRepositorio();
            return tipoAsiento;
        }
        public async Task<bool> GuardarUno(TipoAsientoDto tipoAsientoDto)
        {
            var tipoAsiento = await this._tipoAsientoRespositorio.InsertarTipoAsientoRepositorio(
               new TipoAsiento
               {
                   nombreTipoAsiento = tipoAsientoDto.nombreTipoAsiento
               }
            );
            if (tipoAsiento.id > 0)
            {
                return true;
            }
            else
            {
                throw new Exception("Error al registrar");
            }
        }
        public async Task<TipoAsiento> EditarUno(int id)
        {
            var tipoAsiento = await this._tipoAsientoRespositorio.ObtenerUnoTipoAsientoRepositorio(id);
            if (tipoAsiento != null)
            {
                return tipoAsiento;
            }
            else
            {
                throw new Exception("No exite");
            }
        }
        public async Task<bool> ModificarUno(int id, TipoAsientoDto tipoAsientoDto)
        {
            var tipoAsiento = await this._tipoAsientoRespositorio.ModificarTipoAsientoRepositorio(
                new TipoAsiento
                {
                    id = id,
                    nombreTipoAsiento = tipoAsientoDto.nombreTipoAsiento
                }
            );
          
            return true;
        }
        public async Task<List<TipoAsiento>> EliminarUno()
        {
            var tipoAsiento = await this._tipoAsientoRespositorio.ObtenerTodoTipoAsientoRepositorio();
            return tipoAsiento;
        }
    }
}