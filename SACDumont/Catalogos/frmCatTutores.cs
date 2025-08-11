using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SACDumont.Base;
using SACDumont.Clases;
using SACDumont.Models;
using SACDumont.Modulos;

namespace SACDumont.Catalogos
{
    public partial class frmCatTutores : frmBaseCatalogos
    {
        DataTable dtTutores = new DataTable("Tutores");
        DataTable dtTutAlumno = new DataTable("TutoresAlumnos");
        basFunctions basFunctions = new basFunctions();
        Tutores tutores = new Tutores();
        Tutores_Alumnos tutoresAlumnos = new Tutores_Alumnos();
        int matricula = 0;
        int idTutor = 0;
        public frmCatTutores(int matricula = 0, int idTutor = 0)
        {
            this.matricula = matricula;
            this.idTutor = idTutor;
            InitializeComponent();
        }

        #region "Métodos Virtuales"
        protected override void Nuevo()
        {
            frmCatTutores frm = new frmCatTutores(0, 0);
            frm.ShowDialog();
        }
        protected override void Guardar()
        {
            // Validaciones...
            if (txtNombre.Text == "") { MessageBox.Show("El campo Nombre es obligatorio."); txtNombre.Focus(); return; }
            if (txtApPaterno.Text == "") { MessageBox.Show("El campo Apellido Paterno es obligatorio."); txtApPaterno.Focus(); return; }
            if (txtApMaterno.Text == "") { MessageBox.Show("El campo Apellido Materno es obligatorio."); txtApMaterno.Focus(); return; }
            if (txRFC.Text == "") { MessageBox.Show("El campo CURP es obligatorio."); txRFC.Focus(); return; }
            if (cmbEstado.SelectedIndex == -1) { MessageBox.Show("El campo Estado Nacimiento es obligatorio."); cmbEstado.Focus(); return; }
            if (txtTel1.Text == "") { MessageBox.Show("El campo Teléfono 1 es obligatorio."); txtTel1.Focus(); return; }
            if (txtTel1.Text.Length < 10) { MessageBox.Show("El campo Teléfono 1 debe tener al menos 10 dígitos."); txtTel1.Focus(); return; }

            bool esNuevo = idTutor == 0;
            int idTut = esNuevo ? 0 : Convert.ToInt32(idTutor);

            if (idTutor == 0)
            {
                using (var db = new DumontContext())
                {
                    tutores = new Tutores
                    {
                        nombre = txtNombre.Text,
                        appaterno = txtApPaterno.Text,
                        apmaterno = txtApMaterno.Text,
                        rfc = txRFC.Text,
                        calle = txtCalle.Text,
                        colonia = txtColonia.Text,
                        ciudad = txtCiudad.Text,
                        estado = Convert.ToInt32(cmbEstado.SelectedValue),
                        sexo = cmbSexo.SelectedValue.ToString(),
                        telefono1 = txtTel1.Text,
                        telefono2 = txtTel2.Text,
                        telefono3 = txtTel3.Text,
                        fecha_nacimiento = dtpFechaNac.Value,
                        factura = chFactura.Checked,
                        fecha_alta = DateTime.Now,
                        acivo = true
                    };

                    db.Tutores.Add(tutores);
                    db.SaveChanges();
                    idTut = tutores.id_tutor;

                    tutoresAlumnos = new Tutores_Alumnos
                    {
                        id_tutor = idTut,
                        matricula = matricula,
                        parentesco = Convert.ToInt32(cboParentesco.SelectedValue)
                    };
                    db.TutoresAlumnos.Add(tutoresAlumnos);
                    db.SaveChanges();

                    lbTutorID.Text = idTut.ToString();

                    basFunctions.Registrar(basConfiguracion.UserID, "Tutores", "Alta", idTut);
                    MessageBox.Show("Tutor registrado correctamente con ID " + idTut, "SAC Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                using (var db = new DumontContext())
                {
                    tutores = db.Tutores.Find(idTutor);
                    if (tutores == null)
                    {
                        MessageBox.Show("No se encontró el tutor para actualizar.");
                        return;
                    }


                    tutores.nombre = txtNombre.Text;
                    tutores.appaterno = txtApPaterno.Text;
                    tutores.apmaterno = txtApMaterno.Text;
                    tutores.rfc = txRFC.Text;
                    tutores.calle = txtCalle.Text;
                    tutores.colonia = txtColonia.Text;
                    tutores.ciudad = txtCiudad.Text;
                    tutores.estado = Convert.ToInt32(cmbEstado.SelectedValue);
                    tutores.sexo = (string)cmbSexo.SelectedValue;
                    tutores.telefono1 = txtTel1.Text;
                    tutores.telefono2 = txtTel2.Text;
                    tutores.telefono3 = txtTel3.Text;
                    tutores.fecha_nacimiento = dtpFechaNac.Value;
                    tutores.factura = chFactura.Checked;

                    db.Entry(tutores).State = System.Data.Entity.EntityState.Modified; // Importante para actualizar el registro
                    db.SaveChanges();

                    basFunctions.Registrar(basConfiguracion.UserID, "Tutores", "Editar", idTutor);
                    MessageBox.Show("Tutor actualizado correctamente.", "SAC Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el registro de alumno
        }

        protected override void AgregarTutor()
        {
            // Implementar la lógica para eliminar el registro de alumno
        }

        protected override void Cerrar()
        {
            this.Close();
        }

        protected override void Deshabilitar()
        {
            using (var db = new DumontContext())
            {
                tutores = db.Tutores.Find(idTutor);
                tutores.acivo = false;
                db.SaveChanges();
                this.Close();
            }
        }
        protected override void Habilitar()
        {
            using (var db = new DumontContext())
            {
                tutores = db.Tutores.Find(idTutor);
                tutores.acivo = true;
                db.SaveChanges();
                this.Close();
            }
        }
        #endregion

        #region "Metodos"
        private void CargarTutor(int idTutor)
        {
            if (idTutor == 0)
            {
                // Cargar un nuevo registro vacío
                this.Text = "Nuevo Tutor";
                txtNombre.Text = "";
                txtApPaterno.Text = "";
                txtApMaterno.Text = "";
                txRFC.Text = "";
                txtCalle.Text = "";
                txtColonia.Text = "";
                txtCiudad.Text = "";
                txtTel1.Text = "";
                txtTel2.Text = "";
                txtTel3.Text = "";
                lbTutorID.Text = "0";
                btAddTutor.Visible = false;
            }
            else
            {
                using (var db = new DumontContext())
                {
                    tutores = db.Tutores.Find(idTutor);
                    if (tutores == null)
                    {
                        MessageBox.Show("No se encontró el tutor con ID " + idTutor, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lbTutorID.Text = tutores.id_tutor.ToString();
                    this.Text = "Modificar Tutor: " + tutores.nombre + " " + tutores.appaterno + " " + tutores.apmaterno;
                    txtNombre.Text = basFunctions.StringToLittleCase(tutores.nombre);
                    txtApPaterno.Text = basFunctions.StringToLittleCase(tutores.appaterno);
                    txtApMaterno.Text = basFunctions.StringToLittleCase(tutores.apmaterno);
                    txRFC.Text = tutores.rfc;
                    txtCalle.Text = tutores.calle;
                    txtColonia.Text = tutores.colonia;
                    txtCiudad.Text = tutores.ciudad;
                    cmbEstado.SelectedValue = tutores.estado ?? 0;
                    dtpFechaNac.Value = tutores.fecha_nacimiento ?? System.DateTime.Now;
                    cmbSexo.SelectedValue = tutores.sexo.ToString();
                    txtTel1.Text = tutores.telefono1;
                    txtTel2.Text = tutores.telefono2;
                    txtTel3.Text = tutores.telefono3;
                    chFactura.Checked = tutores.factura ?? false;
                    btAddTutor.Visible = false;

                }
            }
        }

        private void CargarComboSexo()
        {
            var items = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("M", "Masculino"),
                    new KeyValuePair<string, string>("F", "Femenino")
                };
            cmbSexo.DataSource = items;
            cmbSexo.DisplayMember = "Value";   // Lo que se muestra: Masculino, Femenino
            cmbSexo.ValueMember = "Key";       // Lo que se obtiene como SelectedValue: M, F
        }

        private void AsignarValoresTutor(DataRow row)
        {
            var valores = new Dictionary<string, object>
            {
                ["nombre"] = txtNombre.Text,
                ["appaterno"] = txtApPaterno.Text,
                ["apmaterno"] = txtApMaterno.Text,
                ["denomsocial"] = txDenominacionSocial.Text,
                ["calle"] = txtCalle.Text,
                ["colonia"] = txtColonia.Text,
                ["ciudad"] = txtCiudad.Text,
                ["estado"] = cmbEstado.SelectedValue,
                ["rfc"] = txRFC.Text,
                ["telefono1"] = txtTel1.Text,
                ["telefono2"] = txtTel2.Text,
                ["telefono3"] = txtTel3.Text,
                ["sexo"] = cmbSexo.SelectedValue,
                ["factura"] = chFactura.Checked,
                ["fecha_nacimiento"] = dtpFechaNac.Value,
                ["fecha_alta"] = DateTime.Now,
                ["acivo"] = true
            };
            foreach (var item in valores)
            {
                row[item.Key] = item.Value ?? DBNull.Value;
            }
        }

        private void AsignarValoresTutorAlumno(DataRow row)
        {
            var valores = new Dictionary<string, object>
            {
                ["id_tutor"] = idTutor,
                ["matricula"] = matricula == 0 ? cboAlumnos.SelectedValue : matricula,
                ["parentesco"] = cboParentesco.SelectedValue
            };
            foreach (var item in valores)
            {
                row[item.Key] = item.Value ?? DBNull.Value;
            }
        }
        #endregion

        private void frmCatTutores_Load(object sender, EventArgs e)
        {
            if (matricula == 0 && idTutor > 0)
            {
                cboAlumnos.Visible = false;
                lbNombreAlumno.Visible = false;
                cboParentesco.Visible = false;
                label3.Visible = false;
            }
            else if (matricula > 0)
            {
                cboAlumnos.Visible = false;
                lbNombreAlumno.Visible = false;
                cboParentesco.Visible = true;
                label3.Visible = true;
            }

            basFunctions.CargarCatalogo(cmbEstado, "estados", "Id", "Nombre", "WHERE PaisId = 1");
            basFunctions.CargarCatalogoAlumnos(cboAlumnos);
            basFunctions.CargarCatalogoGeneral(cboParentesco, "Parentesco");
            CargarComboSexo();
            CargarTutor(idTutor);
            btAddTutor.Visible = false;
            btResetPass.Visible = false;
            btHabilitar.Visible = false;
            btDeshabilitar.Visible = false;
            btQuitarRecargo.Visible = false;

        }
    }
}
