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

        public bool UpdateEmpleado(GS_Empleados empleado)
        {
            try
            {
                Empleados emp = model.Empleados.Where(d => d.id_empleado == empleado.id_empleado).FirstOrDefault();
                emp.nombre = empleado.nombre;
                emp.apellido_paterno = empleado.apellido_paterno;
                emp.apellido_materno = empleado.apellido_materno;
                emp.fecha_nacimiento = empleado.fecha_nacimiento;
                emp.usuario = empleado.usuario;
                emp.contrasena = empleado.contrasena;
                emp.privilegios = empleado.privilegios;
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }







        //-----------------------------------------------------------------------------------------------------------

        public List<GS_Productos> GetAllProductos()
        {
            var obj = model.Productos.ToList();
            return com.SerializeJson<IEnumerable<Productos>, List<GS_Productos>>(obj);
        }

        public GS_Productos GetProducto(int id)//Regresa todos los datos del producto 
        {
            var obj = model.Productos.ToList();
            var prod = com.SerializeJson<IEnumerable<Productos>, List<GS_Productos>>(obj);
            return (from s in prod
                    where s.id_producto == id
                    select s).First();
        }





        public bool AddProducto(GS_Productos producto)
        {
            try
            {
                Productos prod = new Productos();
                prod.nombre = producto.nombre;
                prod.descripcion = producto.descripcion;
                prod.precio_compra = producto.precio_compra;
                prod.precio_venta = producto.precio_venta;
                prod.existencias = producto.existencias;
                prod.id_categoria = producto.id_categoria;
                prod.id_clasificacion = producto.id_clasificacion;
                prod.id_proveedor = producto.id_proveedor;
                model.Productos.Add(prod);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateProducto(GS_Productos producto)
        {
            try
            {
                Productos prod = model.Productos.Where(d => d.id_producto == producto.id_producto).FirstOrDefault();
                prod.nombre = producto.nombre;
                prod.nombre = producto.nombre;
                prod.descripcion = producto.descripcion;
                prod.precio_compra = producto.precio_compra;
                prod.precio_venta = producto.precio_venta;
                prod.existencias = producto.existencias;
                prod.id_categoria = producto.id_categoria;
                prod.id_clasificacion = producto.id_clasificacion;
                prod.id_proveedor = producto.id_proveedor;
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProducto(int id)
        {
            try
            {
                var obj = model.Productos.ToList();
                var prod = (from s in obj
                           where s.id_producto == id
                           select s).FirstOrDefault();
                model.Productos.Remove(prod);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool AddCategoria(GS_Categorias categoria)
        {
            try
                {
                Categorias cat = new Categorias();
                cat.nombre = categoria.nombre;
                cat.descripcion = categoria.descripcion;
                model.Categorias.Add(cat);
                model.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
        }

        public bool AddClasificacion(GS_Clasificaciones clasificacion)
        {
            try
            {
                Clasificaciones clas = new Clasificaciones();
                clas.nombre = clasificacion.nombre;
                clas.descripcion = clasificacion.descripcion;
                model.Clasificaciones.Add(clas);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<GS_Categorias> GetCategorias()
        {
            var obj = model.Categorias.ToList();
            return com.SerializeJson<IEnumerable<Categorias>, List<GS_Categorias>>(obj);
        }
        public List<GS_Clasificaciones> GetClasificaciones()
        {
            var obj = model.Clasificaciones.ToList();
            return com.SerializeJson<IEnumerable<Clasificaciones>, List<GS_Clasificaciones>>(obj);
        }
        
        public List<GS_Proveedores> GetProveedores()
        {
            var obj = model.Proveedores .ToList();
            return com.SerializeJson<IEnumerable<Proveedores>, List<GS_Proveedores>>(obj);
        }



    }
}
