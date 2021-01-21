using Buissness;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GangrenaShop.Clientes
{
    public partial class ClientesFrm : Form
    {
        public List<GS_Clientes> clientes = new List<GS_Clientes>();
        public BuissnessClass buisnes = new BuissnessClass();
        public ClientesFrm()
        {
            InitializeComponent();
            filldataGrid();
        }

        public void filldataGrid()
        {
            clientes = buisnes.GetAllClientes();

            metroGrid1.Rows.Clear();
            metroGrid1.RowHeadersVisible = false;
            metroGrid1.Columns[0].Visible = false;
            foreach (var item in clientes)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.id_cliente });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.nombre });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.apellido_paterno });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.apellido_materno });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.fecha_nacimiento });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.direccion });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.correo });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.telefono });
                metroGrid1.Rows.Add(row);

            }

        }

        public bool deleteCliente(int id)
        {
            return buisnes.DeleteCliente(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow current = metroGrid1.CurrentRow;
            int id = Convert.ToInt32(current.Cells["id"].Value);
            DialogResult dialogResult = MessageBox.Show("Eliminar Cliente", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                buisnes.DeleteCliente(id);
                MessageBox.Show("Cliente Eliminado");
            }
            filldataGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filldataGrid();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow current = metroGrid1.CurrentRow;
            var clienteEdit = buisnes.GetCliente(Convert.ToInt32(current.Cells["id"].Value));
            Nuevo editForm = new Nuevo(clienteEdit);
            editForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nuevo nuevofrm = new Nuevo();
            nuevofrm.Show();
        }
    }
}
