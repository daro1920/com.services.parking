namespace Parking40_SalidaBarrera
{
    partial class Mensaje
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
            this.label_mensaje = new System.Windows.Forms.Label();
            this.timer_mensaje = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // label_mensaje
            // 
            this.label_mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mensaje.Location = new System.Drawing.Point(12, 43);
            this.label_mensaje.Name = "label_mensaje";
            this.label_mensaje.Size = new System.Drawing.Size(527, 34);
            this.label_mensaje.TabIndex = 0;
            this.label_mensaje.Text = "Mensaje";
            this.label_mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_mensaje
            // 
            this.timer_mensaje.Tick += new System.EventHandler(this.timer_mensaje_Tick);
            // 
            // Mensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 135);
            this.ControlBox = false;
            this.Controls.Add(this.label_mensaje);
            this.Name = "Mensaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Mensaje_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label_mensaje;
        public System.Windows.Forms.Timer timer_mensaje;

    }
}