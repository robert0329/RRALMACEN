using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAlmacen.Almacen.Ingresos
{
    public partial class VistaCategoria_Articulo : Form
    {
        public VistaCategoria_Articulo()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataListado.DoubleClick += new EventHandler(this.dataListadoo_CellDoubleClick);
        }
        private void dataListadoo_CellDoubleClick(object sender, EventArgs e)
        {
            Articulos form = Articulos.GetInstancia();
            //form.setCategoria(Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value), Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value));
            this.Hide();
        }
        private void VistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
    }
}
