
using System.ComponentModel.DataAnnotations;

namespace sistema_venta_erp.Entidades
{
    public class VPlanCuentas
    {
        [Key]
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombreCuenta { get; set; }
        public string moneda { get; set; }
        public decimal valor { get; set; }
        public string CodigoIdentificador { get; set; }
        public int nivel { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public int VPlanCuentaId { get; set; }
    }
}