namespace WindowsFormsApplication1
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.print = new System.Windows.Forms.Button();
            this.difResult = new System.Windows.Forms.Label();
            this.supuestoResult = new System.Windows.Forms.Label();
            this.totalResult = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toDate
            // 
            this.toDate.CustomFormat = "dd/MM/yyyy";
            this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDate.Location = new System.Drawing.Point(106, 58);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(113, 26);
            this.toDate.TabIndex = 2;
            this.toDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // fromDate
            // 
            this.fromDate.CustomFormat = "dd/MM/yyyy";
            this.fromDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDate.Location = new System.Drawing.Point(106, 22);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(113, 26);
            this.fromDate.TabIndex = 1;
            this.fromDate.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hasta:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ejecutar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.toDate);
            this.panel1.Controls.Add(this.fromDate);
            this.panel1.Location = new System.Drawing.Point(120, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 160);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.print);
            this.panel2.Controls.Add(this.difResult);
            this.panel2.Controls.Add(this.supuestoResult);
            this.panel2.Controls.Add(this.totalResult);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(12, 251);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 126);
            this.panel2.TabIndex = 8;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(457, 4);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(87, 29);
            this.print.TabIndex = 4;
            this.print.Text = "imprimir";
            this.print.UseVisualStyleBackColor = true;
            this.print.Visible = false;
            this.print.Click += new System.EventHandler(this.button2_Click);
            // 
            // difResult
            // 
            this.difResult.AutoSize = true;
            this.difResult.BackColor = System.Drawing.SystemColors.Control;
            this.difResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.difResult.ForeColor = System.Drawing.Color.Crimson;
            this.difResult.Location = new System.Drawing.Point(376, 63);
            this.difResult.Name = "difResult";
            this.difResult.Size = new System.Drawing.Size(0, 20);
            this.difResult.TabIndex = 13;
            // 
            // supuestoResult
            // 
            this.supuestoResult.AutoSize = true;
            this.supuestoResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.supuestoResult.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.supuestoResult.Location = new System.Drawing.Point(217, 63);
            this.supuestoResult.Name = "supuestoResult";
            this.supuestoResult.Size = new System.Drawing.Size(0, 20);
            this.supuestoResult.TabIndex = 12;
            // 
            // totalResult
            // 
            this.totalResult.AutoSize = true;
            this.totalResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.totalResult.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.totalResult.Location = new System.Drawing.Point(86, 63);
            this.totalResult.Name = "totalResult";
            this.totalResult.Size = new System.Drawing.Size(0, 20);
            this.totalResult.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Location = new System.Drawing.Point(66, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Location = new System.Drawing.Point(172, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Supuesto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Location = new System.Drawing.Point(333, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Diferencia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cantidad de tickets";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Resultado";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(573, 415);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Diferencias de tickets";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label difResult;
        private System.Windows.Forms.Label supuestoResult;
        private System.Windows.Forms.Label totalResult;
        private System.Windows.Forms.Button print;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}

