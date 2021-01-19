using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GS_Empleados
    {
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public System.DateTime fecha_nacimiento { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public bool privilegios { get; set; }

    }
}
