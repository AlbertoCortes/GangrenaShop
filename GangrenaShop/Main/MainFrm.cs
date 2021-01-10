using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GangrenaShop.PuntoVenta;

namespace GangrenaShop.Main
{
    public partial class MainFrm : Form
    {
        
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
            InitializeComponent();
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void panel_menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_ventas_MouseHover(object sender, EventArgs e)
        {
            panel_ventas.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panelVideojuegos_MouseHover(object sender, EventArgs e)
        {
            panelVideojuegos.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {
            panel6.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panel8_MouseHover(object sender, EventArgs e)
        {
            panel8.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panel10_MouseHover(object sender, EventArgs e)
        {
            panel10.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToShortTimeString();
            label8.Text = DateTime.Now.ToShortDateString();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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



        private void AddFormInPanel(Form fh)
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

        
    }
}
