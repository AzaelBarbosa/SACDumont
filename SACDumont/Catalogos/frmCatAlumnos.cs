using DocumentFormat.OpenXml.Wordprocessing;
using SACDumont.Base;
using SACDumont.Clases;
using SACDumont.Dtos;
using SACDumont.Listados;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using SACDumont.Otros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace SACDumont.Catalogos
{
    public partial class frmCatAlumnos : frmBaseCatalogos
    {
        #region Variables Globales
        // Variables
        DataTable dtAlumnos = new DataTable("Alumnos");
        DataTable dtTutores = new DataTable("Tutores");
        basFunctions basFunctions = new basFunctions();
        sqlServer sqlServer = new sqlServer();
        Becas becas = new Becas();
        Promociones Promociones = new Promociones();
        public List<Promociones_Alumnos> promoAlumno = new List<Promociones_Alumnos>();
        List<PromoAlumnosDTO> promoAlumnosDTOs = new List<PromoAlumnosDTO>();
        List<TutorAlumnoDTO> tutores = new List<TutorAlumnoDTO>();
        List<Tutores_Alumnos> tutores_alumnos = new List<Tutores_Alumnos>();
        Inscripciones inscripciones = new Inscripciones();
        Alumnos alumnos = new Alumnos();
        int intMatricula = 0;
        int idPromo = 0;
        int rowIndexPromo = 0;
        #endregion

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
            //if (txtCurp.Text == "") { MessageBox.Show("El campo CURP es obligatorio."); txtCurp.Focus(); return; }
            if (cmbEstadoNac.SelectedIndex == -1) { MessageBox.Show("El campo Estado Nacimiento es obligatorio."); cmbEstadoNac.Focus(); return; }
            if (cmbPais.SelectedIndex == -1) { MessageBox.Show("El campo País es obligatorio."); cmbPais.Focus(); return; }

            bool esNuevo = intMatricula == 0;
            int matricula = esNuevo ? 0 : Convert.ToInt32(intMatricula);

            if (esNuevo)
            {
                using (var db = new DumontContext())
                {
                    var alumno = new Alumnos
                    {
                        nombre = txtNombre.Text,
                        appaterno = txtApPaterno.Text,
                        apmaterno = txtApMaterno.Text,
                        fecha_nacimiento = dtpFechaNac.Value,
                        pais_nacimiento = Convert.ToInt32(cmbPais.SelectedValue),
                        estado_nacimiento = Convert.ToInt32(cmbEstadoNac.SelectedValue),
                        sexo = cmbSexo.SelectedValue.ToString(),
                        curp = txtCurp.Text,
                        calle = txtCalle.Text,
                        colonia = txtColonia.Text,
                        ciudad = txtCiudad.Text,
                        estado = Convert.ToInt32(cmbEstado.SelectedValue),
                        telefono1 = txtTel1.Text,
                        telefono2 = txtTel2.Text,
                        telefono3 = txtTel3.Text,
                        email = txtEmail.Text,
                        foto_alumno = basFunctions.ImageToBytes(pictureBox1.Image)
                    };

                    db.Alumnos.Add(alumno);

                    var result = db.SaveChanges();
                    if (result > 0)
                    {
                        intMatricula = alumno.matricula; // Obtener la matrícula generada
                        lbMatricula.Text = intMatricula.ToString();
                        basFunctions.Registrar(basConfiguracion.UserID, "Alumnos", "Alta", intMatricula, "Se registró un nuevo alumno con matrícula: " + intMatricula);
                        var inscripcion = new Inscripciones
                        {
                            matricula = intMatricula,
                            id_ciclo = basGlobals.iCiclo,
                            id_grado = (int)cboGrado.IDValor,
                            id_grupo = (int)cboGrupo.IDValor,
                            tipo_inscripcion = "N",
                            beca = chBecado.Checked,
                            promocion = chPromocion.Checked
                        };
                        db.Inscripciones.Add(inscripcion);

                        if (chBecado.Checked)
                        {
                            var beca = new Becas
                            {
                                id_matricula = intMatricula,
                                id_ciclo = basGlobals.iCiclo,
                                porcentaje_beca = Convert.ToDecimal(nPorBeca.Value)
                            };
                            db.Becas.Add(beca);

                        }

                        if (chPromocion.Checked)
                        {
                            foreach (Promociones_Alumnos item in promoAlumno)
                            {
                                item.matricula = intMatricula;
                            }

                            db.PromocionesAlumnos.AddRange(promoAlumno);
                        }
                        db.SaveChanges();
                        if (MessageBox.Show("Alumno registrado correctamente con matrícula " + intMatricula + Environment.NewLine + Environment.NewLine + "¿Desea agregar un tutor?", "Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmCatAlumnos frm = new frmCatAlumnos(intMatricula);
                            frm.ShowDialog();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el alumno. Intente nuevamente.");
                        return;
                    }
                }
            }
            else
            {
                using (var db = new DumontContext())
                {
                    var alumno = db.Alumnos.Find(intMatricula);
                    if (alumno == null)
                    {
                        MessageBox.Show("No se encontró el alumno para actualizar.");
                        return;
                    }
                    // Asignar los valores del formulario al objeto alumno
                    alumno.nombre = txtNombre.Text;
                    alumno.appaterno = txtApPaterno.Text;
                    alumno.apmaterno = txtApMaterno.Text;
                    alumno.fecha_nacimiento = dtpFechaNac.Value;
                    alumno.pais_nacimiento = Convert.ToInt32(cmbPais.SelectedValue);
                    alumno.estado_nacimiento = Convert.ToInt32(cmbEstadoNac.SelectedValue);
                    alumno.sexo = cmbSexo.SelectedValue.ToString();
                    alumno.curp = txtCurp.Text;
                    alumno.calle = txtCalle.Text;
                    alumno.colonia = txtColonia.Text;
                    alumno.ciudad = txtCiudad.Text;
                    alumno.estado = Convert.ToInt32(cmbEstado.SelectedValue);
                    alumno.telefono1 = txtTel1.Text;
                    alumno.telefono2 = txtTel2.Text;
                    alumno.telefono3 = txtTel3.Text;
                    alumno.email = txtEmail.Text;
                    alumno.activo = true;
                    alumno.foto_alumno = basFunctions.ImageToBytes(pictureBox1.Image);

                    // Guardar los cambios

                    db.Entry(alumno).State = System.Data.Entity.EntityState.Modified;

                    var inscripcion = db.Inscripciones.Where(i => i.matricula == alumno.matricula && i.id_ciclo == basGlobals.iCiclo).FirstOrDefault();

                    if (inscripcion != null)
                    {
                        inscripcion.beca = chBecado.Checked;
                        inscripcion.promocion = chPromocion.Checked;

                        db.Entry(inscripcion).State = System.Data.Entity.EntityState.Modified;

                        if (chPromocion.Checked)
                        {
                            var promocionesActuales = db.PromocionesAlumnos
                                                    .Where(p => p.matricula == alumno.matricula && p.id_ciclo == basGlobals.iCiclo)
                                                    .ToList();

                            var promocionesAEliminar = promocionesActuales
                                                    .Where(p => !promoAlumno.Any(lp => lp.id == p.id && p.id_ciclo == basGlobals.iCiclo))
                                                    .ToList();

                            db.PromocionesAlumnos.RemoveRange(promocionesAEliminar);

                            var promocionesNuevas = promoAlumno
                                                    .Where(lp => !promocionesActuales.Any(p => p.id_promocion == lp.id_promocion && p.id_ciclo == basGlobals.iCiclo))
                                                    .ToList();

                            db.PromocionesAlumnos.AddRange(promocionesNuevas);

                            basFunctions.Registrar(basConfiguracion.UserID, "Alumnos", "Editar", intMatricula, "Se modifico la promocion del alumno: " + intMatricula);
                        }

                        var becaExistente = db.Becas.FirstOrDefault(b => b.id_matricula == intMatricula && b.id_ciclo == basGlobals.iCiclo);
                        if (becaExistente == null)
                        {
                            if (chBecado.Checked)
                            {
                                var beca = new Becas
                                {
                                    id_matricula = intMatricula,
                                    id_ciclo = basGlobals.iCiclo,
                                    porcentaje_beca = Convert.ToDecimal(nPorBeca.Value)
                                };
                                db.Becas.Add(beca);
                            }
                        }
                        else
                        {
                            if (chBecado.Checked)
                            {
                                becaExistente.porcentaje_beca = Convert.ToDecimal(nPorBeca.Value);
                                db.Entry(becaExistente).State = System.Data.Entity.EntityState.Modified;
                            }
                            else
                            {
                                db.Becas.Remove(becaExistente);
                                basFunctions.Registrar(basConfiguracion.UserID, "Alumnos", "Editar", intMatricula, "Se elimino la beca del alumno: " + intMatricula);
                            }
                        }
                    }
                    basFunctions.Registrar(basConfiguracion.UserID, "Alumnos", "Editar", intMatricula, "Se actualizó el alumno con matrícula: " + intMatricula);
                    db.SaveChanges();
                    MessageBox.Show("Alumno actualizado correctamente.");
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
            frmAsignarTutor frm = new frmAsignarTutor(intMatricula);
            frm.Text = $"Asignar Tutor para alumno: {intMatricula}";
            frm.ShowDialog();
        }
        protected override void Cerrar()
        {
            this.Close();
        }
        protected override void Acciones()
        {
            frmAcciones frm = new frmAcciones("Alumnos", intMatricula);
            frm.Text = "Acciones Alumno";
            frm.ShowDialog();
        }
        protected override void Deshabilitar()
        {
            using (var db = new DumontContext())
            {
                alumnos = db.Alumnos.Find(intMatricula);
                alumnos.activo = false;
                db.SaveChanges();
                this.Close();
            }
        }
        protected override void Habilitar()
        {
            using (var db = new DumontContext())
            {
                alumnos = db.Alumnos.Find(intMatricula);
                alumnos.activo = true;
                db.SaveChanges();
                this.Close();
            }
        }
        #endregion

        #region "Eventos Personalizados"


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
                btAddTutor.Visible = false;
            }
            else
            {
                using (var db = new DumontContext())
                {
                    alumnos = db.Alumnos.Find(matricula);
                    intMatricula = matricula;
                    lbMatricula.Text = matricula.ToString();
                    this.Text = "Modificar Alumno: " + matricula;
                    // Limpiar los campos
                    txtNombre.Text = alumnos.nombre;
                    txtApPaterno.Text = alumnos.appaterno;
                    txtApMaterno.Text = alumnos.apmaterno;
                    txtCurp.Text = alumnos.curp;
                    txtCalle.Text = alumnos.calle;
                    txtColonia.Text = alumnos.colonia;
                    txtCiudad.Text = alumnos.ciudad;
                    cmbPais.SelectedValue = alumnos.pais_nacimiento ?? 1;
                    cmbEstado.SelectedValue = alumnos.estado ?? 0;
                    CargaEstadosNacimiento();
                    cmbEstadoNac.SelectedValue = alumnos.estado_nacimiento ?? 0;
                    dtpFechaNac.Value = alumnos.fecha_nacimiento ?? System.DateTime.Now;
                    cmbSexo.SelectedValue = alumnos.sexo ?? "M";
                    txtTel1.Text = alumnos.telefono1;
                    txtTel2.Text = alumnos.telefono2;
                    txtTel3.Text = alumnos.telefono3;
                    txtEmail.Text = alumnos.email;
                    if (alumnos.foto_alumno != null)
                    {
                        pictureBox1.Image = basFunctions.BytesToImage(alumnos.foto_alumno);
                    }

                    // Cargar los grados y grupos
                    var inscripcion = db.Inscripciones.FirstOrDefault(i => i.matricula == matricula && i.id_ciclo == basGlobals.iCiclo);
                    if (inscripcion != null)
                    {
                        cboGrado.IDValor = inscripcion.id_grado;
                        cboGrupo.IDValor = inscripcion.id_grupo;
                        chBecado.Checked = inscripcion.beca;
                        chPromocion.Checked = inscripcion.promocion;
                    }
                    else
                    {
                        cboGrado.Inicializar();
                        cboGrupo.Inicializar();
                    }

                    // Cargar las becas y promociones
                    var beca = db.Becas.FirstOrDefault(b => b.id_matricula == matricula && b.id_ciclo == basGlobals.iCiclo);
                    if (beca != null)
                    {
                        nPorBeca.Value = beca.porcentaje_beca;
                    }
                    else
                    {
                        nPorBeca.Value = 0;
                    }

                    promoAlumno = db.PromocionesAlumnos.Where(p => p.matricula == intMatricula && p.id_ciclo == basGlobals.iCiclo).ToList();
                    promoAlumnosDTOs = db.PromocionesAlumnos.Where(p => p.matricula == intMatricula && p.id_ciclo == basGlobals.iCiclo).Select(t => new PromoAlumnosDTO
                    {
                        id_promocion = t.id_promocion,
                        descripcion = db.Promociones.Where(p => p.id_promocion == t.id_promocion).Select(p => p.descripcion).FirstOrDefault(),
                        concepto = db.Promociones.Where(p => p.id_promocion == t.id_promocion).Select(p => p.concepto).FirstOrDefault(),
                        ciclo = db.CiclosEscolares.Where(ce => ce.id_ciclo == t.id_ciclo).Select(ce => ce.ciclo).FirstOrDefault(),
                        id = t.id
                    }).ToList();

                    if (promoAlumno.Count > 0)
                    {
                        dgvPromociones.DataSource = promoAlumnosDTOs;
                        FormatGridPromo();
                    }
                    else
                    {
                        dgvPromociones.DataSource = promoAlumnosDTOs;
                        FormatGridPromo();
                    }

                    // Validar si el alumno tiene tutores
                    tutores = db.TutoresAlumnos
                  .Where(m => m.matricula == intMatricula).ToList().Select(m => new TutorAlumnoDTO
                  {
                      NombreTutor = db.Tutores.Where(tu => tu.id_tutor == m.id_tutor).Select(tu => tu.appaterno + " " + tu.apmaterno + " " + tu.nombre).FirstOrDefault(),
                      IdTutor = m.id_tutor,
                      IdAlumno = m.matricula,
                      Parentesco = db.Catalogos.Where(c => c.valor == m.parentesco && c.tipo_catalogo == "Parentesco").Select(c => c.descripcion).FirstOrDefault()
                  }).ToList();

                    if (tutores.Count > 0)
                    {
                        dtTutores = new DataTable();
                        dtTutores = basFunctions.ConvertToDataTable(tutores);
                        dgvTutors.DataSource = dtTutores;
                        dgvTutors.Columns["IdTutor"].Visible = false;
                        dgvTutors.Columns["IdAlumno"].Visible = false;
                        dgvTutors.Columns["NombreTutor"].HeaderText = "Nombre del Tutor";
                        dgvTutors.Columns["Parentesco"].HeaderText = "Parentesco";
                        dgvTutors.Columns["Parentesco"].Width = 150;
                        dgvTutors.Columns["NombreTutor"].Width = 250;
                    }
                }
            }
        }

        private void FormatGridPromo()
        {
            dgvPromociones.Columns["id_promocion"].Visible = false;
            dgvPromociones.Columns["descripcion"].HeaderText = "Promocion";
            dgvPromociones.Columns["concepto"].HeaderText = "Concepto";
            dgvPromociones.Columns["ciclo"].HeaderText = "Ciclo";
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
            if (dtTutores.Rows.Count == 0)
            {
                if (MessageBox.Show("El Alumno no tiene tutores asignados. ¿Desea agregar un tutor?", "Agregar Tutor", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmAsignarTutor frm = new frmAsignarTutor(intMatricula);
                    frm.Text = "Asignar Tutor a alumno";
                    frm.ShowDialog();
                }
            }
            else
            {
                return;
            }
        }

        private void CargaEstadosNacimiento()
        {
            // Cargar los estados de nacimiento según el país seleccionado
            if (cmbPais.SelectedValue != null)
            {
                int paisId = Convert.ToInt32(cmbPais.SelectedValue);
                basFunctions.CargarCatalogo(cmbEstadoNac, "estados", "Id", "Nombre", "WHERE PaisId = " + paisId);
            }
        }

        private void CargarMenu()
        {

            btQuitarRecargo.Visible = false;
            btResetPass.Visible = false;

            if (intMatricula == 0)
            {
                btHabilitar.Visible = false;
                btDeshabilitar.Visible = false;
            }
            else
            {
                if (alumnos.activo)
                {
                    btHabilitar.Visible = false;
                    btDeshabilitar.Visible = true;
                }
                else
                {
                    btDeshabilitar.Visible = false;
                    btHabilitar.Visible = true;
                }
            }
        }

        private void ConfigurarMenuFoto()
        {
            var menu = new ContextMenuStrip();
            var subir = new ToolStripMenuItem("Subir foto");
            var eliminar = new ToolStripMenuItem("Eliminar foto");

            subir.Click += (s, e) =>
            {
                var ofd = new OpenFileDialog
                {
                    Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp",
                    Title = "Selecciona una foto"
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Cargar en PictureBox
                    pictureBox1.Image = Image.FromFile(ofd.FileName);

                    // Si usas EF (varbinary):
                    // alumno.Foto = ImageToBytes(pictureBox1.Image);
                    // db.SaveChanges(); // o guarda más tarde
                }
            };

            eliminar.Click += (s, e) =>
            {
                if (pictureBox1.Image == null) return;
                if (MessageBox.Show("¿Eliminar la foto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    pictureBox1.Image = null;

                    // Si usas EF (varbinary):
                    // alumno.Foto = null;
                    // db.SaveChanges(); // o guarda más tarde
                }
            };

            menu.Items.Add(subir);
            menu.Items.Add(eliminar);
            pictureBox1.ContextMenuStrip = menu;

            // (Opcional) Mostrar menú también con clic izquierdo:
            pictureBox1.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    pictureBox1.ContextMenuStrip?.Show(pictureBox1, e.Location);
            };
        }

        #endregion

        #region Eventos del Formulario
        private void frmCatAlumnos_Load(object sender, EventArgs e)
        {
            basFunctions.CargarCatalogo(cmbEstado, "estados", "Id", "Nombre", "WHERE PaisId = 1");
            basFunctions.CargarCatalogo(cmbPais, "paises", "Id", "Nombre");
            CargarComboSexo();
            cboGrado.Inicializar();
            cboGrupo.Inicializar();
            CargarAlumno(intMatricula); // Cargar un nuevo registro vacío
            CargarMenu();

            if (intMatricula != 0)
            {
                ValidaTutores();
            }
            ConfigurarMenuFoto();
        }

        private void cmbEstadoNac_Validating(object sender, CancelEventArgs e)
        {
            basFunctions.ValidarYAgregarNuevo(cmbEstadoNac, "estados", "Nombre", int.Parse(cmbPais.SelectedValue.ToString()));
        }

        private void cmbEstado_Validating(object sender, CancelEventArgs e)
        {
            basFunctions.ValidarYAgregarNuevo(cmbEstado, "estados", "Nombre", 1);
        }
        private void cmbPais_Validating(object sender, CancelEventArgs e)
        {
            cmbEstadoNac.DataSource = null;
            cmbEstadoNac.Text = "";
            basFunctions.CargarCatalogo(cmbEstadoNac, "estados", "Id", "Nombre", "WHERE PaisId = " + cmbPais.SelectedValue);
        }

        private void chBecado_CheckedChanged(object sender, EventArgs e)
        {
            if (chBecado.Checked)
            {
                gbBecado.Enabled = true;
                chPromocion.Checked = false;
                nPorBeca.Focus();
            }
            else
            {
                gbBecado.Enabled = false;
                nPorBeca.Value = 0;
            }
        }

        private void chPromocion_CheckedChanged(object sender, EventArgs e)
        {
            if (chPromocion.Checked)
            {
                chBecado.Checked = false;
                gbPromociones.Enabled = true;
                btAddPromo.Enabled = true;
                btDeletePromo.Enabled = true;
            }
            else
            {
                gbPromociones.Enabled = false;
                btAddPromo.Enabled = false;
                btDeletePromo.Enabled = false;
            }
        }

        #endregion

        private void btAddPromo_Click(object sender, EventArgs e)
        {
            frmAsignarPromo frmPromo = new frmAsignarPromo(this, intMatricula);
            frmPromo.ShowDialog();
            using (var db = new DumontContext())
            {
                promoAlumnosDTOs = promoAlumno.Select(t => new PromoAlumnosDTO
                {
                    id_promocion = t.id_promocion,
                    descripcion = db.Promociones.Where(p => p.id_promocion == t.id_promocion).Select(p => p.descripcion).FirstOrDefault(),
                    concepto = db.Promociones.Where(p => p.id_promocion == t.id_promocion).Select(p => p.concepto).FirstOrDefault(),
                    ciclo = db.CiclosEscolares.Where(ce => ce.id_ciclo == t.id_ciclo).Select(ce => ce.ciclo).FirstOrDefault(),
                    id = t.id
                }).ToList();

                dgvPromociones.DataSource = promoAlumnosDTOs;
                FormatGridPromo();
            }
        }

        private void dgvPromociones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndexPromo = e.RowIndex;
                // Obtener la fila
                DataGridViewRow fila = dgvPromociones.Rows[e.RowIndex];

                // Obtener el valor de la columna "ID" (puedes usar el índice también)
                idPromo = (int)fila.Cells["id"].Value;
            }
        }

        private void btDeletePromo_Click(object sender, EventArgs e)
        {
            if (promoAlumno.Count > 0)
            {
                promoAlumno.RemoveAt(rowIndexPromo);
            }

            using (var db = new DumontContext())
            {

                promoAlumnosDTOs = promoAlumno.Select(t => new PromoAlumnosDTO
                {
                    id_promocion = t.id_promocion,
                    descripcion = db.Promociones.Where(p => p.id_promocion == t.id_promocion).Select(p => p.descripcion).FirstOrDefault(),
                    concepto = db.Promociones.Where(p => p.id_promocion == t.id_promocion).Select(p => p.concepto).FirstOrDefault(),
                    ciclo = db.CiclosEscolares.Where(ce => ce.id_ciclo == t.id_ciclo).Select(ce => ce.ciclo).FirstOrDefault(),
                    id = t.id
                }).ToList();

                dgvPromociones.DataSource = promoAlumnosDTOs;
                FormatGridPromo();
            }
        }

        private void btAddFoto_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog()
            {
                Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Selecciona una foto del alumno"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
    }
}
