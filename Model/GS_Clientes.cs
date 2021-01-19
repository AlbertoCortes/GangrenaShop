using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GS_Clientes
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public System.DateTime fecha_nacimiento { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public Nullable<int> telefono { get; set; }
    }
}
