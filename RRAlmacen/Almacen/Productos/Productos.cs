using RRAlmacen.Almacen.Usuarios;
using RRAlmacen.CapaDeDatos;
using RRAlmacen.CapaNegocios;
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
        #endregion
        #region Botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text =
            txtPrecio.Text =
            txtCantidad.Text =
            txtDevolucion.Text = "";
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
            //txtProducto_Id.Enabled = true;
            txtProducto_Id.Text = "";
            IdRetornar();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar(txtNombre.Text)) {CampoRequerrido.SetError(txtNombre, "Campo Requerido");}if (!Validar(txtPrecio.Text)) { CampoRequerrido.SetError(txtPrecio, "Campo Requerido");}
            if (!Validar(txtCantidad.Text)) {CampoRequerrido.SetError(txtCantidad, "Campo Requerido"); }if (!Validar(cboxUnidad.Text)) {CampoRequerrido.SetError(cboxUnidad, "Campo Requerido"); }
            if (!Validar(txtProducto_Id.Text)) { CampoRequerrido.SetError(txtProducto_Id, "Campo Requerido"); }
            else
            {
                try
                {
                    NProductos.Insertar(Convert.ToInt64(txtProducto_Id.Text), txtNombre.Text, Convert.ToInt64(txtPrecio.Text), Utilidades.ToInt(txtCantidad.Text), 5, Convert.ToInt32(cboxUnidad.SelectedValue), cboxUnidad.Text, 0, Utilidades.ToInt(txtCantidad.Text), Utilidades.ToInt(txtCantidad.Text)* Convert.ToInt64(txtPrecio.Text), 18);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            float Producto_Id = float.Parse(txtProducto_Id.Text); string Desc_Producto = txtNombre.Text; 
            int Cantidad = Convert.ToInt32(txtCantidad.Text); int Departamento_Id = Convert.ToInt32(cboxUnidad.SelectedValue); string Departamento = cboxUnidad.Text;
            int Devolucion = Convert.ToInt32(txtDevolucion.Text); float Precio = float.Parse(txtPrecio.Text);
            if (!Validar(txtNombre.Text)) { CampoRequerrido.SetError(txtNombre, "Campo Requerido"); }
            if (!Validar(txtPrecio.Text)) { CampoRequerrido.SetError(txtPrecio, "Campo Requerido"); }
            if (!Validar(txtCantidad.Text)) { CampoRequerrido.SetError(txtCantidad, "Campo Requerido"); }
            if (!Validar(cboxUnidad.Text)) { CampoRequerrido.SetError(cboxUnidad, "Campo Requerido"); }
            if (!Validar(txtProducto_Id.Text)) { CampoRequerrido.SetError(txtProducto_Id, "Campo Requerido"); }
            else
            {
                try
                {
                    string departamento = cboxUnidad.Text;
                    NProductos.Editar(Producto_Id, Desc_Producto, Precio, Cantidad, 5, Departamento_Id, Departamento, Devolucion, (Cantidad - Devolucion), (Cantidad * Precio), 18);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            NProductos.Eliminar(Convert.ToInt64(txtProducto_Id.Text));
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
            string sql = "SELECT Producto_Id, Desc_Producto as NOMBRE, Precio as PRECIO,Devolucion,Departamentos,Total_Unidad,Total FROM Productos";
            try
            {
                using (var cnnReadData = new SqlConnection(RRSOFT.CnnStr))
                {
                    if (cnnReadData.State == ConnectionState.Open)
                        cnnReadData.Close();
                    else cnnReadData.Open();
                    
                    SqlDataReader drReadData = NProductos.SqlCommand(sql, cnnReadData).ExecuteReader();
                    lvProductos.Items.Clear();

                    while (drReadData.Read())
                    {
                        lvProductos.Items.Add(String.Format("{0:0000}", drReadData["Producto_Id"].ToString()));
                        lvProductos.Items[I].SubItems.Add(drReadData["NOMBRE"].ToString());
                        lvProductos.Items[I].SubItems.Add(String.Format("{0:c}", drReadData["Precio"]));
                        lvProductos.Items[I].SubItems.Add(drReadData["Devolucion"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["Departamentos"].ToString());
                        lvProductos.Items[I].SubItems.Add(drReadData["Total_Unidad"].ToString());
                        lvProductos.Items[I].SubItems.Add(String.Format("{0:c}", drReadData["Total"]));
                        total += Convert.ToInt32(drReadData["Total"].ToString());
                        I += 1;
                    }
                    txtTotal.Text = String.Format("{0:c}", total);

                    drReadData.Close();
                    cnnReadData.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Identity()
        {
            try
            {
                //using (var cnnReadData = new SqlConnection(RRSOFT.CnnStr))
                //{
                //   string varSQL = "SELECT Max(Producto_Id) FROM Productos";

                //    SqlCommand cmdReadData = new SqlCommand(varSQL, cnnReadData);

                //    if (cnnReadData.State == ConnectionState.Open)
                //        cnnReadData.Close();
                //        cnnReadData.Open();
                //    var drReadData = Convert.ToInt32(cmdReadData.ExecuteScalar());

                //    if (drReadData == null)
                //    {
                //        txtProducto_Id.Text = Convert.ToString(1);
                //    }
                //    else
                //        txtProducto_Id.Text = Convert.ToString(drReadData + 1);
                    

                //}
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Encabezados()
        {
            lvProductos.View = View.Details;
            lvProductos.Columns.Add("Producto_Id", 80, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Nombre Producto", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Precio Unitario", 100, HorizontalAlignment.Center);
          //  lvProductos.Columns.Add("Cantidad", 80, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Devolucion", 80, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Departamentos", 100, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Total Unidad", 80, HorizontalAlignment.Center);
            lvProductos.Columns.Add("Total", 80, HorizontalAlignment.Center);
        }
        private void Enable()
        {
            varID_PRODUCTO = lvProductos.SelectedItems[0].Text;
            //txtProducto_Id.Text = varID_PRODUCTO;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            txtProducto_Id.Enabled = false;

        }
        private void Producto()
        {
            CampoRequerrido.Clear();
            try
            {
                string sql = "SELECT Producto_Id, Desc_Producto ,Cantidad, Precio, Devolucion, Departamentos" + " FROM Productos" + " WHERE Producto_Id like '%" + varID_PRODUCTO + "%'";
                if (lvProductos.Items.Count != 0)
                {
                    Enable();
                    ListViewItem listItem = lvProductos.SelectedItems[0];
                    using (var cnnReadData = new SqlConnection(RRSOFT.CnnStr))
                    {
                        if (cnnReadData.State == ConnectionState.Open)
                            cnnReadData.Close();
                        else cnnReadData.Open();
                        
                        SqlDataReader drReadData = NProductos.SqlCommand(sql, cnnReadData).ExecuteReader();

                        while (drReadData.Read())
                        {
                            txtProducto_Id.Text = String.Format("{0:0000}", drReadData["Producto_Id"]);
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
            btnNuevo.PerformClick();
            CargarCbox();
            this.Text = "Modulo Productos, Usuario: " + Login._NOMBRE + " " + Login._PATERNO + " " + Login._MATERNO;
            this.lvProductos.DoubleClick += new System.EventHandler(this.lvProductos_DoubleClick);
            Encabezados();
            LeerDatos();
            var u = new Utilidades(txtPrecio, "N"); u = new Utilidades(txtCantidad, "N"); u = new Utilidades(txtDevolucion, "N"); u = new Utilidades(txtProducto_Id, "N"); u = new Utilidades(txtNombre, "L");
        }


        private void IdRetornar()
        {
            int Id = 0;

            using (var con = new SqlConnection(RRSOFT.CnnStr))
            {
                
                string sql = ("SELECT MAX(Producto_Id) From Productos");
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = con;
                con.Open();
                //si no existe ningun registro
                if (DBNull.Value.Equals(cmd.ExecuteScalar()))
                {
                    txtProducto_Id.Text = String.Format("{0:0000}", 1);
                }
                else
                    txtProducto_Id.Text = String.Format("{0:0000}", Convert.ToInt32(cmd.ExecuteScalar())+1);
            }
        }

        private void lvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
