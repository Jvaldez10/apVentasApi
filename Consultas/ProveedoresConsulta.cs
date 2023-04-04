using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Consultas
{
    public class ProveedoresConsulta
    {
        public string ObtenerTodo()
        {
            return @$"
                SELECT
                    id,
                    codigoProveedor,
                    nombreProveedor,
                    dirrecion,
                    credito,
                    telefono
                FROM vproveedores;
            ";
        }
        public string ObtenerUno(int id)
        {
            return @$"
                SELECT
                    id,
                    codigoProveedor,
                    nombreProveedor,
                    dirrecion,
                    credito,
                    telefono
                FROM vproveedores
                WHERE id='{id}';
            ";
        }
        public string InsertarUno(
            string codigoProveedor,
            string nombreProveedor,
            string dirrecion,
            string credito,
            string telefono
        )
        {
            return @$"
                insert into 
                    vproveedores (
                        codigoProveedor, 
                        nombreProveedor, 
                        dirrecion, 
                        credito, 
                        telefono
                    )
                    values
                    (
                        '{codigoProveedor}', 
                        '{nombreProveedor}', 
                        '{dirrecion}', 
                        '{credito}', 
                        '{telefono}'
                    );
            ";
        }
        public string ModificarUno(
            int id,
            string codigoProveedor,
            string nombreProveedor,
            string dirrecion,
            string credito,
            string telefono
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
                    telefono = '{telefono}'
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