using System;
using System.Windows.Forms;

namespace GangrenaShop.PuntoVenta
{
    public partial class PuntoVentaForm : Form
    {
        public PuntoVentaForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Buscar Producto";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Buscar Producto")
            {
                textBox1.Text = "";
            }
        }
    }
}
