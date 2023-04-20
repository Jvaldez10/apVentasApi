using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Repositorio;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Modulos
{
    public class NivelModule
    {
          private readonly VNivelRepositorio _vNivelRepositorio;

        public NivelModule(
            VNivelRepositorio vNivelRepositorio
        )
        {
            this._vNivelRepositorio = vNivelRepositorio;
        }
        public async Task<List<VNivel>> ObtenerTodo()
        {
            return await this._vNivelRepositorio.ObtenerTodoNivelRepositorio();
        }
        public async Task<VNivel> ObtenerUno(int id)
        {
            var niveles = await this._vNivelRepositorio.ObtenerUnoAlmacenRepositorio(id);
            var nivel = niveles.FirstOrDefault();
            return nivel;
        }
        public async Task<string> CrearUno()
        {
            var proveedores = await this._vNivelRepositorio.ObtenerTodoNivelRepositorio();

            if (proveedores.Count > 0)
            {
                var proveedor = proveedores.Last();
                return $"prov-0{proveedor.id}";
            }
            else
            {
                return $"prov-00";
            }

        }
        public async Task<string> InsertarUno(NivelDto nivelDto)
        {
            var insertar = await this._vNivelRepositorio.InsertarNivelRepositorio(
                nivelDto.nombreNivel
            );
            if (insertar > 0)
            {
                return $"Nivel registrado correctamente";
            }
            else
            {
                return $"Error no registrado";
            }
        }

        public async Task<string> ModificarUno(int id, MonedaDto monedaDto)
        {
            var modificar = await this._vNivelRepositorio.ModificarNivelRepositorio(
                id,
                monedaDto.nombreMoneda
            );
            if (modificar > 0)
            {
                return $"Nivel modificado correctamente";
            }
            else
            {
                return $"Error no modificado";
            }
        }

        public async Task<string> EliminarUno(int id)
        {
            var eliminar = await this._vNivelRepositorio.EliminarNivelRepositorio(
               id
            );
            if (eliminar > 0)
            {
                return $"Nivel eliminado correctamente";
            }
            else
            {
                return $"Error no eliminado";
            }
        }
    }
}