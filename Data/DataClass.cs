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
        }//Checa el login usuario

        public int GetId(string user, string pass) //obtiene el id del usuario
        {
            return (from s in model.Empleados
                    where s.usuario == user && s.contrasena == pass
                    select s.id_empleado).FirstOrDefault();
        }

        public bool AdminValidate(int id) // Checa si el id es admin o no (true = admin, false = noadmin)
        {
            return (from s in model.Empleados
                    where s.id_empleado == id
                    select s.privilegios).First();
        }

        public GS_Empleados GetEmpleado(int id)//Regresa todos los datos del empleado 
        {
            var obj = model.Empleados.ToList();
            var emp= com.SerializeJson<IEnumerable<Empleados>, List<GS_Empleados>>(obj);
            return (from s in emp
                    where s.id_empleado == id
                    select s).First();
        }
        public  List<GS_Empleados> GetAllEmpleados()
        {
            var obj = model.Empleados.ToList();
            return com.SerializeJson<IEnumerable<Empleados>, List<GS_Empleados>>(obj);
        }

        public bool DeleteEmpleado(int id)
        {
            try
            {
                var obj = model.Empleados.ToList();
                var emp = (from s in obj
                           where s.id_empleado == id
                           select s).FirstOrDefault();
                model.Empleados.Remove(emp);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool AddEmpleado(GS_Empleados empleado)
        {
            try
            {
                Empleados emp = new Empleados();
                emp.nombre = empleado.nombre;
                emp.apellido_paterno = empleado.apellido_paterno;
                emp.apellido_materno = empleado.apellido_materno;
                emp.fecha_nacimiento = empleado.fecha_nacimiento;
                emp.usuario = empleado.usuario;
                emp.contrasena = empleado.contrasena;
                emp.privilegios = empleado.privilegios;
                model.Empleados.Add(emp);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }



    }
}
