﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Base
{
    public partial class frmListados : Form
    {

        // Métodos virtuales que los hijos pueden sobreescribir
        protected virtual void Nuevo() { }
        protected virtual void Guardar() { }
        protected virtual void Eliminar() { }
        protected virtual void Imprimir() { }
        protected virtual void Cerrar() { }

        public frmListados()
        {
            InitializeComponent();
        }

        private void frmListados_Load(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cerrar();
        }
    }
}
