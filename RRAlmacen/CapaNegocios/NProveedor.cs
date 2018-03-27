using RRAlmacen.CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRAlmacen.CapaNegocios
{
    public class NProveedor
    {
        public static string Insertar(string razon_proveedor, string sector_comercial, string tipo_documento, string num_documento,
            string direccion, string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Razon_Social = razon_proveedor;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;

            return Obj.Insertar(Obj);
        }
        public static SqlCommand SqlCommand(string sql, SqlConnection conn)
        {
            DProveedor dp = new DProveedor();
            SqlCommand sq = dp.SqlCommand(sql, conn);
            return sq;
        }
        //Método Editar que llama al método Editar de la clase DProveedor
        //de la CapaDatos
        public static string Editar(int idproveedor, string razon_proveedor, string sector_comercial, string tipo_documento, string num_documento,
            string direccion, string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.Razon_Social = razon_proveedor;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DProveedor
        //de la CapaDatos
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DProveedor
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        //Método BuscarRazon_Social que llama al método BuscarRazon_Social
        //de la clase DProveedor de la CapaDatos

        public static DataTable BuscarRazon_social(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazon_Social(Obj);
        }

        //Método BuscarRazon_Social que llama al método BuscarRazon_Social
        //de la clase DProveedor de la CapaDatos

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
