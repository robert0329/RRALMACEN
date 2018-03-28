
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
    public class DCategoria
    {
        #region Variables
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;
        #endregion

        #region Encapsulamiento
        public int Idcategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value; }
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

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        #endregion

        #region Contrustore
        public DCategoria()
        {

        }
        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;

        }
        public DCategoria(string textobuscar)
        {
            this.TextoBuscar = textobuscar;

        }
        #endregion

        #region Metodos
        public string Insertar(DCategoria Categoria)
        {
            string rpta = "";

            using (var cnnInsert = new SqlConnection(RRSOFT.CnnStr))
            {
                cnnInsert.Open();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO categoria(nombre, descripcion) values('" + Categoria.Nombre + "','" + Categoria.Descripcion +"')");
                cmdInsert.Connection = cnnInsert;
                rpta = cmdInsert.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
                cnnInsert.Close();
            }
            return rpta;
        }

        public string Editar(DCategoria Categoria)
        {
            string rpta = "";

            using (var cnnUpdate = new SqlConnection(RRSOFT.CnnStr))
            {
                cnnUpdate.Open();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE categoria SET nombre = '" + Categoria.Nombre + "', descripcion = '" + Categoria.Descripcion + "' WHERE idcategoria = '" + Categoria.Idcategoria + "'");
                cmdUpdate.Connection = cnnUpdate;
                rpta = cmdUpdate.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";
            }
            return rpta;
        }

        public string Eliminar(DCategoria Categoria)
        {
            string rpta = "";

            using (var cnnDelete = new SqlConnection(RRSOFT.CnnStr))
            {
                cnnDelete.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cnnDelete;
                cmdDelete.CommandText = "DELETE FROM categoria WHERE idcategoria like '%" + Categoria.Idcategoria + "%'";
                rpta = cmdDelete.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";
            }
            return rpta;
        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = RRSOFT.CnnStr;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
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

        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = RRSOFT.CnnStr;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
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
        #endregion
    }
}
