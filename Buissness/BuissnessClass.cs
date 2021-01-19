using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

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

    }
}
