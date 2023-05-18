using System.ComponentModel.DataAnnotations;

namespace sistema_venta_erp.Entidades
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public int personaId { get; set; }
    }
}
