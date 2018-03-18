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
using System.IO;

namespace RRAlmacen
{
    public partial class SoftWare : Form
    {
        public string FileName { get; }
        public string FileSection { get; }

        public SoftWare()
        {
            InitializeComponent();
        }

        private void SoftWare_Load(object sender, EventArgs e)
        {
            StringBuilder Version = new StringBuilder();
            StringBuilder Autor = new StringBuilder();
            StringBuilder Empresa = new StringBuilder();
            
            string archivo = "C:\\Users\\chico\\OneDrive\\Escritorio\\Almacen\\RRAlmacen\\RRAlmacen\\configuration.ini";
            if (File.Exists(archivo))
            {
                Util.GetPrivateProfileString("Configuration", "SoftWareVersion", "", Version, Version.Capacity, archivo);
                Util.GetPrivateProfileString("Configuration", "Empresa", "", Empresa, Empresa.Capacity, archivo);
                Util.GetPrivateProfileString("Configuration", "Autor", "", Autor, Autor.Capacity, archivo);
                
                textBox1.Text = Version.ToString();
                textBox2.Text = Empresa.ToString();
                textBox3.Text = Autor.ToString();
            }
            else
            {
                MessageBox.Show("No se puede encontrar archivo " + archivo);
            }
        }
        
    }
}
