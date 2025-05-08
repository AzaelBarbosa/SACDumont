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
        public frmMovimiento(DataTable dtMov)
        {
            InitializeComponent();
            this.dtMovimiento = dtMov;
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
            dtMovimiento = sqlServer.ExecSQLReturnDT($@"SELECT a.matricula, m.id_registros ,m.fechahora AS Fecha, a.apmaterno + ' ' + a.apmaterno + ' ' + a.nombre AS Alumno, cat.descripcion AS Grado, catG.descripcion AS Grupo, p.descripcion AS Descripcion, 
                                                        m.monto AS Monto, m.montoTotal - m.monto AS MontoPendiente, m.montoTotal AS Total, catP.descripcion AS FormaPago, catE.descripcion AS Estatus, p.descripcion AS Producto, m.porcentaje_descuento AS Descuento,
                                                        m.monto_descuento AS MontoDescuento, m.beca_descuento AS BecaDescuento,m.monto_recargo AS MontoRecargo , p.descripcion AS Producto   
                                                        FROM movimientos m
                                                        INNER JOIN movimiento_productos mp ON m.id_registros = mp.id_movimiento
                                                        INNER JOIN productos p ON p.id_producto = mp.id_producto
                                                        INNER JOIN alumnos a ON a.matricula = m.id_matricula
                                                        INNER JOIN inscripciones i ON i.matricula = a.matricula
                                                        LEFT JOIN catalogos cat ON cat.valor = i.id_grado AND cat.tipo_catalogo = 'Grado' 
                                                        LEFT JOIN catalogos catG ON catG.valor = i.id_grupo AND catG.tipo_catalogo = 'Grupo' 
                                                        LEFT JOIN catalogos catP ON catP.valor = m.id_tipopago AND catP.tipo_catalogo = 'TipoPago' 
                                                        LEFT JOIN catalogos catE ON catE.valor = m.id_estatusmovimiento AND catE.tipo_catalogo = 'EstatusMovimiento'
                                                        WHERE m.id_ciclo = {basGlobals.iCiclo} AND m.id_registros = {idMovimiento}", "Movimiento");
            if (dtMovimiento.Rows.Count > 0)
            {
                DataRow row = dtMovimiento.Rows[0];
                cboAlumnos.matricula = Convert.ToInt32(row["matricula"].ToString());
                cboAlumnos.Enabled = false;
                txCosto.Text = Convert.ToDecimal(row["Monto"]).ToString("C");
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
            }
        }

        private void ValidaTipoMovimiento()
        {
            if (basGlobals.tipoMovimiento != 1)
            {
                dgvProductos.Visible = false;
                groupBox2.Location = new Point(16, 161);
            }
            else
            {
                dgvProductos.Visible = true;
                groupBox2.Location = new Point(16, 290);
            }
        }

        private void frmMovimiento_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarAlumnos();
            DefinirVariables();
            VerificarMovimiento();
            ValidaTipoMovimiento();
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
