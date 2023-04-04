using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Consultas
{
    public class VAlmacenConsulta
    {
        public string ObtenerTodo()
        {
            return @$"
                SELECT 
                    id,
                    codigoAlmacen,
                    dirrecion,
                    nombreAlmacen 
                FROM 
                    valmacen;
            ";
        }
        public string ObtenerUno(int id)
        {
            return @$"
                SELECT 
                    id,
                    codigoAlmacen,
                    dirrecion,
                    nombreAlmacen 
                FROM 
                    valmacen
                WHERE id='{id}';
            ";
        }
        public string InsertarUno(
            string codigoAlmacen,
            string dirrecion,
            string nombreAlmacen
        )
        {
            return @$"
                insert into 
                valmacen ( 
                    codigoAlmacen, 
                    dirrecion, 
                    nombreAlmacen
                )
                values
                (
                    '{codigoAlmacen}', 
                    '{dirrecion}', 
                    '{nombreAlmacen}'
                );
            ";
        }
        public string ModificarUno(
            int id,
            string codigoAlmacen,
            string dirrecion,
            string nombreAlmacen
        )
        {
            return @$"
                update 
                    valmacen 
                set 
                    codigoAlmacen = '{codigoAlmacen}',
                    dirrecion = '{dirrecion}',
                    nombreAlmacen = '{nombreAlmacen}'
                where 
                    id = '{id}';
            ";
        }
        public string EliminarUno(int id)
        {
            return @$"
                delete from 
                    valmacen 
                where 
                    id = '{id}';
            ";
        }
    }
}