using RRAlmacen.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAlmacen.CapaDeDatos
{
    public class DProveedor
    {
        #region Variables
        private int _Idproveedor;

        private string _Razon_Social;

        private string _Sector_Comercial;

        private string _Tipo_Documento;

        private string _Num_Documento;

        private string _Direccion;

        private string _Telefono;

        private string _Email;

        private string _Url;

        private string _TextoBuscar;
        #endregion
        #region Propiedades
        public int Idproveedor
        {
            get { return _Idproveedor; }
            set { _Idproveedor = value; }
        }


        public string Razon_Social
        {
            get { return _Razon_Social; }
            set { _Razon_Social = value; }
        }


        public string Sector_Comercial
        {
            get { return _Sector_Comercial; }
            set { _Sector_Comercial = value; }
        }


        public string Tipo_Documento
        {
            get { return _Tipo_Documento; }
            set { _Tipo_Documento = value; }
        }

        public string Num_Documento
        {
            get { return _Num_Documento; }
            set { _Num_Documento = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        #endregion
        #region Contrustore
        public DProveedor()
        {

        }
        public DProveedor(int idproveedor, string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url, string textobuscar)
        {
            this.Idproveedor = idproveedor;
            this.Razon_Social = razon_social;
            this.Sector_Comercial = sector_comercial;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = textobuscar;
        }
        #endregion

        public string Insertar(DProveedor Proveedor)
        {
            string rpta = "";
            try
            {
                using (var cnnInsert = new SqlConnection(RRSOFT.CnnStr))
                {
                    cnnInsert.Open();
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Proveedor(idproveedor, razon_social, sector_comercial, tipo_documento, num_documento, direccion, telefono, email, url) " +
                        "values('" + Proveedor.Idproveedor + "','" + Proveedor.Razon_Social + "','" + Proveedor.Sector_Comercial + "','" + Proveedor.Tipo_Documento + "','" + Proveedor.Num_Documento + "','" + Proveedor.Direccion + "','" + Proveedor.Telefono + "','" + Proveedor.Email + "','" + Proveedor.Url + "')");
                    cmdInsert.Connection = cnnInsert;
                    rpta = Convert.ToString(cmdInsert.ExecuteNonQuery());
                    cnnInsert.Close();
                }
                MessageBox.Show("Se Agrego Proveedor con Exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rpta;
        }

        //Método Editar
        public string Editar(DProveedor Proveedor)
        {
            string rpta = "";
            try
            {
                using (var cnnUpdate = new SqlConnection(RRSOFT.CnnStr))
                {
                    cnnUpdate.Open();
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE Proveedor SET razon_social = '" + Proveedor.Razon_Social + "', sector_comercial = '" + Proveedor.Sector_Comercial + "', tipo_documento = '" + Proveedor.Tipo_Documento + "', num_documento = '" + Proveedor.Num_Documento + "', direccion = '" + Proveedor.Direccion + "', telefono = '" + Proveedor.Telefono + "', email = '" + Proveedor.Email + "', url = '" + Proveedor.Url + "' WHERE idproveedor = '" + Proveedor.Idproveedor + "'");
                    cmdUpdate.Connection = cnnUpdate;
                    rpta = Convert.ToString(cmdUpdate.ExecuteNonQuery());
                }
                MessageBox.Show("Se Modifico el Producto con Exito");
            }
            catch (Exception)
            {
                MessageBox.Show("1.- No puedes modificar este articulo ya que tiene varias ventas relacionadas \n 2.- No Puedes Modiciar el Nombre \n 3.- La minimo Stock tiene que ser menor al actual cantidad \n 4.- Error de Sistema Verifiquelo con el Proveedor");
            }
            return rpta;
        }

        //Método Eliminar
        public string Eliminar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = RRSOFT.CnnStr;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Proveedor.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = RRSOFT.CnnStr;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        //Método BuscarNombre
        public DataTable BuscarRazon_Social(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = RRSOFT.CnnStr;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_razon_social";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }




        public DataTable BuscarNum_Documento(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = RRSOFT.CnnStr;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        public SqlCommand SqlCommand(string Sql, SqlConnection conn)
        {
            SqlCommand ss = new SqlCommand(Sql, conn);
            return ss;
        }
    }
}
