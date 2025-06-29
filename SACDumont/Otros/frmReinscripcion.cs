using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Models;
using SACDumont.Modulos;
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
    public partial class frmReinscripcion : frmBaseCatalogos
    {
        #region Variables
        List<Ciclos_Escolares> ciclosEscolares = new List<Ciclos_Escolares>();
        Inscripciones inscripciones = new Inscripciones();
        int matricula = 0;
        #endregion

        #region Metodos Virtuales
        protected override void Nuevo()
        {
            frmReinscripcion frmReinscripcion = new frmReinscripcion();
            frmReinscripcion.ShowDialog();
        }
        protected override void Guardar()
        {

            // Validaciones...
            if (cboAlumnos.matricula == 0) { MessageBox.Show("Debe seleccionar al alumno", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning); cboAlumnos.Focus(); return; }
            if (cboGrado.IDValor == 0) { MessageBox.Show("Debe seleccionar el GRADO al que reinscribe al alumno", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning); cboGrado.Focus(); return; }
            if (cboGrupo.IDValor == 0) { MessageBox.Show("Debe seleccionar el GRUPO al que reinscribe al alumno", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning); cboGrupo.Focus(); return; }
            if (cboCiclo.SelectedValue == null) { MessageBox.Show("Debe seleccionar el CICLO al que reinscribe al alumno", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning); cboCiclo.Focus(); return; }

            using (var db = new DumontContext())
            {
                var inscripcion = new Inscripciones
                {
                    matricula = matricula,
                    id_ciclo = (int)cboCiclo.SelectedValue,
                    id_grado = (int)cboGrado.IDValor,
                    id_grupo = (int)cboGrupo.IDValor
                };
                db.Inscripciones.Add(inscripcion);
                var result = db.SaveChanges();
                if (result != 0)
                {
                    basFunctions.Registrar(basConfiguracion.UserID, "Alumnos", "Reinscripcion", matricula, $"Se Reinscribio el alumno con Matricula: {matricula} al Grado: {cboGrado.Descripcion}");
                    MessageBox.Show($"Alumno Reinscrito correctamente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        protected override void Cerrar()
        {
            this.Close();
        }
        #endregion

        #region Metodos
        private void CargarCiclos()
        {
            using (var db = new DumontContext())
            {
                ciclosEscolares = db.CiclosEscolares.Where(t => t.fecha_fin > DateTime.Now).ToList();
                if (ciclosEscolares != null)
                {
                    cboCiclo.DataSource = ciclosEscolares;
                    cboCiclo.DisplayMember = "ciclo";
                    cboCiclo.ValueMember = "id_ciclo";
                }
            }
        }
        private void CargarMenu()
        {
            btAcciones.Visible = false;
            btAddTutor.Visible = false;
            btQuitarRecargo.Visible = false;
            btResetPass.Visible = false;
            btHabilitar.Visible = false;
            btDeshabilitar.Visible = false;
            btDelete.Visible = false;
        }
        #endregion

        #region Eventos Virtuales
        public frmReinscripcion()
        {
            InitializeComponent();
        }

        private void frmReinscripcion_Load(object sender, EventArgs e)
        {
            CargarMenu();
            cboAlumnos.Inicializar();
            cboGrado.Inicializar();
            cboGrupo.Inicializar();
            CargarCiclos();
        }

        #endregion

        private void gbInformacion_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gbAcademico_Enter(object sender, EventArgs e)
        {

        }

        private void cboAlumnos_OnAlumnoSeleccionado(DataRow obj)
        {
            lbGradoActual.Text = Convert.ToString(obj["DescripcionGrado"]);
            lbGrupoActual.Text = Convert.ToString(obj["DescripcionGrupo"]);
            lbCiclo.Text = Convert.ToString(obj["ciclo"]);
            matricula = Convert.ToInt32(obj["matricula"]);
        }
    }
}
