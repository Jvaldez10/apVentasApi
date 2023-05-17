using System.ComponentModel.DataAnnotations;
namespace sistema_venta_erp.Entidades
{
    public class StockAlmacen
    {
        [Key]
        public int id { get; set; }
        public int VProveedoreId { get; set; }
        public int VProductoId { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal precioTotal { get; set; }
        public int stockAlert { get; set; }
    }
}