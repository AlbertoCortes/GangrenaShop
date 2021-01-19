using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Class1
    {

        GangrenaShopEntities model = new GangrenaShopEntities();

        public List<Empleados> getEmpleados()
        {
            return model.Empleados.ToList();

        }
    }
}
