using Buissness;
using Model;
using System;
using System.Windows.Forms;

namespace GangrenaShop.Proveedores
{
    public partial class Nuevo : Form
    {

        public GS_Proveedores proveedorNuevo = new GS_Proveedores();
        public GS_Proveedores proveedorUpdated = new GS_Proveedores();
        public GS_Proveedores proveedorToUpdate = new GS_Proveedores();
        BuissnessClass buisnes = new BuissnessClass();
        public bool NuevoEditar;   // true nuevo,, false editar




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
            label1.Text = "Nuevo Proveedor";
            NuevoEditar = true;
        }


        public Nuevo(GS_Proveedores proveedor)
        {
            InitializeComponent();
            label1.Text = "Actualizar Proveedor";
            textBox1.Text = proveedor.nombre;
            textBox2.Text = proveedor.nombre_de_contacto;
            textBox3.Text = proveedor.direccion;
            textBox4.Text = proveedor.telefono;
            textBox5.Text = proveedor.correo;
            NuevoEditar = false;
            proveedorToUpdate = proveedor;
        }


        public GS_Proveedores ObtenerDatos()
        {
            GS_Proveedores prov = new GS_Proveedores();
            prov.nombre = textBox1.Text;
            prov.nombre_de_contacto = textBox2.Text;
            prov.direccion = textBox3.Text;
            prov.telefono = textBox4.Text;
            prov.correo = textBox5.Text;
            prov.status = true;
            return prov;
        }



        public bool validate()
        {
            if (
                textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                textBox4.Text == "" ||
                textBox5.Text == "")
                return false;

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ObtenerDatos();
            if (!validate())
            {
                MessageBox.Show("Llene todos los campos");
            }
            else
            {
                if (NuevoEditar == true)
                {
                    proveedorNuevo = ObtenerDatos();
                    if (buisnes.AddProveedor(proveedorNuevo))
                    {
                        MessageBox.Show("Proveedor Agregado");
                        this.Close();
                    }
                }
                else if (NuevoEditar == false)
                {
                    proveedorUpdated = ObtenerDatos();
                    proveedorUpdated.id_proveedor= proveedorToUpdate.id_proveedor;
                    if (buisnes.UpdateProveedor(proveedorUpdated))
                    {
                        MessageBox.Show("Proveedor Actualizado");
                        this.Close();
                    }
                }
            }
        }
    }
}
