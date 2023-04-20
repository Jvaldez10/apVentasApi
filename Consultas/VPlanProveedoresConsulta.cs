using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Consultas
{
    public class VPlanProveedoresConsulta
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
                FROM vplanproveedores;
            ";
        }
        public string ObtenerUltimoPlan(int VPlanCuentaId)
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
                FROM vplanproveedores 
                WHERE VPlanCuentaId='{VPlanCuentaId}'  
                ORDER BY id DESC LIMIT 1
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
                FROM vplanproveedores
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
                vplanproveedores (
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
                    vplanproveedores 
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
                    vplanproveedores 
                where 
                    id = '{id}';
            ";
        }
    }
}