using RRAlmacen.CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRAlmacen.CapaNegocios
{
    public class NArticulo
    {
        public static string Insertar(string codigo, string nombre, string descripcion,  int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion, int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int idarticulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DArticulo
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DArticulo de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        public static DataTable Stock_Articulos()
        {
            return new DArticulo().Stock_Articulos();
        }
    }
}
