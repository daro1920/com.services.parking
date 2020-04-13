namespace e_billing
{
    partial class AddMove
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.horaLabel = new System.Windows.Forms.Label();
            this.strHora = new System.Windows.Forms.DateTimePicker();
            this.tipoVehiculoTableAdapter1 = new e_billing.ParkingDataSet1TableAdapters.TipoVehiculoTableAdapter();
            this.strFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.matriculaLabel = new System.Windows.Forms.Label();
            this.strImp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.strObs = new System.Windows.Forms.TextBox();
            this.vehType = new System.Windows.Forms.ComboBox();
            this.tipoMovimientoCajaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.parkingDataSet2 = new e_billing.ParkingDataSet2();
            this.vehTypeLabel = new System.Windows.Forms.Label();
            this.tipoMovimientoCajaTableAdapter = new e_billing.ParkingDataSet2TableAdapters.TipoMovimientoCajaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tipoMovimientoCajaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(297, 188);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 54);
            this.button3.TabIndex = 34;
            this.button3.Text = "x Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkGreen;
            this.button2.Location = new System.Drawing.Point(193, 188);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 54);
            this.button2.TabIndex = 33;
            this.button2.Text = "✓ Aceptar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // horaLabel
            // 
            this.horaLabel.AutoSize = true;
            this.horaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horaLabel.Location = new System.Drawing.Point(25, 46);
            this.horaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.horaLabel.Name = "horaLabel";
            this.horaLabel.Size = new System.Drawing.Size(61, 24);
            this.horaLabel.TabIndex = 30;
            this.horaLabel.Text = "Hora:";
            // 
            // strHora
            // 
            this.strHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.strHora.Location = new System.Drawing.Point(116, 50);
            this.strHora.Name = "strHora";
            this.strHora.ShowUpDown = true;
            this.strHora.Size = new System.Drawing.Size(210, 20);
            this.strHora.TabIndex = 37;
            // 
            // tipoVehiculoTableAdapter1
            // 
            this.tipoVehiculoTableAdapter1.ClearBeforeFill = true;
            // 
            // strFecha
            // 
            this.strFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.strFecha.Location = new System.Drawing.Point(116, 21);
            this.strFecha.Name = "strFecha";
            this.strFecha.Size = new System.Drawing.Size(210, 20);
            this.strFecha.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 38;
            this.label1.Text = "Fecha:";
            // 
            // matriculaLabel
            // 
            this.matriculaLabel.AutoSize = true;
            this.matriculaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matriculaLabel.Location = new System.Drawing.Point(25, 73);
            this.matriculaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.matriculaLabel.Name = "matriculaLabel";
            this.matriculaLabel.Size = new System.Drawing.Size(86, 24);
            this.matriculaLabel.TabIndex = 41;
            this.matriculaLabel.Text = "Importe:";
            // 
            // strImp
            // 
            this.strImp.Location = new System.Drawing.Point(116, 79);
            this.strImp.Name = "strImp";
            this.strImp.Size = new System.Drawing.Size(210, 20);
            this.strImp.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 24);
            this.label2.TabIndex = 43;
            this.label2.Text = "Obs:";
            // 
            // strObs
            // 
            this.strObs.Location = new System.Drawing.Point(87, 143);
            this.strObs.Name = "strObs";
            this.strObs.Size = new System.Drawing.Size(486, 20);
            this.strObs.TabIndex = 42;
            // 
            // vehType
            // 
            this.vehType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tipoMovimientoCajaBindingSource, "id", true));
            this.vehType.DataSource = this.tipoMovimientoCajaBindingSource;
            this.vehType.DisplayMember = "str_descrip";
            this.vehType.FormattingEnabled = true;
            this.vehType.Location = new System.Drawing.Point(88, 109);
            this.vehType.Name = "vehType";
            this.vehType.Size = new System.Drawing.Size(238, 21);
            this.vehType.TabIndex = 45;
            this.vehType.ValueMember = "id";
            // 
            // tipoMovimientoCajaBindingSource
            // 
            this.tipoMovimientoCajaBindingSource.DataMember = "TipoMovimientoCaja";
            this.tipoMovimientoCajaBindingSource.DataSource = this.parkingDataSet2;
            // 
            // parkingDataSet2
            // 
            this.parkingDataSet2.DataSetName = "ParkingDataSet2";
            this.parkingDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vehTypeLabel
            // 
            this.vehTypeLabel.AutoSize = true;
            this.vehTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehTypeLabel.Location = new System.Drawing.Point(25, 107);
            this.vehTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vehTypeLabel.Name = "vehTypeLabel";
            this.vehTypeLabel.Size = new System.Drawing.Size(58, 24);
            this.vehTypeLabel.TabIndex = 44;
            this.vehTypeLabel.Text = "Tipo:";
            // 
            // tipoMovimientoCajaTableAdapter
            // 
            this.tipoMovimientoCajaTableAdapter.ClearBeforeFill = true;
            // 
            // AddMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 280);
            this.Controls.Add(this.vehType);
            this.Controls.Add(this.vehTypeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.strObs);
            this.Controls.Add(this.matriculaLabel);
            this.Controls.Add(this.strImp);
            this.Controls.Add(this.strFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.strHora);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.horaLabel);
            this.Name = "AddMove";
            this.Text = "AddMove";
            this.Load += new System.EventHandler(this.AddMove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tipoMovimientoCajaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label horaLabel;
        private ParkingDataSet1TableAdapters.TipoVehiculoTableAdapter tipoVehiculoTableAdapter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label matriculaLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label vehTypeLabel;
        private ParkingDataSet2 parkingDataSet2;
        private System.Windows.Forms.BindingSource tipoMovimientoCajaBindingSource;
        private ParkingDataSet2TableAdapters.TipoMovimientoCajaTableAdapter tipoMovimientoCajaTableAdapter;
        public System.Windows.Forms.DateTimePicker strHora;
        public System.Windows.Forms.DateTimePicker strFecha;
        public System.Windows.Forms.TextBox strImp;
        public System.Windows.Forms.TextBox strObs;
        public System.Windows.Forms.ComboBox vehType;
    }
}