using SACDumont.Base;
using SACDumont.Catalogos;
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

namespace SACDumont.Otros
{
    public partial class frmCrearCiclos : frmBaseCatalogos
    {
        #region Variables
        int idCiclo = 0;
        Ciclos_Escolares Ciclos_Escolares = new Ciclos_Escolares();
        List<Productos> productos = new List<Productos>();
        List<Producto_Ciclo> productoNewCiclo = new List<Producto_Ciclo>();
        List<Producto_Ciclo> productoCiclo = new List<Producto_Ciclo>();
        #endregion

        #region Metodos Virtuales
        protected override void Nuevo()
        {
            frmCatProducto frm = new frmCatProducto(0);
            frm.ShowDialog();
        }
        protected override void Guardar()
        {
            if (txDescripcion.Text.Length == 0) { MessageBox.Show("Debe ingresar la descripcion del ciclo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (dtpFechaInicio.Value > dtpFechaFin.Value) { MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (dtpFechaFin.Value < dtpFechaInicio.Value) { MessageBox.Show("La fecha final no puede ser menor a la fecha inicial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (idCiclo > 0)
            {
                using (var db = new DumontContext())
                {
                    Ciclos_Escolares = db.CiclosEscolares.Find(idCiclo);
                    if (Ciclos_Escolares == null)
                    {
                        MessageBox.Show("El ciclo escolar no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Ciclos_Escolares.ciclo = txDescripcion.Text;
                    Ciclos_Escolares.fecha_inicio = dtpFechaInicio.Value;
                    Ciclos_Escolares.fecha_fin = dtpFechaFin.Value;
                    db.Entry(Ciclos_Escolares).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    productos = db.Productos.Where(p => p.estado == true).ToList();
                    foreach (var producto in productos)
                    {
                        var prodExiste = db.ProductoCiclo.Where(pc => pc.id_producto == producto.id_producto && pc.id_ciclo == Ciclos_Escolares.id_ciclo).FirstOrDefault();
                        if (prodExiste == null)
                        {
                            productoCiclo.Add(new Producto_Ciclo()
                            {
                                id_producto = producto.id_producto,
                                id_ciclo = Ciclos_Escolares.id_ciclo,
                                precio = db.ProductoCiclo.Where(pc => pc.id_producto == producto.id_producto && pc.id_ciclo == basConfiguracion.IdCicloActual).Select(pc => pc.precio).FirstOrDefault(),
                                fecha_vencimiento = DateTime.Now.AddYears(100), // Asignar una fecha de vencimiento por defecto
                                id_grupo = db.ProductoCiclo.Where(pc => pc.id_producto == producto.id_producto && pc.id_ciclo == basConfiguracion.IdCicloActual).Select(pc => pc.id_grupo).FirstOrDefault(),
                            });
                        }
                    }
                    if (productoCiclo.Count > 0)
                    {
                        db.ProductoCiclo.AddRange(productoCiclo);
                        db.SaveChanges();
                        db.Dispose();
                    }
                }
                MessageBox.Show($"Ciclo Escolar actualizado correctamente {Environment.NewLine} Recuerde revisar las fechas de Vencimiento de los productos.", "Ciclo Escolar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                using (var db = new DumontContext())
                {
                    Ciclos_Escolares = new Ciclos_Escolares()
                    {
                        ciclo = txDescripcion.Text,
                        fecha_fin = dtpFechaFin.Value,
                        fecha_inicio = dtpFechaInicio.Value
                    };

                    db.Entry(Ciclos_Escolares).State = System.Data.Entity.EntityState.Added;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        productoCiclo = db.ProductoCiclo.Where(pc => pc.id_ciclo == basGlobals.iCiclo).ToList();
                        foreach (var producto in productoCiclo)
                        {
                            productoNewCiclo.Add(new Producto_Ciclo()
                            {
                                id_producto = producto.id_producto,
                                id_ciclo = Ciclos_Escolares.id_ciclo,
                                precio = producto.precio,
                                fecha_vencimiento = producto.fecha_vencimiento.AddYears(1), // Asignar una fecha de vencimiento por defecto
                                id_grupo = producto.id_grupo
                            });
                        }
                        if (productoNewCiclo.Count > 0)
                        {
                            db.ProductoCiclo.AddRange(productoNewCiclo);
                            db.SaveChanges();
                            db.Dispose();
                        }
                    }
                    MessageBox.Show($"Ciclo Escolar creado correctamente.{Environment.NewLine} No olvide revisar las fechas de vencimiento y precios de los productos que requieran.", "Ciclo Escolar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        protected override void Eliminar()
        {

        }
        protected override void Acciones()
        {
        }
        protected override void Deshabilitar()
        {

        }
        protected override void Habilitar()
        {

        }
        protected override void Cerrar()
        {
            this.Close();
        }
        #endregion

        #region Metodos
        private void CargarMenu()
        {
            btAddTutor.Visible = false;
            btQuitarRecargo.Visible = false;
            btResetPass.Visible = false;
            btHabilitar.Visible = false;
            btDeshabilitar.Visible = false;
        }

        private void CargarCiclo()
        {
            if (idCiclo == 0) return;

            using (var db = new DumontContext())
            {
                Ciclos_Escolares = db.CiclosEscolares.Find(idCiclo);
                txDescripcion.Text = Ciclos_Escolares.ciclo;
                dtpFechaInicio.Value = Ciclos_Escolares.fecha_inicio;
                dtpFechaFin.Value = Ciclos_Escolares.fecha_fin;
            }
        }
        #endregion

        #region Eventos Formulario
        public frmCrearCiclos(int idCiclo)
        {
            InitializeComponent();
            this.idCiclo = idCiclo;
        }

        private void frmCrearCiclos_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarCiclo();
        }

        #endregion
    }
}
