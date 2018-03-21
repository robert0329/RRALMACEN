using RRAlmacen.Almacen.Usuarios;
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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }
        #region VARIABLES
        public string varID_PRODUCTO = "";
        public int varUnidad = 0;
        public string _FOLIO = "";
        public string area = "";
        #endregion
        #region Botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text =
            txtPrecio.Text =
            txtCantidad.Text =
            btnstockMinima.Text =
            txtDevolucion.Text = "";
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
            Folio.Enabled = true;
            Folio.Text = "";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar(txtNombre.Text)) {CampoRequerrido.SetError(txtNombre, "Campo Requerido");}
            if (!Validar(txtPrecio.Text)) { CampoRequerrido.SetError(txtPrecio, "Campo Requerido");}
            if (!Validar(txtCantidad.Text)) {CampoRequerrido.SetError(txtCantidad, "Campo Requerido"); }
            if (!Validar(btnstockMinima.Text)) { CampoRequerrido.SetError(btnstockMinima, "Campo Requerido");}
            if (!Validar(cboxUnidad.Text)) {CampoRequerrido.SetError(cboxUnidad, "Campo Requerido"); }
            if (!Validar(Folio.Text)) { CampoRequerrido.SetError(Folio, "Campo Requerido"); }
            else { GuardarDatos(); }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!Validar(txtNombre.Text)) { CampoRequerrido.SetError(txtNombre, "Campo Requerido"); }
            if (!Validar(txtPrecio.Text)) { CampoRequerrido.SetError(txtPrecio, "Campo Requerido"); }
            if (!Validar(txtCantidad.Text)) { CampoRequerrido.SetError(txtCantidad, "Campo Requerido"); }
            if (!Validar(btnstockMinima.Text)) { CampoRequerrido.SetError(btnstockMinima, "Campo Requerido"); }
            if (!Validar(cboxUnidad.Text)) { CampoRequerrido.SetError(cboxUnidad, "Campo Requerido"); }
            if (!Validar(Folio.Text)) { CampoRequerrido.SetError(Folio, "Campo Requerido"); }
            else { Modificar(); }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        #endregion
        #region Funciones
        private bool Validar(string dato)
        {
            if (dato != "")
                return true;
            else
                return false;
        }
        private void GuardarDatos()
        {
            string Desc_Producto = txtNombre.Text; int Precio = Utilidades.ToInt(txtPrecio.Text); int Cantidad = Utilidades.ToInt(txtCantidad.Text);
            int Stock_Minima = Utilidades.ToInt(btnstockMinima.Text); int Devolucion = 0;int Departamento_Id = Convert.ToInt32(cboxUnidad.SelectedValue);
            string Departamentos = cboxUnidad.Text; int Total_Unidad = Utilidades.ToInt(txtCantidad.Text) - Devolucion;int Total = Total_Unidad * Precio; int Producto_Id = Utilidades.ToInt(Folio.Text);

            try
            {
                using (var cnnInsert = new SqlConnection(RRSOFT.CnnStr))
                {
                    cnnInsert.Open();
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Productos(Desc_Producto, Producto_Id, Precio, Cantidad, Stock_Minima, Total, Total_Unidad, Devolucion, Departamento_Id,Departamentos, IVA) values('" + Desc_Producto + "','" + Producto_Id + "','" + Precio + "','" + Cantidad + "','" + Stock_Minima + "','" + Total + "','" + Total_Unidad + "','" + Devolucion + "','" + Departamento_Id + "','" + Departamentos + "','" + 0.16 + "')");
                    cmdInsert.Connection = cnnInsert;
                    cmdInsert.ExecuteNonQuery();
                    cnnInsert.Close();
                }
                MessageBox.Show("Se Agrego Producto con Exito");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Modificar()
        {
            string Desc_Producto = txtNombre.Text; int Precio = Convert.ToInt32(txtPrecio.Text); int Cantidad = Convert.ToInt32(txtCantidad.Text);
            int Stock_Minima = Convert.ToInt32(btnstockMinima.Text); int Devolucion = Convert.ToInt32(txtDevolucion.Text); int Departamento_Id = Convert.ToInt32(cboxUnidad.SelectedValue);
            int Total_Unidad = (Convert.ToInt32(txtCantidad.Text) - Devolucion); int Total = Convert.ToInt32(Total_Unidad) * Convert.ToInt32(Precio); int Producto_Id = Convert.ToInt32(Folio.Text); string Departamentos = cboxUnidad.Text;
            try
            {
                using (var cnnUpdate = new SqlConnection(RRSOFT.CnnStr))
                {
                    cnnUpdate.Open();
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE Productos SET Desc_Producto = '" + Desc_Producto + "', Precio = '" + Precio + "', Cantidad = '" + Cantidad + "', Stock_Minima = '" + Stock_Minima + "', Departamento_Id = '" + Departamento_Id + "', Devolucion = '" + Devolucion + "', Total = '" + Total + "', Total_Unidad = '" + Total_Unidad + "', Departamentos = '" + Departamentos + "', IVA = '" + 0.18 + "' WHERE Producto_Id = '" + varID_PRODUCTO + "'");
                    cmdUpdate.Connection = cnnUpdate;
                    cmdUpdate.ExecuteNonQuery();
                    varID_PRODUCTO = "";
                }          
                MessageBox.Show("Se Modifico el Producto con Exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("1.- No puedes modificar este articulo ya que tiene varias ventas relacionadas \n 2.- No Puedes Modiciar el Nombre \n 3.- La minimo Stock tiene que ser menor al actual cantidad \n 4.- Error de Sistema Verifiquelo con el Proveedor");
            }
        }
        private void Eliminar()
        {
            if (varID_PRODUCTO != "")
            {
                try
                {
                    using (var cnnReadData = new SqlConnection(RRSOFT.CnnStr))
                    {
                        if (cnnReadData.State == ConnectionState.Open)
                            cnnReadData.Close();
                        else cnnReadData.Open();
                        SqlCommand cmdReadData = new SqlCommand("SELECT Producto_Id, Desc_producto ,Cantidad FROM Productos WHERE Desc_Producto like '%" + varID_PRODUCTO + "%'", cnnReadData);
                        SqlDataReader drReadData = cmdReadData.ExecuteReader();
                    }
                    using (var cnndetDelete = new SqlConnection(RRSOFT.CnnStr))
                    {
                        cnndetDelete.Open();
                        SqlCommand cmddetDelete = new SqlCommand();
                        cmddetDelete.Connection = cnndetDelete;
                        cmddetDelete.CommandText = "DELETE FROM Detalle_Ventas WHERE Producto_Id like '%" + varID_PRODUCTO + "%'";
                        cmddetDelete.ExecuteNonQuery();
                    }
                    using (var cnnDelete = new SqlConnection(RRSOFT.CnnStr))
                    {
                        cnnDelete.Open();
                        SqlCommand cmdDelete = new SqlCommand();
                        cmdDelete.Connection = cnnDelete;
                        cmdDelete.CommandText = "DELETE FROM Productos WHERE Producto_Id like '%" + varID_PRODUCTO + "%'";
                        cmdDelete.ExecuteNonQuery();
                    }                       
                    MessageBox.Show("Se Elimino el Producto Seleccionado");
                    //ReadData();
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
        private void CargarCbox()
        {
            cboxUnidad.DataSource = CargarComboBox().Tables[0];
            cboxUnidad.DisplayMember = "Desc_Departamento";
            cboxUnidad.ValueMember = "Departamento_Id";
        }
        public DataSet CargarComboBox()
        {
            DataSet Retorno = new DataSet();
            using (var conn = new SqlConnection(RRSOFT.CnnStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select Departamento_Id, Desc_Departamento from Departamentos");
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Connection = conn;
                da.SelectCommand = cmd;               
                da.Fill(Retorno, "Desc_Departamento");
            }              
            return Retorno;
        }
        private void LeerDatos()
        {
            int total = 0; int I = 0;
            try
            {
                using (var cnnReadData = new SqlConnection(RRSOFT.CnnStr))
                {
                    cnnReadData.Open();
                    SqlCommand cmdReadData = new SqlCommand("SELECT Producto_Id, Desc_Producto as NOMBRE, Precio as PRECIO, Cantidad,Stock_Minima,Devolucion,Departamentos,Total_Unidad,Total FROM Productos", cnnReadData);
                    SqlDataReader drReadData;
                    drReadData = cmdReadData.ExecuteReader();
                    lvProductos.Items.Clear();

                    while (drReadData.Read())
                    {
                        lvProductos.Items.Add(drReadData["Producto_Id"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());
                        lvProductos.Items[I].SubItems.Add(String.Format("{0:c}", drReadData["Precio"]));
                        lvProductos.Items[I].SubItems.Add(drReadData["Cantidad"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["Devolucion"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["Departamentos"].ToString());
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Encabezados()
        {
            lvProductos.View = View.Details;
            lvProductos.Columns.Add("Producto_Id", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Nombre Producto", 150, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Precio Unitario", 110, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Cantidad", 80, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Devolucion", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Departamentos", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Total Unidad", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Total", 100, HorizontalAlignment.Center);
        }
        private void Enable()
        {
            varID_PRODUCTO = lvProductos.SelectedItems[0].Text;
            Folio.Text = varID_PRODUCTO;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            Folio.Enabled = false;

        }
        private void Producto()
        {
            CampoRequerrido.Clear();
            try
            {
                if (lvProductos.Items.Count != 0)
                {
                    Enable();
                    ListViewItem listItem = lvProductos.SelectedItems[0];
                    using (var cnnReadData = new SqlConnection(RRSOFT.CnnStr))
                    {
                        if (cnnReadData.State == ConnectionState.Open)
                            cnnReadData.Close();
                        else cnnReadData.Open();

                        SqlCommand cmdReadData = new SqlCommand("SELECT Producto_Id, Desc_Producto ,Cantidad, Precio, Devolucion, Departamentos" + " FROM Productos" + " WHERE Producto_Id like '%" + varID_PRODUCTO + "%'", cnnReadData);
                        SqlDataReader drReadData;
                        drReadData = cmdReadData.ExecuteReader();

                        while (drReadData.Read())
                        {
                            txtCantidad.Text = drReadData["Cantidad"].ToString();
                            txtNombre.Text = drReadData["Desc_Producto"].ToString();
                            txtPrecio.Text = drReadData["Precio"].ToString();
                            txtDevolucion.Text = drReadData["Devolucion"].ToString();
                            cboxUnidad.Text = drReadData["Departamentos"].ToString();
                            txtDevolucion.Enabled = true;
                        }
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
        private void lvProductos_DoubleClick(object sender, EventArgs e)
        {
            Producto();
            btnGuardar.Enabled = false;
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') { e.Handled = true; }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1) { e.Handled = true; }
        }
        #endregion
        private void Productos_Load(object sender, EventArgs e)
        {
            CargarCbox();
            this.Text = "Módulo de Control de Productos, Usuario: " + Login._NOMBRE + " " + Login._PATERNO + " " + Login._MATERNO;
            this.lvProductos.DoubleClick += new System.EventHandler(this.lvProductos_DoubleClick);
            Encabezados();
            LeerDatos();
            var u = new Utilidades(txtPrecio, "N"); u = new Utilidades(txtCantidad, "N"); u = new Utilidades(txtDevolucion, "N"); u = new Utilidades(btnstockMinima, "N"); u = new Utilidades(Folio, "N"); u = new Utilidades(txtNombre, "L");
        }
    }
}
