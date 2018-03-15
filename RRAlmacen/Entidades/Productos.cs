using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRAlmacen.Entidades
{
    public class Productos
    {
        [Key]
        public int Producto_Id { get; set; }
        public string Desc_Producto { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public int Stock_Minima { get; set; }
        public string Area { get; set; }
        //public int Departamento_Id { get; set; }
        //public double ITBIS { get; set; }
                
    }
}
