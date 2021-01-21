using GangrenaShop.Main;
using System;
using System.Windows.Forms;

namespace GangrenaShop.PuntoVenta
{
    public partial class PuntoVentaForm : Form
    {
        double primero, segundo;
        string operador;
        public PuntoVentaForm()
        {
            InitializeComponent();
            label9.Text = MainFrm.empleado.nombre +" " +MainFrm.empleado.apellido_paterno ;
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

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToShortTimeString();

        }


        //-------------------------------------CALCU ------------------------------------------//

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text += "0";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text += ".";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text += "1";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text += "2";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Text += "3";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text += "4";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text += "5";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text += "6";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text += "7";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text += "8";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            operador = "+";
            primero = Double.Parse(textBox2.Text);
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            operador = "-";
            primero = Double.Parse(textBox2.Text);
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            operador = "*";
            primero = Double.Parse(textBox2.Text);
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            operador = "/";
            primero = Double.Parse(textBox2.Text);
            textBox2.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text += "9";
        }

        public double Suma(double a, double b) => a + b;

        public double Resta(double a, double b) => a - b;
        public double Multiplicar(double a, double b) => a * b;


        public double Dividir(double a, double b) => a / b;

        private void button18_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            primero = 0;
            segundo = 0; 
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
            
            if(e.KeyChar == (char)'+'){
                operador = "+";
                primero = Double.Parse(textBox2.Text);
                textBox2.Clear();
            }else if(e.KeyChar == (char)'-')
            {
                operador = "-";
                primero = Double.Parse(textBox2.Text);
                textBox2.Clear();
            }else if(e.KeyChar == (char)'*')
            {
                operador = "*";
                primero = Double.Parse(textBox2.Text);
                textBox2.Clear();
            }else if(e.KeyChar == (char)'/')
            {
                operador = "/";
                primero = Double.Parse(textBox2.Text);
                textBox2.Clear();
            }

            if(e.KeyChar == Convert.ToChar(Keys.Return))
            {
                segundo = double.Parse(textBox2.Text);
                switch (operador)
                {
                    case "+":
                        textBox2.Text = Suma(primero, segundo).ToString();
                        break;
                    case "-":
                        textBox2.Text = Resta(primero, segundo).ToString();
                        break;
                    case "*":
                        textBox2.Text = Multiplicar(primero, segundo).ToString();
                        break;
                    case "/":
                        textBox2.Text = Dividir(primero, segundo).ToString();
                        break;

                }
            }

        

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox2.Text = string.Empty;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            segundo = double.Parse(textBox2.Text);
            switch (operador) {
                case "+":
                    textBox2.Text = Suma(primero, segundo).ToString();
                    break;
                case "-":
                    textBox2.Text = Resta(primero, segundo).ToString();
                    break;
                case "*":
                    textBox2.Text = Multiplicar(primero, segundo).ToString();
                    break;
                case "/":
                    textBox2.Text = Dividir(primero, segundo).ToString();
                    break;
            
            }

        }

    }
}
