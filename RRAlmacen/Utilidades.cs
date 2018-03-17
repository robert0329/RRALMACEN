using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAlmacen
{
    public class Utilidades
    {
        TextBox caja;
        string Texto;

        public static int ToInt(string Numero)
        {
            int retorno = 0;

            int.TryParse(Numero, out retorno);

            return retorno;
        }
        public static int StringToInt(string texto)
        {
            int numero = 0;

            int.TryParse(texto, out numero);

            return numero;
        }
        public void SoloNumero(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo Numeros...");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SoloLetras(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo Letras");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Utilidades(TextBox externa, string Modo)
        {
            caja = externa;
            if (Modo.Equals("LN"))
                caja.KeyPress += new KeyPressEventHandler(cajaLN_KeyPress);
            else if (Modo.Equals("L"))
                caja.KeyPress += new KeyPressEventHandler(cajaL_KeyPress);
            else if (Modo.Equals("N"))
                caja.KeyPress += new KeyPressEventHandler(cajaN_KeyPress);
        }

        private void cajaLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(caja.Text))
                {
                    caja.Text = Texto;
                    caja.ForeColor = Color.Silver;
                }
            }
            else
                if (Char.IsDigit(e.KeyChar) || Char.IsLetter(e.KeyChar))
                if (caja.Text.Equals(Texto) || caja.ForeColor == Color.Silver)
                {
                    caja.Clear();
                    caja.ForeColor = Color.Black;
                }
        }
        private void cajaL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(caja.Text))
                {
                    caja.Text = Texto;
                    caja.ForeColor = Color.Silver;
                }
            }
            else
                if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space)
            {
                if (caja.Text.Equals(Texto) || caja.ForeColor == Color.Silver)
                {
                    caja.Clear();
                    caja.ForeColor = Color.Black;
                }
            }
            else
                e.Handled = true;
        }
        private void cajaN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(caja.Text))
                {
                    caja.Text = Texto;
                    caja.ForeColor = Color.Silver;
                }
            }
            else
                if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                if (caja.Text.Equals(Texto) || caja.ForeColor == Color.Silver)
                {
                    caja.Clear();
                    caja.ForeColor = Color.Black;
                }
            }
            else
                e.Handled = true;
        }
    }
}
