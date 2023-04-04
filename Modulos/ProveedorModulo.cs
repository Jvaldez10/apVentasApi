using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{

    public class ProveedoresModulo
    {
        private readonly ProveedoresRepositorio _proveedoresRepositorio;

        public ProveedoresModulo(
            ProveedoresRepositorio proveedoresRepositorio
        )
        {
            this._proveedoresRepositorio = proveedoresRepositorio;
        }
        public async Task<List<VProveedor>> ObtenerTodo()
        {
            return await this._proveedoresRepositorio.ObtenerTodoProveedoresRepositorio();
        }
        public async Task<VProveedor> ObtenerUno(int id)
        {
            var proveedores = await this._proveedoresRepositorio.ObtenerUnoproveedorRepositorio(id);
            var proveedor = proveedores.FirstOrDefault();
            return proveedor;
        }
        public async Task<string> CrearUno()
        {
            var proveedores = await this._proveedoresRepositorio.ObtenerTodoProveedoresRepositorio();

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
        public async Task<string> InsertarUno(ProveedorDto proveedorDto)
        {
            var insertar = await this._proveedoresRepositorio.InsertarProveedoresRepositorio(
                proveedorDto.codigoProveedor,
                proveedorDto.nombreProveedor,
                proveedorDto.dirrecion,
                proveedorDto.credito,
                proveedorDto.telefono
            );
            if (insertar > 0)
            {
                return $"Proveedor registrado correctamente";
            }
            else
            {
                return $"Error no registrado";
            }
        }

        public async Task<string> ModificarUno(int id, ProveedorDto proveedorDto)
        {
            var modificar = await this._proveedoresRepositorio.ModificarProveedoresRepositorio(
                id,
                proveedorDto.codigoProveedor,
                proveedorDto.nombreProveedor,
                proveedorDto.dirrecion,
                proveedorDto.credito,
                proveedorDto.telefono
           );
            if (modificar > 0)
            {
                return $"Proveedor modificado correctamente";
            }
            else
            {
                return $"Error no modificado";
            }
        }

        public async Task<string> EliminarUno(int id)
        {
            var eliminar = await this._proveedoresRepositorio.EliminarProveedoresRepositorio(
               id
            );
            if (eliminar > 0)
            {
                return $"Proveedor eliminado correctamente";
            }
            else
            {
                return $"Error no eliminado";
            }
        }
    }
}