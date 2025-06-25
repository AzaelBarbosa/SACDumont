using log4net.Util;
using SACDumont.Base;
using SACDumont.Clases;
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

namespace SACDumont.Cobros
{
    public partial class frmMovimiento : frmBaseCatalogos
    {
        #region Variables

        DataTable dtMovimiento = new DataTable("Movimiento");
        int idCiclo = basConfiguracion.IdCiclo;
        int id_estatusmovimiento = (int)modulos.EstatusMovimiento.Liquidado;
        int idMovimiento = 0;
        int idMatricula = 0;
        int idGrado = 0;
        int idGrupo = 0;
        string strConcepto = "";
        DataSet dsTemp = new DataSet("Movimiento");
        basSql sql = new basSql();
        Movimientos movimiento = new Movimientos();
        List<movimiento_productos> listaProductos = new List<movimiento_productos>();
        List<cobros> listaCobros = new List<cobros>();
        #endregion

        #region Constructores
        protected override void Nuevo()
        {
            frmMovimiento frmMovimiento = new frmMovimiento(0);
            frmMovimiento.ShowDialog();
        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el movimiento
            if (cboAlumnos.matricula == 0)
            {
                MessageBox.Show("Debe seleccionar un alumno antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (basGlobals.listaProductos.Count == 0 && basGlobals.listaCobros.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto o cobro antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (basGlobals.listaCobros.Count > 0 && basGlobals.listaCobros.Sum(p => p.monto) <= 0)
            {
                MessageBox.Show("El monto total de los cobros debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (basGlobals.listaProductos.Count > 0 && basGlobals.listaProductos.Sum(p => p.monto) <= 0)
            {
                MessageBox.Show("El monto total de los productos debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((basGlobals.listaProductos.Sum(p => p.monto) + basGlobals.listaProductos.Sum(p => p.monto_recargo)) - basGlobals.listaCobros.Sum(p => p.monto) > 0)
            {
                id_estatusmovimiento = (int)modulos.EstatusMovimiento.Abono; // Si hay saldo pendiente, el estatus es Pendiente
            }
            else
            {
                id_estatusmovimiento = (int)modulos.EstatusMovimiento.Liquidado; // Si no hay saldo pendiente, el estatus es Liquidado
            }

                 using (var db = new DumontContext())
                 {
                 if (idMovimiento > 0)
                 {
                    var mov = db.Movimientos.Find(idMovimiento);
                    if (mov != null)
                    {
                        mov.porcentaje_descuento = 0;
                        mov.monto_descuento = 0;
                        mov.beca_descuento = 0;
                        mov.digitoscuenta = "0";
                        mov.id_estatusmovimiento = id_estatusmovimiento;
                        mov.montoTotal = basGlobals.listaProductos.Sum(p => p.monto) + basGlobals.listaProductos.Sum(c => c.monto_recargo);


                        foreach (var item in basGlobals.listaCobros)
                        {
                            if (item.id_cobro == 0) // Ya existe en la BD → actualizar
                            {
                                item.id_movimiento = idMovimiento;
                                db.MovimientoCobros.Add(item);
                            }
                        }

                        db.SaveChanges(); // 🔥 EF genera los INSERT automáticamente para productos y cobros);
                    }

                    else
                    {
                        MessageBox.Show("Movimiento no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                    else
                    {
                        var nuevo = new Movimientos
                        {
                            id_registros = 0, // Se asignará automáticamente por la base de datos
                            id_matricula = (int)cboAlumnos.matricula,
                            id_usuario = idGrupo,
                            fechahora = DateTime.Now,
                            id_ciclo = basGlobals.iCiclo,
                            montoTotal = basGlobals.listaProductos.Sum(p => p.monto) + basGlobals.listaProductos.Sum(c => c.monto_recargo),
                            porcentaje_descuento = 0, // Asignar el valor correspondiente si se aplica descuento
                            monto_descuento = 0, // Asignar el valor correspondiente si se aplica descuento
                            beca_descuento = 0, // Asignar el valor correspondiente si se aplica beca
                            id_tipomovimiento = basGlobals.tipoMovimiento, // Asignar el estatus correspondiente
                            digitoscuenta = "0",
                            id_estatusmovimiento = id_estatusmovimiento, // Asignar el estatus correspondiente

                        };

                        db.Movimientos.Add(nuevo);
                        db.SaveChanges(); // 🔥 EF genera el INSERT automáticamente

                        db.MovimientoProductos.AddRange(basGlobals.listaProductos.Select(p => new movimiento_productos
                        {
                            id_movimiento = (int)nuevo.id_registros,
                            id_producto = p.id_producto,
                            descriptionProducto = p.descriptionProducto,
                            cantidad = p.cantidad,
                            monto = p.monto,
                            monto_recargo = p.monto_recargo
                        }));
                        db.MovimientoCobros.AddRange(basGlobals.listaCobros.Select(c => new cobros
                        {
                            id_movimiento = (int)nuevo.id_registros,
                            monto = c.monto,
                            tipopago = c.tipopago,
                            descripcionPago = c.descripcionPago
                        }));
                        db.SaveChanges(); // 🔥 EF genera los INSERT automáticamente para productos y cobros
                    }
                 }
            this.Close();
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el movimiento
        }
        protected override void Cerrar()
        {
            basGlobals.listaCobros = new List<cobros>();
            basGlobals.Movimiento = new Movimientos();
            basGlobals.listaProductos = new List<movimiento_productos>();
            this.Close();
        }
        protected override void Deshabilitar()
        {
            // Implementar la lógica para deshabilitar el movimiento
        }

        #endregion

        #region Métodos Privados
        private void CargarAlumnos()
        {
            cboAlumnos.Inicializar();
        }
        private void CargarMenu()
        {
            btAddTutor.Visible = false;
            btQuitarRecargo.Visible = false;
        }
        public frmMovimiento(int idMov)
        {
            InitializeComponent();
            this.idMovimiento = idMov;
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
            if (idMovimiento == 0)
            {
                return;
            }

            basGlobals.Movimiento = sql.GetMovimiento(idMovimiento);
            basGlobals.listaProductos = sql.GetMovimientoProductos(idMovimiento);
            basGlobals.listaCobros = sql.GetMovimientosPagos(idMovimiento);

            if (movimiento != null)
            {
                lbIDMovimiento.Text = basGlobals.Movimiento.id_registros.ToString();
                cboAlumnos.matricula = (int)basGlobals.Movimiento.id_matricula;
                cboAlumnos.Enabled = false;
                txImporte.Text = (basGlobals.listaProductos.Sum(p => p.monto)).ToString("C2");
                txRecargo.Text = (basGlobals.listaProductos.Sum(p => p.monto_recargo)).ToString("C2");
                txImportePte.Text = (basGlobals.Movimiento.montoTotal - basGlobals.listaCobros.Sum(p => p.monto)).ToString("C2");
                txTotal.Text = ( basGlobals.Movimiento.montoTotal).ToString("C");
                txDescuento.Text = (basGlobals.Movimiento.monto_descuento).ToString("C");
                txBeca.Text = (basGlobals.Movimiento.beca_descuento).ToString("C");
                dgvCobros.DataSource = basGlobals.listaCobros;
                dgvCobros.Columns["id_cobro"].Visible = false;
                dgvCobros.Columns["id_movimiento"].Visible = false;
                dgvCobros.Columns["tipopago"].Visible = false;
                dgvCobros.Columns["monto"].HeaderText = "Monto";
                dgvCobros.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvCobros.Columns["descripcionPago"].HeaderText = "Forma de Pago";
                dgvCobros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCobros.RowHeadersVisible = false;
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
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProductos.RowHeadersVisible = false;
                if (basGlobals.Movimiento.id_estatusmovimiento == (int)modulos.EstatusMovimiento.Liquidado)
                {
                    btDeleteProducto.Enabled = false;
                    btNewProducto.Enabled = false;
                    btDeletePago.Enabled = false;
                    btNewPago.Enabled = false;
                }
                else if (basGlobals.Movimiento.id_estatusmovimiento == (int)modulos.EstatusMovimiento.Abono)
                {
                    btDeleteProducto.Enabled = false;
                    btNewProducto.Enabled = false;
                    btDeletePago.Enabled = true;
                    btNewPago.Enabled = true;
                }
            }

        }

        #endregion

        #region Eventos
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
                dgvProductos.DataSource = null;
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
                dgvCobros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCobros.MultiSelect = false;
                dgvCobros.RowHeadersVisible = false;
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

        private void btDeleteProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int idProducto = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["id_producto"].Value);
                basGlobals.listaProductos.RemoveAll(p => p.id_producto == idProducto);
                dgvProductos.DataSource = null;
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
                dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProductos.MultiSelect = false;
                txImporte.Text = basGlobals.listaProductos.Sum(p => p.monto).ToString();
                txImporte.Text = Convert.ToDecimal(txImporte.Text).ToString("C2");
                txRecargo.Text = basGlobals.listaProductos.Sum(p => p.monto_recargo).ToString();
                txRecargo.Text = Convert.ToDecimal(txRecargo.Text).ToString("C2");
                txTotal.Text = (Convert.ToDecimal(txImporte.Text.Replace("$", "").Replace(",", "").Trim()) + Convert.ToDecimal(txRecargo.Text.Replace("$", "").Replace(",", "").Trim())).ToString("C2");
                txImportePte.Text = txTotal.Text;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btDeletePago_Click(object sender, EventArgs e)
        {
            if (dgvCobros.SelectedRows.Count > 0)
            {
                int idCobro = Convert.ToInt32(dgvCobros.SelectedRows[0].Cells["id_cobro"].Value);
                basGlobals.listaCobros.RemoveAll(p => p.id_cobro == idCobro);
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

                decimal decImportePte = (Convert.ToDecimal(txTotal.Text.Replace("$", "").Replace(",", "").Trim()) - Convert.ToDecimal(basGlobals.listaCobros.Sum(p => p.monto).ToString()));
                txImportePte.Text = decImportePte.ToString("C2");
                if (decImportePte > 0)
                {
                    txImportePte.ForeColor = Color.Red;
                }
                else
                {
                    txImportePte.ForeColor = Color.Black;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cobro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
