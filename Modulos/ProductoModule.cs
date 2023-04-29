using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_venta_erp.Controllers.Dto;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Repositorio;
using sistema_venta_erp.Utilidades;

namespace sistema_venta_erp.Modulos
{
    public class ProductoModule
    {
        private readonly ILogger<ProductoModule> _logger;
        private readonly VProductoRepositorio _vProductoRepositorio;
        private readonly ProveedoresRepositorio _proveedoresRepositorio;
        private readonly VClasificacionRepositorio _vClasificacionRepositorio;
        private readonly VProductoImagenesRepositorio _vProductoImagenesRepositorio;
        private readonly FilesConvert _filesConvert;
        private readonly Letras _letras;

        public ProductoModule(
            ILogger<ProductoModule> logger,
            VProductoRepositorio vProductoRepositorio,
            ProveedoresRepositorio proveedoresRepositorio,
            VClasificacionRepositorio vClasificacionRepositorio,
            VProductoImagenesRepositorio vProductoImagenesRepositorio,
            FilesConvert filesConvert,
            Letras letras
        )
        {
            this._logger = logger;
            this._vProductoRepositorio = vProductoRepositorio;
            this._proveedoresRepositorio = proveedoresRepositorio;
            this._vClasificacionRepositorio = vClasificacionRepositorio;
            this._vProductoImagenesRepositorio = vProductoImagenesRepositorio;
            this._filesConvert = filesConvert;
            this._letras = letras;
        }
        public async Task<object> ObtenerTodo()
        {
            var productoslista = await this._vProductoRepositorio.ObtenerTodoProductoRepositorio();
            return productoslista;
        }
        public async Task<object> Create()
        {
            var proveedores = await this._proveedoresRepositorio.ObtenerTodoProveedoresRepositorio();
            var categoriasList = await this._vClasificacionRepositorio.ObtenerTodoClasificacionRepositorio();
            var categorias = categoriasList.Where(x => x.clasificacionId == 0);
            var codigo = await this.GenerateCodigo();
            var resultado = new
            {
                codigo = codigo,
                proveedores = proveedores,
                categorias = categorias
            };
            return resultado;
        }
        private async Task<string> GenerateCodigo()
        {
            var productos = await this._vProductoRepositorio.ObtenerTodoProductoRepositorio();

            var codigo = "";
            if (productos.Count > 0)
            {
                var ultimo = productos.Last();
                codigo = $"prod-{ultimo.id + 1}";
            }
            else
            {
                codigo = "prod-0";
            }
            return codigo;
        }
        public async Task<string> Insert(ProductoDto productoDto)
        {
            var insert = await this._vProductoRepositorio.InsertarProductoRepositorio(
               new VProducto
               {
                   codigoProducto = productoDto.codigoProducto,
                   fechaVencimiento = productoDto.fechaVencimiento,
                   lote = productoDto.lote,
                   nombreProducto = productoDto.nombreProducto,
                   precioCompra = productoDto.precioCompra,
                   precioVentaMin = productoDto.precioVentaMin,
                   precioVentaMax = productoDto.precioVentaMax,
                   stockActual = productoDto.stockActual,
                   stockMinimo = productoDto.stockMinimo,
                   cantidad = productoDto.cantidad,
                   VClasificacionId = productoDto.clasificacionId,
                   VProveedoreId = productoDto.proveedoreId,
                   utilidadMax = productoDto.utilidadMax,
                   utilidadMin = productoDto.utilidadMin,
                   codigoBarra = productoDto.codigoBarra,
                   unidadMedida = productoDto.unidadMedida
               }
            );
            //insert iamgenes
            await this.InsertarImagenesDataBase(productoDto, insert.id);
            if (insert.id > 0)
            {
                return "Resgistrado correctamente";
            }
            else
            {
                return "Ocurrio un error";
            }
        }
        public async Task<object> Editar(int id)
        {
            var obtenerProducto = await this._vProductoRepositorio.ObtenerUnoProductoRepositorio(id);
            var obtenerImagenes = await this._vProductoImagenesRepositorio.ObtenerTodoProductoImagenesRepositorio();
            var imagenes = obtenerImagenes.Where(x => x.VproductoId == id).ToList();
            //convert iamgen
            var base64Imagenes = new List<string>();
            foreach (var imagen in imagenes)
            {
                base64Imagenes.Add(this._filesConvert.GetFileToBase64(imagen.nombre, imagen.nombre));
            }
            var producto = new ProductoDto
            {
                id = obtenerProducto.id,
                cantidad = obtenerProducto.cantidad,
                clasificacionId = obtenerProducto.VClasificacionId,
                codigoBarra = obtenerProducto.codigoBarra,
                codigoProducto = obtenerProducto.codigoProducto,
                fechaVencimiento = obtenerProducto.fechaVencimiento,
                imagenes = base64Imagenes,
                lote = obtenerProducto.lote,
                nombreProducto = obtenerProducto.nombreProducto,
                precioCompra = obtenerProducto.precioCompra,
                precioVentaMax = obtenerProducto.precioVentaMax,
                precioVentaMin = obtenerProducto.precioVentaMin,
                proveedoreId = obtenerProducto.VProveedoreId,
                stockActual = obtenerProducto.stockActual,
                stockMinimo = obtenerProducto.stockMinimo,
                unidadMedida = obtenerProducto.unidadMedida,
                utilidadMax = obtenerProducto.utilidadMax,
                utilidadMin = obtenerProducto.utilidadMin
            };

            var proveedores = await this._proveedoresRepositorio.ObtenerTodoProveedoresRepositorio();
            var categoriasList = await this._vClasificacionRepositorio.ObtenerTodoClasificacionRepositorio();
            var categorias = categoriasList.Where(x => x.clasificacionId == 0);
            var resultado = new
            {
                producto = producto,
                imagenes = base64Imagenes,
                proveedores = proveedores,
                categorias = categorias
            };
            return resultado;
        }
        public async Task<string> Update(int id, ProductoDto productoDto)
        {
            var update = await this._vProductoRepositorio.ModificarProductoRepositorio(
               new VProducto
               {
                   id = id,
                   codigoProducto = productoDto.codigoProducto,
                   fechaVencimiento = productoDto.fechaVencimiento,
                   lote = productoDto.lote,
                   nombreProducto = productoDto.nombreProducto,
                   precioCompra = productoDto.precioCompra,
                   precioVentaMin = productoDto.precioVentaMin,
                   precioVentaMax = productoDto.precioVentaMax,
                   stockActual = productoDto.stockActual,
                   stockMinimo = productoDto.stockMinimo,
                   cantidad = productoDto.cantidad,
                   VClasificacionId = productoDto.clasificacionId,
                   VProveedoreId = productoDto.proveedoreId,
                   utilidadMax = productoDto.utilidadMax,
                   utilidadMin = productoDto.utilidadMin,
                   codigoBarra = productoDto.codigoBarra,
                   unidadMedida = productoDto.unidadMedida
               }
            );
            //eliminar imagenes
            var archivosEliminar = await this._vProductoImagenesRepositorio.ObtenerTodoProductoImagenesRepositorio();
            var archivos = archivosEliminar.Where(x => x.VproductoId == id).ToList();
            await this.BorrarImagenesDataBase(archivos);
            await this.BorrarArchivoFile(archivos);
            //insert iamgenes
            await this.InsertarImagenesDataBase(productoDto, id);
            if (update.id > 0)
            {
                return "Resgistrado correctamente";
            }
            else
            {
                return "Ocurrio un error";
            }
        }
        /*otros*/
        private async Task<bool> BorrarImagenesDataBase(List<VProductoImagenes> vProductoImagenes)
        {
            foreach (var imagen in vProductoImagenes)
            {
                await this._vProductoImagenesRepositorio.EliminarProductoImagenesRepositorio(imagen.id);
            }
            return true;
        }
        private async Task<bool> BorrarArchivoFile(List<VProductoImagenes> vProductoImagenes)
        {
            foreach (var imagen in vProductoImagenes)
            {
                await this._filesConvert.DeleteFile(imagen.nombre);
            }
            return true;
        }
        private async Task<bool> InsertarImagenesDataBase(ProductoDto productoDto, int id)
        {
            int i = 0;
            foreach (var data in productoDto.imagenes)
            {
                var formatBase64 = this._letras.NombreFormatoBase64(data);
                var base64 = this._letras.DataBase64(data);
                var path = await this._filesConvert.GuardarFileToBase64(base64, $"{productoDto.nombreProducto}{DateTime.Now.ToString("HHmmss")}{i}", $".{formatBase64}");
                //insert imagenes
                await this._vProductoImagenesRepositorio.InsertarProductoImagenesRepositorio(
                    new VProductoImagenes
                    {
                        nombre = path,
                        VproductoId = id
                    }
                );
                i++;
            }
            return true;
        }
    }
}