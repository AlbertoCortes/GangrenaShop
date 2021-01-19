using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Data
{
    public class DataClass
    {

        static GangrenaShopEntities model = new GangrenaShopEntities();
        static CommonClass com = new CommonClass();

        public  List<GS_Empleados> GetEmpleados()
        {
            var obj = model.Empleados.ToList();
            return com.SerializeJson<IEnumerable<Empleados>, List<GS_Empleados>>(obj);
        }



    }
}
