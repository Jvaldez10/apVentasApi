using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Entidades
{
    public class VProveedor
    {
        [Key]
        public int id { get; set; }
        public string codigoProveedor { get; set; }
        public string nombreProveedor { get; set; }
        public string dirrecion { get; set; }
        public string telefono { get; set; }
        public string contacto { get; set; }
        public int planCuentaId { get; set; }
    }
}