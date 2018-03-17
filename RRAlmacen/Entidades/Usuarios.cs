using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRAlmacen.Entidades
{
    public class Usuarios
    {
        [Key]
        public int Usuario_Id { get; set; }
        public string USER_NAME { get; set; }
        public string USER_PASSWORD { get; set; }
        public string GRUPO { get; set; }
        public string PATERNO { get; set; }
        public string MATERNO { get; set; }
        public string NOMBRE { get; set; }
        public bool VENTAS { get; set; }
        public bool ADMINISTRAR { get; set; }
        public bool REPORTES { get; set; }
        public bool CATALOGOS { get; set; }
        public bool CONSULTAS { get; set; }
        public bool DESHACER_VENTA { get; set; }
        public bool LOGON { get; set; }
        public bool FACTURACION { get; set; }
    }
}
