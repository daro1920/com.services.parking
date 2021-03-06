﻿namespace e_billing
{
    partial class Entrence
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
            this.plate = new System.Windows.Forms.TextBox();
            this.matriculaLabel = new System.Windows.Forms.Label();
            this.vehTypeLabel = new System.Windows.Forms.Label();
            this.vehType = new System.Windows.Forms.ComboBox();
            this.tipoVehiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.parkingDataSet1 = new e_billing.ParkingDataSet1();
            this.tipoVehiculoTableAdapter = new e_billing.ParkingDataSet1TableAdapters.TipoVehiculoTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.vehConv = new System.Windows.Forms.ComboBox();
            this.conveniosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conveniosTableAdapter = new e_billing.ParkingDataSet1TableAdapters.ConveniosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tipoVehiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conveniosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // plate
            // 
            this.plate.Location = new System.Drawing.Point(214, 33);
            this.plate.Name = "plate";
            this.plate.Size = new System.Drawing.Size(121, 20);
            this.plate.TabIndex = 3;
            // 
            // matriculaLabel
            // 
            this.matriculaLabel.AutoSize = true;
            this.matriculaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matriculaLabel.Location = new System.Drawing.Point(16, 33);
            this.matriculaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.matriculaLabel.Name = "matriculaLabel";
            this.matriculaLabel.Size = new System.Drawing.Size(100, 24);
            this.matriculaLabel.TabIndex = 11;
            this.matriculaLabel.Text = "Matricula:";
            // 
            // vehTypeLabel
            // 
            this.vehTypeLabel.AutoSize = true;
            this.vehTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehTypeLabel.Location = new System.Drawing.Point(16, 73);
            this.vehTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.vehTypeLabel.Name = "vehTypeLabel";
            this.vehTypeLabel.Size = new System.Drawing.Size(177, 24);
            this.vehTypeLabel.TabIndex = 12;
            this.vehTypeLabel.Text = "Tipo de Vehiculo:";
            // 
            // vehType
            // 
            this.vehType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tipoVehiculoBindingSource, "id", true));
            this.vehType.DataSource = this.tipoVehiculoBindingSource;
            this.vehType.DisplayMember = "str_descrip";
            this.vehType.FormattingEnabled = true;
            this.vehType.Location = new System.Drawing.Point(214, 75);
            this.vehType.Name = "vehType";
            this.vehType.Size = new System.Drawing.Size(121, 21);
            this.vehType.TabIndex = 14;
            this.vehType.ValueMember = "id";
            // 
            // tipoVehiculoBindingSource
            // 
            this.tipoVehiculoBindingSource.DataMember = "TipoVehiculo";
            this.tipoVehiculoBindingSource.DataSource = this.parkingDataSet1;
            // 
            // parkingDataSet1
            // 
            this.parkingDataSet1.DataSetName = "ParkingDataSet1";
            this.parkingDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tipoVehiculoTableAdapter
            // 
            this.tipoVehiculoTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkGreen;
            this.button2.Location = new System.Drawing.Point(189, 186);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 54);
            this.button2.TabIndex = 25;
            this.button2.Text = "✓ Aceptar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(293, 186);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 54);
            this.button3.TabIndex = 26;
            this.button3.Text = "x Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tipo de Convenio:";
            // 
            // vehConv
            // 
            this.vehConv.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.conveniosBindingSource, "id", true));
            this.vehConv.DataSource = this.conveniosBindingSource;
            this.vehConv.DisplayMember = "str_descrip";
            this.vehConv.FormattingEnabled = true;
            this.vehConv.Location = new System.Drawing.Point(214, 120);
            this.vehConv.Name = "vehConv";
            this.vehConv.Size = new System.Drawing.Size(121, 21);
            this.vehConv.TabIndex = 28;
            this.vehConv.ValueMember = "id";
            // 
            // conveniosBindingSource
            // 
            this.conveniosBindingSource.DataMember = "Convenios";
            this.conveniosBindingSource.DataSource = this.parkingDataSet1;
            // 
            // conveniosTableAdapter
            // 
            this.conveniosTableAdapter.ClearBeforeFill = true;
            // 
            // Entrence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 270);
            this.Controls.Add(this.vehConv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.vehType);
            this.Controls.Add(this.vehTypeLabel);
            this.Controls.Add(this.matriculaLabel);
            this.Controls.Add(this.plate);
            this.Name = "Entrence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada";
            this.Load += new System.EventHandler(this.Entrence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tipoVehiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conveniosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox plate;
        private System.Windows.Forms.Label matriculaLabel;
        private System.Windows.Forms.Label vehTypeLabel;
        private System.Windows.Forms.ComboBox vehType;
        private ParkingDataSet1 parkingDataSet1;
        private System.Windows.Forms.BindingSource tipoVehiculoBindingSource;
        private ParkingDataSet1TableAdapters.TipoVehiculoTableAdapter tipoVehiculoTableAdapter;

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox vehConv;
        private System.Windows.Forms.BindingSource conveniosBindingSource;
        private ParkingDataSet1TableAdapters.ConveniosTableAdapter conveniosTableAdapter;
    }
}