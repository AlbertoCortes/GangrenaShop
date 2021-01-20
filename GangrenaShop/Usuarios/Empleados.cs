using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buissness;
using Model;

namespace GangrenaShop.Usuarios
{
    public partial class Empleados : Form
    {
        public List<GS_Empleados> empleados = new List<GS_Empleados>();
        public BuissnessClass buisnes = new BuissnessClass();
        

        public Empleados()
        {
            InitializeComponent();
            filldataGrid();
        }

        public bool deleteEmpleado(int id)
        {
            return buisnes.DeleteEmpleado(id);
        }

        public void filldataGrid()
        {
            empleados = buisnes.GetAllEmpleados();
            
            metroGrid1.Rows.Clear();
            metroGrid1.RowHeadersVisible = false;
            metroGrid1.Columns[0].Visible = false;
            foreach (var item in empleados)
            {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.id_empleado });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.nombre });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.apellido_paterno });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.apellido_materno });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.fecha_nacimiento });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.usuario });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = item.contrasena });
                    if(item.privilegios == true)
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = "SI" });

                    }
                    else
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = "NO" });

                    }

                metroGrid1.Rows.Add(row);
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow current = metroGrid1.CurrentRow;
            int id = Convert.ToInt32(current.Cells["id"].Value);
            DialogResult dialogResult = MessageBox.Show("Eliminar Empleado", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                buisnes.DeleteEmpleado(id);
                MessageBox.Show("Empleado Eliminado");
            }
            filldataGrid();
        }
    }
}
