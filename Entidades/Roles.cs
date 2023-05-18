using System.ComponentModel.DataAnnotations;

namespace sistema_venta_erp.Entidades
{
    public class Roles
    {
        [Key]
        public int rolesId { get; set; }
        public int usuarioId { get; set; }
        public int rolId { get; set; }
    }
}
