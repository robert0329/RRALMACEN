using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Almacen.Productos.ProductosForm _frmproducto = new Almacen.Productos.ProductosForm();
            _frmproducto.StartPosition = FormStartPosition.CenterScreen;
            _frmproducto.ShowDialog();
        }
    }
}
