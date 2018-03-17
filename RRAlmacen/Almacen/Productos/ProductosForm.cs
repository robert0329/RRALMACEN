using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RRAlmacen.DAL;
using RRAlmacen.Entidades;

namespace RRAlmacen.Almacen.Productos
{
    public partial class ProductosForm : Form
    {
        public ProductosForm()
        {
            InitializeComponent();
        }
        
        #region Variables Globales
            public string varID_PRODUCTO = "";
            public int varUnidad = 0;
            public string _FOLIO = "";
            public string area = "";
        
        #endregion

        #region Validaciones
        private void Campo_requerido()
        {
            if (txtNombre.Text == "")
            {
                CampoRequerrido.SetError(txtNombre, "Campo Requerido");
            }
            else
            {
                CampoRequerrido.SetError(txtNombre, "");
            }

            if (txtPrecio.Text == "")
            {
                CampoRequerrido.SetError(txtPrecio, "Campo Requerido");
            }
            else
            {
                CampoRequerrido.SetError(txtPrecio, "");
            }

            if (txtCantidad.Text == "")
            {
                CampoRequerrido.SetError(txtCantidad, "Campo Requerido");
            }
            else
            {
                CampoRequerrido.SetError(txtCantidad, "");
            }

            if (btnstockMinima.Text == "")
            {
                CampoRequerrido.SetError(btnstockMinima, "Campo Requerido");
            }
            else
            {
                CampoRequerrido.SetError(btnstockMinima, "");
            }
            if (cboxUnidad.Text == "")
            {
                CampoRequerrido.SetError(cboxUnidad, "Campo Requerido");
            }
            else
            {
                CampoRequerrido.SetError(cboxUnidad, "");
            }
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }
        private bool Validar(string dato)
        {
            if (dato != "")
                return true;

            else
                return false;
        }
        #endregion

