using RRAlmacen.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAlmacen.Almacen.Productos
{
    public partial class BuscarProducto : Form
    {
        public BuscarProducto()
        {
            InitializeComponent();
        }
        public string varID_PRODUCTO = "";
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ReadData(txtDESC_PRODUCTO.Text);
        }
        private void Encabezados()
        {
            lvProductos.View = View.Details;
            lvProductos.Columns.Add("Clave producto", 0,
                HorizontalAlignment.Left);
            lvProductos.Columns.Add("Descripción", 250,
                HorizontalAlignment.Left);
            lvProductos.Columns.Add("Existencia", 90,
                HorizontalAlignment.Right);
            lvProductos.Columns.Add("Precio", 90, HorizontalAlignment.Right);
            lvProductos.Columns.Add("Devolucion", 90, HorizontalAlignment.Right);
        }
        void lvProductos_DoubleClick(object sender, System.EventArgs e)
        {
            Producto();
        }
        void lvProductos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    Producto();
                    break;

                case (char)Keys.Escape:
                    varID_PRODUCTO = "";
                    this.Close();
                    break;
            }
        }
        private void Producto()
        {
            try
            {
                if (lvProductos.Items.Count != 0)
                {
                    varID_PRODUCTO = lvProductos.SelectedItems[0].Text;
                }

                else
                {
                    varID_PRODUCTO = "";
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista. \nDescripción del error: \n" + ex.Message, "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ReadData(string prmDESC_PRODUCTO)
        {
            try
            {
                //string selectSQL = @"Data Source=DESKTOP-A3NC6RU\SQLEXPRESS;Initial Catalog=RRSOFTWARE;Integrated Security=True";
                SqlConnection cnnReadData = new SqlConnection(RRSOFT.CnnStr);

                if (cnnReadData.State == ConnectionState.Open)
                    cnnReadData.Close();
                else cnnReadData.Open();

                int I = 0;

                SqlCommand cmdReadData = new SqlCommand("SELECT Producto_Id," +
                    " Desc_Producto," +
                    " Cantidad,Precio,Devolucion,Total_Unidad" +
                    " FROM Productos" +
                    " WHERE Desc_Producto like '%" + prmDESC_PRODUCTO + "%'", cnnReadData);

                SqlDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvProductos.Items.Clear();

                while (drReadData.Read())
                {
                    lvProductos.Items.Add(drReadData["Producto_Id"].ToString());
                    lvProductos.Items[I].SubItems.Add(drReadData["Desc_Producto"].ToString());
                    lvProductos.Items[I].SubItems.Add(drReadData["Cantidad"].ToString());
                    lvProductos.Items[I].SubItems.Add(String.Format("{0:c}", drReadData["Precio"]));
                    lvProductos.Items[I].SubItems.Add(drReadData["Devolucion"].ToString());
                    lvProductos.Items[I].SubItems.Add(drReadData["Total_Unidad"].ToString());
                    I += 1;
                }
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            this.Text = "Busca Producto";
            this.lvProductos.DoubleClick += new System.EventHandler(this.lvProductos_DoubleClick);
            this.lvProductos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvProductos_KeyPress);
            Encabezados();
        }
    }
}
