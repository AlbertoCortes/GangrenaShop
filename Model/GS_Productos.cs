using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GS_Productos
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio_compra { get; set; }
        public decimal precio_venta { get; set; }
        public int existencias { get; set; }
        public int id_categoria { get; set; }
        public int id_clasificacion { get; set; }
        public int id_proveedor { get; set; }
    }
}
