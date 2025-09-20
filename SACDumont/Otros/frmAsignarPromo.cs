using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Models;
using SACDumont.modulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SACDumont.Otros
{
    public partial class frmAsignarPromo : frmBaseGeneral
    {
        #region Variables
        frmCatAlumnos frmAlumnos;
        Promociones_Alumnos promAlumno;
        List<Promociones_Alumnos> listPromo = new List<Promociones_Alumnos>();
        Promociones promo = new Promociones();
        Promociones promoAdd = new Promociones();
        int matricula = 0;
        #endregion

        #region Metdo Virtuales
        protected override void Guardar()
        {
            try
            {
                using (var db = new DumontContext())
                {
                    promoAdd = db.Promociones.Find(cboPromociones.SelectedValue);
                    listPromo = db.PromocionesAlumnos.Where(pa => pa.matricula == matricula && pa.id_ciclo == basGlobals.iCiclo).ToList();

                    foreach (Promociones_Alumnos item in frmAlumnos.promoAlumno)
                    {
                        promo = db.Promociones.Find(item.id_promocion);
                        if (promo.concepto == promoAdd.concepto)
                        {
                            MessageBox.Show($"Ya existe una promocion agregada con el Concepto {promoAdd.concepto} {Environment.NewLine} Si desea agregar esta promocion primero debe eliminar la promocion existente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                promAlumno = new Promociones_Alumnos
                {
                    matricula = matricula,
                    id_promocion = (int)cboPromociones.SelectedValue,
                    id_ciclo = basGlobals.iCiclo
                };

                frmAlumnos.promoAlumno.Add(promAlumno);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Metodos Privados

        private void CargarPromociones()
        {
            List<Promociones> listPromos = new List<Promociones>();
            using (var db = new DumontContext())
            {
                listPromos = db.Promociones.Where(t => t.id_ciclo == basGlobals.iCiclo).ToList();
                cboPromociones.DataSource = listPromos;
                cboPromociones.DisplayMember = "descripcion";
                cboPromociones.ValueMember = "id_promocion";
            }
        }
        #endregion
        public frmAsignarPromo(frmCatAlumnos frm, int matricula)
        {
            InitializeComponent();
            this.frmAlumnos = frm;
            this.matricula = matricula;
        }

        private void frmAsignarPromo_Load(object sender, EventArgs e)
        {
            CargarPromociones();
        }
    }
}
