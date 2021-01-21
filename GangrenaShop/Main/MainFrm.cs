using GangrenaShop.PuntoVenta;
using GangrenaShop.Usuarios;
using System;
using System.Linq;
using System.Windows.Forms;
using Buissness;
using Model;
using GangrenaShop.Productos;
using GangrenaShop.Clientes;
using GangrenaShop.Proveedores;

namespace GangrenaShop.Main
{
    public partial class MainFrm : Form
    {
        public bool ID_sesion; //Variable sesion admin true = admin / false = normal
        public static GS_Empleados empleado;

        public BuissnessClass comun = new BuissnessClass();
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
        public MainFrm()
        {
        }

        public MainFrm(int id) {
            InitializeComponent();
            var form = Application.OpenForms.OfType<MenuPanelForm>().FirstOrDefault();
            MenuPanelForm hijo = form ?? new MenuPanelForm();
            AddFormInPanel(hijo);
            GetEmpleado(id);
            if(!empleado.privilegios)
                {
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                }
            label9.Text = empleado.nombre +' '+ empleado.apellido_paterno;
        
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToShortTimeString();
            label8.Text = DateTime.Now.ToShortDateString();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//Cerrar button

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        } // Minimizar Maximizar

        private void GetEmpleado(int id) //Obtiene el valor de sesion de usuario
        {
            empleado = comun.GetEmpleado(id);
        }




        private void AbrirFormulario<T>() where T : Form, new()
        {
            Form formulario = panel_menu.Controls.OfType<T>().FirstOrDefault();
            if (formulario != null)
            {
                //Si la instancia esta minimizada la dejamos en su estado normal
                if (formulario.WindowState == FormWindowState.Minimized)
                {
                    formulario.WindowState = FormWindowState.Normal;
                }
                //Si la instancia existe la pongo en primer plano
                formulario.BringToFront();
                return;
            }
            //Se abre el form
            formulario = new T();
            formulario.TopLevel = false;
            panel_menu.Controls.Add(formulario);
            panel_menu.Tag = formulario;
            formulario.Show();
        }

//        AbrirFormulario<PuntoVentaForm>();

        private void button1_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<PuntoVentaForm>().FirstOrDefault();
            PuntoVentaForm hijo = form ?? new PuntoVentaForm();
            AddFormInPanel(hijo);   
        }



        public void AddFormInPanel(Form fh)
        {
            if (this.superPanel.Controls.Count > 0)
                this.superPanel.Controls.RemoveAt(0);
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.superPanel.Controls.Add(fh);
            this.superPanel.Tag = fh;
            fh.Show();
        }

        private void panel_ventas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form = Application.OpenForms.OfType<PuntoVentaForm>().FirstOrDefault();
            PuntoVentaForm hijo = form ?? new PuntoVentaForm();
            AddFormInPanel(hijo);
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form = Application.OpenForms.OfType<MenuPanelForm>().FirstOrDefault();
            MenuPanelForm hijo = form ?? new MenuPanelForm();
            AddFormInPanel(hijo);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<Empleados>().FirstOrDefault();
            Empleados hijo = form ?? new Empleados();
            AddFormInPanel(hijo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<ProductosFrm>().FirstOrDefault();
            ProductosFrm hijo = form ?? new ProductosFrm();
            AddFormInPanel(hijo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<ClientesFrm>().FirstOrDefault();
            ClientesFrm hijo = form ?? new ClientesFrm();
            AddFormInPanel(hijo);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<ProveedoresFrm>().FirstOrDefault();
            ProveedoresFrm hijo = form ?? new ProveedoresFrm();
            AddFormInPanel(hijo);
        }
    }
}
