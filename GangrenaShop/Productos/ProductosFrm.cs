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
    public partial class ProductosFrm : Form
    {
        BuissnessClass buisnes = new BuissnessClass();
        public List<GS_Productos> productos = new List<GS_Productos>();
        private List<GS_Categorias> categorias;
        private List<GS_Clasificaciones> clasificaciones;
        private List<GS_Proveedores> proveedores;

        public ProductosFrm()
        {
            InitializeComponent();
            filldataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clasificacion clasFrm = new Clasificacion();
            clasFrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Categoria catFrm = new Categoria();
            catFrm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Nuevo nuevoFrm = new Nuevo();
            nuevoFrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow current = metroGrid1.CurrentRow;
            int id = Convert.ToInt32(current.Cells["id"].Value);
            DialogResult dialogResult = MessageBox.Show("Eliminar Producto", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                buisnes.DeleteEmpleado(id);
                MessageBox.Show("Empleado Eliminado");
            }
            filldataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow current = metroGrid1.CurrentRow;
            var productoEdit = buisnes.GetProducto(Convert.ToInt32(current.Cells["id"].Value));
            Nuevo editForm = new Nuevo(productoEdit);
            editForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            filldataGrid();
        }

        public void filldataGrid()
        {
            productos = buisnes.GetAllProductos();
            categorias = buisnes.GetCategorias();
            clasificaciones = buisnes.GetClasificaciones();
            proveedores = buisnes.GetProveedores();

            metroGrid1.Rows.Clear();
            metroGrid1.RowHeadersVisible = false;
            metroGrid1.Columns[0].Visible = false;
            foreach (var item in productos)
            {
               
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.id_producto });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.nombre });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.descripcion });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.precio_compra });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.precio_venta });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.existencias });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = (from s in categorias
                            where s.id_categoria == item.id_categoria
                            select s.nombre).FirstOrDefault()
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = (from s in clasificaciones
                             where s.id_clasificacion == item.id_clasificacion
                             select s.nombre).FirstOrDefault()
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = (from s in proveedores
                             where s.id_proveedor == item.id_proveedor
                             select s.nombre).FirstOrDefault()
                }) ;
                
                metroGrid1.Rows.Add(row);

            }

        }
    }
}
