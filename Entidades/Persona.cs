using System.ComponentModel.DataAnnotations;

namespace sistema_venta_erp.Entidades
{
    public class Persona
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
    }
}
