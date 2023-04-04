using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;

namespace sistema_venta_erp.Modulos
{
    public class AlmacenModulo
    {
        private readonly ILogger<AlmacenModulo> logger;
        private readonly VAlmacenRepositorio _vAlmacenRepositorio;

        public AlmacenModulo(
            ILogger<AlmacenModulo> logger,
            VAlmacenRepositorio proveedoresRepositorio
        )
        {
            this.logger = logger;
            this._vAlmacenRepositorio = proveedoresRepositorio;
        }
        public async Task<List<VAlmacen>> ObtenerTodo()
        {
            return await this._vAlmacenRepositorio.ObtenerTodoAlmacenesRepositorio();
        }
        public async Task<VAlmacen> ObtenerUno(int id)
        {
            var proveedores = await this._vAlmacenRepositorio.ObtenerUnoAlmacenRepositorio(id);
            var proveedor = proveedores.FirstOrDefault();
            return proveedor;
        }

        public async Task<string> InsertarUno(AlmacenDto almacenDto)
        {
            var insertar = await this._vAlmacenRepositorio.InsertarAlmacenesRepositorio(
                almacenDto.codigoAlmacen,
                almacenDto.dirrecion,
                almacenDto.nombreAlmacen
            );
            if (insertar > 0)
            {
                return $"Almacen registrado correctamente";
            }
            else
            {
                return $"Error no registrado";
            }
        }

        public async Task<string> ModificarUno(int id, AlmacenDto almacenDto)
        {
            var modificar = await this._vAlmacenRepositorio.ModificarAlmacenesRepositorio(
                id,
                almacenDto.codigoAlmacen,
                almacenDto.dirrecion,
                almacenDto.nombreAlmacen
           );
            if (modificar > 0)
            {
                return $"Almacen modificado correctamente";
            }
            else
            {
                return $"Error no modificado";
            }
        }

        public async Task<string> EliminarUno(int id)
        {
            var eliminar = await this._vAlmacenRepositorio.EliminarAlmacenesRepositorio(
               id
            );
            if (eliminar > 0)
            {
                return $"Almacen eliminado correctamente";
            }
            else
            {
                return $"Error no eliminado";
            }
        }
    }
}