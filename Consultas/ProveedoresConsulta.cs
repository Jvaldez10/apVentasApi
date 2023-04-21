using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Consultas
{
    public class ProveedoresConsulta
    {
        public string InsertarUno(
            string codigoProveedor,
            string nombreProveedor,
            string dirrecion,
            decimal credito,
            int telefono,
            int planCuentaId
        )
        {
            return @$"
                insert into 
                    vproveedores (
                        codigoProveedor, 
                        nombreProveedor, 
                        dirrecion, 
                        credito, 
                        telefono,
                        planCuentaId
                    )
                    values
                    (
                        '{codigoProveedor}', 
                        '{nombreProveedor}', 
                        '{dirrecion}', 
                        '{credito}', 
                        '{telefono}',
                        '{planCuentaId}'
                    );
            ";
        }
        public string ModificarUno(
            int id,
            string codigoProveedor,
            string nombreProveedor,
            string dirrecion,
            decimal credito,
            int telefono,
            int planCuentaId
        )
        {
            return @$"
                update 
                    vproveedores 
                set 
                    codigoProveedor = '{codigoProveedor}',
                    nombreProveedor = '{nombreProveedor}',
                    dirrecion = '{dirrecion}',
                    credito = '{credito}',
                    telefono = '{telefono}',
                    planCuentaId = '{planCuentaId}'
                where 
                    id = '{id}';
            ";

        }
        public string EliminarUno(int id)
        {
            return @$"
                delete from 
                    vproveedores 
                where 
                    id = '{id}';
            ";
        }
    }
}