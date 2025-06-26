using SACDumont.Base;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using SACDumont.Otros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Catalogos
{
    public partial class frmCatPromocion : frmBaseCatalogos
    {
        #region Variables
        int idPromocion = 0;
        Promociones Promocion = new Promociones();

        #endregion

        #region Metodos Virtuales
        // Métodos virtuales que los hijos pueden sobreescribir
        protected override void Nuevo()
        {

        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el registro de alumno
            if (idPromocion == 0)
            {
                using (var db = new DumontContext())
                {
                    Promocion.descripcion = txDescripcion.Text;
                    Promocion.fecha_inicio = dtpFechaInicio.Value;
                    Promocion.fecha_fin = dtpFechaFin.Value;
                    Promocion.porcentaje_promocion = nPromo.Value;
                    Promocion.id_ciclo = basGlobals.iCiclo;
                    Promocion.id_promocion = 0;

                    db.Promociones.Add(Promocion);

                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        idPromocion = Promocion.id_promocion;
                        basFunctions.Registrar(basConfiguracion.UserID, "Promocion", "Alta", idPromocion, $"Se Creo la promociono: {Promocion.descripcion}");
                        MessageBox.Show("Promocion creada correctamente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                using (var db = new DumontContext())
                {
                    Promocion = db.Promociones.Find(idPromocion);

                    Promocion.descripcion = txDescripcion.Text;
                    Promocion.fecha_inicio = dtpFechaInicio.Value;
                    Promocion.fecha_fin = dtpFechaFin.Value;
                    Promocion.porcentaje_promocion = nPromo.Value;
                    Promocion.id_ciclo = basGlobals.iCiclo;

                    db.Promociones.Add(Promocion);
                    db.Entry(Promocion).State = System.Data.Entity.EntityState.Modified;

                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        basFunctions.Registrar(basConfiguracion.UserID, "Promocion", "Editar", idPromocion, $"Se modifico la promociono: {Promocion.descripcion}");
                        MessageBox.Show("Promocion modificada correctamente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el registro de alumno
            using (var db = new DumontContext())
            {
                Promocion = db.Promociones.Find(idPromocion);
                db.Promociones.Remove(Promocion);
                db.Entry(Promocion).State = System.Data.Entity.EntityState.Deleted;
                var result = db.SaveChanges();
                if (result == 1)
                {
                    MessageBox.Show("Promocion eliminada correctamente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        protected override void Acciones()
        {
            if (idPromocion == 0) return;

            frmAcciones frm = new frmAcciones("Promocion", idPromocion);
            frm.Text = $"Acciones Promocion {Promocion.descripcion}";
            frm.ShowDialog();
        }
        protected override void Deshabilitar()
        {
            // Implementar la lógica para deshabilitar el registro
        }
        protected override void Cerrar()
        {
            this.Close();
        }

        #endregion

        #region Metodos Privados

        private void CargarMenu()
        {
            btQuitarRecargo.Visible = false;
            btAddTutor.Visible = false;
        }

        private void CargarPromocion()
        {
            if (idPromocion == 0) return;

            using (var db = new DumontContext())
            {
                Promocion = db.Promociones.Find(idPromocion);
                if (Promocion != null)
                {
                    lbIdPromo.Text = Promocion.id_promocion.ToString();
                    txDescripcion.Text = Promocion.descripcion;
                    dtpFechaFin.Value = (DateTime)Promocion.fecha_fin;
                    dtpFechaInicio.Value = (DateTime)Promocion.fecha_inicio;
                    nPromo.Value = (int)Promocion.porcentaje_promocion;
                }
            }
        }
        #endregion

        #region Eventos Formulario
        public frmCatPromocion(int idPromocion)
        {
            InitializeComponent();
            this.idPromocion = idPromocion;
        }

        private void frmCatPromocion_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarPromocion();
        }

        #endregion
    }
}
