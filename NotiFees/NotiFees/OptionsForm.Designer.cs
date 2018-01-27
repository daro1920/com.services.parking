namespace NotiFees
{
    partial class OptionsForm
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
            this.imprimir = new System.Windows.Forms.Button();
            this.reportError = new System.Windows.Forms.Button();
            this.showImage = new System.Windows.Forms.Button();
            this.markAsBig = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imprimir
            // 
            this.imprimir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.imprimir.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.imprimir.Location = new System.Drawing.Point(39, 138);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(99, 44);
            this.imprimir.TabIndex = 0;
            this.imprimir.Text = "Imprimir";
            this.imprimir.UseVisualStyleBackColor = false;
            this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
            // 
            // reportError
            // 
            this.reportError.BackColor = System.Drawing.Color.WhiteSmoke;
            this.reportError.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.reportError.Location = new System.Drawing.Point(354, 138);
            this.reportError.Name = "reportError";
            this.reportError.Size = new System.Drawing.Size(99, 44);
            this.reportError.TabIndex = 1;
            this.reportError.Text = "Reportar Error";
            this.reportError.UseVisualStyleBackColor = false;
            this.reportError.Click += new System.EventHandler(this.reportError_Click);
            // 
            // showImage
            // 
            this.showImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.showImage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.showImage.Location = new System.Drawing.Point(249, 138);
            this.showImage.Name = "showImage";
            this.showImage.Size = new System.Drawing.Size(99, 44);
            this.showImage.TabIndex = 2;
            this.showImage.Text = "Mostrar Imagen";
            this.showImage.UseVisualStyleBackColor = false;
            this.showImage.Click += new System.EventHandler(this.showImage_Click);
            // 
            // markAsBig
            // 
            this.markAsBig.BackColor = System.Drawing.Color.WhiteSmoke;
            this.markAsBig.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.markAsBig.Location = new System.Drawing.Point(144, 138);
            this.markAsBig.Name = "markAsBig";
            this.markAsBig.Size = new System.Drawing.Size(99, 44);
            this.markAsBig.TabIndex = 3;
            this.markAsBig.Text = "Imprimir veh. grande";
            this.markAsBig.UseVisualStyleBackColor = false;
            this.markAsBig.Click += new System.EventHandler(this.markAsBig_Click);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.WhiteSmoke;
            this.close.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.close.Location = new System.Drawing.Point(459, 138);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(99, 44);
            this.close.TabIndex = 4;
            this.close.Text = "Cancelar";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(34, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Elija una opción";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(599, 194);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.markAsBig);
            this.Controls.Add(this.showImage);
            this.Controls.Add(this.reportError);
            this.Controls.Add(this.imprimir);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parking Eugenio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button reportError;
        private System.Windows.Forms.Button showImage;
        private System.Windows.Forms.Button markAsBig;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button imprimir;
    }
}