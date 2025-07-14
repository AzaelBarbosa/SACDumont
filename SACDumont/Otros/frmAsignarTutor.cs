using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Otros
{
    public partial class frmAsignarTutor : frmBaseCatalogos
    {
        #region Variables
        int idAlumno = 0;
        Tutores_Alumnos tutoresAlumnos = new Tutores_Alumnos();
        #endregion

        #region Metodos Virtuales
        protected override void Nuevo()
        {
            frmCatTutores frm = new frmCatTutores(idAlumno);
            frm.Text = "Agregar Tutor";
            frm.ShowDialog();
            this.Close();
        }

        protected override void Guardar()
        {
            try
            {
                if (cboTutores.IDTutor == null || cboParentesco.IDValor == null)
                {
                    MessageBox.Show("Debe seleccionar un tutor y un parentesco.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (var db = new DumontContext())
                {
                    if (cboTutores.IDTutor != null)
                    {
                        int idTutor = Convert.ToInt32(cboTutores.IDTutor);
                        tutoresAlumnos = new Tutores_Alumnos()
                        {
                            id_tutor = idTutor,
                            matricula = idAlumno,
                            parentesco = (int)cboParentesco.IDValor
                        };

                        db.TutoresAlumnos.Add(tutoresAlumnos);
                        var result = db.SaveChanges();
                        if (result > 0)
                        {
                            MessageBox.Show("Tutor asignado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error al asignar el tutor. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un tutor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al intentar guardar el tutor. Por favor, inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Cerrar()
        {
            this.Close();
        }
        #endregion

        #region Metodos Privados

        private void CargarMenu()
        {
            btAcciones.Visible = false;
            btDeshabilitar.Visible = false;
            btHabilitar.Visible = false;
            btQuitarRecargo.Visible = false;
            btAddTutor.Visible = true;
            btDelete.Visible = true;
            btResetPass.Visible = false;
        }
        #endregion

        #region Eventos Formulario
        public frmAsignarTutor(int idAlumno)
        {
            InitializeComponent();
            this.idAlumno = idAlumno;
        }

        private void frmAsignarTutor_Load(object sender, EventArgs e)
        {
            CargarMenu();
            cboTutores.Inicializar();
            cboParentesco.Inicializar();
        }

        #endregion
    }
}
