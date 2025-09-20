using SACDumont.Base;
using SACDumont.Dtos;
using SACDumont.modulos;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace SACDumont.Otros
{
    public partial class frmPopup : frmBaseGeneral
    {
        // Variables de clase
        private DataSet dsTemp = new DataSet("Movimiento");
        string tipoReporte = "";

        protected override void Guardar()
        {
            try
            {
                if (tipoReporte == "ListaAsistencia")
                {
                    if (cboGrupo.IDValor != 4 && cboGrado.IDValor != 0)
                    {
                        basFunctions.AlumnosExportarYMostrarPDF((int)cboGrupo.IDValor, (int)cboGrado.IDValor);
                    }
                    else
                    {
                        switch (cboGrupo.IDValor)
                        {
                            case 1:

                                for (int i = 1; i <= 3; i++)
                                {
                                    basFunctions.AlumnosExportarYMostrarPDF((int)cboGrupo.IDValor, i);
                                }
                                break;

                            case 2:

                                for (int i = 4; i <= 9; i++)
                                {
                                    basFunctions.AlumnosExportarYMostrarPDF((int)cboGrupo.IDValor, i);
                                }
                                break;

                            case 3:

                                for (int i = 10; i <= 12; i++)
                                {
                                    basFunctions.AlumnosExportarYMostrarPDF((int)cboGrupo.IDValor, i);
                                }
                                break;

                            case 0:

                                for (int i = 13; i <= 13; i++)
                                {
                                    basFunctions.AlumnosExportarYMostrarPDF((int)cboGrupo.IDValor, i);
                                }
                                break;

                            default:
                                // Código si no coincide ningún caso
                                break;
                        }
                    }
                }
                else if (tipoReporte == "ListaAlumno")
                {
                    if (cboGrupo.IDValor != 4 && cboGrado.IDValor != 0)
                    {
                        PreparaReporteLAlumnos((int)cboGrupo.IDValor, (int)cboGrado.IDValor);
                    }
                    else
                    {
                        switch (cboGrupo.IDValor)
                        {
                            case 1:

                                for (int i = 1; i <= 3; i++)
                                {
                                    PreparaReporteLAlumnos((int)cboGrupo.IDValor, i);
                                }
                                break;

                            case 2:

                                for (int i = 4; i <= 9; i++)
                                {
                                    PreparaReporteLAlumnos((int)cboGrupo.IDValor, i);
                                }
                                break;

                            case 3:

                                for (int i = 10; i <= 12; i++)
                                {
                                    PreparaReporteLAlumnos((int)cboGrupo.IDValor, i);
                                }
                                break;

                            case 0:

                                for (int i = 13; i <= 13; i++)
                                {
                                    PreparaReporteLAlumnos((int)cboGrupo.IDValor, i);
                                }
                                break;

                            default:
                                // Código si no coincide ningún caso
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PreparaReporteLAlumnos(int idGrupo, int idGrado)
        {
            string nombreReporte = "Reporte";
            DataTable dataTable = new DataTable();
            List<AlumnosDTO> alumnosDTO = new List<AlumnosDTO>();
            using (var db = new DumontContext())
            {
                var lista = db.Inscripciones
                  .Where(m => m.id_ciclo == basGlobals.iCiclo && m.id_grupo == idGrupo && m.id_grado == idGrado && m.matricula > 0 && m.Alumnos.activo == true).Include(m => m.Alumnos)
                  .Select(m => new AlumnosDTO
                  {
                      Grupo = db.Catalogos.Where(c => c.valor == idGrupo && c.tipo_catalogo == "Grupo").Select(c => c.descripcion).FirstOrDefault(),
                      Grado = db.Catalogos.Where(c => c.valor == idGrado && c.tipo_catalogo == "Grado").Select(c => c.descripcion).FirstOrDefault(),
                      Alumno = db.Alumnos
                                  .Where(a => a.matricula == m.matricula)
                                  .Select(a => a.appaterno + " " + a.apmaterno + " " + a.nombre)
                                  .FirstOrDefault(),
                      Matricula = m.matricula.ToString()
                  }).OrderBy(m => m.Alumno)
                  .ToList();

                if (lista.Count > 0)
                {
                    nombreReporte = lista[0].Grado;
                }

                alumnosDTO = lista;
            }

            dataTable = basFunctions.ConvertToDataTable(alumnosDTO);

            basFunctions.ExportarYMostrarPDF("ListAlumnos.frx", dataTable, "TicketData", nombreReporte);
        }
        public frmPopup(string tipoReporte)
        {
            InitializeComponent();
            this.tipoReporte = tipoReporte;
        }

        private void frmPopup_Load(object sender, EventArgs e)
        {
            guardarToolStripMenuItem.Text = "Imprimir";
            cboGrado.Inicializar();
            cboGrupo.Inicializar();
        }
    }
}
