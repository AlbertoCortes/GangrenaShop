 using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.Entity.SqlServer;

namespace Data
{
    public class DataClass
    {

        static GangrenaShopEntities model = new GangrenaShopEntities();
        static CommonClass com = new CommonClass();
        private static string __hack = typeof(SqlProviderServices).ToString();

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
            catch(Exception e)
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
            catch(Exception e)
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


        //--------------------------------------------------------------------------------------------------------------------------------------

        public List<GS_Clientes> GetAllClientes()
        {
            var obj = model.Clientes.ToList();
            return com.SerializeJson<IEnumerable<Clientes>, List<GS_Clientes>>(obj);
        }

        public GS_Clientes GetCliente(int id)//Regresa todos los datos del cliente 
        {
            var obj = model.Clientes.ToList();
            var cli = com.SerializeJson<IEnumerable<Clientes>, List<GS_Clientes>>(obj);
            return (from s in cli
                    where s.id_cliente == id
                    select s).First();
        }

        public bool AddCliente(GS_Clientes cliente)
        {
            try
            {
                Clientes cli = new Clientes();
                cli.nombre = cliente.nombre;
                cli.apellido_paterno = cliente.apellido_paterno;
                cli.apellido_materno = cliente.apellido_materno;
                cli.fecha_nacimiento = cliente.fecha_nacimiento;
                cli.direccion = cliente.direccion;
                cli.correo = cliente.correo;
                cli.telefono = cliente.telefono;
                model.Clientes.Add(cli);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateCliente(GS_Clientes cliente)
        {
            try
            {
                Clientes cli = model.Clientes.Where(d => d.id_cliente == cliente.id_cliente).FirstOrDefault();
                cli.nombre = cliente.nombre;
                cli.apellido_paterno = cliente.apellido_paterno;
                cli.apellido_materno = cliente.apellido_materno;
                cli.fecha_nacimiento = cliente.fecha_nacimiento;
                cli.direccion = cliente.direccion;
                cli.correo = cliente.correo;
                cli.telefono = cliente.telefono;
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCliente(int id)
        {
            try
            {
                var obj = model.Clientes.ToList();
                var cli = (from s in obj
                            where s.id_cliente == id
                            select s).FirstOrDefault();
                model.Clientes.Remove(cli);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        //-----------------------------------------------------------------------------------------------------------------------------
        public List<GS_Proveedores> GetAllProveedores()
        {
            var obj = model.Proveedores.ToList();
            return com.SerializeJson<IEnumerable<Proveedores>, List<GS_Proveedores>>(obj);
        }

        public GS_Proveedores GetProveedor(int id)//Regresa todos los datos del cliente 
        {
            var obj = model.Proveedores.ToList();
            var prov = com.SerializeJson<IEnumerable<Proveedores>, List<GS_Proveedores>>(obj);
            return (from s in prov
                    where s.id_proveedor == id
                    select s).First();
        }

        public bool AddProveedor(GS_Proveedores proveedor)
        {
            try
            {
                Proveedores prov = new Proveedores();
                prov.nombre = proveedor.nombre;
                prov.nombre_de_contacto = proveedor.nombre_de_contacto;
                prov.direccion = proveedor.direccion;
                prov.telefono = proveedor.telefono;
                prov.correo = proveedor.correo;
                prov.status = proveedor.status;
                model.Proveedores.Add(prov);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateProveedor(GS_Proveedores proveedor)
        {
            try
            {
                Proveedores prov = model.Proveedores.Where(d => d.id_proveedor == proveedor.id_proveedor).FirstOrDefault();
                prov.nombre = proveedor.nombre;
                prov.nombre_de_contacto = proveedor.nombre;
                prov.direccion = proveedor.direccion;
                prov.telefono = proveedor.telefono;
                prov.correo = proveedor.correo;
                prov.status = proveedor.status;
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProveedor(int id)
        {
            try
            {
                var obj = model.Proveedores.ToList();
                var prov = (from s in obj
                           where s.id_proveedor == id
                           select s).FirstOrDefault();
                model.Proveedores.Remove(prov);
                model.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }




        public bool GuardarVenta(GS_Ventas venta, List<GS_Ventas_conceptos> conceptos)
        {
            try
            {
                Ventas ven = new Ventas();
                ven.fecha_venta = venta.fecha_venta;
                ven.id_empleado = venta.id_empleado;
                ven.id_cliente = venta.id_cliente;
                ven.id_tipo_pago = 1;
                model.Ventas.Add(ven);
                
                int id_venta = ven.id_venta;
                foreach (var item in conceptos)
                {
                    Ventas_conceptos concepto = new Ventas_conceptos();
                    concepto.id_venta = id_venta;
                    concepto.id_producto = item.id_producto;
                    concepto.cantidad = 1;

                    Productos productom = (from s in model.Productos.ToList()
                                     where s.id_producto == item.id_producto
                                     select s).FirstOrDefault();

                    productom.existencias -= 1;
                    model.Ventas_conceptos.Add(concepto);
                    
                }
                model.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }



        public List<GS_Ventas> GetAllVentas()
        {
            var obj = model.Ventas.ToList();
            return com.SerializeJson<IEnumerable<Ventas>, List<GS_Ventas>>(obj);
        }


        public List<GS_Ventas_conceptos> GetAllConceptos()
        {
            var obj = model.Ventas_conceptos.ToList();
            return com.SerializeJson<IEnumerable<Ventas_conceptos>, List<GS_Ventas_conceptos>>(obj);
        }
















    }
}



