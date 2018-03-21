using RRAlmacen.Almacen.Database;
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

namespace RRAlmacen.Almacen.Ventas
{
    public partial class Cobrar : Form
    {
        public Cobrar()
        {
            InitializeComponent();
        }
        int varFolio = 0;
        double varTotal = 0;
        public Cobrar(int prmFolio)
        {
            InitializeComponent();
            varFolio = prmFolio;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((txtEfectivo.Text != "") && (Convert.ToDouble(txtEfectivo.Text) >= varTotal))
            {
                DialogResult _Resp = new DialogResult();
                _Resp = MessageBox.Show("¿Desea imprimir el ticket?",
                    "Ticket", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (_Resp == DialogResult.Yes)
                {
                    GenerarTicket(varFolio);
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Debe introducir una Cantidad Valida",
                    "Faltan datos");
            }
        }

        private void Cobrar_Load(object sender, EventArgs e)
        {
            this.Text = "Cobrar";          
            this.txtEfectivo.TextChanged += new EventHandler(txtEfectivo_TextChanged);
            varTotal = fnCalculaPago(varFolio);
            txtTotal.Text = String.Format("{0:c}", varTotal);
        }
        void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCambio.Text = String.Format("{0:c}", (Convert.ToDouble(txtEfectivo.Text) - varTotal));
            }
            catch (Exception ex)
            {
               txtCambio.Text = ex.Message;
            }
        }
        private double fnCalculaPago(int prmFolio)
        {
            try
            {
                SqlConnection _cnnCalculaPago = new SqlConnection(RRSOFT.CnnStr);
                _cnnCalculaPago.Open();
                SqlCommand _cmdCalculaPago = new SqlCommand("SELECT SUM(Cantidad * Precio) " +
                    "FROM Detalle_Ventas " +
                    "WHERE FOLIO=" + prmFolio + "", _cnnCalculaPago);
                double _return = Convert.ToDouble(_cmdCalculaPago.ExecuteScalar());
                _cnnCalculaPago.Close();
                _cnnCalculaPago.Dispose();
                _cmdCalculaPago.Dispose();
                return (_return);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "fnCalculaPago");
                return (0);
            }
        }
        private void HOLA()
        {
            try
            {
                SqlConnection cnnInsert = new SqlConnection(RRSOFT.CnnStr);
                cnnInsert.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cnnInsert;
                
                cmdInsert.CommandText = "INSERT INTO ARTICULOS_VENDIDOS (DESC_PRODUCTO,CANTIDAD, P_U_VENTA, P_UNITARIO) VALUES('A,'100', ')";

                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerarTicket(int prmFOLIO)
        {
            try
            {
                string Ticket = "Nombre de la tienda: " + AppConfig._NEGOCIO + "\n" +
                    "RFC:" + AppConfig._RFC + "\n" +
                    "------------------------------\n" +
                    "ARTICULO   CANT   PRECIO   TOTAL\n" +
                    "------------------------------\n";

                string varSQL =
                    "SELECT FOLIO,Total FROM Ventas WHERE FOLIO=" + prmFOLIO + "";

                string DetalleTicket = "";
                double varGranTotal = 0;
                SqlConnection cnnTicket = new SqlConnection(RRSOFT.CnnStr);
                cnnTicket.Open();
                SqlCommand cmdTicket = new SqlCommand(varSQL, cnnTicket);
                SqlDataReader drTicket;
                drTicket = cmdTicket.ExecuteReader();

                while (drTicket.Read())
                {
                    DetalleTicket +=
                        drTicket["Total"];
                    varGranTotal += (double)drTicket["Total"];
                }

                DetalleTicket += "------------------------------\n" +
                    "Total: " + String.Format("{0:c}", varGranTotal);
                Ticket += DetalleTicket;

                mPrintDocument _mPrintDocument = new mPrintDocument(Ticket);
                _mPrintDocument.PrintPreview();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
