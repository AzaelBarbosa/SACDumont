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
using SACDumont.Catalogos;
using SACDumont.Clases;
using SACDumont.Cobros;
using SACDumont.modulos;
using SACDumont.Modulos;

namespace SACDumont.Listados
{
    public partial class frmMovimientos : frmListados
    {
        DataTable dtMovimientos = new DataTable("Movimientos");
        basGlobals basGlobals = new basGlobals();
        int idCiclo = basConfiguracion.IdCiclo;
        int tipoMovimiento = basGlobals.tipoMovimiento;
        int estatusMovimiento = basGlobals.estatusMovimiento;
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
        protected override void Imprimir()
        {
            // Implementar la lógica para imprimir el listado de movimientos
        }
        protected override void Cerrar()
        {
            this.Close();
        }
        private void CargarMovimientos()
        {
            dtMovimientos = sqlServer.ExecSQLReturnDT($@"SELECT m.id_registros ,m.fechahora AS Fecha, p.descripcion AS Producto, a.apmaterno + ' ' + a.apmaterno + ' ' + a.nombre AS Alumno, cat.descripcion AS Grado, catG.descripcion AS Grupo, 
                                                        m.montoTotal AS Total, (SELECT SUM(monto) FROM cobros WHERE id_movimiento = m.id_registros) - m.montoTotal AS MontoPendiente, m.porcentaje_descuento AS Descuento, m.monto_descuento AS MontoDescuento, m.beca_descuento AS BecaDescuento,
                                                        catP.descripcion AS FormaPago, catE.descripcion AS Estatus
                                                        FROM movimientos m
                                                        INNER JOIN movimiento_productos mp ON m.id_registros = mp.id_movimiento
                                                        INNER JOIN productos p ON p.id_producto = mp.id_producto
                                                        INNER JOIN alumnos a ON a.matricula = m.id_matricula
                                                        INNER JOIN inscripciones i ON i.matricula = a.matricula
                                                        LEFT JOIN catalogos cat ON cat.valor = i.id_grado AND cat.tipo_catalogo = 'Grado' 
                                                        LEFT JOIN catalogos catG ON catG.valor = i.id_grupo AND catG.tipo_catalogo = 'Grupo' 
                                                        LEFT JOIN catalogos catP ON catP.valor = m.id_tipopago AND catP.tipo_catalogo = 'TipoPago' 
                                                        LEFT JOIN catalogos catE ON catE.valor = m.id_estatusmovimiento AND catE.tipo_catalogo = 'EstatusMovimiento'
                                                        WHERE m.id_ciclo = {basGlobals.iCiclo} AND p.concepto = '{basGlobals.sConcepto}'", "Movimientos");
            dgvMovimientos.DataSource = dtMovimientos;
            FormatGrid();
            dgvMovimientos.Refresh();
        }

        private void FormatGrid()
        {
            dgvMovimientos.Columns["id_registros"].Visible = false;
            dgvMovimientos.Columns["Fecha"].HeaderText = "Fecha";
            dgvMovimientos.Columns["Alumno"].HeaderText = "Alumno";
            dgvMovimientos.Columns["Grado"].HeaderText = "Grado";
            dgvMovimientos.Columns["Grupo"].HeaderText = "Grupo";
            dgvMovimientos.Columns["MontoPendiente"].HeaderText = "Monto Pendiente";
            dgvMovimientos.Columns["MontoPendiente"].DefaultCellStyle.Format = "C2";
            dgvMovimientos.Columns["Total"].HeaderText = "Total";
            dgvMovimientos.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvMovimientos.Columns["FormaPago"].HeaderText = "Forma de Pago";
            dgvMovimientos.Columns["Estatus"].HeaderText = "Estatus";
            dgvMovimientos.Columns["Producto"].HeaderText = "Producto";
            dgvMovimientos.Columns["Descuento"].HeaderText = "Descuento";
            dgvMovimientos.Columns["Descuento"].DefaultCellStyle.Format = "P0";
            dgvMovimientos.Columns["MontoDescuento"].HeaderText = "Monto Descuento";
            dgvMovimientos.Columns["MontoDescuento"].DefaultCellStyle.Format = "C2";
            dgvMovimientos.Columns["BecaDescuento"].HeaderText = "Beca Descuento";
            dgvMovimientos.Columns["BecaDescuento"].DefaultCellStyle.Format = "C2";
            //dgvMovimientos.Columns["MontoRecargo"].HeaderText = "Monto Recargo";
            //dgvMovimientos.Columns["MontoRecargo"].DefaultCellStyle.Format = "C2";

            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.MultiSelect = false;
        }
        private void CargarMenu()
        {
            guardarToolStripMenuItem.Visible = false;
        }
        public frmMovimientos()
        {
            InitializeComponent();
        }

        private void frmMovimientos_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarMovimientos();
        }

        private void dgvMovimientos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = ((DataRowView)dgvMovimientos.SelectedRows[0].DataBoundItem).Row;
           
            if (dgvMovimientos.SelectedRows.Count == 0) return;
            {
                DataSet ds = sql.GetMovimientoDetalle(Convert.ToInt32(row["id_registros"].ToString()));
                frmMovimiento frm = new frmMovimiento(ds);
                frm.ShowDialog();
                CargarMovimientos();
            }
        }

        private void dgvMovimientos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMovimientos.Columns[e.ColumnIndex].Name == "Estatus" && e.Value != null)
            {
                string estatus = e.Value.ToString();

                switch (estatus)
                {
                    case "Cancelado":
                        e.CellStyle.ForeColor = Color.Red;
                        break;
                    case "Pendiente":
                        e.CellStyle.ForeColor = Color.Orange;
                        break;
                    case "Liquidado":
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case "Abonado":
                        e.CellStyle.ForeColor = Color.Blue;
                        break;
                }
            }
            if (dgvMovimientos.Columns[e.ColumnIndex].Name == "MontoPendiente" && e.Value != null)
            {
                decimal decMonto  = (decimal)e.Value;

                if (decMonto > 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}
