using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_venta_erp.Consultas
{
    public class VCategoriaConsulta
    {
        public string ObtenerTodo()
        {
            return @$"
                SELECT 
                    id,
                    nombreCategoria,
                    estado,
                    descripcion 
                FROM 
                    Vcategoria;
            ";
        }
        public string ObtenerUno(int id)
        {
            return @$"
                SELECT 
                    id,
                    nombreCategoria,
                    descripcion,
                    estado 
                FROM 
                    Vcategoria
                WHERE id='{id}';
            ";
        }
        public string InsertarUno(
            string nombreCategoria,
            string descripcion,
            string estado
        )
        {
            return @$"
                insert into 
                Vcategoria ( 
                    nombreCategoria, 
                    descripcion, 
                    estado
                )
                values
                (
                    '{nombreCategoria}', 
                    '{descripcion}', 
                    '{estado}'
                );
            ";
        }
        public string ModificarUno(
            int id,
            string nombreCategoria,
            string descripcion,
            string estado
        )
        {
            return @$"
                update 
                    Vcategoria 
                set 
                    nombreCategoria = '{nombreCategoria}',
                    descripcion = '{descripcion}',
                    estado = '{estado}'
                where 
                    id = '{id}';
            ";
        }
        public string EliminarUno(int id)
        {
            return @$"
                delete from 
                    Vcategoria 
                where 
                    id = '{id}';
            ";
        }
    }
}