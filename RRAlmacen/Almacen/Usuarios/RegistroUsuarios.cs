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
using RRAlmacen.Entidades;

namespace RRAlmacen.Almacen.Usuarios
{
    public partial class RegistroUsuarios : Form
    {
        public RegistroUsuarios()
        {
            InitializeComponent();
        }
        
        private void RegistroUsuarios_Load(object sender, EventArgs e)
        {
            cargar();
        }

        #region VARIABLES
        string I;
        static SqlConnection cnnUsers;
        static SqlDataAdapter daUsers;
        static SqlCommandBuilder cbUsers;
        DataSet dsUsers = new DataSet("dsUsers");
        CurrencyManager cmUsers;
        #endregion
        #region Funciones
        public void cargar()
        {

            cnnUsers = new SqlConnection(RRSOFT.CnnStr);
            daUsers = new SqlDataAdapter();
            daUsers.SelectCommand = new SqlCommand("SELECT * FROM Usuarios", cnnUsers);
            cbUsers = new SqlCommandBuilder(daUsers);

            if (cnnUsers.State == ConnectionState.Open)
                cnnUsers.Close();
            cnnUsers.Open();
            dsUsers.Clear();

            daUsers.Fill(dsUsers, "Usuarios");
            UsuarioId.DataBindings.Add("Text", dsUsers, "Usuarios.Usuario_Id");
            txtUsuario.DataBindings.Add("Text", dsUsers, "Usuarios.USER_NAME");
            txtContraseña.DataBindings.Add("Text", dsUsers, "Usuarios.USER_PASSWORD");
            txtConContraseña.DataBindings.Add("Text", dsUsers, "Usuarios.USER_PASSWORD");
            txtPaterno.DataBindings.Add("Text", dsUsers, "Usuarios.PATERNO");
            txtMaterno.DataBindings.Add("Text", dsUsers, "Usuarios.MATERNO");
            txtNombre.DataBindings.Add("Text", dsUsers, "Usuarios.NOMBRE");
            chkAdministrar.DataBindings.Add("Checked", dsUsers, "Usuarios.ADMINISTRAR", false);
            chkVentas.DataBindings.Add("Checked", dsUsers, "Usuarios.VENTAS", true);
            chkReportes.DataBindings.Add("Checked", dsUsers, "Usuarios.REPORTES", true);
            chkFacturacion.DataBindings.Add("Checked", dsUsers, "Usuarios.FACTURACION", true);
            chkConsultas.DataBindings.Add("Checked", dsUsers, "Usuarios.CONSULTAS", true);
            chkDeshacer.DataBindings.Add("Checked", dsUsers, "Usuarios.DESHACER_VENTA", true);
            chkCatalogos.DataBindings.Add("Checked", dsUsers, "Usuarios.CATALOGOS", true);
            chkLogon.DataBindings.Add("Checked", dsUsers, "Usuarios.LOGON", true);
            cmUsers = (CurrencyManager)this.BindingContext[dsUsers, "Usuarios"];
            cnnUsers.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }
        public void Id()
        {
            int id = BLL.UsuariosBLL.Identity();
            if (id > 1 || BLL.UsuariosBLL.GetList().Count > 0)
                I = (id + 1).ToString();
            UsuarioId.Text = I;
        }
        private void new_usuario()
        {

            if (chkAdministrar.Checked == true)
            {
                chkAdministrar.Checked = true;
            }
            else chkAdministrar.Checked = false;

            if (chkVentas.Checked == true)
            {
                chkVentas.Checked = true;
            }
            else chkVentas.Checked = false;

            if (chkFacturacion.Checked == true)
            {
                chkFacturacion.Checked = true;
            }
            else chkFacturacion.Checked = false;

            if (chkDeshacer.Checked == true)
            {
                chkDeshacer.Checked = true;
            }
            else chkDeshacer.Checked = false;

            if (chkConsultas.Checked == true)
            {
                chkConsultas.Checked = true;
            }
            else chkConsultas.Checked = false;

            if (chkReportes.Checked == true)
            {
                chkReportes.Checked = true;
            }
            else chkReportes.Checked = false;


            SqlConnection cnnInsert = new SqlConnection(RRSOFT.CnnStr);
            cnnInsert.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cnnInsert;
            //   cmdInsert.CommandText = ("INSERT INTO USERS (USER_NAME, USER_PASSWORD, PATERNO, MATERNO, NOMBRE) VALUES('" + txtUSER_LOGIN.Text + "','"+ txtPASSWORD.Text + "','" + txtPATERNO.Text + "'," + txtMATERNO.Text + "," + txtNOMBRE.Text +")");
            cmdInsert.CommandText = "INSERT INTO Usuarios (USER_NAME, USER_PASSWORD, PATERNO, MATERNO, NOMBRE) VALUES('" + txtUsuario.Text + "','" + txtContraseña.Text + "','" + txtPaterno.Text + "','" + txtMaterno.Text + "','" + txtNombre.Text + "')";

            //  cmdInsert.CommandText = "INSERT INTO USERS VALUES(@USER_NAME,@USER_PASSWORD,@PATERNO , @MATERNO , @NOMBRE)";


            cmdInsert.Parameters.AddWithValue("@USER_NAME", txtUsuario.Text);

            cmdInsert.Parameters.AddWithValue("@USER_PASSWORD", txtContraseña.Text);

            cmdInsert.Parameters.AddWithValue("@PATERNO", txtPaterno.Text);

            cmdInsert.Parameters.AddWithValue("@MATERNO", txtMaterno.Text);

            cmdInsert.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);


