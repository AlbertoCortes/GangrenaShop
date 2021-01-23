using Buissness;
using GangrenaShop.Main;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GangrenaShop.PuntoVenta
{
    public partial class PuntoVentaForm : Form
    {
        public BuissnessClass buisnes = new BuissnessClass();
        double primero, segundo;
        string operador;
        double total, totaiIva;
        public PuntoVentaForm()
        {
            InitializeComponent();
            label9.Text = MainFrm.empleado.nombre +" " +MainFrm.empleado.apellido_paterno ;
            fillCombos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }





        public void fillCombos()
        {
            List<GS_Clientes> cliente = new List<GS_Clientes>();
            cliente = buisnes.GetAllClientes();
            comboBox1.DataSource = cliente;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id_cliente";
            //foreach (var item in cliente)
            //{
            //    comboBox1.DataSource = cliente;
            //    comboBox1.Items.Add(item.nombre +" "+ item.apellido_paterno);
            //   comboBox1.ValueMember = item.id_cliente.ToString();
            //   // comboBox1.Items.Add(item.id_cliente);

            //}
        }







        private void button1_Click(object sender, EventArgs e)
        {
            if(metroGrid2.Rows.Count>0)
            {
                int id_clientee = Convert.ToInt32(comboBox1.SelectedValue);
                DialogResult dialogResult = MessageBox.Show("Confirmar compra", "Confirmar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GS_Ventas venta = new GS_Ventas();
                    venta.id_empleado = MainFrm.empleado.id_empleado;
                    venta.fecha_venta = DateTime.Today;
                    venta.id_cliente = id_clientee;
                    List<GS_Ventas_conceptos> conceptos = new List<GS_Ventas_conceptos>();

                    foreach (DataGridViewRow row in metroGrid2.Rows)
                    {
                        DataGridViewRow current = metroGrid2.CurrentRow;
                        GS_Ventas_conceptos co = new GS_Ventas_conceptos();


                        int idProd = Convert.ToInt32(current.Cells["id1"].Value);
                        List<GS_Productos> productos = buisnes.GetAllProductos();
                        var filt = (from s in productos
                                    where s.id_producto == idProd
                                    select s).FirstOrDefault();
                        co.id_producto = filt.id_producto;
                        conceptos.Add(co);
                    }
                    if (buisnes.GuardarVenta(venta, conceptos))
                    {
                        MessageBox.Show("Venta procesada");
                        metroGrid1.Rows.Clear();
                        metroGrid2.Rows.Clear();

                    }
                }


            }

                  
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


        public void fillGrid()
        {
            List<GS_Productos> productos = buisnes.GetAllProductos();
            var filt = from s in productos
                       where s.nombre.ToLower().Contains(textBox1.Text.ToLower())
                       select s;

            metroGrid1.Rows.Clear();
            metroGrid1.RowHeadersVisible = false;
            foreach (var item in filt)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.id_producto });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.nombre });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.precio_venta });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.existencias });
                metroGrid1.Rows.Add(row);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                fillGrid();
            }
            else
            {
                metroGrid1.Rows.Clear();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (metroGrid1.Rows.Count > 0)
            {
                DataGridViewRow current1 = metroGrid1.CurrentRow;
                int exis = Convert.ToInt32(current1.Cells["existencias"].Value);
                if (exis > 0)
                {
                    DataGridViewRow current = metroGrid1.CurrentRow;
                    int idProd = Convert.ToInt32(current.Cells["id"].Value);
                    List<GS_Productos> productos = buisnes.GetAllProductos();
                    var filt = (from s in productos
                                where s.id_producto == idProd
                                select s).FirstOrDefault();
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = idProd });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = filt.nombre });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = filt.precio_venta });
                    metroGrid2.Rows.Add(row);
                    exis -= 1;
                    current1.Cells["existencias"].Value = (exis).ToString();
                }
            }
           

            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (metroGrid2.Rows.Count > 0)
            {
                DataGridViewRow current = metroGrid2.CurrentRow;
                int id = Convert.ToInt32(current.Cells["id1"].Value);
                metroGrid2.Rows.Remove(metroGrid2.CurrentRow);

                foreach (DataGridViewRow item in metroGrid1.Rows)
                {
                    if (Convert.ToInt32(item.Cells["id"].Value) == id)
                    {
                        int exis = Convert.ToInt32(item.Cells["existencias"].Value);
                        exis += 1;
                        item.Cells["existencias"].Value = (exis).ToString();
                    }
                }

            }
        } 
        
          
            




    

        public void updateTotalVenta()
        {
            total = 0;
            foreach (DataGridViewRow row in metroGrid2.Rows)
            {
                total += Convert.ToDouble(row.Cells["Column6"].Value);
               // total += (double)
            }
            totaiIva = total + (total * .16);
            label6.Text = "$ " + total.ToString() + " MXN";
            label2.Text = "$ " + totaiIva.ToString() + " MXN";
        }


        private void metroGrid2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updateTotalVenta();
        }
        private void metroGrid2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateTotalVenta();
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

        private void comboBox1_Click(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            fillCombos();
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
