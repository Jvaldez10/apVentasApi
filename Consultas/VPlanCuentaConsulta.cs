using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Consultas
{
    public class VPlanCuentaConsulta
    {
        public string ObtenerTodo()
        {
            return @$"
                SELECT
                    id,
                    codigoIdentificador,
                    VPlanCuentaId,
                    codigo,
                    debe,
                    haber,
                    moneda,
                    nivel,
                    nombreCuenta,
                    valor
                FROM vplancuenta;
            ";
        }
        public string ObtenerUno(int id)
        {
            return @$"
                SELECT
                    id,
                    codigoIdentificador,
                    VPlanCuentaId,
                    codigo,
                    debe,
                    haber,
                    moneda,
                    nivel,
                    nombreCuenta,
                    valor
                FROM vplancuenta
                WHERE id='{id}';
            ";
        }
        public string InsertarUno(
            string codigo,
            string nombreCuenta,
            string moneda,
            decimal valor,
            string codigoIdentificador,
            int nivel,
            decimal debe,
            decimal haber,
            int VPlanCuentaId
        )
        {
            return @$"
                insert into 
                vplancuenta (
                    codigo, 
                    nombreCuenta, 
                    moneda, 
                    valor, 
                    codigoIdentificador, 
                    nivel, 
                    debe, 
                    haber, 
                    VPlanCuentaId
                )
                values
                (
                    '{codigo}', 
                    '{nombreCuenta}', 
                    '{moneda}', 
                    '{valor}', 
                    '{codigoIdentificador}', 
                    '{nivel}', 
                    '{debe}', 
                    '{haber}', 
                    '{VPlanCuentaId}'
                );
            ";
        }
        public string ModificarUno(
            int id,
            string codigo,
            string nombreCuenta,
            string moneda,
            decimal valor,
            string codigoIdentificador,
            int nivel,
            decimal debe,
            decimal haber,
            int VPlanCuentaId
        )
        {
            return @$"
                update 
                    vplancuenta 
                set 
                    codigo = '{codigo}',
                    nombreCuenta = '{nombreCuenta}',
                    moneda = '{moneda}',
                    valor = '{valor}',
                    codigoIdentificador = '{codigoIdentificador}',
                    nivel = '{nivel}',
                    debe = '{debe}',
                    haber = '{haber}',
                    VPlanCuentaId = '{VPlanCuentaId}'
                where 
                    id = '{id}';
            ";
        }
        public string EliminarUno(int id)
        {
            return @$"
                delete from 
                    vplancuenta 
                where 
                    id = '{id}';
            ";
        }
    }
}