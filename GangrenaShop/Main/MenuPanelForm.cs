using System;
using System.Windows.Forms;

namespace GangrenaShop.Main
{
    public partial class MenuPanelForm : Form
    {
        public MenuPanelForm()
        {
            InitializeComponent();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToShortTimeString();
            label8.Text = DateTime.Now.ToShortDateString();
            
        }

        private void panel_menu_Paint(object sender, PaintEventArgs e)
        {
            toolTipVentas.SetToolTip(panel_ventas, "Modulo del punto de ventas, haga click en el menu lateral para acceder");
            toolTipCatalogo.SetToolTip(panelVideojuegos, "Modulo de catalogo de productos, haga click en el menu lateral para acceder");
            toolTipClientes.SetToolTip(panel2, "Modulo de clientes, haga click en el menu lateral para acceder");
            toolTipProveedor.SetToolTip(panel6, "Modulo de proveedores, haga click en el menu lateral para acceder");
            toolTipEmpleado.SetToolTip(panel8, "Modulo de empleados, haga click en el menu lateral para acceder");
            toolTipAdmin.SetToolTip(panel10, "Modulo del punto de ventas, haga click en el menu lateral para acceder");


        }
    }
}
