using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;
using FastReport.Export.PdfSimple;
namespace SACDumont.Base
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        public void ImprimirDirectamente()
        {
            DataTable tabla = new DataTable("Alumno");
            tabla.Columns.Add("Matricula", typeof(string));
            tabla.Columns.Add("NombreCompleto", typeof(string));
            tabla.Columns.Add("Grado", typeof(string));
            tabla.Columns.Add("Grupo", typeof(string));
            tabla.Rows.Add("A001", "Juan Pérez", "1°", "A");

            Report report = new Report();
            report.Load("ReporteAlumno.frx");
            report.RegisterData(tabla, "Alumno");
            report.GetDataSource("Alumno").Enabled = true;
            report.Prepare();

        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable("Alumno");
            Report report = new Report();
            report.Load("ReporteAlumno.frx");
            report.RegisterData(dataTable, "Alumno");
            report.GetDataSource("Alumno").Enabled = true;
            report.Prepare();

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                dialog.Title = "Guardar reporte como PDF";
                dialog.FileName = "FichaAlumno.pdf";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PDFSimpleExport export = new PDFSimpleExport();
                    report.Export(export, dialog.FileName);

                    // Abrir el archivo PDF automáticamente
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = dialog.FileName,
                        UseShellExecute = true
                    });
                }
            }

            report.Dispose(); // Siempre liberar recursos
        }
    }
}
