namespace SACDumont.Otros
{
    partial class frmCambioCiclo
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboCiclos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ciclo:";
            // 
            // cboCiclos
            // 
            this.cboCiclos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiclos.FormattingEnabled = true;
            this.cboCiclos.Location = new System.Drawing.Point(71, 55);
            this.cboCiclos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCiclos.Name = "cboCiclos";
            this.cboCiclos.Size = new System.Drawing.Size(342, 28);
            this.cboCiclos.TabIndex = 3;
            // 
            // frmCambioCiclo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 117);
            this.Controls.Add(this.cboCiclos);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCambioCiclo";
            this.Text = "frmCambioCiclo";
            this.Load += new System.EventHandler(this.frmCambioCiclo_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboCiclos, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCiclos;
    }
}