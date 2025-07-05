using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Models;
using SACDumont.modulos;
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
    public partial class frmCrearCiclos : frmBaseCatalogos
    {
        #region Variables
        int idCiclo = 0;
        Ciclos_Escolares Ciclos_Escolares = new Ciclos_Escolares();
        #endregion

        #region Metodos Virtuales
        protected override void Nuevo()
        {
            frmCatProducto frm = new frmCatProducto(0);
            frm.ShowDialog();
        }
        protected override void Guardar()
        {
            if (txDescripcion.Text.Length == 0) { MessageBox.Show("Debe ingresar la descripcion del ciclo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (dtpFechaInicio.Value > dtpFechaFin.Value) { MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (dtpFechaFin.Value < dtpFechaInicio.Value) { MessageBox.Show("La fecha final no puede ser menor a la fecha inicial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            using (var db = new DumontContext())
            {
                Ciclos_Escolares = new Ciclos_Escolares()
                {
                    ciclo = txDescripcion.Text,
                    fecha_fin = dtpFechaFin.Value,
                    fecha_inicio = dtpFechaInicio.Value,
                    id_ciclo = 0
                };

                db.Entry(Ciclos_Escolares).State = System.Data.Entity.EntityState.Added;
                var result = db.SaveChanges();
                if (result == 1)
                {
                    MessageBox.Show("Ciclo Escolar creado correctamente", "Ciclo Escolar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        protected override void Eliminar()
        {

        }
        protected override void Acciones()
        {
        }
        protected override void Deshabilitar()
        {

        }
        protected override void Habilitar()
        {

        }
        protected override void Cerrar()
        {
            this.Close();
        }
        #endregion

        #region Metodos
        private void CargarMenu()
        {
            btAddTutor.Visible = false;
            btQuitarRecargo.Visible = false;
            btResetPass.Visible = false;
            btHabilitar.Visible = false;
            btDeshabilitar.Visible = false;
        }

        private void CargarCiclo()
        {
            if (idCiclo == 0) return;

            using (var db = new DumontContext())
            {
                Ciclos_Escolares = db.CiclosEscolares.Find(idCiclo);
                txDescripcion.Text = Ciclos_Escolares.ciclo;
                dtpFechaInicio.Value = Ciclos_Escolares.fecha_inicio;
                dtpFechaFin.Value = Ciclos_Escolares.fecha_fin;
            }
        }
        #endregion

        #region Eventos Formulario
        public frmCrearCiclos(int idCiclo)
        {
            InitializeComponent();
            this.idCiclo = idCiclo;
        }

        private void frmCrearCiclos_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarCiclo();
        }

        #endregion
    }
}
