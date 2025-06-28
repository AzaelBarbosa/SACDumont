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
using SACDumont.Modulos;

namespace SACDumont.Catalogos
{
    public partial class frmCatTutores : frmBaseCatalogos
    {
        DataTable dtTutores = new DataTable("Tutores");
        DataTable dtTutAlumno = new DataTable("TutoresAlumnos");
        basFunctions basFunctions = new basFunctions();
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
            if (cboParentesco.SelectedIndex == -1) { MessageBox.Show("El campo Parentesco es obligatorio."); cboParentesco.Focus(); return; }

            bool esNuevo = idTutor == 0;
            int idTut = esNuevo ? 0 : Convert.ToInt32(idTutor);

            if (esNuevo)
            {
                dtTutores = sqlServer.ExecSQLReturnDT("SELECT * FROM tutores WHERE 1=0");
                dtTutAlumno = sqlServer.ExecSQLReturnDT("SELECT * FROM tutores_alumnos WHERE 1=0");
                DataRow newRow = dtTutores.NewRow();
                DataRow newRowTutAlum = dtTutAlumno.NewRow();
                newRow["id_tutor"] = 0; // Placeholder

                AsignarValoresTutor(newRow);
                AsignarValoresTutorAlumno(newRowTutAlum);
                dtTutores.Rows.Add(newRow);
                dtTutAlumno.Rows.Add(newRowTutAlum);
                sqlServer.InsertByDataTable(ref dtTutores, "tutores");
                sqlServer.InsertByDataTable(ref dtTutAlumno, "tutores_alumnos");

                // Obtener la matrícula generada
                int nuevoId = Convert.ToInt32(dtTutores.Rows[0]["id_tutor"]);
                lbTutorID.Text = nuevoId.ToString();

                basFunctions.Registrar(basConfiguracion.UserID, "Alumnos", "Alta", nuevoId);
                MessageBox.Show("Tutor registrado correctamente con ID " + nuevoId, "SAC Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                dtTutores = sqlServer.ExecSQLReturnDT($"SELECT * FROM tutores WHERE id_tutor = {idTutor}");
                if (dtTutores.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró el tutor para actualizar.");
                    return;
                }

                DataRow existingRow = dtTutores.Rows[0];
                AsignarValoresTutor(existingRow);
                //existingRow.SetModified(); // importante

                sqlServer.InsertByDataTable(ref dtTutores, "tutores");
                basFunctions.Registrar(basConfiguracion.UserID, "Alumnos", "Editar", idTutor);
                MessageBox.Show("Tutor actualizado correctamente.", "SAC Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
                // Cargar el registro de alumno existente
                string sSQL = "SELECT * FROM Tutores WHERE id_tutor = " + idTutor;
                DataTable dtAlumno = sqlServer.ExecSQLReturnDT(sSQL, "Tutores");
                btAddTutor.Visible = false;
                if (dtAlumno.Rows.Count > 0)
                {
                    DataRow row = dtAlumno.Rows[0];
                    lbTutorID.Text = row["id_tutor"].ToString();
                    this.Text = "Modificar Tutor: " + row["nombre"].ToString() + " " + row["appaterno"].ToString() + " " + row["apmaterno"].ToString();
                    txtNombre.Text = row["nombre"].ToString();
                    txtApPaterno.Text = row["appaterno"].ToString();
                    txtApMaterno.Text = row["apmaterno"].ToString();
                    txRFC.Text = row["curp"].ToString();
                    txtCalle.Text = row["calle"].ToString();
                    txtColonia.Text = row["colonia"].ToString();
                    txtCiudad.Text = row["ciudad"].ToString();
                    cmbEstado.SelectedValue = Convert.ToInt32(row["estado"]);
                    dtpFechaNac.Value = Convert.ToDateTime(row["fecha_nacimiento"]);
                    cmbSexo.SelectedItem = row["sexo"].ToString();
                    txtTel1.Text = row["telefono1"].ToString();
                    txtTel2.Text = row["telefono2"].ToString();
                    txtTel3.Text = row["telefono3"].ToString();
                    chFactura.Checked = Convert.ToBoolean(row["factura"]);
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
            if (matricula == 0)
            {
                cboAlumnos.Visible = true;
                lbNombreAlumno.Visible = true;
            }
            else
            {
                cboAlumnos.Visible = false;
                lbNombreAlumno.Visible = false;
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
