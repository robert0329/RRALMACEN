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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using RRAlmacen.Almacen.Categorias;
using RRAlmacen.Almacen.Ingresos;
using RRAlmacen.Almacen.Clientes;
using RRAlmacen.Almacen.Consultas;
using Conexion;

namespace RRAlmacen
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        public string Idtrabajador;
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";
        public string id = "";

        public void Id(int Id)
        {
            id = Convert.ToString(Id);
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            if (Acceso == "Administrador")
            {
                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = true;
                this.MnuConsultas.Enabled = true;
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = true;

            }
            else if (Acceso == "Vendedor")
            {
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = true;

            }
            else if (Acceso == "Almacenero")
            {
                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = false;

            }
            else
            {
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = false;
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = false;

            }
        }
        
        private void RunLogin()
        {
            Login Login = new Login();
            Login.StartPosition = FormStartPosition.CenterScreen;
            Login.ShowDialog();

        }

        private void restaurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //poner cursor de relojito
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (File.Exists(@"c:\Respaldo\resp.bak"))
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

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Articulos ar = new Articulos();
            ar.ShowDialog();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categorias ct = new Categorias();
            ct.ShowDialog();
        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion pr = new Presentacion();
            pr.ShowDialog();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingresos ingresos = new Ingresos();
            ingresos.ShowDialog();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores proveedores = new Proveedores();
            proveedores.ShowDialog();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trabajadores tr = new Trabajadores();
            tr.ShowDialog();
        }

        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread run = new System.Threading.Thread(new System.Threading.ThreadStart(RunLogin));
            this.Close();
            run.SetApartmentState(System.Threading.ApartmentState.STA);
            run.Start();
        }

        private void backUpBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool desea_respaldar = true;

            //poner cursor de relojito mintras respalda
            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(@"c:\Respaldo"))
            {
                if (File.Exists(@"c:\Respaldo\resp.bak"))
                {
                    if (MessageBox.Show(@"Ya habia un respaldo anteriormente ¿desea remplazarlo?", "Respaldo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(@"c:\Respaldo\resp.bak");
                    }
                    else
                        desea_respaldar = false;
                }
            }
            else
                Directory.CreateDirectory(@"c:\Respaldo");

            if (desea_respaldar)
            {
                //esto puede ser un método aparte de conexion a la base de datos-----------
                SqlConnection connect;
                connect = new SqlConnection(RRSOFT.CnnStr);
                connect.Open();
                //-------------------------------------------------------------------------

                //esto puede ser un método aparte para ejecutar comandos SQL---------------
                SqlCommand command;
                command = new SqlCommand(@"backup database RRSOFTWARE to disk ='C:\Respaldo\resp.bak", connect);
                command.ExecuteNonQuery();
                //-------------------------------------------------------------------------

                connect.Close();

                MessageBox.Show("El Respaldo de la base de datos fue realizado satisfactoriamente", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.ShowDialog();
        }

        private void stockDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_Stock_Articulos r = new Consulta_Stock_Articulos();
            r.ShowDialog();
        }

        private void comprasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaCompras c = new ConsultaCompras();
            c.ShowDialog();
        }
    }
}
