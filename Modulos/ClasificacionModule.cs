using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class ClasificacionModule
    {
        private readonly ILogger<ClasificacionModule> _logger;
        private readonly VClasificacionRepositorio _vClasificacionRepositorio;

        public ClasificacionModule(
            ILogger<ClasificacionModule> logger,
            VClasificacionRepositorio vClasificacionRepositorio
        )
        {
            this._logger = logger;
            this._vClasificacionRepositorio = vClasificacionRepositorio;
        }
        public async Task<List<ClasificacionLista>> ObtenerTodo()
        {
            var clasificaciones = await this._vClasificacionRepositorio.ObtenerTodoClasificacionRepositorio();
            //order por clasificacion
            var resultado = new List<ClasificacionLista>();
            foreach (var clasificacion in clasificaciones)
            {
                var padre = await this.ObtenerUno(clasificacion.clasificacionId);
                resultado.Add(
                    new ClasificacionLista
                    {
                        caracteristicas = clasificacion.caracteristicas,
                        clasificacionId = clasificacion.clasificacionId,
                        id = clasificacion.id,
                        nombreClasificacion = clasificacion.nombreClasificacion,
                        nombreClasificacionPadre = padre == null ? "" : padre.nombreClasificacion
                    }
                );
            }
            return resultado.OrderBy(x => x.id).ToList();
        }
        public async Task<VClasificacion> ObtenerUno(int id)
        {
            var clasificacion = await this._vClasificacionRepositorio.ObtenerUnoClasificacionRepositorio(id);
            return clasificacion;
        }
        public async Task<List<VClasificacion>> ObtenerUnoPadreId(int id)
        {
            var clasificacionesLista = await this._vClasificacionRepositorio.ObtenerTodoClasificacionRepositorio();
            var clasificaciones = clasificacionesLista.Where(x => x.clasificacionId == id).ToList();
            return clasificaciones;
        }
        public async Task<object> CrearUno()
        {
            var clasificacion = await this._vClasificacionRepositorio.ObtenerTodoClasificacionRepositorio();
            var resultado = new
            {
                clasificacion = clasificacion
            };
            return resultado;
        }
        public async Task<string> InsertarUno(ClasificacionDto ClasificacionDto)
        {
            if (await this.validarExiste(ClasificacionDto.nombreClasificacion))
            {
                var insert = await this._vClasificacionRepositorio.InsertarClasificacionRepositorio(new VClasificacion
                {
                    caracteristicas = ClasificacionDto.caracteristicas,
                    nombreClasificacion = ClasificacionDto.nombreClasificacion,
                    clasificacionId = ClasificacionDto.clasificacionId
                });
                return "Clasificacion creado correctamente";
            }
            else
            {
                return "Ya existe";
            }
        }
        public async Task<object> EditarUno(int id)
        {
            var resultado = new
            {
                clasificaciones = await this.ObtenerTodo(),
                clasificacion = await this._vClasificacionRepositorio.ObtenerUnoClasificacionRepositorio(id)
            };
            return resultado;
        }
        public async Task<string> ModificarUno(int id, ClasificacionDto ClasificacionDto)
        {
            if (await this.validarExiste(ClasificacionDto.nombreClasificacion, id))
            {
                var Clasificacion = await this._vClasificacionRepositorio.ModificarClasificacionRepositorio(new VClasificacion
                {
                    caracteristicas = ClasificacionDto.caracteristicas,
                    clasificacionId = ClasificacionDto.clasificacionId,
                    nombreClasificacion = ClasificacionDto.nombreClasificacion,
                    id = id
                });
                return "Clasificacion modificado correctamente";
            }
            else
            {
                return "Ya existe";
            }
        }

        public async Task<string> EliminarUno(int id)
        {
            var cliente = await this._vClasificacionRepositorio.EliminarClasificacionRepositorio(id);
            return $"Cliente eliminado correctamente";
        }
        /*validaciones*/
        private async Task<bool> validarExiste(string nombreClasificacion, int id = 0)
        {
            var clasificaciones = await this._vClasificacionRepositorio.ObtenerTodoClasificacionRepositorio();
            var validate = clasificaciones.Where(x => x.nombreClasificacion == nombreClasificacion && x.id != id).Any();
            if (!validate)
            {
                //no existe
                return true;
            }
            else
            {
                //ya existe
                return false;
            }
        }
    }
    public class ClasificacionLista
    {
        public int id { get; set; }
        public string nombreClasificacion { get; set; }
        public string caracteristicas { get; set; }
        public int clasificacionId { get; set; }
        public string nombreClasificacionPadre { get; set; }
    }
}