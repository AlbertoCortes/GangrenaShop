using Model;
using System;
using System.Windows.Forms;
using Buissness;

namespace GangrenaShop.Usuarios
{
    public partial class Nuevo : Form
    {
        public GS_Empleados empleado = new GS_Empleados();
        BuissnessClass buisnes = new BuissnessClass();
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
        }

        public void ObtenerDatos()
        {
            empleado.nombre = textBox1.Text;
            empleado.apellido_paterno = textBox2.Text;
            empleado.apellido_materno = textBox3.Text;
            empleado.fecha_nacimiento = dateTimePicker1.Value.Date;
            empleado.usuario = textBox4.Text;
            empleado.contrasena = textBox5.Text;
            if (comboBox1.Text == "Si") empleado.privilegios = true;
            else empleado.privilegios = false;
        }
        public bool validate(GS_Empleados empleado)
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

        private void button2_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
            if (!validate(empleado))
            {
                MessageBox.Show("Llene todos los campos");
            }
            else
            {
                if (buisnes.AddEmpleado(empleado))
                {
                    MessageBox.Show("Empleado Agregado");
                }

            }
        }
    }
}