            cmdInsert.ExecuteNonQuery();


            cnnInsert.Close();


            MessageBox.Show("Se Agrego Producto con Exito");
        }
        private void Limpia()
        {
            UsuarioId.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtConContraseña.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            txtNombre.Text = "";
            chkVentas.Checked = false;
            chkReportes.Checked = false;
            chkConsultas.Checked = false;
            chkAdministrar.Checked = false;
            chkFacturacion.Checked = false;
            chkCatalogos.Checked = false;
            chkDeshacer.Checked = false;
            chkLogon.Checked = false;
            Id();
            //UsuarioId.Enabled = true;
        }
        private void txtConContraseña_Validating(object sender, CancelEventArgs e)
        {
            if (txtConContraseña.Text.Trim() != txtContraseña.Text.Trim())
            {
                btnGarabar.Enabled = false;
                btnEditar.Enabled = false;
                txtContraseña.Focus();
                MessageBox.Show("Las Contraseñas no Coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                btnGarabar.Enabled = true;
                btnEditar.Enabled = true;
            }

        }
        #endregion
        #region Botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpia();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnGarabar.PerformClick();
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            cmUsers.Position = 0;
        }
        private void btnFinal_Click(object sender, EventArgs e)
        {
            cmUsers.Position = cmUsers.Count - 1;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            cmUsers.Position += 1;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            cmUsers.Position -= 1;
        }
        private void btnGarabar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Usuarios usuarios = new Entidades.Usuarios();
                usuarios.Usuario_Id = Convert.ToInt32(UsuarioId.Text);
                usuarios.USER_NAME = txtUsuario.Text;
                usuarios.USER_PASSWORD = txtConContraseña.Text;
                usuarios.NOMBRE = txtNombre.Text;
                usuarios.PATERNO = txtPaterno.Text;
                usuarios.MATERNO = txtMaterno.Text;
                usuarios.GRUPO = txtNombre.Text;
                usuarios.VENTAS = Convert.ToBoolean(chkVentas.Checked ? -1 : 0);
                usuarios.ADMINISTRAR = Convert.ToBoolean(chkAdministrar.Checked ? -1 : 0);
                usuarios.REPORTES = Convert.ToBoolean(chkReportes.Checked ? -1 : 0);
                usuarios.CONSULTAS = Convert.ToBoolean(chkConsultas.Checked ? -1 : 0);
                usuarios.CATALOGOS = Convert.ToBoolean(chkCatalogos.Checked ? -1 : 0);
                usuarios.DESHACER_VENTA = Convert.ToBoolean(chkDeshacer.Checked ? -1 : 0);
                usuarios.LOGON = Convert.ToBoolean(chkLogon.Checked ? -1 : 0);
                usuarios.FACTURACION = Convert.ToBoolean(chkFacturacion.Checked ? -1 : 0);

                if (BLL.UsuariosBLL.Save(usuarios) == true)
                {
                    MessageBox.Show("Guardado exitoso!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "" + ex.StackTrace);
            }
        }
        #endregion
    }
}
