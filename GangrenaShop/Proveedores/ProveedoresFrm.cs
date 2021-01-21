using Buissness;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GangrenaShop.Proveedores
{
    public partial class ProveedoresFrm : Form
    {
        public List<GS_Proveedores> proveedores = new List<GS_Proveedores>();
        public BuissnessClass buisnes = new BuissnessClass();
        public ProveedoresFrm()
        {
            InitializeComponent();
            filldataGrid();
        }



        public void filldataGrid()
        {
            proveedores = buisnes.GetAllProveedores();

            metroGrid1.Rows.Clear();
            metroGrid1.RowHeadersVisible = false;
            metroGrid1.Columns[0].Visible = false;
            foreach (var item in proveedores)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.id_proveedor });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.nombre });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.nombre_de_contacto });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.direccion });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.telefono });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.correo });
                if (item.status)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = "Activo" });

                }
                else
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = "Desabilitado" });

                }
                metroGrid1.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow current = metroGrid1.CurrentRow;
            int id = Convert.ToInt32(current.Cells["id"].Value);
            DialogResult dialogResult = MessageBox.Show("Eliminar Proveedor", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                buisnes.DeleteProveedor(id);
                MessageBox.Show("Proveedor Eliminado");
            }
            filldataGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filldataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nuevo nuevofrm = new Nuevo();
            nuevofrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow current = metroGrid1.CurrentRow;
            var proveedorEdit = buisnes.GetProveedor(Convert.ToInt32(current.Cells["id"].Value));
            Nuevo editForm = new Nuevo(proveedorEdit);
            editForm.Show();
        }
    }
}
