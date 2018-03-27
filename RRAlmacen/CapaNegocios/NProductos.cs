using RRAlmacen.CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRAlmacen.CapaNegocios
{
    public class NProductos
    {
        public static string Insertar(float Producto_Id, string Desc_Producto, float Precio, int Cantidad, int Stock_Minima, int Departamento_Id, string Departamentos, int Devolucion, int Total_Unidad, float Total, float IVA)
        {
            DProductos Obj = new DProductos();
            Obj.Producto_Id = Producto_Id;
            Obj.Desc_Producto = Desc_Producto;
            Obj.Precio = Precio;
            Obj.Cantidad = Cantidad;
            Obj.Stock_Minima = Stock_Minima;
            Obj.Departamento_Id = Departamento_Id;
            Obj.Departamentos = Departamentos;
            Obj.Devolucion = Devolucion;
            Obj.Total_Unidad = Total_Unidad;
            Obj.Total = Total;
            Obj.IVA = IVA;
            return Obj.Insertar(Obj);
        }

        public static string Editar(float Producto_Id, string Desc_Producto, float Precio, int Cantidad, int Stock_Minima, int Departamento_Id, string Departamentos, int Devolucion, int Total_Unidad, float Total, float IVA)
        {
            DProductos Obj = new DProductos();
            Obj.Producto_Id = Producto_Id;
            Obj.Desc_Producto = Desc_Producto;
            Obj.Precio = Precio;
            Obj.Cantidad = Cantidad;
            Obj.Stock_Minima = Stock_Minima;
            Obj.Departamento_Id = Departamento_Id;
            Obj.Departamentos = Departamentos;
            Obj.Devolucion = Devolucion;
            Obj.Total_Unidad = Total_Unidad;
            Obj.Total = Total;
            Obj.IVA = IVA;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(float Producto_Id)
        {
            DProductos Obj = new DProductos();
            Obj.Producto_Id = Producto_Id;
            return Obj.Eliminar(Obj);
        }

        public static SqlCommand SqlCommand(string sql,SqlConnection conn)
        {
            DProductos dp = new DProductos();
            SqlCommand sq = dp.SqlCommand(sql,conn);
            return sq;
        }
    }
}
