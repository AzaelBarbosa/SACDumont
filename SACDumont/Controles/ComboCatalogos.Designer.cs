namespace SACDumont.Controles
{
    partial class ComboCatalogos
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
            this.cboCatalogos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboCatalogos
            // 
            this.cboCatalogos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCatalogos.FormattingEnabled = true;
            this.cboCatalogos.Location = new System.Drawing.Point(0, 0);
            this.cboCatalogos.Name = "cboCatalogos";
            this.cboCatalogos.Size = new System.Drawing.Size(381, 21);
            this.cboCatalogos.TabIndex = 0;
            this.cboCatalogos.SelectedIndexChanged += new System.EventHandler(this.cboCatalogos_SelectedIndexChanged);
            this.cboCatalogos.Validating += new System.ComponentModel.CancelEventHandler(this.cboCatalogos_Validating);
            // 
            // ComboCatalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboCatalogos);
            this.Name = "ComboCatalogos";
            this.Size = new System.Drawing.Size(381, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCatalogos;
    }
}
