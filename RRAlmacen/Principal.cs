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
using RRAlmacen.Almacen.Categorias;
using RRAlmacen.Almacen.Ingresos;

namespace RRAlmacen
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private int childFormNumber = 0;

        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //Almacen.Productos.ProductosForm pp = new Almacen.Productos.ProductosForm();
            //pp.MdiParent = this;
            //pp.Show();

            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultasVentas_Click(object sender, EventArgs e)
        {

        }

        private void btnVneta_Click(object sender, EventArgs e)
        {
            
        }

        private void crearProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            if (Acceso == "Administrador")
            {
                respaldoToolStripMenuItem.Enabled = true;
                mnuAdministrar.Enabled = true;
                mnuConsultas.Enabled = true;


                btnVneta.Enabled = true;
                btnConsultasVentas.Enabled = true;
                btnProductos.Enabled = true;
                btnUsuarios.Enabled = true;

            }
            else if (Acceso == "Vendedor")
            {


            }
            else if (Acceso == "Almacenero")
            {


            }
            else
            {


            }
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
                command = new SqlCommand(@"backup database RRSOFTWARE to disk ='C:\Users\chico\OneDrive\Escritorio\Sistema de Ventas C# - SQL Server 2014 (Free) - Incanatoit\Base de Datos\dbventas.bak' with init,stats=10", connect);
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

        private void appConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Almacen.Database.AppConfig rr = new Almacen.Database.AppConfig();
            rr.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categorias cc = new Categorias();
            cc.ShowDialog(); 
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Almacen.Ingresos.Proveedores pr = new Almacen.Ingresos.Proveedores();
            pr.ShowDialog();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Almacen.Ingresos.Ingresos ii = new Almacen.Ingresos.Ingresos();
            ii.ShowDialog();
        }

        private void categoriasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Categorias ct = new Categorias();
            ct.ShowDialog();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Articulos ar = new Articulos();
            ar.ShowDialog();
        }

        private void presentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion pr = new Presentacion();
            pr.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trabajadores tt = new Trabajadores();
            tt.ShowDialog();
        }
    }
}
