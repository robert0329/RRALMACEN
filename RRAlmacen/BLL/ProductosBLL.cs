
using RRAlmacen.DAL;
using RRAlmacen.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRAlmacen.BLL
{
    public class ProductosBLL
    {
        public static bool Save(Productos productos)
        {
            bool result = false;
            using (var conn = new RRSOFT())
            {
                try
                {
                    var search = Search(productos.Producto_Id);
                    if (search == null)
                        conn.productos.Add(productos);
                    else
                        conn.Entry(productos).State = EntityState.Modified;
                    conn.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                    throw;
                }
                return result;
            }
        }
        
        public static Productos Search(int productosId)
        {
            var search = new Productos();
            using (var conn = new RRSOFT())
            {
                try
                {
                    search = conn.productos.Find(productosId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return search;
        }
        
        public static bool Delete(Productos exist)
        {
            bool result = false;
            using (var conn = new RRSOFT())
            {
                try
                {
                    conn.Entry(exist).State = EntityState.Deleted;
                    conn.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return result;
        }
        public static List<Productos> GetList()
        {
            var list = new List<Productos>();
            using (var conn = new RRSOFT())
            {
                try
                {
                    list = conn.productos.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }
        public static List<Productos> GetListId(int productosId)
        {
            List<Productos> list = new List<Productos>();
            using (var conn = new RRSOFT())
            {
                try
                {
                    list = conn.productos.Where(p => p.Producto_Id == productosId).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return list;
        }

        public static int Identity()
        {
            int identity = 0;
            string con = @"Data Source=DESKTOP-A3NC6RU\SQLEXPRESS;Initial Catalog=RRSOFTWARE;Integrated Security=True";
            using (SqlConnection conexion = new SqlConnection(con))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Productos')", conexion);
                    identity = Convert.ToInt32(comando.ExecuteScalar());
                    conexion.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return identity;
        }
        
    }
}
