﻿namespace SACDumont.Base
{
    partial class frmBaseCatalogos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseCatalogos));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btDeshabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.btHabilitar = new System.Windows.Forms.ToolStripMenuItem();
            this.btResetPass = new System.Windows.Forms.ToolStripMenuItem();
            this.btDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btQuitarRecargo = new System.Windows.Forms.ToolStripMenuItem();
            this.btAddTutor = new System.Windows.Forms.ToolStripMenuItem();
            this.btAcciones = new System.Windows.Forms.ToolStripMenuItem();
            this.btCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNew,
            this.btSave,
            this.btDeshabilitar,
            this.btHabilitar,
            this.btResetPass,
            this.btDelete,
            this.btQuitarRecargo,
            this.btAddTutor,
            this.btAcciones,
            this.btCerrar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(788, 55);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btNew
            // 
            this.btNew.Image = global::SACDumont.Properties.Resources.agregar;
            this.btNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(54, 51);
            this.btNew.Text = "Nuevo";
            this.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btNew.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // btSave
            // 
            this.btSave.Image = global::SACDumont.Properties.Resources.guardar;
            this.btSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(61, 51);
            this.btSave.Text = "Guardar";
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btSave.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // btDeshabilitar
            // 
            this.btDeshabilitar.Image = global::SACDumont.Properties.Resources.flecha_hacia_abajo;
            this.btDeshabilitar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btDeshabilitar.Name = "btDeshabilitar";
            this.btDeshabilitar.Size = new System.Drawing.Size(81, 51);
            this.btDeshabilitar.Text = "Deshabilitar";
            this.btDeshabilitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btDeshabilitar.Click += new System.EventHandler(this.btDeshabilitar_Click);
            // 
            // btHabilitar
            // 
            this.btHabilitar.Image = global::SACDumont.Properties.Resources.flecha_hacia_arriba;
            this.btHabilitar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btHabilitar.Name = "btHabilitar";
            this.btHabilitar.Size = new System.Drawing.Size(64, 51);
            this.btHabilitar.Text = "Habilitar";
            this.btHabilitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btHabilitar.Click += new System.EventHandler(this.btHabilitar_Click);
            // 
            // btResetPass
            // 
            this.btResetPass.Image = global::SACDumont.Properties.Resources.bloquear;
            this.btResetPass.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btResetPass.Name = "btResetPass";
            this.btResetPass.Size = new System.Drawing.Size(126, 51);
            this.btResetPass.Text = "Resetear Contraseña";
            this.btResetPass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btResetPass.Click += new System.EventHandler(this.btResetPass_Click);
            // 
            // btDelete
            // 
            this.btDelete.Image = global::SACDumont.Properties.Resources.eliminar;
            this.btDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(62, 51);
            this.btDelete.Text = "Eliminar";
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btDelete.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // btQuitarRecargo
            // 
            this.btQuitarRecargo.Image = global::SACDumont.Properties.Resources.eliminar;
            this.btQuitarRecargo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btQuitarRecargo.Name = "btQuitarRecargo";
            this.btQuitarRecargo.Size = new System.Drawing.Size(98, 51);
            this.btQuitarRecargo.Text = "Quitar Recargo";
            this.btQuitarRecargo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btQuitarRecargo.Click += new System.EventHandler(this.btQuitarRecargo_Click);
            // 
            // btAddTutor
            // 
            this.btAddTutor.Image = global::SACDumont.Properties.Resources.eliminarusuario;
            this.btAddTutor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btAddTutor.Name = "btAddTutor";
            this.btAddTutor.Size = new System.Drawing.Size(92, 51);
            this.btAddTutor.Text = "Agregar Tutor";
            this.btAddTutor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btAddTutor.Click += new System.EventHandler(this.agregarTutorToolStripMenuItem_Click);
            // 
            // btAcciones
            // 
            this.btAcciones.Image = global::SACDumont.Properties.Resources.reportes;
            this.btAcciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btAcciones.Name = "btAcciones";
            this.btAcciones.Size = new System.Drawing.Size(67, 51);
            this.btAcciones.Text = "Acciones";
            this.btAcciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btAcciones.Click += new System.EventHandler(this.btAcciones_Click);
            // 
            // btCerrar
            // 
            this.btCerrar.Image = global::SACDumont.Properties.Resources.eliminar;
            this.btCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(51, 51);
            this.btCerrar.Text = "Cerrar";
            this.btCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btCerrar.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.png");
            this.imageList1.Images.SetKeyName(1, "2.png");
            this.imageList1.Images.SetKeyName(2, "3.png");
            this.imageList1.Images.SetKeyName(3, "4.png");
            this.imageList1.Images.SetKeyName(4, "5.png");
            this.imageList1.Images.SetKeyName(5, "6.png");
            this.imageList1.Images.SetKeyName(6, "7.png");
            this.imageList1.Images.SetKeyName(7, "8.png");
            this.imageList1.Images.SetKeyName(8, "9.png");
            this.imageList1.Images.SetKeyName(9, "10.png");
            this.imageList1.Images.SetKeyName(10, "11.png");
            this.imageList1.Images.SetKeyName(11, "12.png");
            this.imageList1.Images.SetKeyName(12, "13.png");
            this.imageList1.Images.SetKeyName(13, "14.png");
            this.imageList1.Images.SetKeyName(14, "15.png");
            this.imageList1.Images.SetKeyName(15, "16.png");
            this.imageList1.Images.SetKeyName(16, "17.png");
            // 
            // frmBaseCatalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 622);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaseCatalogos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBaseCatalogos";
            this.Load += new System.EventHandler(this.frmBaseCatalogos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem btAddTutor;
        protected internal System.Windows.Forms.ToolStripMenuItem btCerrar;
        protected internal System.Windows.Forms.ToolStripMenuItem btQuitarRecargo;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.ToolStripMenuItem btNew;
        public System.Windows.Forms.ToolStripMenuItem btDelete;
        public System.Windows.Forms.ToolStripMenuItem btAcciones;
        public System.Windows.Forms.ToolStripMenuItem btSave;
        public System.Windows.Forms.ToolStripMenuItem btDeshabilitar;
        public System.Windows.Forms.ToolStripMenuItem btHabilitar;
        public System.Windows.Forms.ToolStripMenuItem btResetPass;
    }
}