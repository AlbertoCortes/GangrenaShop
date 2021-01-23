using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Model;
using Buissness;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace GangrenaShop.Admin
{
    public partial class AdminFrm : Form
    {

        BuissnessClass buisnes = new BuissnessClass();
        List<GS_Empleados> emp = new List<GS_Empleados>();
        List<GS_Ventas> vent = new List<GS_Ventas>();
        public AdminFrm()
        {
            InitializeComponent();
            GraficoVentaEmpleado(VentasEmpleado());
            GraficoVentaSemana(VentaSemanas());
            GraficoIngresoSemanal(VentaSemanas());
            GraficoIngresoAnual( mensual());
        }


        public void GraficoVentaSemana(List<VentaSemana> ventas)
        {
            foreach (var item in ventas)
            {
                chart2.Series["Ventas por semana"].Points.AddXY(item.dia.ToString("dddd", new CultureInfo("es-ES")), item.ventas);
                
            }
            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        }

        public void GraficoIngresoSemanal(List<VentaSemana> semana)
        {
            foreach (var item in semana)
            {
                chart3.Series["Ingreso semanal"].Points.AddXY(item.dia.ToString("dddd", new CultureInfo("es-ES")), item.ingreso);
            }
            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        }


        public void GraficoIngresoAnual(List<VentasMes> meses)
        {
            foreach (var item in meses)
            {
                chart4.Series["Ventas Anuales"].Points.AddXY(item.mes, item.ventas);

            }
            chart4.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;

            //foreach (var item in meses)
            //{
            //    Series serie = chart4.Series.Add(item.mes);
            //    serie.Label = item.ventas.ToString();
            //    serie.Points.Add((double)item.ventas);

            //}



        }


        public void GraficoVentaEmpleado(List<EmpleadoVenta> ventas)
        {
            List<EmpleadoVenta> lista = new List<EmpleadoVenta>();
            lista = ventas;
            emp = buisnes.GetAllEmpleados();
            foreach (var item in lista)
            {
                var nombre = (from s in emp where s.id_empleado == item.id_empleado select s).FirstOrDefault();
                string n = nombre.nombre + " ("+ item.ventas+")";
                if(item.ventas > 0)
                    chart1.Series["Ventas por empleado"].Points.AddXY(n,item.ventas);
            }
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        }
    
        public List<EmpleadoVenta> VentasEmpleado()
        {
            List<int> ids = new List<int>();
            List<EmpleadoVenta> ventasporempleado = new List<EmpleadoVenta>();
            List<GS_Empleados> emp = new List<GS_Empleados>();
            List<GS_Ventas> vent = new List<GS_Ventas>();
            emp = buisnes.GetAllEmpleados();
            foreach (var item in emp)
            {
                ids.Add(item.id_empleado);
            }
            vent = buisnes.GetAllVentas();

            foreach (var item in ids)
            {
                EmpleadoVenta s = new EmpleadoVenta();
                s.id_empleado = item;
                int cont = 0;
                foreach (var v in vent)
                {
                    if(item ==v.id_empleado)
                    {
                        cont++;
                    }
                }
                s.ventas = cont;
                ventasporempleado.Add(s);

            }
            return ventasporempleado;

        }


        public List<VentaSemana> VentaSemanas()
        {
            List<VentaSemana> semana = new List<VentaSemana>();
            vent = buisnes.GetAllVentas();
            DateTime hoy = DateTime.Now;
            DateTime semanaTranscurrida = hoy.AddDays(-7);
            List<GS_Ventas> ultimasVentas = new List<GS_Ventas>();
            ultimasVentas = (from s in vent where s.fecha_venta.Date >= semanaTranscurrida.Date select s).ToList();
            var ultimasfechas = ultimasVentas.GroupBy(x => x.fecha_venta).Select(y => y.First()).ToList();
            List<GS_Ventas_conceptos> conceptos = new List<GS_Ventas_conceptos>();
            conceptos = buisnes.GetAllConceptos();
            List<GS_Productos> productos = new List<GS_Productos>();
            productos = buisnes.GetAllProductos();

            foreach (var item in ultimasfechas)
            {
                VentaSemana vv = new VentaSemana();
                int cont = 0;
                vv.dia = item.fecha_venta;
               
                List<int> vnn = new List<int>();

                foreach (var gg in ultimasVentas)
                {
                    if (gg.fecha_venta == item.fecha_venta)
                    {
                        foreach (var item2 in conceptos)
                        {
                            if (item2.id_venta == item.id_venta && item.fecha_venta.Date == gg.fecha_venta.Date)
                            {
                                var cc = (from a in buisnes.GetAllConceptos() where a.id_venta == gg.id_venta select a.id_producto).FirstOrDefault();
                                vnn.Add(cc);
                            }
                        }
                        cont++;
                    }
                    decimal ingreso = 0;

                    foreach (var i in vnn)
                    {
                        ingreso += (from s in productos where s.id_producto == i select s.precio_venta).FirstOrDefault();
                    }
                   vv.ingreso = ingreso + ingreso * (decimal).16;
                }
               
                vv.vendidos = vnn;
                vv.ventas = cont;
                semana.Add(vv);
            }
            return semana;

        }

        public List<VentasMes> mensual()
        {
            List<VentasMes> mes = new List<VentasMes>();
            vent = buisnes.GetAllVentas();
            List<GS_Ventas> ultimasVentas = new List<GS_Ventas>();
            ultimasVentas = (from s in vent where s.fecha_venta.Year >= DateTime.Now.Year select s).ToList();
            int[] meses =  new int[12];
            meses[0] = 1;
            meses[1] = 2;
            meses[2] = 3;
            meses[3] = 4;
            meses[4] = 5;
            meses[5] = 6;
            meses[6] = 7;
            meses[7] = 8;
            meses[8] = 9;
            meses[9] = 10;
            meses[10] = 11;
            meses[11] = 12;
            List<GS_Ventas_conceptos> conceptos = new List<GS_Ventas_conceptos>();
            conceptos = buisnes.GetAllConceptos();
            List<GS_Productos> productos = new List<GS_Productos>();
            productos = buisnes.GetAllProductos();

            foreach (var item in meses)
            {
                    VentasMes vv = new VentasMes();
                    int cont = 0;
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(item);
                vv.mes = nombreMes;


                List<int> vnn = new List<int>();

                    foreach (var gg in ultimasVentas)
                    {
                        if (gg.fecha_venta.Month == item)
                        {
                            foreach (var item2 in conceptos)
                            {
                                if (item2.id_venta == gg.id_venta && gg.fecha_venta.Month == item)
                                {
                                    var cc = (from a in buisnes.GetAllConceptos() where a.id_venta == gg.id_venta select a.id_producto).FirstOrDefault();
                                    vnn.Add(cc);
                                }
                            }
                            cont++;
                        }
                        decimal ingreso = 0;

                        foreach (var i in vnn)
                        {
                            ingreso += (from s in productos where s.id_producto == i select s.precio_venta).FirstOrDefault();
                        }
                        vv.ventas = ingreso + ingreso * (decimal).16;
                    }
                mes.Add(vv);
            }


            return mes;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart2.Series["Ventas por semana"].Points.Clear();
            chart3.Series["Ingreso semanal"].Points.Clear();
            chart1.Series["Ventas por empleado"].Points.Clear();
            chart4.Series["Ventas Anuales"].Points.Clear();
            GraficoVentaEmpleado(VentasEmpleado());
            GraficoVentaSemana(VentaSemanas());
            GraficoIngresoSemanal(VentaSemanas());
            GraficoIngresoAnual(mensual());
        }
    }












    }

    public class VentasMes
    {
        public string mes { get; set; }

        public decimal ventas { get; set; }
    }
    public class VentaSemana
    {
        public DateTime dia { get; set; }
        public int ventas { get; set; }
        public decimal ingreso { get; set; }
        public List<int> vendidos { get; set; }
    }


    public class EmpleadoVenta
    {
        public int id_empleado { get; set; }
        public int ventas { get; set; }
    }



