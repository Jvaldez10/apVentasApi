using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Consultas
{
    public class VentasConsulta
    {
        public string OntenerAsientos(int TipoAsientoId)
        {

            return @$"
                SELECT
                    vp.codigo,
                    vp.`nombreCuenta`,
                    avp.VPlanCuentaId as PlanCuentaId,
                    avp.rol,
                    a.id
                FROM asiento as a
                    INNER JOIN asientovplancuenta as avp ON avp.`asientoId` = a.id
                    INNER JOIN vplancuenta as vp ON vp.id = avp.`VPlanCuentaId`
                    INNER JOIN tipoasiento as ta ON ta.id = a.`tipoasientoId`
                WHERE ta.id = '{TipoAsientoId}';
            ";
        }
    }
}