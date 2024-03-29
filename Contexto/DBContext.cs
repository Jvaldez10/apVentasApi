using Microsoft.EntityFrameworkCore;
using sistema_venta_erp.Entidades;
using sistema_venta_erp.Entidades.Querys;

namespace sistema_venta_erp.Contexto
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public virtual DbSet<VAlmacen> valmacen { get; set; }
        public virtual DbSet<VCategoria> vcategoria { get; set; }
        public virtual DbSet<VPlanCuentas> vplancuenta { get; set; }
        public virtual DbSet<VProducto> vproducto { get; set; }
        public virtual DbSet<VProveedor> vproveedor { get; set; }
        public virtual DbSet<VUtilidad> vutilidad { get; set; }
        public virtual DbSet<VPlanClientes> vplanclientes { get; set; }
        public virtual DbSet<VPlanProductos> vplanproductos { get; set; }
        public virtual DbSet<VPlanProveedores> vplanproveedores { get; set; }
        public virtual DbSet<VNivel> vnivel { get; set; }
        public virtual DbSet<VMoneda> vmoneda { get; set; }
        public virtual DbSet<VCliente> vclientes { get; set; }
        public virtual DbSet<VClasificacion> vclasificacion { get; set; }
        public virtual DbSet<VProductoImagenes> vproductoimagenes { get; set; }
        public virtual DbSet<TipoAsiento> tipoasiento { get; set; }
        public virtual DbSet<Asiento> asiento { get; set; }
        public virtual DbSet<AsientoPlanCuenta> asientovplancuenta { get; set; }
        public virtual DbSet<ObtenerTipoAsiento> ObtenerTipoAsiento { get; set; }
        public virtual DbSet<ConfiguracionPlanCuenta> configuracionplancuenta { get; set; }
        public virtual DbSet<General> general { get; set; }
        public virtual DbSet<TipoClasificacion> tipoclasificacion { get; set; }
        public virtual DbSet<OrdenCompra> ordencompra { get; set; }
        public virtual DbSet<OrdenCompraProducto> ordencompraproducto { get; set; }
        public virtual DbSet<Movimiento> movimiento { get; set; }
        public virtual DbSet<EntradaAlmacen> entradaalmacen { get; set; }
        public virtual DbSet<Venta> venta { get; set; }
        public virtual DbSet<SalidaAlmacen> salidaalmacen { get; set; }
        public virtual DbSet<EstadoVenta> estadoventa { get; set; }
        public virtual DbSet<EstadoOrdenCompra> estadoordencompra { get; set; }
        public virtual DbSet<VentaProducto> ventaproducto { get; set; }
        public virtual DbSet<StockAlmacen> stockalmacen { get; set; }
        public virtual DbSet<Persona> persona { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }
        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<Roles> roles { get; set; }
    }
}