using System.ComponentModel.DataAnnotations;

namespace sistema_venta_erp.Entidades
{
    public class Rol
    {
        [Key]
        public int rol { get; set; }
        public string nombre { get; set; }
    }
}
