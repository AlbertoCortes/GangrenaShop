using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GS_Ventas_conceptos
    {
        //  public int id_ventas_conceptos { get; set; }
        public int id_venta_concepto { get; set; }
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
    }
}
