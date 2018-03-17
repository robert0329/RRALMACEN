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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Principal Menu = new Principal();

        public static string _USER_NAME = "";
        public static string _PATERNO = "";
        public static string _MATERNO = "";
        public static string _NOMBRE = "";
        public static bool _VENTAS = false;
        public static bool _ADMINISTRAR = false;
        public static bool _REPORTES = false;
        public static bool _FACTURACION = false;
        public static bool _CONSULTAS = false;
        public static bool _CATALOGO = false;
        private DataTable fnLogin(string prmUSER_NAME, string prmPASSWORD)
        {
            DataTable dt = new DataTable();
            try
            {

                string Query = " SELECT *";
                Query += " FROM Usuarios ";
                Query += " WHERE USER_NAME='" + prmUSER_NAME + "' ";
                Query += " AND USER_PASSWORD ='" + prmPASSWORD + "'";

                using (SqlConnection connection = new SqlConnection(RRSOFT.CnnStr))
                using (SqlCommand command = new SqlCommand(Query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" || txtContraseña.Text.Trim() == "")
            {
                MessageBox.Show("El Usuario o la Contraseña son incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (fnLogin(txtUsuario.Text, txtContraseña.Text).Rows.Count > 0)
                {

                    _USER_NAME = fnLogin(txtUsuario.Text, txtContraseña.Text).Rows[0]["USER_NAME"].ToString();
                    _PATERNO = fnLogin(txtUsuario.Text, txtContraseña.Text).Rows[0]["PATERNO"].ToString();
                    _MATERNO = fnLogin(txtUsuario.Text, txtContraseña.Text).Rows[0]["MATERNO"].ToString();
                    _NOMBRE = fnLogin(txtUsuario.Text, txtContraseña.Text).Rows[0]["NOMBRE"].ToString();

                    _VENTAS = bool.Parse((fnLogin(txtUsuario.Text, txtContraseña.Text).Rows[0]["VENTAS"].ToString()));
                    _ADMINISTRAR = Convert.ToBoolean((fnLogin(txtUsuario.Text, txtContraseña.Text).Rows[0]["ADMINISTRAR"].ToString()));
                    _REPORTES = Convert.ToBoolean((fnLogin(txtUsuario.Text, txtContraseña.Text).Rows[0]["REPORTES"].ToString()));
                    _FACTURACION = Convert.ToBoolean((fnLogin(txtUsuario.Text, txtContraseña.Text).Rows[0]["FACTURACION"].ToString()));
                    _CONSULTAS = Convert.ToBoolean((fnLogin(txtUsuario.Text, txtContraseña.Text).Rows[0]["CONSULTAS"].ToString()));
                    _CATALOGO = Convert.ToBoolean((fnLogin(txtUsuario.Text, txtContraseña.Text).Rows[0]["CATALOGOS"].ToString()));

                    System.Threading.Thread run = new System.Threading.Thread(new System.Threading.ThreadStart(RunPrincipal));
                    this.Close();
                    run.SetApartmentState(System.Threading.ApartmentState.STA);
                    run.Start();
                }
                else
                {
                    MessageBox.Show("El Usuario no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }
        private void RunPrincipal()
        {
            Principal Login = new Principal();
            Login.ShowDialog();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
