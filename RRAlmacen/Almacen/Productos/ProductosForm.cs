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
using RRAlmacen.Almacen.Usuarios;
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
            if (txtNombre.Text == "") { CampoRequerrido.SetError(txtNombre, "Campo Requerido"); } else { CampoRequerrido.SetError(txtNombre, ""); }
            if (txtPrecio.Text == "") { CampoRequerrido.SetError(txtPrecio, "Campo Requerido"); } else { CampoRequerrido.SetError(txtPrecio, ""); }
            if (txtCantidad.Text == ""){CampoRequerrido.SetError(txtCantidad, "Campo Requerido");}else {CampoRequerrido.SetError(txtCantidad, "");}
            if (btnstockMinima.Text == ""){CampoRequerrido.SetError(btnstockMinima, "Campo Requerido");}else{CampoRequerrido.SetError(btnstockMinima, "");}
            if (cboxUnidad.Text == "") { CampoRequerrido.SetError(cboxUnidad, "Campo Requerido"); } else { CampoRequerrido.SetError(cboxUnidad, ""); }
            tmr = new Timer();
            tmr.Interval = 4000;
            tmr.Start();
            tmr.Tick += Clear;
            
        }
        private void Clear(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Stop();
            CampoRequerrido.Clear();
            
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.'){e.Handled = true;}
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1){e.Handled = true; }
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
        private void lvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }     
        private void lvProductos_DoubleClick(object sender, EventArgs e)
        {
            Producto();
            btnAceptar.Enabled = false;
        }
        
        private void Producto()
        {
            CampoRequerrido.Clear();
            try
            {
                if (lvProductos.Items.Count != 0)
                {
                    Ena();           
                    ListViewItem listItem = lvProductos.SelectedItems[0];
                    SqlConnection cnnReadData = new SqlConnection(RRSOFT.CnnStr);

                    if (cnnReadData.State == ConnectionState.Open)
                        cnnReadData.Close();else cnnReadData.Open();

                    SqlCommand cmdReadData = new SqlCommand("SELECT Producto_Id, Desc_Producto ,Cantidad, Precio, Devolucion, Departamentos" +" FROM Productos" + " WHERE Producto_Id like '%" + varID_PRODUCTO + "%'", cnnReadData);
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
            string Desc_Producto = txtNombre.Text;
            int Precio = Utilidades.ToInt(txtPrecio.Text);
            int Cantidad = Utilidades.ToInt(txtCantidad.Text);
            int Stock_Minima = Utilidades.ToInt(btnstockMinima.Text);
            int Devolucion = 0;
            int Departamento_Id = Convert.ToInt32(cboxUnidad.SelectedValue);
            string Departamentos = cboxUnidad.Text;
            int Total_Unidad = Utilidades.ToInt(txtCantidad.Text) - Devolucion;
            int Total = Total_Unidad * Precio;
            int Producto_Id = Utilidades.ToInt(Folio.Text);

            if (Cantidad < Stock_Minima)
            {
                CampoRequerrido.SetError(txtCantidad, "No puede ser menor al stock");
            }else
                try
                {
                    SqlConnection cnnInsert = new SqlConnection(RRSOFT.CnnStr);
                    cnnInsert.Open();
                    SqlCommand cmdInsert = new SqlCommand();
                    cmdInsert.Connection = cnnInsert;
                    cmdInsert.CommandText = "INSERT INTO Productos(Desc_Producto, Producto_Id, Precio, Cantidad, Stock_Minima, Total, Total_Unidad, Devolucion, Departamento_Id,Departamentos, IVA) values('" + Desc_Producto + "','" + Producto_Id + "','" + Precio + "','" + Cantidad + "','" + Stock_Minima + "','" + Total + "','" + Total_Unidad + "','" + Devolucion + "','" + Departamento_Id + "','" + Departamentos + "','" + 0.16 + "')";
                    cmdInsert.ExecuteNonQuery();
                    MessageBox.Show("Se Agrego Producto con Exito");
                    cnnInsert.Close();
                    ProductosForm _frmInsProductos = new ProductosForm();
                    _frmInsProductos.StartPosition = FormStartPosition.Manual;
                    _frmInsProductos.Show();
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            lvProductos.Columns.Add("Devolucion", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Departamentos", 100, HorizontalAlignment.Center);
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
                SqlCommand cmdReadData = new SqlCommand("SELECT Producto_Id, Desc_Producto as NOMBRE, Precio as PRECIO, Cantidad,Stock_Minima,Devolucion,Departamentos,Total_Unidad,Total FROM Productos", cnnReadData);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ProductosForm_Load(object sender, EventArgs e)
        {
            dd();
            this.Text = "Módulo de Control de Productos, Usuario: " +
            Login._NOMBRE + " " + Login._PATERNO + " " + Login._MATERNO;
            this.lvProductos.DoubleClick += new System.EventHandler(this.lvProductos_DoubleClick);
            Encabezados();
            ReadData();
            var u = new Utilidades(txtPrecio, "N"); u = new Utilidades(txtCantidad, "N"); u = new Utilidades(txtDevolucion, "N"); u = new Utilidades(btnstockMinima, "N");  u = new Utilidades(Folio, "N"); u = new Utilidades(txtNombre, "L");
        }
        private void UpdateData()
        {
            string Desc_Producto = txtNombre.Text; int Precio = Convert.ToInt32(txtPrecio.Text);int Cantidad = Convert.ToInt32(txtCantidad.Text);
            int Stock_Minima = Convert.ToInt32(btnstockMinima.Text);int Devolucion = Convert.ToInt32(txtDevolucion.Text);int Departamento_Id = Convert.ToInt32(cboxUnidad.SelectedValue);
            int Total_Unidad = (Convert.ToInt32(txtCantidad.Text) - Devolucion);int Total = Convert.ToInt32(Total_Unidad) * Convert.ToInt32(Precio);  int Producto_Id = Convert.ToInt32(Folio.Text); string Departamentos = cboxUnidad.Text;
            try
            {
                SqlConnection cnnUpdate = new SqlConnection(RRSOFT.CnnStr);
                cnnUpdate.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cnnUpdate;

                cmdUpdate.CommandText = "UPDATE Productos SET Desc_Producto = '" + Desc_Producto + "', Precio = '" + Precio + "', Cantidad = '" + Cantidad + "', Stock_Minima = '" + Stock_Minima + "', Departamento_Id = '" + Departamento_Id + "', Devolucion = '" + Devolucion + "', Total = '" +Total + "', Total_Unidad = '" + Total_Unidad + "', Departamentos = '" + Departamentos + "', IVA = '" + 0.18 + "' WHERE Producto_Id = '" + varID_PRODUCTO + "'";

                cmdUpdate.ExecuteNonQuery();
                varID_PRODUCTO = "";
                MessageBox.Show("Se Modifico el Producto con Exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("1.- No puedes modificar este articulo ya que tiene varias ventas relacionadas \n 2.- No Puedes Modiciar el Nombre \n 3.- La minimo Stock tiene que ser menor al actual cantidad \n 4.- Error de Sistema Verifiquelo con el Proveedor");
            }
        }
        private void dd()
        {
            cboxUnidad.DataSource = MostrarNombreGuardarID().Tables[0];
            cboxUnidad.DisplayMember = "Desc_Departamento";
            cboxUnidad.ValueMember = "Departamento_Id";
        }
        public DataSet MostrarNombreGuardarID()
        {
            SqlConnection conn = new SqlConnection(RRSOFT.CnnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = conn;
            string sql = "Select Departamento_Id, Desc_Departamento from Departamentos";
            cmd.CommandText = sql;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Desc_Departamento");
            return ds;
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
            Folio.Enabled = true;
            Folio.Text = "";
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

                    SqlConnection cnndetDelete = new SqlConnection(RRSOFT.CnnStr);
                    cnndetDelete.Open();

                    SqlCommand cmddetDelete = new SqlCommand();
                    cmddetDelete.Connection = cnndetDelete;
                    cmddetDelete.CommandText = "DELETE FROM Detalle_Ventas WHERE Producto_Id like '%" + varID_PRODUCTO + "%'";
                    cmddetDelete.ExecuteNonQuery();
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
            if (!Validar(txtNombre.Text)){}if (!Validar(txtPrecio.Text)){}if (!Validar(txtCantidad.Text)){}if (!Validar(btnstockMinima.Text)){}if (!Validar(cboxUnidad.Text)){}else{
                UpdateData();
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Campo_requerido();
            if (!Validar(txtNombre.Text) && !Validar(txtPrecio.Text) &&
                !Validar(txtCantidad.Text) && !Validar(btnstockMinima.Text) && !Validar(cboxUnidad.Text) && !Validar(Folio.Text)) { }
            else
            {
                AddData();
            }
        }
        #endregion

    }
}
