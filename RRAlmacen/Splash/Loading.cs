using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAlmacen.Splash
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void tmr_Tick_1(object sender, EventArgs e)
        {
            tmr.Stop();
            System.Threading.Thread run = new System.Threading.Thread(new System.Threading.ThreadStart(RunPrincipal));
            this.Close();
            run.SetApartmentState(System.Threading.ApartmentState.STA);
            run.Start();
        }
        private void RunPrincipal()
        {
            Almacen.Productos.ProductosForm Login = new Almacen.Productos.ProductosForm();
            Login.ShowDialog();

        }
        private void Loading_Load(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Interval = 4000;
            tmr.Start();
            tmr.Tick += tmr_Tick_1;
        }

    }
}
