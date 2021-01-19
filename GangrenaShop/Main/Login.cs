using Data;
using System;
using System.Windows.Forms;

namespace GangrenaShop.Main
{
    public partial class Login : Form
    {
        private string usuerTest = "beto15";
        private string passTest = "Iom77aa";

        public DataClass dat = new DataClass();
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
            enter_key_press(sender, e);
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
        private void enter_key_press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                login();
            }
        }

        private void login() {
            if (txt_usuario.Text == usuerTest && txt_contra.Text == passTest) {
                //Abrir menu y cerrar este formularoi
                this.Hide();
                MainFrm mnn = new MainFrm();
                mnn.Show();
            }else {
                MessageBox.Show("Error, el usuario y la contraseña no coinciden");
                txt_contra.Text = "";
                txt_contra.Select();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = dat.GetEmpleados();
            login();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
