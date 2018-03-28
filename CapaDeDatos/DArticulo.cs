
using Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class DArticulo
    {
        #region Variables
        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _Idcategoria;
        private int _Idpresentacion;
        private string _TextoBuscar;
        #endregion

        #region Encapsulamiento
        public int Idarticulo
        {
            get { return _Idarticulo; }
            set { _Idarticulo = value; }
        }
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
        public int Idcategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value; }
        }
        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        #endregion

        public DArticulo()
        {

        }

        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string textobuscar)
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;

        }

        public string Insertar(DArticulo Articulo)
        {
            string rpta = "";

            using (var cnnInsert = new SqlConnection(RRSOFT.CnnStr))
            {
                cnnInsert.Open();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO articulo(codigo, nombre, descripcion, imagen, " +
                    "idcategoria, idpresentacion) values('" + Articulo.Codigo + "','" + Articulo.Nombre + "','" + Articulo.Descripcion + "','" + Articulo.Imagen + "','" + Articulo.Idcategoria + "','" + Articulo.Idpresentacion + "')");
                cmdInsert.Connection = cnnInsert;
                rpta = cmdInsert.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
                cnnInsert.Close();
            }          
            return rpta;
        }

        public string Editar(DArticulo Articulo)
        {
            string rpta = "";

            using (var cnnUpdate = new SqlConnection(RRSOFT.CnnStr))
            {
                cnnUpdate.Open();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE articulo SET nombre = '" + Articulo.Nombre + "', codigo = '" + Articulo.Codigo + "', descripcion = '" + Articulo.Descripcion + "', imagen = '" + Articulo.Imagen + "', idcategoria = '" + Articulo.Idcategoria + "', idpresentacion = '" + Articulo.Idpresentacion + "' WHERE Idarticulo = '" + Articulo.Idarticulo + "'");
                cmdUpdate.Connection = cnnUpdate;
                rpta = cmdUpdate.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";
            }   
            return rpta;
        }
        
        public string Eliminar(DArticulo Articulo)
        {
            string rpta = "";      
            
            using (var cnnDelete = new SqlConnection(RRSOFT.CnnStr))
            {
                cnnDelete.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cnnDelete;
                cmdDelete.CommandText = "DELETE FROM articulo WHERE idarticulo like '%" + Articulo.Idarticulo + "%'";
                rpta = cmdDelete.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";
            }
            return rpta;
        }
        
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = RRSOFT.CnnStr;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_articulo";
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
        
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = RRSOFT.CnnStr;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_articulo_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Articulo.TextoBuscar;
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

        public DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = RRSOFT.CnnStr;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spstock_articulos";
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
    }
}
