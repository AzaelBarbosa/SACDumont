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
using SACDumont.Modulos;
using SACDumont.Clases;
using SACDumont.modulos;

namespace SACDumont.Cobros
{
    public partial class frmMovimiento : frmBaseCatalogos
    {
        DataTable dtMovimiento = new DataTable("Movimiento");
        int idCiclo = basConfiguracion.IdCiclo;
        int tipoMovimiento = (int)modulos.TipoMovimiento.Otros;
        int idMovimiento = 0;
        int idMatricula = 0;
        int idGrado = 0;
        int idGrupo = 0;
        string strConcepto = "";
        DataSet dsTemp = new DataSet("Movimiento");
        basSql sql = new basSql();

        protected override void Nuevo()
        {
            frmMovimiento frmMovimiento = new frmMovimiento(null);
            frmMovimiento.ShowDialog();
        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el movimiento
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el movimiento
        }
        protected override void Cerrar()
        {
            this.Close();
        }
        protected override void Deshabilitar()
        {
            // Implementar la lógica para deshabilitar el movimiento
        }
        protected override void QuitarRecargo()
        {
            // Implementar la lógica para quitar el recargo del movimiento
        }

        private void CargarAlumnos()
        {
            cboAlumnos.SqlQuery = $@"SELECT al.matricula, al.apmaterno + ' ' + al.apmaterno + ' ' + al.nombre AS Alumno, cat.valor AS Grado, cat.descripcion AS DescripcionGrado, 
                                    ins.id_grupo AS Grupo, catG.descripcion AS DescripcionGrupo 
                                    FROM alumnos al
                                    INNER JOIN inscripciones ins ON al.matricula = ins.matricula
                                    LEFT JOIN catalogos cat ON cat.valor = ins.id_grado AND cat.tipo_catalogo = 'Grado' 
                                    LEFT JOIN catalogos catG ON catG.valor = ins.id_grupo AND catG.tipo_catalogo = 'Grupo' 
                                    WHERE ins.id_ciclo = {basGlobals.iCiclo}";
            cboAlumnos.Inicializar();
        }
        private void CargarMenu()
        {
            btAddTutor.Visible = false;
        }
        public frmMovimiento(DataSet dsMov)
        {
            InitializeComponent();
            this.dsTemp = dsMov;
        }

        private void DefinirVariables()
        {
            // Definir las variables necesarias para el movimiento
            if (basGlobals.tipoMovimiento == (int)modulos.TipoMovimiento.Colegiatura)
            {
                strConcepto = "COLEGIATURA";
            }
            else if (basGlobals.tipoMovimiento == (int)modulos.TipoMovimiento.Inscripcion)
            {
                strConcepto = "INSCRIPCION";
            }
            else if (basGlobals.tipoMovimiento == (int)modulos.TipoMovimiento.Producto)
            {
                strConcepto = "PRODUCTO";
            }
            else if (basGlobals.tipoMovimiento == (int)modulos.TipoMovimiento.Otros)
            {
                strConcepto = "OTROS";
            }
        }

        private void VerificarMovimiento()
        {
            if (dsTemp == null)
            {
                return;
            }

            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                DataRow row = dsTemp.Tables[0].Rows[0];
                lbIDMovimiento.Text = row["id_registros"].ToString();
                cboAlumnos.matricula = Convert.ToInt32(row["matricula"].ToString());
                cboAlumnos.Enabled = false;
                txCosto.Text = Convert.ToDecimal(row["Total"]).ToString("C");
                txFechaVencimiento.Text = Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy");
                txImportePte.Text = Convert.ToDecimal(row["MontoPendiente"]).ToString("C");
                txTotal.Text = Convert.ToDecimal(row["Total"]).ToString("C");
                nPorcDescuento.Value = Convert.ToDecimal(row["Descuento"]);
                txDescuento.Text = Convert.ToDecimal(row["MontoDescuento"]).ToString("C");
                txBeca.Text = Convert.ToDecimal(row["BecaDescuento"]).ToString("C");
                txRecargo.Text = Convert.ToDecimal(row["MontoRecargo"]).ToString("C");
                comboProductos1.Text = row["Producto"].ToString();
                comboProductos1.Enabled = false;
                cboCatalogos.Text = row["FormaPago"].ToString();
                cboCatalogos.Enabled = false;
                dgvCobros.DataSource = dsTemp.Tables["Cobros"];
                dgvCobros.Columns["id_cobro"].Visible = false;
                dgvCobros.Columns["FormaPago"].HeaderText = "Forma de Pago";
                dgvCobros.Columns["monto"].HeaderText = "Monto";
                dgvCobros.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvCobros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCobros.RowHeadersVisible = false;
                dgvProductos.DataSource = dsTemp.Tables["Productos"];
                dgvProductos.Columns["id_movimiento"].Visible = false;
                dgvProductos.Columns["Concepto"].Visible = false;
                dgvProductos.Columns["Producto"].HeaderText = "Producto";
                dgvProductos.Columns["cantidad"].HeaderText = "Qty";
                dgvProductos.Columns["cantidad"].DefaultCellStyle.Format = "N0";
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProductos.RowHeadersVisible = false;
            }

        }

        private void ValidaTipoMovimiento()
        {
            if (basGlobals.tipoMovimiento != 1)
            {
                gbCobros.Visible = false;
                gbProductos.Visible = false;
                groupBox2.Location = new Point(16, 161);
            }
            else
            {
                gbProductos.Visible = true;
                gbCobros.Visible = true;
                groupBox2.Location = new Point(16, 290);
            }
        }

        private void frmMovimiento_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarAlumnos();
            DefinirVariables();
            VerificarMovimiento();
            //ValidaTipoMovimiento();
        }

        private void comboProductos1_OnCobroSeleccionado_1(DataRow obj)
        {
            txCosto.Text = Convert.ToDecimal(obj["precio"]).ToString("C");
            txFechaVencimiento.Text = Convert.ToDateTime(obj["fecha_vencimiento"]).ToString("dd/MM/yyyy");
            txImporte.Enabled = true;
            cboCatalogos.Enabled = true; 
            cboCatalogos.Inicializar();
        }

        private void cboAlumnos_OnAlumnoSeleccionado(DataRow obj)
        {
            idMatricula = Convert.ToInt32(obj["matricula"]);
            idGrado = Convert.ToInt32(obj["Grado"]);
            idGrupo = Convert.ToInt32(obj["Grupo"]);
            this.cboAlumnos.Size = new Size(398, 21);

            comboProductos1.SqlQuery = $@"SELECT p.id_producto, p.descripcion, p.concepto, pc.fecha_vencimiento, pc.precio FROM productos p 
                                        INNER JOIN producto_ciclo pc ON pc.id_producto = p.id_producto
                                        LEFT JOIN movimiento_productos mp ON mp.id_producto = p.id_producto
                                        LEFT JOIN movimientos m ON m.id_registros = mp.id_movimiento 
                                        WHERE pc.id_ciclo = {basGlobals.iCiclo} AND pc.id_grupo = {idGrupo} AND mp.id_producto IS NULL AND p.concepto = '{strConcepto}'";
            comboProductos1.Inicializar();
        }

    }
}
