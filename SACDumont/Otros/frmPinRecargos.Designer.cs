namespace SACDumont.Otros
{
    partial class frmPinRecargos
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
            this.btSubmit = new System.Windows.Forms.Button();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSubmit
            // 
            this.btSubmit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btSubmit.Location = new System.Drawing.Point(0, 160);
            this.btSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(323, 28);
            this.btSubmit.TabIndex = 0;
            this.btSubmit.Text = "OK";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(12, 113);
            this.txtPin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(306, 22);
            this.txtPin.TabIndex = 1;
            // 
            // cboUsuario
            // 
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(12, 39);
            this.cboUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(306, 24);
            this.cboUsuario.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese el PIN de autorización del día:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione el Usuario que le proporcionara el PIN";
            // 
            // frmPinRecargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 188);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboUsuario);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.btSubmit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPinRecargos";
            this.Text = "Autorización";
            this.Load += new System.EventHandler(this.frmPinRecargos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}