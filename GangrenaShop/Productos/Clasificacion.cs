using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Buissness;

namespace GangrenaShop.Productos
{
    public partial class Clasificacion : Form
    {
        BuissnessClass buisnes = new BuissnessClass();
        GS_Clasificaciones clas = new GS_Clasificaciones();
        public Clasificacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Llene todos los campos");
            }
            else
            {
                clas.nombre = textBox1.Text;
                clas.descripcion = textBox2.Text;
                buisnes.AddClasificacion(clas);
                MessageBox.Show("Clasificacion agregada");
                this.Close();
            }
        }
    }
}
