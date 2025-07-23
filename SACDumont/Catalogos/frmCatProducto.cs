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
using SACDumont.modulos;
using SACDumont.Modulos;
using SACDumont.Otros;

namespace SACDumont.Catalogos
{
    public partial class frmCatProducto : frmBaseCatalogos
    {
        #region "Variables"
        DataTable dtProductos = new DataTable("Productos");
        DataTable dtProductosCiclo = new DataTable("ProductoCiclo");
        Productos productos = new Productos();
        Producto_Ciclo producto_Ciclo = new Producto_Ciclo();
        int idProducto = 0;
        public int idGrupo = 0;
        basFunctions basFunctions = new basFunctions();
        sqlServer sqlServer = new sqlServer();
        bool bolEstatus = false;
        #endregion

        #region "Métodos Virtuales"

        protected override void Nuevo()
        {
            frmCatProducto frm = new frmCatProducto(0);
            frm.ShowDialog();
        }
        protected override void Guardar()
        {
            // Validaciones...
            if (cboConcepto.Text == "") { MessageBox.Show("El campo Concepto es obligatorio."); cboConcepto.Focus(); return; }
            if (txDescripcion.Text == "") { MessageBox.Show("El campo Descripcion es obligatorio."); txDescripcion.Focus(); return; }
            if (txtCosto.Text == "") { MessageBox.Show("El campo Costo es obligatorio."); txtCosto.Focus(); return; }

            bool esNuevo = idProducto == 0;
            int idProd = esNuevo ? 0 : Convert.ToInt32(idProducto);

            if (idProducto == 0)
            {
                using (DumontContext db = new DumontContext())
                {
                    productos.id_producto = 0;
                    productos.descripcion = txDescripcion.Text.ToUpper();
                    productos.concepto = cboConcepto.Text;
                    productos.abreviatura = txAbreviatura.Text.ToUpper();
                    productos.estado = true;
                    productos.fecha_alta = DateTime.Now;

                    db.Entry(productos).State = System.Data.Entity.EntityState.Added;
                    int result = db.SaveChanges();
                    if (result == 1)
                    {
                        producto_Ciclo.id_producto = productos.id_producto;
                        producto_Ciclo.precio = Convert.ToDecimal(txtCosto.Text);
                        producto_Ciclo.id_ciclo = basGlobals.iCiclo;
                        producto_Ciclo.fecha_vencimiento = dtFechaVenci.Value;
                        producto_Ciclo.id_grupo = (int)cboGrupo.IDValor;

                        db.Entry(producto_Ciclo).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                    }

                }

                //Registrar el nuevo producto
                basFunctions.Registrar(basConfiguracion.UserID, "Productos", "Alta", productos.id_producto, $"Se registró un nuevo producto: {productos.descripcion}");
                MessageBox.Show("Producto registrado correctamente con ID " + productos.id_producto, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {

                using (DumontContext db = new DumontContext())
                {
                    productos = db.Productos.Find(idProducto);
                    if (productos != null)
                    {
                        productos.descripcion = txDescripcion.Text.ToUpper();
                        productos.concepto = cboConcepto.Text;
                        productos.abreviatura = txAbreviatura.Text.ToUpper();

                        db.Entry(productos).State = System.Data.Entity.EntityState.Modified;

                        producto_Ciclo = db.ProductoCiclo.FirstOrDefault(t => t.id_producto == idProducto && t.id_ciclo == basGlobals.iCiclo);

                        if (producto_Ciclo != null)
                        {
                            producto_Ciclo.precio = Convert.ToDecimal(txtCosto.Text.Replace("$", "").Replace(",", ""));
                            producto_Ciclo.id_ciclo = basGlobals.iCiclo;
                            producto_Ciclo.fecha_vencimiento = dtFechaVenci.Value;
                            producto_Ciclo.id_grupo = (int)cboGrupo.IDValor;

                            db.Entry(producto_Ciclo).State = System.Data.Entity.EntityState.Modified;
                        }

                        var result = db.SaveChanges();
                        if (result != 0)
                        {
                            basFunctions.Registrar(basConfiguracion.UserID, "Productos", "Editar", productos.id_producto, $"Se modifico el producto: {productos.descripcion}");
                            MessageBox.Show("Producto actualizado correctamente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el registro de producto

            using (var db = new DumontContext())
            {
                List<movimiento_productos> listaMov = db.MovimientoProductos.Where(t => t.id_producto == idProducto).ToList();
                if (listaMov.Count > 0)
                {
                    MessageBox.Show("El producto que desea eliminar ya se encuentra asignado a uno o mas movimientos." + Environment.NewLine + "No es posible eliminar el Producto", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                productos = db.Productos.Find(idProducto);
                producto_Ciclo = db.ProductoCiclo.FirstOrDefault(t => t.id_producto == idProducto && t.id_ciclo == basGlobals.iCiclo);
                if (MessageBox.Show($"Esta por eliminar el producto:" + Environment.NewLine + Environment.NewLine + $"{productos.descripcion}" + Environment.NewLine + "¿Desea Continuar?", "Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Productos.Remove(productos);
                    db.Entry(productos).State = System.Data.Entity.EntityState.Deleted;
                    db.ProductoCiclo.Remove(producto_Ciclo);
                    db.Entry(producto_Ciclo).State = System.Data.Entity.EntityState.Deleted;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        MessageBox.Show("Promocion eliminada correctamente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }
        protected override void Acciones()
        {
            frmAcciones frm = new frmAcciones("Productos", idProducto);
            frm.Text = "Acciones Producto";
            frm.ShowDialog();
        }
        protected override void Deshabilitar()
        {
            using (var db = new DumontContext())
            {
                productos = db.Productos.Find(idProducto);
                productos.estado = false;
                db.SaveChanges();
                this.Close();
            }
        }
        protected override void Habilitar()
        {
            using (var db = new DumontContext())
            {
                productos = db.Productos.Find(idProducto);
                productos.estado = true;
                db.SaveChanges();
                this.Close();
            }
        }
        protected override void Cerrar()
        {
            this.Close();
        }

        #endregion

        #region "Métodos"

        private void LimpiarControles()
        {
            txDescripcion.Text = string.Empty;
            cboConcepto.Text = string.Empty;
            txtCosto.Text = string.Empty;
            txAbreviatura.Text = string.Empty;
        }
        private void CargarProducto()
        {
            if (idProducto == 0)
            {
                // Cargar un nuevo registro vacío
                this.Text = "Nuevo Producto";
                LimpiarControles();
                lbProductoID.Text = "0";
            }
            else
            {
                // Cargar el registro de producto existente
                using (DumontContext db = new DumontContext())
                {
                    productos = db.Productos.Find(idProducto);
                    producto_Ciclo = db.ProductoCiclo.FirstOrDefault(t => t.id_producto == idProducto && t.id_ciclo == basGlobals.iCiclo && t.id_grupo == idGrupo);
                    if (productos != null)
                    {
                        txAbreviatura.Text = productos.abreviatura ?? " ";
                        txDescripcion.Text = productos.descripcion.ToString().ToUpper();
                        cboConcepto.Text = productos.concepto.ToString();
                        txtCosto.Text = producto_Ciclo.precio.ToString("C2");
                        dtFechaVenci.Value = producto_Ciclo.fecha_vencimiento;
                        cboGrupo.IDValor = producto_Ciclo.id_grupo;
                        lbProductoID.Text = productos.id_producto.ToString();
                        bolEstatus = productos.estado;
                    }
                }
            }
        }
        private void CargarMenu()
        {
            btAddTutor.Visible = false;
            btQuitarRecargo.Visible = false;
            btResetPass.Visible = false;
            if (bolEstatus)
            {
                btHabilitar.Visible = false;
            }
            else
            {
                btDeshabilitar.Visible = false;
            }
        }

        private void CargarCombo()
        {
            cboConcepto.DataSource = Enum.GetValues(typeof(Conceptos));
        }
        #endregion

        public frmCatProducto(int idProducto)
        {
            InitializeComponent();
            this.idProducto = idProducto;
        }

        private void frmCatProducto_Load(object sender, EventArgs e)
        {
            cboGrupo.Inicializar();
            CargarProducto();
            CargarMenu();
            CargarCombo();
        }
    }
}
