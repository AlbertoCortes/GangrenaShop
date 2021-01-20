using Model;
using System;
using System.Windows.Forms;
using Buissness;

namespace GangrenaShop.Usuarios
{
    public partial class Nuevo : Form
    {
        public GS_Empleados empleadoNuevo = new GS_Empleados();
        public GS_Empleados empleadoUpdated = new GS_Empleados();
        public GS_Empleados empleadoToUpdate = new GS_Empleados();
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
            label1.Text = "Nuevo Empleado";
            NuevoEditar = true;
        }

        public Nuevo(GS_Empleados empleado) //editar
        {
            InitializeComponent();
            label1.Text ="Actualizar Empleado";
            textBox1.Text = empleado.nombre;
            textBox2.Text = empleado.apellido_paterno;
            textBox3.Text = empleado.apellido_materno;
            textBox4.Text = empleado.usuario;
            textBox5.Text = empleado.contrasena;
            dateTimePicker1.Value = empleado.fecha_nacimiento;
            if (empleado.privilegios == true)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;

            }
            NuevoEditar = false;
            empleadoToUpdate = empleado;

        }

        public GS_Empleados ObtenerDatos()
        {
            GS_Empleados emp = new GS_Empleados();
            emp.nombre = textBox1.Text;
            emp.apellido_paterno = textBox2.Text;
            emp.apellido_materno = textBox3.Text;
            emp.fecha_nacimiento = dateTimePicker1.Value.Date;
            emp.usuario = textBox4.Text;
            emp.contrasena = textBox5.Text;
            if (comboBox1.Text == "Si") emp.privilegios = true;
            else emp.privilegios = false;

            return emp;
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
                    empleadoNuevo = ObtenerDatos();
                    if (buisnes.AddEmpleado(empleadoNuevo))
                    {
                        MessageBox.Show("Empleado Agregado");
                        this.Close();
                    }
                }
                else if(NuevoEditar == false)
                {
                    empleadoUpdated = ObtenerDatos();
                    empleadoUpdated.id_empleado = empleadoToUpdate.id_empleado;
                    if (buisnes.UpdateEmpleado(empleadoUpdated))
                    {
                        MessageBox.Show("Empleado Actualizado");
                        this.Close();
                    }
                }


                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
