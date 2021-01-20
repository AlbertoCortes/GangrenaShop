using Data;
using Model;
using System.Collections.Generic;

namespace Buissness
{
    public class BuissnessClass
    {
        DataClass data = new DataClass();

        public bool login(string user, string pass)
        {
            return data.LoginCheck(user, pass);
        }

        public int GetId(string user, string pass)
        {
            return data.GetId(user, pass);
        }

        public bool AdminValidate(int id)
        {
            return data.AdminValidate(id);
        }

        public GS_Empleados GetEmpleado(int id)
        {
            return data.GetEmpleado(id);
        }
        public List<GS_Empleados> GetAllEmpleados()
        {
            return data.GetAllEmpleados();
        }

        public bool DeleteEmpleado(int id)
        {
            return data.DeleteEmpleado(id);
        }

        public bool AddEmpleado(GS_Empleados empleado)
        {
            return data.AddEmpleado(empleado);
        }

    }
}
