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

namespace RRAlmacen.Almacen.Usuarios
{
    public partial class RegistroUsuarios : Form
    {
        public RegistroUsuarios()
        {
            InitializeComponent();
        }
        static SqlConnection cnnUsers;
        static SqlDataAdapter daUsers;
        static SqlCommandBuilder cbUsers;
        DataSet dsUsers = new DataSet("dsUsers");
        CurrencyManager cmUsers;
        private void RegistroUsuarios_Load(object sender, EventArgs e)
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
            cmUsers = (CurrencyManager)this.BindingContext[dsUsers, "Usuarios"];
            cnnUsers.Close();
        }

        private void btnGarabar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnnInsert = new SqlConnection(RRSOFT.CnnStr);
                cnnInsert.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cnnInsert;

                cmdInsert.CommandText += "INSERT INTO Usuarios (USER_NAME, USER_PASSWORD, GRUPO, PATERNO, MATERNO, NOMBRE, VENTAS, ADMINISTRAR, REPORTES, CATALOGOS, CONSULTAS, DESHACER_VENTA, LOGON, FACTURACION)";
                cmdInsert.CommandText += " VALUES('" + txtNombre.Text + "', '" + txtConContraseña.Text + "', 'Usuarios', '" + txtPaterno.Text + "', '" + txtMaterno.Text + "', '" + txtNombre.Text + "','" + (chkVentas.Checked ? -1 : 0) + "', '" + (chkAdministrar.Checked ? -1 : 0) + "', '" + (chkReportes.Checked ? -1 : 0) + "', '" + (chkCatalogos.Checked ? -1 : 0) + "', '" + (chkConsultas.Checked ? -1 : 0) + "', '" + (chkDeshacer.Checked ? -1 : 0) + "', '" + (chkLogon.Checked ? -1 : 0) + "', '" + (chkFacturacion.Checked ? -1 : 0) + "')    ";
                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("El Agrego con exito el Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnnInsert.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "" + ex.StackTrace);
            }
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
            chkDeshacer.Checked = false;
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
    }
}
