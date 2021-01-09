using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
