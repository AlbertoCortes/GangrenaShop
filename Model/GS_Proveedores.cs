using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GS_Proveedores
    {
        public int id_proveedor { get; set; }
        public string nombre { get; set; }
        public string nombre_de_contacto { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public bool status { get; set; }
    }
}
