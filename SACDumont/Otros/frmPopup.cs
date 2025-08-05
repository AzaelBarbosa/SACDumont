using SACDumont.Base;
using SACDumont.Dtos;
using SACDumont.modulos;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                            default:
                                // Código si no coincide ningún caso
                                break;
                        }
                    }
                }
                else if (tipoReporte == "ListaAlumno")
                {
                    DataTable dataTable = new DataTable();
                    List<AlumnosDTO> alumnosDTO = new List<AlumnosDTO>();
                    using (var db = new DumontContext())
                    {
                        var lista = db.Inscripciones
                          .Where(m => m.id_ciclo == basGlobals.iCiclo && m.id_grupo == cboGrupo.IDValor && m.id_grado == cboGrado.IDValor).Include(m => m.Alumnos)
                          .Select(m => new AlumnosDTO
                          {
                              Grupo = db.Catalogos.Where(c => c.valor == cboGrupo.IDValor && c.tipo_catalogo == "Grupo").Select(c => c.descripcion).FirstOrDefault(),
                              Grado = db.Catalogos.Where(c => c.valor == cboGrado.IDValor && c.tipo_catalogo == "Grado").Select(c => c.descripcion).FirstOrDefault(),
                              Alumno = db.Alumnos
                                          .Where(a => a.matricula == m.matricula)
                                          .Select(a => a.appaterno + " " + a.apmaterno + " " + a.nombre)
                                          .FirstOrDefault(),
                              Matricula = m.matricula.ToString()
                          })
                          .ToList();

                        alumnosDTO = lista;
                    }

                    dataTable = basFunctions.ConvertToDataTable(alumnosDTO);

                    basFunctions.ExportarYMostrarPDF("ListaAlumnos.frx", dataTable, "Alumnos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
