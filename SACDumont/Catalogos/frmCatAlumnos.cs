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
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Wordprocessing;
using static ClosedXML.Excel.XLPredefinedFormat;
using SACDumont.Listados;

namespace SACDumont.Catalogos
{
    public partial class frmCatAlumnos : frmBaseCatalogos
    {
        // Variables
        DataTable dtAlumnos = new DataTable("Alumnos");
        DataTable dtTutores = new DataTable("Tutores");
        basFunctions basFunctions = new basFunctions();
        sqlServer sqlServer = new sqlServer();
        int intMatricula = 0;

        public frmCatAlumnos(int matricula)
        {
            this.intMatricula = matricula;
            InitializeComponent();
        }

        #region "Metodos Virtuales"
            protected override void Nuevo()
            {
                frmCatAlumnos frmCatAlumnos = new frmCatAlumnos(0);
                frmCatAlumnos.ShowDialog();
            }
            protected override void Guardar()
            {
                // Validaciones...
                if (txtNombre.Text == "") { MessageBox.Show("El campo Nombre es obligatorio."); txtNombre.Focus(); return; }
                if (txtApPaterno.Text == "") { MessageBox.Show("El campo Apellido Paterno es obligatorio."); txtApPaterno.Focus(); return; }
                if (txtApMaterno.Text == "") { MessageBox.Show("El campo Apellido Materno es obligatorio."); txtApMaterno.Focus(); return; }
                if (txtCurp.Text == "") { MessageBox.Show("El campo CURP es obligatorio."); txtCurp.Focus(); return; }
                if (cmbEstadoNac.SelectedIndex == -1) { MessageBox.Show("El campo Estado Nacimiento es obligatorio."); cmbEstadoNac.Focus(); return; }
                if (cmbPais.SelectedIndex == -1) { MessageBox.Show("El campo País es obligatorio."); cmbPais.Focus(); return; }

                bool esNuevo =  intMatricula == 0;
                int matricula = esNuevo ? 0 : Convert.ToInt32(intMatricula);

                if (esNuevo)
                {
                    dtAlumnos = sqlServer.ExecSQLReturnDT("SELECT * FROM alumnos WHERE 1=0");
                    DataRow newRow = dtAlumnos.NewRow();
                    newRow["matricula"] = 0; // Placeholder

                    AsignarValoresAlumno(newRow);
                    dtAlumnos.Rows.Add(newRow);
                    sqlServer.InsertByDataTable(ref dtAlumnos, "alumnos");

                    // Obtener la matrícula generada
                    int nuevaMatricula = Convert.ToInt32(dtAlumnos.Rows[0]["matricula"]);
                    lbMatricula.Text = nuevaMatricula.ToString();

                    MessageBox.Show("Alumno registrado correctamente con matrícula " + nuevaMatricula);

                    if (MessageBox.Show("¿Desea agregar un tutor?", "Agregar Tutor", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmCatAlumnos frm = new frmCatAlumnos(nuevaMatricula);
                        frm.ShowDialog();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    dtAlumnos = sqlServer.ExecSQLReturnDT($"SELECT * FROM alumnos WHERE matricula = {matricula}");
                    if (dtAlumnos.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontró el alumno para actualizar.");
                        return;
                    }

                    DataRow existingRow = dtAlumnos.Rows[0];
                    AsignarValoresAlumno(existingRow);
                    //existingRow.SetModified(); // importante

                    sqlServer.InsertByDataTable(ref dtAlumnos, "alumnos");

                    MessageBox.Show("Alumno actualizado correctamente.");
                }

            }
            protected override void Eliminar()
            {
                // Implementar la lógica para eliminar el registro de alumno
            }
            protected override void AgregarTutor()
            {
                frmCatTutores frm = new frmCatTutores(intMatricula);
                frm.Text = "Agregar Tutor";
                frm.ShowDialog();
            }
            protected override void Cerrar()
            {
                this.Close();
            }

        #endregion

        #region "Eventos Personalizados"

        private void AsignarValoresAlumno(DataRow row)
            {
                var valores = new Dictionary<string, object>
                {
                    ["nombre"] = txtNombre.Text,
                    ["appaterno"] = txtApPaterno.Text,
                    ["apmaterno"] = txtApMaterno.Text,
                    ["fecha_nacimiento"] = dtpFechaNac.Value,
                    ["pais_nacimiento"] = cmbPais.SelectedValue,
                    ["estado_nacimiento"] = cmbEstadoNac.SelectedValue,
                    ["sexo"] = cmbSexo.SelectedValue,
                    ["curp"] = txtCurp.Text,
                    ["calle"] = txtCalle.Text,
                    ["colonia"] = txtColonia.Text,
                    ["ciudad"] = txtCiudad.Text,
                    ["estado"] = cmbEstado.SelectedValue,
                    ["telefono1"] = txtTel1.Text,
                    ["telefono2"] = txtTel2.Text,
                    ["telefono3"] = txtTel3.Text,
                    ["email"] = txtEmail.Text,
                    ["activo"] = chkActivo.Checked
                };

                foreach (var item in valores)
                {
                    row[item.Key] = item.Value ?? DBNull.Value;
                }
            }

            private void CargarAlumno(int matricula)
            {
                if (matricula == 0)
                {
                    // Cargar un nuevo registro vacío
                    this.Text = "Nuevo Alumno";
                    txtNombre.Text = "";
                    txtApPaterno.Text = "";
                    txtApMaterno.Text = "";
                    txtCurp.Text = "";
                    txtCalle.Text = "";
                    txtColonia.Text = "";
                    txtCiudad.Text = "";
                    txtTel1.Text = "";
                    txtTel2.Text = "";
                    txtTel3.Text = "";
                    txtEmail.Text = "";
                    agregarTutorToolStripMenuItem.Visible = false;
                }
                else
                {
                    // Cargar el registro de alumno existente
                    string sSQL = "SELECT * FROM Alumnos WHERE matricula = " + matricula;
                    DataTable dtAlumno = sqlServer.ExecSQLReturnDT(sSQL, "Alumnos");
                    agregarTutorToolStripMenuItem.Visible = true;
                    if (dtAlumno.Rows.Count > 0)
                    {
                        DataRow row = dtAlumno.Rows[0];
                        lbMatricula.Text = row["matricula"].ToString();
                        this.Text = "Modificar Alumno: " + row["nombre"].ToString() + " " + row["appaterno"].ToString() + " " + row["apmaterno"].ToString();
                        txtNombre.Text = row["nombre"].ToString();
                        txtApPaterno.Text = row["appaterno"].ToString();
                        txtApMaterno.Text = row["apmaterno"].ToString();
                        txtCurp.Text = row["curp"].ToString();
                        txtCalle.Text = row["calle"].ToString();
                        txtColonia.Text = row["colonia"].ToString();
                        txtCiudad.Text = row["ciudad"].ToString();
                        cmbEstado.SelectedValue = Convert.ToInt32(row["estado"]);
                        cmbPais.SelectedValue = Convert.ToInt32(row["pais_nacimiento"]);
                        cmbEstadoNac.SelectedValue = Convert.ToInt32(row["estado_nacimiento"]);
                        dtpFechaNac.Value = Convert.ToDateTime(row["fecha_nacimiento"]);
                        cmbSexo.SelectedItem = row["sexo"].ToString();
                        txtTel1.Text = row["telefono1"].ToString();
                        txtTel2.Text = row["telefono2"].ToString();
                        txtTel3.Text = row["telefono3"].ToString();
                        txtEmail.Text = row["email"].ToString();
                        chkActivo.Checked = Convert.ToBoolean(row["activo"]);
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

            private void ValidaTutores()
            {
                // Validar si el alumno tiene tutores
                string sSQL = "SELECT * FROM tutores_alumnos WHERE matricula = " + intMatricula;
                DataTable dtTutores = sqlServer.ExecSQLReturnDT(sSQL, "Tutores");
                if (dtTutores.Rows.Count > 0)
                {
                    if (MessageBox.Show("El Alumno no tiene tutores asignados. ¿Desea agregar un tutor?", "Agregar Tutor", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmCatTutores frm = new frmCatTutores(intMatricula);
                        frm.Text = "Agregar Tutor";
                        frm.ShowDialog();
                    }
                }
                else
                {
                    return;
                }
            }

        #endregion

        private void frmCatAlumnos_Load(object sender, EventArgs e)
        {
            basFunctions.CargarCatalogo(cmbEstado,"estados", "Id", "Nombre", "WHERE PaisId = 1");
            basFunctions.CargarCatalogo(cmbPais, "paises", "Id", "Nombre");
            CargarComboSexo();
            CargarAlumno(intMatricula); // Cargar un nuevo registro vacío
            if (intMatricula != 0)
            {
                ValidaTutores();
            }
        }

        private void cmbEstadoNac_Validating(object sender, CancelEventArgs e)
        {
            basFunctions.ValidarYAgregarNuevo(cmbEstadoNac, "estados", "Nombre", int.Parse(cmbPais.SelectedValue.ToString()));
        }

        private void cmbEstado_Validating(object sender, CancelEventArgs e)
        {
            basFunctions.ValidarYAgregarNuevo(cmbEstado, "estados", "Nombre", 1);
        }

        private void cmbPais_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbPais_Validating(object sender, CancelEventArgs e)
        {
            cmbEstadoNac.Items.Clear();
            cmbEstadoNac.Text = "";
            basFunctions.CargarCatalogo(cmbEstadoNac, "estados", "Id", "Nombre", "WHERE PaisId = " + cmbPais.SelectedValue);
        }
    }
}
