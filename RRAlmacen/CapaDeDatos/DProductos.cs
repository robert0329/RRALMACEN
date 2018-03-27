using RRAlmacen.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAlmacen.CapaDeDatos
{
    public class DProductos
    {
        public float Producto_Id { get; set; }
        public string Desc_Producto { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }
        public int Stock_Minima { get; set; }
        public int Departamento_Id { get; set; }
        public int Devolucion { get; set; }
        public int Total_Unidad { get; set; }
        public float Total { get; set; }
        public float IVA { get; set; }
        public string Departamentos { get; set; }
        public DProductos()
        {

        }

        public DProductos(int Producto_Id, string Desc_Producto, float Precio, int Cantidad, int Stock_Minima, int Departamento_Id,string Departamentos, int Devolucion, int Total_Unidad, float Total, float IVA)
        {
            this.Producto_Id = Producto_Id;
            this.Desc_Producto = Desc_Producto;
            this.Precio = Precio;
            this.Cantidad = Cantidad;
            this.Stock_Minima = Stock_Minima;
            this.Departamento_Id = Departamento_Id;
            this.Departamentos = Departamentos;
            this.Devolucion = Devolucion;
            this.Total_Unidad = Total_Unidad;
            this.Total = Total;
            this.IVA = IVA;
        }

        public string Insertar(DProductos producto)
        {
            string rpta = "";
            try
            {
                using (var cnnInsert = new SqlConnection(RRSOFT.CnnStr))
                {
                    cnnInsert.Open();
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Productos(Desc_Producto, Producto_Id, Precio, Cantidad, Stock_Minima, Total, Total_Unidad, Devolucion, Departamento_Id,Departamentos, IVA) values('" + producto.Desc_Producto + "','" + producto.Producto_Id + "','" + producto.Precio + "','" + producto.Cantidad + "','" + producto.Stock_Minima + "','" + producto.Total + "','" + producto.Total_Unidad + "','" + producto.Devolucion + "','" + producto.Departamento_Id + "','" + producto.Departamentos + "','" + 0.16 + "')");
                    cmdInsert.Connection = cnnInsert;
                    rpta = Convert.ToString(cmdInsert.ExecuteNonQuery());
                    cnnInsert.Close();
                }
                MessageBox.Show("Se Agrego Producto con Exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rpta;
        }       
        public string Editar(DProductos producto)
        {
            string rpta = "";
            try
            {
                using (var cnnUpdate = new SqlConnection(RRSOFT.CnnStr))
                {
                    cnnUpdate.Open();
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE Productos SET Desc_Producto = '" + producto.Desc_Producto + "', Precio = '" + producto.Precio + "', Cantidad = '" + producto.Cantidad + "', Stock_Minima = '" + producto.Stock_Minima + "', Departamento_Id = '" + producto.Departamento_Id + "', Devolucion = '" + producto.Devolucion + "', Total = '" + producto.Total + "', Total_Unidad = '" + producto.Total_Unidad + "', Departamentos = '" + producto.Departamentos + "', IVA = '" + 0.18 + "' WHERE Producto_Id = '" + producto.Producto_Id + "'");
                    cmdUpdate.Connection = cnnUpdate;
                    rpta = Convert.ToString(cmdUpdate.ExecuteNonQuery());
                }
                MessageBox.Show("Se Modifico el Producto con Exito");
            }
            catch (Exception)
            {
                MessageBox.Show("1.- No puedes modificar este articulo ya que tiene varias ventas relacionadas \n 2.- No Puedes Modiciar el Nombre \n 3.- La minimo Stock tiene que ser menor al actual cantidad \n 4.- Error de Sistema Verifiquelo con el Proveedor");
            }
            return rpta;
        }
        public string Eliminar(DProductos producto)
        {
            string rpta = "";
            if (Convert.ToString(producto.Producto_Id) != "")
            {
                try
                {
                    using (var cnnReadData = new SqlConnection(RRSOFT.CnnStr))
                    {
                        if (cnnReadData.State == ConnectionState.Open)
                            cnnReadData.Close();
                        else cnnReadData.Open();
                        SqlCommand cmdReadData = new SqlCommand("SELECT Producto_Id, Desc_producto ,Cantidad FROM Productos WHERE Desc_Producto like '%" + producto.Producto_Id + "%'", cnnReadData);
                        SqlDataReader drReadData = cmdReadData.ExecuteReader();
                    }
                    using (var cnndetDelete = new SqlConnection(RRSOFT.CnnStr))
                    {
                        cnndetDelete.Open();
                        SqlCommand cmddetDelete = new SqlCommand();
                        cmddetDelete.Connection = cnndetDelete;
                        cmddetDelete.CommandText = "DELETE FROM Detalle_Ventas WHERE Producto_Id like '%" + producto.Producto_Id + "%'";
                        cmddetDelete.ExecuteNonQuery();
                    }
                    using (var cnnDelete = new SqlConnection(RRSOFT.CnnStr))
                    {
                        cnnDelete.Open();
                        SqlCommand cmdDelete = new SqlCommand();
                        cmdDelete.Connection = cnnDelete;
                        cmdDelete.CommandText = "DELETE FROM Productos WHERE Producto_Id like '%" + Producto_Id + "%'";
                        cmdDelete.ExecuteNonQuery();
                    }
                    MessageBox.Show("Se Elimino el Producto Seleccionado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un Producto de la Lista");
            }
            return rpta;
        }

        public SqlCommand SqlCommand(string Sql, SqlConnection conn)
        {
            SqlCommand ss = new SqlCommand(Sql, conn);
            return ss;
        }

        
    }
}
