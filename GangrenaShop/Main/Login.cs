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
    public partial class Login : Form
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
        public Login()
        {
            InitializeComponent();
            txt_usuario.Select();
            txt_contra.PasswordChar = '*';
        }

        private void txt_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            esc_salir(sender, e);

        }

        private void txt_contra_KeyPress(object sender, KeyPressEventArgs e)
        {
            esc_salir(sender, e);
        }


        private void esc_salir(object sender, KeyPressEventArgs e) //Salir de la app al presionar la tecla esc, solo sirve en login
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                DialogResult dialogResult = MessageBox.Show("Desea salir de la aplicacion", "Salir", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
                e.Handled = true;
            }
        }
    }
}
