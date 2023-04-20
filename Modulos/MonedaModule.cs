using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class MonedaModule
    {
        private readonly VMonedaRepositorio _vMonedaRepositorio;

        public MonedaModule(
            VMonedaRepositorio vMonedaRepositorio
        )
        {
            this._vMonedaRepositorio = vMonedaRepositorio;
        }
        public async Task<List<VMoneda>> ObtenerTodo()
        {
            return await this._vMonedaRepositorio.ObtenerTodoMonedaRepositorio();
        }
        public async Task<VMoneda> ObtenerUno(int id)
        {
            var monedas = await this._vMonedaRepositorio.ObtenerUnoMonedaRepositorio(id);
            var moneda = monedas.FirstOrDefault();
            return moneda;
        }
        public async Task<string> CrearUno()
        {
            var proveedores = await this._vMonedaRepositorio.ObtenerTodoMonedaRepositorio();

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
        public async Task<string> InsertarUno(MonedaDto monedaDto)
        {
            var insertar = await this._vMonedaRepositorio.InsertarMonedaRepositorio(
                monedaDto.nombreMoneda

            );
            if (insertar > 0)
            {
                return $"Moneda registrado correctamente";
            }
            else
            {
                return $"Error no registrado";
            }
        }

        public async Task<string> ModificarUno(int id, MonedaDto monedaDto)
        {
            var modificar = await this._vMonedaRepositorio.ModificarMonedaRepositorio(
                id,
                monedaDto.nombreMoneda
            );
            if (modificar > 0)
            {
                return $"Moneda modificado correctamente";
            }
            else
            {
                return $"Error no modificado";
            }
        }

        public async Task<string> EliminarUno(int id)
        {
            var eliminar = await this._vMonedaRepositorio.EliminarMonedaRepositorio(
               id
            );
            if (eliminar > 0)
            {
                return $"Moneda eliminado correctamente";
            }
            else
            {
                return $"Error no eliminado";
            }
        }
    }
}