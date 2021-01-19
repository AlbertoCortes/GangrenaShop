using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GS_Ventas
    {
        public int id_venta { get; set; }
        public System.DateTime fecha_venta { get; set; }
        public int id_empleado { get; set; }
        public int id_cliente { get; set; }
        public int id_tipo_pago { get; set; }
    }
}
