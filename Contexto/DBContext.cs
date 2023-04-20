using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistema_venta_erp.Entidades;

namespace sistema_venta_erp.Contexto
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public virtual DbSet<VAlmacen> VAlmacen { get; set; }
        public virtual DbSet<VCategoria> VCategoria { get; set; }
        public virtual DbSet<VPlanCuentas> VPlanCuentas { get; set; }
        public virtual DbSet<VProducto> VProducto { get; set; }
        public virtual DbSet<VProveedor> VProveedor { get; set; }
        public virtual DbSet<VUtilidad> VUtilidad { get; set; }
        public virtual DbSet<VPlanClientes> VPlanClientes { get; set; }
        public virtual DbSet<VPlanProductos> VPlanProductos { get; set; }
        public virtual DbSet<VPlanProveedores> VPlanProveedores { get; set; }
        public virtual DbSet<VNivel> VNivel { get; set; }
        public virtual DbSet<VMoneda> VMoneda { get; set; }
        public virtual DbSet<VCliente> VCliente { get; set; }
        public virtual DbSet<VClasificacion> VClasificacion { get; set; }
        public virtual DbSet<VProductoImagenes> VProductoImagenes { get; set; }
    }
}