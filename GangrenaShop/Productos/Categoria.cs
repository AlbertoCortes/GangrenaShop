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
    public partial class Categoria : Form
    {
        BuissnessClass buisnes = new BuissnessClass();
        GS_Categorias cat = new GS_Categorias();
        public Categoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Llene todos los campos");
            }
            else
            {
                cat.nombre = textBox1.Text;
                cat.descripcion = textBox2.Text;
                buisnes.AddCategoria(cat);
                MessageBox.Show("Categoria agregada");
                this.Close();
            }
        }
    }
}
