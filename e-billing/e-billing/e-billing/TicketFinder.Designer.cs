namespace e_billing
{
    partial class TicketFinder
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
            this.parkingDataSet1 = new e_billing.ParkingDataSet1();
            this.conveniosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conveniosTableAdapter = new e_billing.ParkingDataSet1TableAdapters.ConveniosTableAdapter();
            this.conveniosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.vehConv = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCB = new System.Windows.Forms.TextBox();
            this.errorMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conveniosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conveniosBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // parkingDataSet1
            // 
            this.parkingDataSet1.DataSetName = "ParkingDataSet1";
            this.parkingDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // conveniosBindingSource1
            // 
            this.conveniosBindingSource1.DataMember = "Convenios";
            this.conveniosBindingSource1.DataSource = this.parkingDataSet1;
            // 
            // vehConv
            // 
            this.vehConv.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.conveniosBindingSource1, "id", true));
            this.vehConv.DataSource = this.conveniosBindingSource;
            this.vehConv.DisplayMember = "str_descrip";
            this.vehConv.DropDownWidth = 300;
            this.vehConv.FormattingEnabled = true;
            this.vehConv.ItemHeight = 13;
            this.vehConv.Location = new System.Drawing.Point(246, 64);
            this.vehConv.Name = "vehConv";
            this.vehConv.Size = new System.Drawing.Size(248, 21);
            this.vehConv.TabIndex = 2;
            this.vehConv.ValueMember = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 24);
            this.label2.TabIndex = 31;
            this.label2.Text = "Tipo de Convenio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(156, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 29);
            this.label1.TabIndex = 33;
            this.label1.Text = "Presente código de barras";
            // 
            // textBoxCB
            // 
            this.textBoxCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCB.Location = new System.Drawing.Point(161, 202);
            this.textBoxCB.Name = "textBoxCB";
            this.textBoxCB.Size = new System.Drawing.Size(309, 32);
            this.textBoxCB.TabIndex = 1;
            this.textBoxCB.TextChanged += new System.EventHandler(this.textBoxCB_TextChangedAsync);
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.ForeColor = System.Drawing.Color.Red;
            this.errorMessage.Location = new System.Drawing.Point(158, 176);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(135, 13);
            this.errorMessage.TabIndex = 34;
            this.errorMessage.Text = "El ticket no fue encontrado";
            this.errorMessage.Visible = false;
            // 
            // TicketFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 267);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCB);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.vehConv);
            this.Controls.Add(this.label2);
            this.Name = "TicketFinder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket";
            this.Load += new System.EventHandler(this.TicketFinder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conveniosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conveniosBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ParkingDataSet1 parkingDataSet1;
        private System.Windows.Forms.BindingSource conveniosBindingSource;
        private ParkingDataSet1TableAdapters.ConveniosTableAdapter conveniosTableAdapter;
        private System.Windows.Forms.BindingSource conveniosBindingSource1;
        private System.Windows.Forms.ComboBox vehConv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCB;
        private System.Windows.Forms.Label errorMessage;
    }
}