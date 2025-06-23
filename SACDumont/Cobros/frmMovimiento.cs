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
using SACDumont.Models;
using log4net.Util;

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
            basGlobals.listaCobros = new List<MovimientoCobros>();
            basGlobals.listMovimientos = new List<Movimientos>();
            basGlobals.listaProductos = new List<MovimientosProductos>();
            this.Close();
        }
        protected override void Deshabilitar()
        {
            // Implementar la lógica para deshabilitar el movimiento
        }

        private void CargarAlumnos()
        {
            //cboAlumnos.Inicializar();
        }
        private void CargarMenu()
        {
            btAddTutor.Visible = false;
            btQuitarRecargo.Visible = false;
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
                basGlobals.dsMovimiento = sql.GetMovimientoDetalle(0);
                return;
            }

            if (dsTemp.Tables[0].Rows.Count > 0)
            {
                DataRow row = dsTemp.Tables[0].Rows[0];
                lbIDMovimiento.Text = row["id_registros"].ToString();
                cboAlumnos.matricula = Convert.ToInt32(row["matricula"].ToString());
                cboAlumnos.Enabled = false;
                txImporte.Text = Convert.ToDecimal(row["Total"]).ToString("C");
                txImportePte.Text = Convert.ToDecimal(row["MontoPendiente"]).ToString("C");
                txTotal.Text = Convert.ToDecimal(row["Total"]).ToString("C");
                //nPorcDescuento.Value = Convert.ToDecimal(row["Descuento"]);
                txDescuento.Text = Convert.ToDecimal(row["MontoDescuento"]).ToString("C");
                txBeca.Text = Convert.ToDecimal(row["BecaDescuento"]).ToString("C");
                //txRecargo.Text = Convert.ToDecimal(row["MontoRecargo"]).ToString("C");
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
                dgvProductos.Columns["monto"].HeaderText = "Monto";
                dgvProductos.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvProductos.Columns["monto_recargo"].HeaderText = "Recargo";
                dgvProductos.Columns["monto_recargo"].DefaultCellStyle.Format = "C2";
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProductos.RowHeadersVisible = false;
                if (row["Estatus"].ToString() == "Liquidado")
                {
                    btDeleteProducto.Enabled = false;
                    btNewProducto.Enabled = false;
                    btDeletePago.Enabled = false;
                    btNewPago.Enabled = false;
                }
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

        private void cboAlumnos_OnAlumnoSeleccionado(DataRow obj)
        {
            idMatricula = Convert.ToInt32(obj["matricula"]);
            idGrado = Convert.ToInt32(obj["Grado"]);
            idGrupo = Convert.ToInt32(obj["Grupo"]);
            this.cboAlumnos.Size = new Size(398, 21);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboAlumnos.matricula == 0)
            {
                MessageBox.Show("Debe seleccionar un alumno antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmCobroProducto frmCobro = new frmCobroProducto(idGrupo,strConcepto);
            frmCobro.Text = "Agregar Producto";
            frmCobro.ShowDialog();
            if (basGlobals.listaProductos.Count > 0)
            {
                dgvProductos.DataSource = basGlobals.listaProductos;
                dgvProductos.Columns["id_movimiento"].Visible = false;
                dgvProductos.Columns["id_producto"].Visible = false;
                dgvProductos.Columns["id"].Visible = false;
                dgvProductos.Columns["descriptionProducto"].HeaderText = "Producto";
                dgvProductos.Columns["cantidad"].HeaderText = "Qty";
                dgvProductos.Columns["cantidad"].DefaultCellStyle.Format = "N0";
                dgvProductos.Columns["monto"].HeaderText = "Monto";
                dgvProductos.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvProductos.Columns["monto_recargo"].HeaderText = "Recargo";
                dgvProductos.Columns["monto_recargo"].DefaultCellStyle.Format = "C2";

                dgvProductos.Columns["descriptionProducto"].Width = 220;
                dgvProductos.Columns["cantidad"].Width = 30;
                dgvProductos.Columns["monto"].Width = 110;
                dgvProductos.Columns["monto_recargo"].Width = 110;
                dgvProductos.RowHeadersVisible = false;

                txImporte.Text = basGlobals.listaProductos.Sum(p => p.monto).ToString();
                txImporte.Text = Convert.ToDecimal(txImporte.Text).ToString("C2");
                txRecargo.Text = basGlobals.listaProductos.Sum(p => p.monto_recargo).ToString();
                txRecargo.Text = Convert.ToDecimal(txRecargo.Text).ToString("C2");
                txTotal.Text = (Convert.ToDecimal(txImporte.Text.Replace("$", "").Replace(",", "").Trim()) + Convert.ToDecimal(txRecargo.Text.Replace("$", "").Replace(",", "").Trim())).ToString("C2");
                txImportePte.Text = txTotal.Text;
                txImportePte.ForeColor = Color.Red;
                dgvProductos.Refresh();
            }
        }

        private void btNewPago_Click(object sender, EventArgs e)
        {
            decimal decImportePte = 0;

            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay ningun Producto para cobrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (basGlobals.listaCobros.Count > 0)
            {
                decImportePte = (Convert.ToDecimal(txTotal.Text.Replace("$", "").Replace(",", "").Trim()) - Convert.ToDecimal(basGlobals.listaCobros.Sum(p => p.monto).ToString()));
                txImportePte.Text = decImportePte.ToString("C2");

            }
            else
            {
                decImportePte = (Convert.ToDecimal(txTotal.Text.Replace("$", "").Replace(",", "").Trim()));
                txImportePte.Text = decImportePte.ToString("C2");
            }

            frmMovimientoCobro frmMovimientoCobro = new frmMovimientoCobro(decImportePte);
            frmMovimientoCobro.Text = "Agregar Cobro";
            frmMovimientoCobro.ShowDialog();
            if (basGlobals.listaCobros.Count > 0)
            {
                dgvCobros.DataSource = null;
                dgvCobros.DataSource = basGlobals.listaCobros;
                dgvCobros.Columns["id_cobro"].Visible = false;
                dgvCobros.Columns["id_movimiento"].Visible = false;
                dgvCobros.Columns["tipopago"].Visible = false;
                dgvCobros.Columns["descripcionPago"].HeaderText = "Forma de Pago";
                dgvCobros.Columns["monto"].HeaderText = "Monto";
                dgvCobros.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvCobros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCobros.RowHeadersVisible = false;
                dgvCobros.Refresh();
            }

            if (decImportePte > 0)
            {
                txImportePte.ForeColor = Color.Red;
            }
            else
            {
                txImportePte.ForeColor = Color.Black;
            }
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cboAlumnos_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
