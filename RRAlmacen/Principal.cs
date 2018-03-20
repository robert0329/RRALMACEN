using System.Data.SqlClient;
using RRAlmacen.Almacen.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using RRAlmacen.DAL;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace RRAlmacen
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //Almacen.Productos.ProductosForm pp = new Almacen.Productos.ProductosForm();
            //pp.MdiParent = this;
            //pp.Show();

            Almacen.Productos.ProductosForm _frmproducto = new Almacen.Productos.ProductosForm();
            _frmproducto.StartPosition = FormStartPosition.CenterScreen;
            _frmproducto.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Almacen.Productos.BuscarProducto _frmproducto = new Almacen.Productos.BuscarProducto();
            _frmproducto.StartPosition = FormStartPosition.CenterScreen;
            _frmproducto.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Almacen.Usuarios.RegistroUsuarios _frmproducto = new Almacen.Usuarios.RegistroUsuarios();
            _frmproducto.StartPosition = FormStartPosition.CenterScreen;
            _frmproducto.ShowDialog();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultasVentas_Click(object sender, EventArgs e)
        {

        }

        private void btnVneta_Click(object sender, EventArgs e)
        {
            Almacen.Ventas.Ventas vt = new Almacen.Ventas.Ventas();
            vt.ShowDialog();
        }

        private void crearProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Almacen.Productos.ProductosForm _frmproducto = new Almacen.Productos.ProductosForm();
            _frmproducto.StartPosition = FormStartPosition.CenterScreen;
            _frmproducto.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.Text = "Módulo de Control de Ventas, Usuario: " +
            Login._NOMBRE + " " +
            Login._PATERNO + " " +
            Login._MATERNO;
            mnuVentas.Enabled = Login._VENTAS;
            respaldoToolStripMenuItem.Enabled = Login._ADMINISTRAR;
            mnuAdministrar.Enabled = Login._ADMINISTRAR;
            mnuConsultas.Enabled = Login._CONSULTAS;


            btnVneta.Enabled = Login._VENTAS;
            btnConsultasVentas.Enabled = Login._CONSULTAS;
            btnProductos.Enabled = Login._CATALOGO;
            btnUsuarios.Enabled = Login._ADMINISTRAR;
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread run = new System.Threading.Thread(new System.Threading.ThreadStart(RunLogin));
            this.Close();
            run.SetApartmentState(System.Threading.ApartmentState.STA);
            run.Start();;
        }
        private void RunLogin()
        {
            Login Login = new Login();
            Login.StartPosition = FormStartPosition.CenterScreen;
            Login.ShowDialog();

        }

        private void crearRespaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool desea_respaldar = true;

            //poner cursor de relojito mintras respalda
            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(@"c:\ Respaldo"))
            {
                if (File.Exists(@"c:\ Respaldo\resp.bak"))
                {
                    if (MessageBox.Show(@"Ya habia un respaldo anteriormente ¿desea remplazarlo?", "Respaldo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(@"c:\ Respaldo\resp.bak");
                    }
                    else
                        desea_respaldar = false;
                }
            }
            else
                Directory.CreateDirectory(@"c:\ Respaldo");

            if (desea_respaldar)
            {
                //esto puede ser un método aparte de conexion a la base de datos-----------
                SqlConnection connect;
                connect = new SqlConnection(RRSOFT.CnnStr);
                connect.Open();
                //-------------------------------------------------------------------------

                //esto puede ser un método aparte para ejecutar comandos SQL---------------
                SqlCommand command;
                command = new SqlCommand(@"backup database RRSOFTWARE to disk ='c:\ Respaldo\resp.bak' with init,stats=10", connect);
                command.ExecuteNonQuery();
                //-------------------------------------------------------------------------

                connect.Close();

                MessageBox.Show("El Respaldo de la base de datos fue realizado satisfactoriamente", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //poner cursor de relojito
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (File.Exists(@"c:\ Respaldo\resp.bak"))
                {
                    if (MessageBox.Show("¿Está seguro de restaurar?", "Respaldo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //esto puede ser un método aparte de conexion a la base de datos-----------
                        SqlConnection connect;
                        connect = new SqlConnection(RRSOFT.CnnStr);
                        connect.Open();
                        //--------------------------------------------------------------------------

                        //esto puede ser un método aparte para ejecutar comandos SQL----------------
                        SqlCommand command;
                        command = new SqlCommand("use master", connect);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(@"restore database RRSOFTWARE from disk = 'c:\ Respaldo\resp.bak'", connect);
                        command.ExecuteNonQuery();
                        //--------------------------------------------------------------------------
                        connect.Close();

                        MessageBox.Show("Se ha restaurado la base de datos", "Restauración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show(@"No haz hecho ningun respaldo anteriormente (o no está en la ruta correcta)", "Restauracion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void softWareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoftWare rr = new SoftWare();
            rr.ShowDialog();
        }
    }
}
