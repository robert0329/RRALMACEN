
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
        
        public static string CnnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            }
        }
    }
}
