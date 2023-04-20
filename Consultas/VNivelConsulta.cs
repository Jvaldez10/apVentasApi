using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Consultas
{
    public class VNivelConsulta
    {
        public string ObtenerTodo()
        {
            return @$"
                SELECT 
                    id,
                    nombreNivel
                FROM 
                    vnivel;
            ";
        }
        public string ObtenerUno(int id)
        {
            return @$"
                SELECT 
                    id,
                    nombreNivel
                FROM 
                    vnivel
                WHERE id='{id}';
            ";
        }
        public string InsertarUno(
            string nombreNivel
        )
        {
            return @$"
                insert into
                    vnivel (nombreNivel)
                values ('{nombreNivel}');
            ";
        }
        public string ModificarUno(
            int id,
            string nombreNivel
        )
        {
            return @$"
                update vnivel set nombreNivel = '{nombreNivel}' where id = '{id}';
            ";
        }
        public string EliminarUno(int id)
        {
            return @$"
                delete from 
                    vnivel 
                where 
                    id = '{id}';
            ";
        }
    }
}