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

namespace RRAlmacen.Almacen.Usuarios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        DataTable Datos;
        private void btnAceptar_Click(object sender, EventArgs e)
        {
             Datos = NTrabajador.Login(this.txtUsuario.Text, this.txtContraseña.Text);
            
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.Threading.Thread run = new System.Threading.Thread(new System.Threading.ThreadStart(RunPrincipal));
                this.Close();
                run.SetApartmentState(System.Threading.ApartmentState.STA);
                run.Start();
            }

        }
        private void RunPrincipal()
        {          
            Principal Login = new Principal();
            Login.Idtrabajador = Datos.Rows[0][0].ToString();
            Login.Apellidos = Datos.Rows[0][1].ToString();
            Login.Nombre = Datos.Rows[0][2].ToString();
            Login.Acceso = Datos.Rows[0][3].ToString();
            Login.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