        #region Funciones
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Campo_requerido();
            if (!Validar(txtNombre.Text) && !Validar(txtPrecio.Text) &&
                !Validar(txtCantidad.Text) && !Validar(btnstockMinima.Text) && !Validar(cboxUnidad.Text))
            {

            }
            else
            {
                AddData();
            }
        }
        private void lvProductos_DoubleClick(object sender, EventArgs e)
        {

            Producto();
            //txtCantidad.Focus();
            btnAceptar.Enabled = false;

        }
        private void Producto()
        {
            CampoRequerrido.Clear();
            try
            {
                if (lvProductos.Items.Count != 0)
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;

                    varID_PRODUCTO = lvProductos.SelectedItems[0].Text;
                    ListViewItem listItem = lvProductos.SelectedItems[0];
                    

                    SqlConnection cnnReadData = new SqlConnection(RRSOFT.CnnStr);

                    if (cnnReadData.State == ConnectionState.Open)
                        cnnReadData.Close();else cnnReadData.Open();
                    SqlCommand cmdReadData = new SqlCommand("SELECT Producto_Id, Desc_Producto ,Cantidad, Precio, Stock_Minima, Devolucion" +" FROM Productos" + " WHERE Producto_Id like '%" + varID_PRODUCTO + "%'", cnnReadData);

                    SqlDataReader drReadData;
                    drReadData = cmdReadData.ExecuteReader();
                    while (drReadData.Read())
                    {
                        txtCantidad.Text = drReadData["Cantidad"].ToString();
                        txtNombre.Text = drReadData["Desc_Producto"].ToString();
                        txtPrecio.Text = drReadData["Precio"].ToString();
                        btnstockMinima.Text = drReadData["Stock_Minima"].ToString();
                        txtDevolucion.Text = drReadData["Devolucion"].ToString();
                        //textBox1.Text = varID_PRODUCTO;
                        txtDevolucion.Enabled = true;
                    }
                }
                else
                {
                    varID_PRODUCTO = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista. \nDescripción del error: \n" + ex.Message, "Operación no válida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void AddData()
        {
            Entidades.Productos productos = new Entidades.Productos();
            productos.Desc_Producto = txtNombre.Text;
            productos.Precio = Convert.ToInt32(txtPrecio.Text);
            productos.Cantidad = Convert.ToInt32(txtCantidad.Text);
            productos.Stock_Minima = Convert.ToInt32(btnstockMinima.Text);
            productos.Area = cboxUnidad.Text;
            productos.Devolucion = 0;
            productos.Total_Unidad = Convert.ToInt32(txtCantidad.Text) - productos.Devolucion;
            productos.Total = Convert.ToInt32(productos.Total_Unidad) * Convert.ToInt32(productos.Precio);
           
            if (BLL.ProductosBLL.Save(productos) == true)
            {
                MessageBox.Show("Se ha guardado con Exito!!!");
                ReadData();
                CancelButton.PerformClick();
            }
            else
                MessageBox.Show("No Se ha guardado con Exito!!!");

        }
        private void Cerrar()
        {
            ProductosForm _frmInsProductos = new ProductosForm();
            _frmInsProductos.StartPosition = FormStartPosition.CenterParent;
            _frmInsProductos.ShowDialog();
        }
        private void Encabezados()
        {
            lvProductos.View = View.Details;
            lvProductos.Columns.Add("Producto_Id", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Nombre Producto", 150, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Precio Unitario", 110, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Cantidad", 80, HorizontalAlignment.Center);
            //lvProductos.Columns.Add("Stock Minima", 80, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Devolucion", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Total Unidad", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Total", 100, HorizontalAlignment.Center);

        }
        private void ReadData()
        {
            btnCancelar.PerformClick();
            try
            {

                SqlConnection cnnReadData = new SqlConnection(RRSOFT.CnnStr);
                cnnReadData.Open();
                int I = 0;

                SqlCommand cmdReadData = new SqlCommand("SELECT Producto_Id, Desc_Producto as NOMBRE, Precio as PRECIO, Cantidad,Stock_Minima,Devolucion,Total_Unidad,Total FROM Productos", cnnReadData);

                SqlDataReader drReadData;
                drReadData = cmdReadData.ExecuteReader();
                lvProductos.Items.Clear();

                int total = 0;
                while (drReadData.Read())
                {
                    lvProductos.Items.Add(drReadData["Producto_Id"].ToString());
                    lvProductos.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());

                    lvProductos.Items[I].SubItems.Add(String.Format("{0:c}", drReadData["Precio"]));

                    lvProductos.Items[I].SubItems.Add(drReadData["Cantidad"].ToString());

                    //lvProductos.Items[I].SubItems.Add(drReadData["Stock_Minima"].ToString());
                    lvProductos.Items[I].SubItems.Add(drReadData["Devolucion"].ToString());
                    lvProductos.Items[I].SubItems.Add(drReadData["Total_Unidad"].ToString());
                    lvProductos.Items[I].SubItems.Add(String.Format("{0:c}", drReadData["Total"]));

                    total += Convert.ToInt32(drReadData["Total"].ToString());
                    if (drReadData["Cantidad"].ToString() == "1"
                        || drReadData["Cantidad"].ToString() == "2" ||
                        drReadData["Cantidad"].ToString() == "3"
                        || drReadData["Cantidad"].ToString() == "4")
                    {

                        MessageBox.Show("(" + drReadData["NOMBRE"].ToString() + ")" + "  'Cantidad de Producto menor a Sera Necesario Surtir'");
                    }



                    I += 1;
                }
                txtTotal.Text = String.Format("{0:c}", total);

                if (I != 0)
                {
                    lvProductos.Items.Add("");
                    lvProductos.Items[I].SubItems.Add("");
                    lvProductos.Items[I].SubItems.Add("");
                }
                drReadData.Close();
                cnnReadData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ProductosForm_Load(object sender, EventArgs e)
        {
            this.Text = "Productos";
            this.lvProductos.DoubleClick += new System.EventHandler(this.lvProductos_DoubleClick);
            Encabezados();
            ReadData();
            var u1 = new Utilidades(txtPrecio, "N");
            var u2 = new Utilidades(txtCantidad, "N");
            var u3 = new Utilidades(txtDevolucion, "N");
            var u4 = new Utilidades(btnstockMinima, "N");
        }
        private void UpdateData()
        {
            Entidades.Productos productos = new Entidades.Productos();

            productos.Producto_Id = Convert.ToInt32(varID_PRODUCTO);
            productos.Desc_Producto = txtNombre.Text;
            productos.Precio = Convert.ToInt32(txtPrecio.Text);
            productos.Cantidad = Convert.ToInt32(txtCantidad.Text);
            productos.Stock_Minima = Convert.ToInt32(btnstockMinima.Text);
            productos.Area = cboxUnidad.Text;
            productos.Devolucion = Convert.ToInt32(txtDevolucion.Text);
            productos.Total_Unidad = Convert.ToInt32(txtCantidad.Text) - productos.Devolucion;
            productos.Total = Convert.ToInt32(productos.Total_Unidad) * Convert.ToInt32(productos.Precio);

            if (BLL.ProductosBLL.Save(productos) == true)
            {
                MessageBox.Show("Se ha Modificado con Exito!!!");
                ReadData();
                CancelButton.PerformClick();
            }
            else
                MessageBox.Show("No Se ha Modificado con Exito!!!");
        }
        #endregion

        #region Botones
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text =
            txtPrecio.Text =
            txtCantidad.Text =
            btnstockMinima.Text = 
            
            txtDevolucion.Text = "";
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAceptar.Enabled = true;
            
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (varID_PRODUCTO != "")
            {
                try
                {
                    SqlConnection cnnReadData = new SqlConnection(RRSOFT.CnnStr);

                    if (cnnReadData.State == ConnectionState.Open)
                        cnnReadData.Close();
                    else cnnReadData.Open();


                    SqlCommand cmdReadData = new SqlCommand("SELECT Producto_Id, Desc_producto ,Cantidad" +
                        " FROM Productos" +
                        " WHERE Desc_Producto like '%" + varID_PRODUCTO + "%'", cnnReadData);
                    SqlDataReader drReadData;
                    drReadData = cmdReadData.ExecuteReader();

                    //SqlConnection cnndetDelete = new SqlConnection(selectSQL);
                    //cnndetDelete.Open();

                    //SqlCommand cmddetDelete = new SqlCommand();
                    //cmddetDelete.Connection = cnndetDelete;
                    ////Eliminamos el Registro seleccionado DE DETALLE_VENTAS
                    //cmddetDelete.CommandText = "DELETE FROM DETALLE_VENTAS WHERE ID_PRODUCTO like '%" + _FOLIO + "%'";

                    //cmddetDelete.ExecuteNonQuery();

                    SqlConnection cnnDelete = new SqlConnection(RRSOFT.CnnStr);
                    cnnDelete.Open();
                    SqlCommand cmdDelete = new SqlCommand();
                    cmdDelete.Connection = cnnDelete;

                    cmdDelete.CommandText = "DELETE FROM Productos WHERE Producto_Id like '%" + varID_PRODUCTO + "%'";

                    cmdDelete.ExecuteNonQuery();

                    MessageBox.Show("Se Elimino el Producto Seleccionado");
                    ReadData();
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
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Campo_requerido();
            if (!Validar(txtNombre.Text))
            {

            }

            if (!Validar(txtPrecio.Text))
            {

            }

            if (!Validar(txtCantidad.Text))
            {

            }

            if (!Validar(btnstockMinima.Text))
            {

            }

            if (!Validar(cboxUnidad.Text))
            {

            }

            //si no entonces tu codigo
            else
            {
                UpdateData();
            }
        }
        private void lvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        
    }
}
