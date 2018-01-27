namespace Parking40_SalidaBarrera
{
    partial class SalidaBarrera
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_Titulo = new System.Windows.Forms.Label();
            this.label_Subtitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCB = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label_Titulo
            // 
            this.label_Titulo.AutoSize = true;
            this.label_Titulo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Titulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Titulo.Location = new System.Drawing.Point(296, 16);
            this.label_Titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Titulo.Name = "label_Titulo";
            this.label_Titulo.Size = new System.Drawing.Size(259, 35);
            this.label_Titulo.TabIndex = 0;
            this.label_Titulo.Text = "PARKING ESTER";
            // 
            // label_Subtitulo
            // 
            this.label_Subtitulo.AutoSize = true;
            this.label_Subtitulo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Subtitulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Subtitulo.Location = new System.Drawing.Point(224, 64);
            this.label_Subtitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Subtitulo.Name = "label_Subtitulo";
            this.label_Subtitulo.Size = new System.Drawing.Size(396, 35);
            this.label_Subtitulo.TabIndex = 1;
            this.label_Subtitulo.Text = "Gracias por su preferencia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(225, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Presente código de barras";
            // 
            // textBoxCB
            // 
            this.textBoxCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCB.Location = new System.Drawing.Point(99, 181);
            this.textBoxCB.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCB.Name = "textBoxCB";
            this.textBoxCB.Size = new System.Drawing.Size(672, 38);
            this.textBoxCB.TabIndex = 3;
            this.textBoxCB.TextChanged += new System.EventHandler(this.textBoxCB_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SalidaBarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 235);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Subtitulo);
            this.Controls.Add(this.label_Titulo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SalidaBarrera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.SalidaBarrera_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Titulo;
        private System.Windows.Forms.Label label_Subtitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCB;
        private System.Windows.Forms.Timer timer1;
    }
}

