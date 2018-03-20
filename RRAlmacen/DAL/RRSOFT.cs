
using RRAlmacen.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRAlmacen.DAL
{
    public class RRSOFT: DbContext
    {
        public RRSOFT() : base("name = ConStr")
        {

        }
        public SqlConnection establecerConexion()
        {
            string cs = "Data Source=NOMBRE_SERVER;Initial Catalog=NOMBRE_BD;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            return con;
        }
        public static string CnnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            }
        }
        public virtual DbSet<Productos> productos { get; set; }
        public virtual DbSet<Usuarios> usuario { get; set; }

    }
}
