using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Buissness;
using System.Windows.Forms;

namespace GangrenaShop.Productos
{
    public partial class Nuevo : Form
    {
        BuissnessClass buis = new BuissnessClass();
        List<GS_Categorias> categorias = new List<GS_Categorias>();
        List<GS_Clasificaciones> clasificaciones = new List<GS_Clasificaciones>();
        List<GS_Proveedores> proveedores = new List<GS_Proveedores>();

        public bool NuevoEditar;
        GS_Productos productoNuevo = new GS_Productos();
        GS_Productos productoUpdated = new GS_Productos();
        GS_Productos productoToUpdate = new GS_Productos();
        protected override CreateParams CreateParams  // crea pequeña sombra en borderless form
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public Nuevo()
        {
            InitializeComponent();
            label1.Text = "Nuevo Producto";
            categorias = buis.GetCategorias();
            clasificaciones = buis.GetClasificaciones();
            proveedores = buis.GetProveedores();
            fillCombos();
            NuevoEditar = true;
        }
        
        public Nuevo(GS_Productos producto)
        {
            InitializeComponent();
            label1.Text = "Actualizar Producto";
            categorias = buis.GetCategorias();
            clasificaciones = buis.GetClasificaciones();
            proveedores = buis.GetProveedores();
            //fillCombos();
            textBox1.Text = producto.nombre;
            textBox5.Text = producto.descripcion;
            textBox2.Text = producto.precio_compra.ToString();
            textBox3.Text = producto.precio_venta.ToString();
            textBox4.Text = producto.existencias.ToString();
            comboBox1.Text = (from s in categorias
                              where s.id_categoria == producto.id_categoria
                              select s.nombre).FirstOrDefault();
            comboBox2.Text = (from s in clasificaciones
                              where s.id_clasificacion == producto.id_clasificacion
                              select s.nombre).FirstOrDefault();
            comboBox3.Text = (from s in proveedores
                              where s.id_proveedor == producto.id_proveedor
                              select s.nombre).FirstOrDefault();



            NuevoEditar = false;
            fillCombos();
            productoToUpdate = producto;
        }

        public void fillCombos()
        {
            foreach (var item in categorias)
            {
                comboBox1.Items.Add(item.nombre);
                comboBox1.ValueMember = item.id_categoria.ToString();
            }

            foreach (var item in clasificaciones)
            {
                comboBox2.Items.Add(item.nombre);
                comboBox2.ValueMember = item.id_clasificacion.ToString();

            }

            foreach (var item in proveedores)
            {
                comboBox3.Items.Add(item.nombre);
                comboBox3.ValueMember = item.id_proveedor.ToString();

            }
        }
        public bool validate()
        {
            if (
                textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                textBox4.Text == "" ||
                textBox5.Text == "" )
                return false;

            return true;
        }


        public GS_Productos ObtenerDatos()
        {
            GS_Productos prod = new GS_Productos();
            prod.nombre = textBox1.Text;
            prod.descripcion = textBox5.Text;
            prod.precio_compra = Convert.ToDecimal(textBox2.Text);
            prod.precio_venta = Convert.ToDecimal(textBox3.Text);
            prod.existencias = Convert.ToInt32(textBox4.Text);
            prod.id_categoria = buis.idCategoria(comboBox1.Text);
            prod.id_clasificacion = buis.idClasificacion(comboBox2.Text);
            prod.id_proveedor = buis.idProveedor(comboBox3.Text);
            return prod;
        }



        private void Nuevo_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                MessageBox.Show("Llene todos los campos");
            }
            else
            {
                if (NuevoEditar == true)
                {
                    productoNuevo = ObtenerDatos();
                    if (buis.AddProducto(productoNuevo))
                    {
                        MessageBox.Show("Producto Agregado");
                        this.Close();
                    }
                }
                else if (NuevoEditar == false)
                {
                    productoUpdated = ObtenerDatos();
                    productoUpdated.id_producto = productoToUpdate.id_producto;
                    if (buis.UpdateProducto(productoUpdated))
                    {
                        MessageBox.Show("Producto Actualizado");
                        this.Close();
                    }
                }




            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
