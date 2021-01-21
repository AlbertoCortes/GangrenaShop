using Buissness;
using Model;
using System;
using System.Windows.Forms;

namespace GangrenaShop.Clientes
{
    public partial class Nuevo : Form
    {
        public GS_Clientes clienteNuevo = new GS_Clientes();
        public GS_Clientes clienteUpdated = new GS_Clientes();
        public GS_Clientes clienteToUpdate = new GS_Clientes();
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
            label1.Text = "Nuevo Cliente";
            NuevoEditar = true;
        }
        
        public Nuevo(GS_Clientes cliente)
        {
            InitializeComponent();
            label1.Text = "Actualizar Cliente";
            textBox1.Text = cliente.nombre;
            textBox2.Text = cliente.apellido_paterno;
            textBox3.Text = cliente.apellido_materno;
            dateTimePicker1.Value = cliente.fecha_nacimiento;
            textBox4.Text = cliente.direccion;
            textBox5.Text = cliente.correo;
            textBox6.Text = cliente.telefono;
            NuevoEditar = false;
            clienteToUpdate = cliente;
        }
        public GS_Clientes ObtenerDatos()
        {
            GS_Clientes cli = new GS_Clientes();
            cli.nombre = textBox1.Text;
            cli.apellido_paterno = textBox2.Text;
            cli.apellido_materno = textBox3.Text;
            cli.fecha_nacimiento = dateTimePicker1.Value.Date;
            cli.direccion = textBox4.Text;
            cli.correo = textBox5.Text;
            cli.telefono = textBox6.Text;
            return cli;
        }
        public bool validate()
        {
            if (
                textBox1.Text == "" ||
                textBox2.Text == "" ||
                textBox3.Text == "" ||
                textBox6.Text == "" ||
                textBox5.Text == "")
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
                    clienteNuevo = ObtenerDatos();
                    if (buisnes.AddCliente(clienteNuevo))
                    {
                        MessageBox.Show("Cliente Agregado");
                        this.Close();
                    }
                }
                else if (NuevoEditar == false)
                {
                    clienteUpdated = ObtenerDatos();
                    clienteUpdated.id_cliente = clienteToUpdate.id_cliente;
                    if (buisnes.UpdateCliente(clienteUpdated))
                    {
                        MessageBox.Show("Cliente Actualizado");
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
