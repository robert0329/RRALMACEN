
using Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeDatos
{
    public class DProveedor
    {

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



        //Propiedades
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

        //Constructores
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
        //Métodos
        public string Insertar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "spinsertar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter ParRazon_Social = new SqlParameter();
                ParRazon_Social.ParameterName = "@razon_social";
                ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                ParRazon_Social.Size = 150;
                ParRazon_Social.Value = Proveedor.Razon_Social;
                SqlCmd.Parameters.Add(ParRazon_Social);

                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sector_comercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.Sector_Comercial;
                SqlCmd.Parameters.Add(ParSectorComercial);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Proveedor.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);


                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 150;
                ParUrl.Value = Proveedor.Url;
                SqlCmd.Parameters.Add(ParUrl);



                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


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

        //Método Editar
        public string Editar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "speditar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Proveedor.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter ParRazon_Social = new SqlParameter();
                ParRazon_Social.ParameterName = "@razon_social";
                ParRazon_Social.SqlDbType = SqlDbType.VarChar;
                ParRazon_Social.Size = 150;
                ParRazon_Social.Value = Proveedor.Razon_Social;
                SqlCmd.Parameters.Add(ParRazon_Social);

                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sector_comercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.Sector_Comercial;
                SqlCmd.Parameters.Add(ParSectorComercial);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.Tipo_Documento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Proveedor.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);


                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 150;
                ParUrl.Value = Proveedor.Url;
                SqlCmd.Parameters.Add(ParUrl);
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


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
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        //#region Variables
        //private int _Idproveedor;

        //private string _Razon_Social;

        //private string _Sector_Comercial;

        //private string _Tipo_Documento;

        //private string _Num_Documento;

        //private string _Direccion;

        //private string _Telefono;

        //private string _Email;

        //private string _Url;

        //private string _TextoBuscar;
        //#endregion
        //#region Propiedades
        //public int Idproveedor
        //{
        //    get { return _Idproveedor; }
        //    set { _Idproveedor = value; }
        //}


        //public string Razon_Social
        //{
        //    get { return _Razon_Social; }
        //    set { _Razon_Social = value; }
        //}


        //public string Sector_Comercial
        //{
        //    get { return _Sector_Comercial; }
        //    set { _Sector_Comercial = value; }
        //}


        //public string Tipo_Documento
        //{
        //    get { return _Tipo_Documento; }
        //    set { _Tipo_Documento = value; }
        //}

        //public string Num_Documento
        //{
        //    get { return _Num_Documento; }
        //    set { _Num_Documento = value; }
        //}

        //public string Direccion
        //{
        //    get { return _Direccion; }
        //    set { _Direccion = value; }
        //}
        //public string Telefono
        //{
        //    get { return _Telefono; }
        //    set { _Telefono = value; }
        //}

        //public string Email
        //{
        //    get { return _Email; }
        //    set { _Email = value; }
        //}
        //public string Url
        //{
        //    get { return _Url; }
        //    set { _Url = value; }
        //}
        //public string TextoBuscar
        //{
        //    get { return _TextoBuscar; }
        //    set { _TextoBuscar = value; }
        //}
        //#endregion
        //#region Contrustore
        //public DProveedor()
        //{

        //}
        //public DProveedor(int idproveedor, string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url, string textobuscar)
        //{
        //    this.Idproveedor = idproveedor;
        //    this.Razon_Social = razon_social;
        //    this.Sector_Comercial = sector_comercial;
        //    this.Tipo_Documento = tipo_documento;
        //    this.Num_Documento = num_documento;
        //    this.Direccion = direccion;
        //    this.Telefono = telefono;
        //    this.Email = email;
        //    this.Url = url;
        //    this.TextoBuscar = textobuscar;
        //}
        //#endregion

        //public string Insertar(DProveedor Proveedor)
        //{
        //    string rpta = "";
        //    try
        //    {
        //        using (var cnnInsert = new SqlConnection(RRSOFT.CnnStr))
        //        {
        //            cnnInsert.Open();
        //            SqlCommand cmdInsert = new SqlCommand("INSERT INTO proveedor(idproveedor, razon_social, sector_comercial, tipo_documento, num_documento, direccion, telefono, email, url) " +
        //                "values('" + Proveedor.Idproveedor + "','" + Proveedor.Razon_Social + "','" + Proveedor.Sector_Comercial + "','" + Proveedor.Tipo_Documento + "','" + Proveedor.Num_Documento + "','" + Proveedor.Direccion + "','" + Proveedor.Telefono + "','" + Proveedor.Email + "','" + Proveedor.Url + "')");
        //            cmdInsert.Connection = cnnInsert;
        //            rpta = Convert.ToString(cmdInsert.ExecuteNonQuery());
        //            cnnInsert.Close();
        //        }
        //        MessageBox.Show("Se Agrego Proveedor con Exito");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return rpta;
        //}

        ////Método Editar
        //public string Editar(DProveedor Proveedor)
        //{
        //    string rpta = "";
        //    try
        //    {
        //        using (var cnnUpdate = new SqlConnection(RRSOFT.CnnStr))
        //        {
        //            cnnUpdate.Open();
        //            SqlCommand cmdUpdate = new SqlCommand("UPDATE Proveedor SET razon_social = '" + Proveedor.Razon_Social + "', sector_comercial = '" + Proveedor.Sector_Comercial + "', tipo_documento = '" + Proveedor.Tipo_Documento + "', num_documento = '" + Proveedor.Num_Documento + "', direccion = '" + Proveedor.Direccion + "', telefono = '" + Proveedor.Telefono + "', email = '" + Proveedor.Email + "', url = '" + Proveedor.Url + "' WHERE idproveedor = '" + Proveedor.Idproveedor + "'");
        //            cmdUpdate.Connection = cnnUpdate;
        //            rpta = Convert.ToString(cmdUpdate.ExecuteNonQuery());
        //        }
        //        MessageBox.Show("Se Modifico el Producto con Exito");
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("1.- No puedes modificar este articulo ya que tiene varias ventas relacionadas \n 2.- No Puedes Modiciar el Nombre \n 3.- La minimo Stock tiene que ser menor al actual cantidad \n 4.- Error de Sistema Verifiquelo con el Proveedor");
        //    }
        //    return rpta;
        //}

        ////Método Eliminar
        //public string Eliminar(DProveedor Proveedor)
        //{
        //    string rpta = "";
        //    SqlConnection SqlCon = new SqlConnection();
        //    try
        //    {
        //        //Código
        //        SqlCon.ConnectionString = RRSOFT.CnnStr;
        //        SqlCon.Open();
        //        //Establecer el Comando
        //        SqlCommand SqlCmd = new SqlCommand();
        //        SqlCmd.Connection = SqlCon;
        //        SqlCmd.CommandText = "speliminar_proveedor";
        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter ParIdproveedor = new SqlParameter();
        //        ParIdproveedor.ParameterName = "@idproveedor";
        //        ParIdproveedor.SqlDbType = SqlDbType.Int;
        //        ParIdproveedor.Value = Proveedor.Idproveedor;
        //        SqlCmd.Parameters.Add(ParIdproveedor);


        //        //Ejecutamos nuestro comando

        //        rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


        //    }
        //    catch (Exception ex)
        //    {
        //        rpta = ex.Message;
        //    }
        //    finally
        //    {
        //        if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
        //    }
        //    return rpta;
        //}

        ////Método Mostrar
        //public DataTable Mostrar()
        //{
        //    DataTable DtResultado = new DataTable("proveedor");
        //    SqlConnection SqlCon = new SqlConnection();
        //    try
        //    {
        //        SqlCon.ConnectionString = RRSOFT.CnnStr;
        //        SqlCommand SqlCmd = new SqlCommand();
        //        SqlCmd.Connection = SqlCon;
        //        SqlCmd.CommandText = "spmostrar_proveedor";
        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
        //        SqlDat.Fill(DtResultado);

        //    }
        //    catch (Exception ex)
        //    {
        //        DtResultado = null;
        //    }
        //    return DtResultado;

        //}


        ////Método BuscarNombre
        //public DataTable BuscarRazon_Social(DProveedor Proveedor)
        //{
        //    DataTable DtResultado = new DataTable("proveedor");
        //    SqlConnection SqlCon = new SqlConnection();
        //    try
        //    {
        //        SqlCon.ConnectionString = RRSOFT.CnnStr;
        //        SqlCommand SqlCmd = new SqlCommand();
        //        SqlCmd.Connection = SqlCon;
        //        SqlCmd.CommandText = "spbuscar_proveedor_razon_social";
        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter ParTextoBuscar = new SqlParameter();
        //        ParTextoBuscar.ParameterName = "@textobuscar";
        //        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
        //        ParTextoBuscar.Size = 50;
        //        ParTextoBuscar.Value = Proveedor.TextoBuscar;
        //        SqlCmd.Parameters.Add(ParTextoBuscar);

        //        SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
        //        SqlDat.Fill(DtResultado);

        //    }
        //    catch (Exception ex)
        //    {
        //        DtResultado = null;
        //    }
        //    return DtResultado;

        //}




        //public DataTable BuscarNum_Documento(DProveedor Proveedor)
        //{
        //    DataTable DtResultado = new DataTable("proveedor");
        //    SqlConnection SqlCon = new SqlConnection();
        //    try
        //    {
        //        SqlCon.ConnectionString = RRSOFT.CnnStr;
        //        SqlCommand SqlCmd = new SqlCommand();
        //        SqlCmd.Connection = SqlCon;
        //        SqlCmd.CommandText = "spbuscar_proveedor_num_documento";
        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter ParTextoBuscar = new SqlParameter();
        //        ParTextoBuscar.ParameterName = "@textobuscar";
        //        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
        //        ParTextoBuscar.Size = 50;
        //        ParTextoBuscar.Value = Proveedor.TextoBuscar;
        //        SqlCmd.Parameters.Add(ParTextoBuscar);

        //        SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
        //        SqlDat.Fill(DtResultado);

        //    }
        //    catch (Exception ex)
        //    {
        //        DtResultado = null;
        //    }
        //    return DtResultado;

        //}
        public SqlCommand SqlCommand(string Sql, SqlConnection conn)
        {
            SqlCommand ss = new SqlCommand(Sql, conn);
            return ss;
        }
    }
}
