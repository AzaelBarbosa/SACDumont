﻿namespace SACDumont.Controles
{
    partial class ComboProductos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txProducto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txProducto
            // 
            this.txProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.txProducto.Location = new System.Drawing.Point(0, 0);
            this.txProducto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txProducto.Name = "txProducto";
            this.txProducto.Size = new System.Drawing.Size(622, 20);
            this.txProducto.TabIndex = 38;
            this.txProducto.Click += new System.EventHandler(this.txProducto_Click);
            this.txProducto.TextChanged += new System.EventHandler(this.txProducto_TextChanged);
            this.txProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txProducto_KeyPress);
            // 
            // ComboProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txProducto);
            this.Name = "ComboProductos";
            this.Size = new System.Drawing.Size(622, 21);
            this.Load += new System.EventHandler(this.ComboProductos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txProducto;
    }
}
