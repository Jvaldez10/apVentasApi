using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Consultas
{
    public class VMonedaConsulta
    {
        public string ObtenerTodo()
        {
            return @$"
                SELECT 
                    id,
                    nombreMoneda
                FROM 
                    VMoneda;
            ";
        }
        public string ObtenerUno(int id)
        {
            return @$"
                SELECT 
                    id,
                    nombreMoneda
                FROM 
                    VMoneda
                WHERE id='{id}';
            ";
        }
        public string InsertarUno(
            string nombreMoneda
        )
        {
            return @$"
                insert into
                    VMoneda (nombreMoneda)
                values ('{nombreMoneda}');
            ";
        }
        public string ModificarUno(
            int id,
            string nombreMoneda
        )
        {
            return @$"
                update VMoneda set nombreMoneda = '{nombreMoneda}' where id = '{id}';
            ";
        }
        public string EliminarUno(int id)
        {
            return @$"
                delete from 
                    VMoneda 
                where 
                    id = '{id}';
            ";
        }
    }
}