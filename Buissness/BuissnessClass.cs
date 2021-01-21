using Data;
using Model;
using System.Collections.Generic;
using System.Linq;

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


        public bool UpdateEmpleado(GS_Empleados empleado)
        {
            return data.UpdateEmpleado(empleado);
        }


        //----------------------------------------------------------------------------------------

        public List<GS_Productos> GetAllProductos()
        {
            return data.GetAllProductos();
        }

        public GS_Productos GetProducto(int id)
        {
            return data.GetProducto(id);
        }

        public bool DeleteProducto(int id) 
        {
            return data.DeleteProducto(id);
        }

        public bool AddProducto(GS_Productos producto)
        {
            return data.AddProducto(producto);

        }

        public bool UpdateProducto(GS_Productos producto) {
            return data.UpdateProducto(producto);
        }
        
        public bool AddCategoria(GS_Categorias categoria)
        {
            return data.AddCategoria(categoria);

        }

        public bool AddClasificacion(GS_Clasificaciones clasificacion)
        {
            return data.AddClasificacion(clasificacion);
        }

        public List<GS_Categorias> GetCategorias()
        {
            return data.GetCategorias();
        }

        public List<GS_Clasificaciones> GetClasificaciones()
        {
            return data.GetClasificaciones();
        }

        public List<GS_Proveedores> GetProveedores()
        {
            return data.GetProveedores();
        }

        public int idCategoria(string nombre)
        {
            List<GS_Categorias> cat = new List<GS_Categorias>();
            cat= data.GetCategorias();
            var id = (from s in cat
                     where s.nombre == nombre
                     select s.id_categoria).FirstOrDefault();
            return id;           
        }
        public int idClasificacion(string nombre)
        {
            List<GS_Clasificaciones> cat = new List<GS_Clasificaciones>();
            cat= data.GetClasificaciones();
            var id = (from s in cat
                     where s.nombre == nombre
                     select s.id_clasificacion).FirstOrDefault();
            return id;           
        }
        public int idProveedor(string nombre)
        {
            List<GS_Proveedores> cat = new List<GS_Proveedores>();
            cat= data.GetProveedores();
            var id = (from s in cat
                     where s.nombre == nombre
                     select s.id_proveedor).FirstOrDefault();
            return id;           
        }

        //---------------------------------------------------------------------------------------------------------------------------

        public List<GS_Clientes> GetAllClientes()
        {
            return data.GetAllClientes();
        }

        public GS_Clientes GetCliente(int id)
        {
            return data.GetCliente(id);
        }

        public bool DeleteCliente(int id)
        {
            return data.DeleteCliente(id);
        }

        public bool AddCliente(GS_Clientes cliente)
        {
            return data.AddCliente(cliente);

        }

        public bool UpdateCliente(GS_Clientes cliente)
        {
            return data.UpdateCliente(cliente);
        }



        //------------------------------------------------------------------------------------------------

        public List<GS_Proveedores> GetAllProveedores()
        {
            return data.GetAllProveedores();
        }

        public GS_Proveedores GetProveedor(int id)
        {
            return data.GetProveedor(id);
        }

        public bool DeleteProveedor(int id)
        {
            return data.DeleteProveedor(id);
        }

        public bool AddProveedor(GS_Proveedores proveedor)
        {
            return data.AddProveedor(proveedor);

        }

        public bool UpdateProveedor(GS_Proveedores proveedor)
        {
            return data.UpdateProveedor(proveedor);
        }





    }
}
