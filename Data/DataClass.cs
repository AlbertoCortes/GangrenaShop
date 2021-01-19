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

        public bool LoginCheck (string user, string pass)
        {
            try
            {
                var obj = (from s in model.Empleados
                           where s.usuario == user && s.contrasena == pass
                           select s).FirstOrDefault();
                if(obj != null)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public int GetId(string user, string pass)
        {
            return (from s in model.Empleados
                    where s.usuario == user && s.contrasena == pass
                    select s.id_empleado).FirstOrDefault();
        }


        public  List<GS_Empleados> GetEmpleados()
        {
            var obj = model.Empleados.ToList();
            return com.SerializeJson<IEnumerable<Empleados>, List<GS_Empleados>>(obj);
        }



    }
}
