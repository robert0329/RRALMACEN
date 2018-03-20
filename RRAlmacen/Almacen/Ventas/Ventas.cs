using RRAlmacen.Almacen.Productos;
using RRAlmacen.Almacen.Usuarios;
using RRAlmacen.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAlmacen.Almacen.Ventas
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }
        
        string varUSER_LOGIN = Login._USER_NAME;
        int varID_CAJA = 1;

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarProducto myForm = new BuscarProducto();
                myForm.StartPosition = FormStartPosition.CenterScreen;
                myForm.ShowDialog();
                if (!(myForm.varID_PRODUCTO == ""))
                {
                    txtID_PRODUCTO.Text = myForm.varID_PRODUCTO;
                    txtID_PRODUCTO.Focus();
                }
                myForm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnBuscaProducto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID_PRODUCTO.Text = "";
            }
        }
        double[] FindProductDetails(string prmID_PRODUCTO)
        {
            double[] Retorno = new double[2];
            try
            {
                SqlConnection cnnFindProductDetails = new SqlConnection(RRSOFT.CnnStr);
                string varSQL = "SELECT count(*) FROM Productos WHERE Producto_Id = '" + prmID_PRODUCTO + "'";
               SqlCommand cmdFindProductDetails = new SqlCommand();
                cmdFindProductDetails.Connection =cnnFindProductDetails;
                cmdFindProductDetails.CommandText = varSQL;

                if (cnnFindProductDetails.State == ConnectionState.Open)
                    cnnFindProductDetails.Close();
                cnnFindProductDetails.Open();

                if (!(Convert.ToInt32(cmdFindProductDetails.ExecuteScalar()) == 0))
                {
                    varSQL = "SELECT Precio" +
                        " FROM Productos " +
                        "WHERE Producto_Id='" +
                        prmID_PRODUCTO + "'";
                    cmdFindProductDetails.CommandText = varSQL;
                    Retorno[0] = Convert.
                        ToDouble(cmdFindProductDetails.ExecuteScalar());
                    varSQL = "SELECT IVA " +
                        "FROM Productos " +
                        "WHERE Producto_Id ='" +
                        prmID_PRODUCTO + "'";
                    cmdFindProductDetails.CommandText = varSQL;
                    Retorno[1] = Convert.
                        ToDouble(cmdFindProductDetails.ExecuteScalar());
                }
                else
                {
                    Retorno[0] = 0;
                    Retorno[1] = 0;
                }
                cmdFindProductDetails.Dispose();
                cnnFindProductDetails.Close();
                cnnFindProductDetails.Dispose();
                return (Retorno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"FindProductDetails");
                return (Retorno);
            }
        }
        void Encabezados()
        {
            lvVenta.View = View.Details;
            lvVenta.Columns.Add("Producto", 100, HorizontalAlignment.Left);
            lvVenta.Columns.Add("Descripcion", 250, HorizontalAlignment.Left);
            lvVenta.Columns.Add("Cant", 75, HorizontalAlignment.Right);
            lvVenta.Columns.Add("Prec", 75, HorizontalAlignment.Right);
            lvVenta.Columns.Add("Total", 100, HorizontalAlignment.Right);
        }
        void txtCANTIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                if (((txtID_PRODUCTO.Text != "") || (txtCANTIDAD.Text == "")))
                {
                    if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                    {
                        e.Handled = true;
                    }
                    if (e.KeyChar == 13)
                    {
                        SaveTemp_Ventas(txtID_PRODUCTO.Text, Convert.ToDouble(txtCANTIDAD.Text));
                        txtID_PRODUCTO.Focus();
                    }
                }
                else
                {
                    lblMensaje.Text = "Debe introducir una clave de producto y/o una cantidad";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }    
        void SaveTemp_Ventas(string prmID_PRODUCTO, double prmCANTIDAD)
        {
            double[] varProductDetails = new double[1];
            varProductDetails = FindProductDetails(prmID_PRODUCTO);
            double varPRECIO = varProductDetails[0];
            try
            {
                if (varPRECIO == 0)
                {
                    lblMensaje.Text = "El producto no existe!!!";
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    Temp_Ventas(varUSER_LOGIN, varID_CAJA, prmID_PRODUCTO, prmCANTIDAD, varPRECIO);
                    ReadData(varUSER_LOGIN, varID_CAJA);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        void ReadData(string prmUSER_NAME, int prmID_CAJA)
        {
            StringBuilder Version = new StringBuilder();

            string archivo = "C:\\Users\\chico\\OneDrive\\Escritorio\\Almacen\\RRAlmacen\\RRAlmacen\\configuration.ini";
           
                Util.GetPrivateProfileString("Configuration", "IVA", "", Version, Version.Capacity, archivo);
            double varIVA = 0;
            double varGRAND_TOTAL = 0;
            try
            {
                SqlConnection cnnReadData = new SqlConnection(RRSOFT.CnnStr);
                
                int I = 0;
                SqlCommand cmdReadData = new SqlCommand("select Productos.Producto_Id, Productos.Desc_Producto,Productos.IVA, Temp_Ventas.Cantidad,Temp_Ventas.Precio,(Temp_Ventas.Cantidad * Temp_Ventas.Precio) as Total from Productos inner join Temp_Ventas on Productos.Producto_Id = Temp_Ventas.Producto_Id where Temp_Ventas.User_Name = '" + prmUSER_NAME +"'" , cnnReadData);
                SqlDataReader drReadData;

                if (cnnReadData.State == ConnectionState.Open)
                    cnnReadData.Close();
                cnnReadData.Open();
                drReadData = cmdReadData.ExecuteReader();
                lvVenta.Items.Clear();

                while (drReadData.Read())
                {
                    lvVenta.Items.Add(drReadData["Producto_Id"].ToString());
                    lvVenta.Items[I].SubItems.Add(drReadData["Desc_Producto"].ToString());
                    lvVenta.Items[I].SubItems.Add(drReadData["Cantidad"].ToString());
                    lvVenta.Items[I].SubItems.Add(drReadData["Precio"].ToString());
                    lvVenta.Items[I].SubItems.Add(String.Format("{0:c}", drReadData["Total"]));


                    varGRAND_TOTAL += Convert.ToDouble(drReadData["Total"]);
                    varIVA += Convert.ToDouble(Version.ToString()) * ((Convert.ToDouble(drReadData["TOTAL"])));
                    
                    I += 1;
                }
                drReadData.Close();
                cmdReadData.Dispose();
                cnnReadData.Close();
                cnnReadData.Dispose();
                txtGRAND_TOTAL.Text = String.Format("{0:c}", varGRAND_TOTAL);
                Iva.Text = String.Format("{0:c}", varIVA);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Temp_Ventas(string prmUSER_LOGIN, int prmID_CAJA, string prmID_PRODUCTO, double prmCANTIDAD, double prmPRECIO)
        {
            //Para cargar la venta tenporal
            string varSQL = "";

            try
            {
                SqlConnection cnnTempVentas = new SqlConnection(RRSOFT.CnnStr);
                if (GetSale(prmUSER_LOGIN, prmID_CAJA, prmID_PRODUCTO) == 0)
                {
                    varSQL = "INSERT INTO Temp_Ventas(User_Name,Producto_Id,Cantidad,Precio)VALUES('" + prmUSER_LOGIN + "','" + prmID_PRODUCTO + "'," + prmCANTIDAD + "," + prmPRECIO + ")";

                }

                else
                {
                    varSQL = "UPDATE Temp_Ventas SET Cantidad = " + prmCANTIDAD + " WHERE User_Name = '" + prmUSER_LOGIN + "' AND Producto_Id = '" + prmID_PRODUCTO + "'";
                }

                SqlCommand cmdTempVentas = new SqlCommand(varSQL, cnnTempVentas);

                if (cnnTempVentas.State == ConnectionState.Open)
                    cnnTempVentas.Close();
                cnnTempVentas.Open();
                cmdTempVentas.ExecuteNonQuery();
                cnnTempVentas.Close();
                cmdTempVentas.Dispose();
                cnnTempVentas.Dispose();
                txtID_PRODUCTO.Text = "";
                txtCANTIDAD.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TempVentas");
            }
        }
        double GetSale(string prmUSER_LOGIN, int prmID_CAJA, string prmID_PRODUCTO)
        {
            //Para cargar la venta tenporal
            double Retorno;

            try
            {
                SqlConnection cnnGetSale = new SqlConnection(RRSOFT.CnnStr);

                string varSQL = "SELECT COUNT(*) FROM Temp_Ventas  WHERE User_Name = '" + prmUSER_LOGIN + "' AND Producto_Id = '" + prmID_PRODUCTO + "'";

                SqlCommand cmdGetSale = new SqlCommand(varSQL, cnnGetSale);

                if (cnnGetSale.State == ConnectionState.Open)
                    cnnGetSale.Close();
                cnnGetSale.Open();

                Retorno = Convert.ToDouble(cmdGetSale.ExecuteScalar());
                cmdGetSale.Dispose();
                cnnGetSale.Close();
                cnnGetSale.Dispose();
                return (Retorno);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GetSale");
                return (0);
            }
        }
        private void DeshacerVenta(string prmUSER_LOGIN, int prmID_CAJA)
        {
            SqlConnection conDeshacerVenta;
            SqlCommand cmdDeshacerVenta;
            string strSQL_Delete = "DELETE FROM Temp_Ventas " +
                " WHERE User_Name = '" + prmUSER_LOGIN + "' ";
            try
            {
                conDeshacerVenta =
                    new SqlConnection(RRSOFT.CnnStr);
                conDeshacerVenta.Open();
                cmdDeshacerVenta = new SqlCommand(strSQL_Delete, conDeshacerVenta);
                cmdDeshacerVenta.ExecuteNonQuery();
                cmdDeshacerVenta.Dispose();
                conDeshacerVenta.Close();
                ReadData(varUSER_LOGIN, varID_CAJA);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DeshacerVenta");
            }

        }
        public void PlaySystemSound()
        {
            SystemSounds.Question.Play();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            SqlConnection conDeshacerVenta;
            SqlCommand cmdDeshacerVenta;
            string strSQL_Delete = "DELETE FROM Temp_Ventas ";
            try
            {
                conDeshacerVenta =
                    new SqlConnection(RRSOFT.CnnStr);
                conDeshacerVenta.Open();
                cmdDeshacerVenta = new SqlCommand(strSQL_Delete, conDeshacerVenta);
                cmdDeshacerVenta.ExecuteNonQuery();
                cmdDeshacerVenta.Dispose();
                conDeshacerVenta.Close();
                ReadData(varUSER_LOGIN, varID_CAJA);
                txtID_PRODUCTO.Text = "";
                txtCANTIDAD.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DeshacerVenta");
            }
        }
        private void Ventas_Load(object sender, EventArgs e)
        {
            this.Text = "Ventas";
            Encabezados();
            ReadData(varUSER_LOGIN, varID_CAJA);
            this.txtCANTIDAD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCANTIDAD_KeyPress);
            this.txtCANTIDAD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCANTIDAD_KeyDown);
            this.txtID_PRODUCTO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_PRODUCTO_KeyPress);
            this.txtID_PRODUCTO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_PRODUCTO_KeyDown);
        }
        private void txtCANTIDAD_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            RealizaVenta();
        }
        void txtCANTIDAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                //RealizaVenta();
            }
        }
        void txtID_PRODUCTO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                //RealizaVenta();
            }
        }
        void txtID_PRODUCTO_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblMensaje.Text = "";
            try
            {
                if (!((txtID_PRODUCTO.Text == "") || (txtCANTIDAD.Text == "")))
                {
                    if (e.KeyChar == 13)
                    {
                        SaveTemp_Ventas(txtID_PRODUCTO.Text, Convert.ToDouble(txtCANTIDAD.Text));
                        txtID_PRODUCTO.Focus();
                    }
                }
                else
                {
                    lblMensaje.Text = "Debe introducir una clave de producto y/o una cantidad";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RealizaVenta()
        {
            SystemSounds.Asterisk.Play();
            if (lvVenta.Items.Count != 0)
            {
                int varFolio = RealizaVenta(varUSER_LOGIN, varID_CAJA);
                if (varFolio != 0)
                {
                    Cobrar _frmCobrar = new Cobrar(varFolio);
                    _frmCobrar.StartPosition = FormStartPosition.CenterScreen;
                    _frmCobrar.ShowDialog();
                }
            }
        }
        private int RealizaVenta(string prmUSER_LOGIN, int prmID_CAJA)
        {
            int varFolio = 0;
            try
            {
                SqlConnection cnnInsert = new SqlConnection(RRSOFT.CnnStr);
                cnnInsert.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cnnInsert;

                //insertamos el registro padre
                cmdInsert.CommandText = "INSERT INTO Ventas (User_Name,Caja_Id,Fecha) " +
                                        "VALUES('" + prmUSER_LOGIN + "'," + prmID_CAJA + ",GETDATE())";
                
                                                

                // MADAS 2


                cmdInsert.ExecuteNonQuery();

                //obtenemos el autonumerico
                cmdInsert.CommandText = "SELECT @@IDENTITY";
                varFolio = Convert.ToInt32(cmdInsert.ExecuteScalar());
                
                cmdInsert.CommandText = "INSERT INTO Detalle_Ventas (Producto_Id,FOLIO,Cantidad,Precio,IVA) SELECT Producto_Id," + varFolio + ",Cantidad,Precio,IVA FROM Temp_Ventas WHERE User_Name ='" + prmUSER_LOGIN + "'";
                cmdInsert.ExecuteNonQuery();

                cmdInsert.CommandText = "UPDATE Productos SET Producto_Id = cat.Producto_Id FROM Productos prod JOIN Temp_Ventas cat ON(prod.Cantidad = prod.Cantidad - cat.Cantidad) WHERE cat.User_Name = '" + prmUSER_LOGIN + "'";

                cmdInsert.ExecuteNonQuery();
                
                cmdInsert.CommandText = "DELETE FROM Temp_Ventas " +
                " WHERE User_Name = '" + prmUSER_LOGIN + "'";
                cmdInsert.ExecuteNonQuery();

                //MAMADAS DE EDUAR



                //LIBERAMOS LOS RECUSROS
                cnnInsert.Close();
                cnnInsert.Dispose();
                cmdInsert.Dispose();

                //mostramos la info                
                ReadData(varUSER_LOGIN, varID_CAJA);
                return (varFolio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RealizaVenta");
                return (0);
            }
        }
        public Ventas(string prmUSER_LOGIN, int prmID_CAJA)
        {
            InitializeComponent();
            varID_CAJA = prmID_CAJA;
            varUSER_LOGIN = prmUSER_LOGIN;

        }

       
    }
}
