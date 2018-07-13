namespace e_billing
{
    partial class Main
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.adentroModDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.str_descrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adentroModBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.parkingDataSet = new e_billing.ParkingDataSet();
            this.adentroDataGridView1 = new System.Windows.Forms.DataGridView();
            this.inButton = new System.Windows.Forms.Button();
            this.outButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fillBy6ToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillBy6ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.adentroModTableAdapter = new e_billing.ParkingDataSetTableAdapters.AdentroModTableAdapter();
            this.tableAdapterManager = new e_billing.ParkingDataSetTableAdapters.TableAdapterManager();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adentroModDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adentroModBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adentroDataGridView1)).BeginInit();
            this.fillBy6ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Location = new System.Drawing.Point(5, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(942, 508);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tab1
            // 
            this.tab1.AutoScroll = true;
            this.tab1.Controls.Add(this.adentroModDataGridView);
            this.tab1.Controls.Add(this.adentroDataGridView1);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Margin = new System.Windows.Forms.Padding(2);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(2);
            this.tab1.Size = new System.Drawing.Size(934, 482);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Adentro";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // adentroModDataGridView
            // 
            this.adentroModDataGridView.AutoGenerateColumns = false;
            this.adentroModDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adentroModDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.str_descrip,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn15,
            this.id});
            this.adentroModDataGridView.DataSource = this.adentroModBindingSource;
            this.adentroModDataGridView.Location = new System.Drawing.Point(4, 5);
            this.adentroModDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.adentroModDataGridView.Name = "adentroModDataGridView";
            this.adentroModDataGridView.RowTemplate.Height = 24;
            this.adentroModDataGridView.Size = new System.Drawing.Size(927, 474);
            this.adentroModDataGridView.TabIndex = 2;
            this.adentroModDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adentroModDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "correlativo_ticket";
            this.dataGridViewTextBoxColumn6.HeaderText = "Ticket";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "str_matricula";
            this.dataGridViewTextBoxColumn9.HeaderText = "Matricula";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "str_fecha_entrada";
            this.dataGridViewTextBoxColumn7.HeaderText = "Fecha E";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "str_hora_entrada";
            this.dataGridViewTextBoxColumn8.HeaderText = "Hora E";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // str_descrip
            // 
            this.str_descrip.DataPropertyName = "str_descrip";
            this.str_descrip.HeaderText = "Tipo Vehiculo";
            this.str_descrip.Name = "str_descrip";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "prepago";
            this.dataGridViewTextBoxColumn16.HeaderText = "Importe Prep.";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "fecha_venc_prepago";
            this.dataGridViewTextBoxColumn17.HeaderText = "F. Venc. Prep";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "hora_venc_prepago";
            this.dataGridViewTextBoxColumn18.HeaderText = "H. Venc. Prep";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "str_nombre_usuario";
            this.dataGridViewTextBoxColumn15.HeaderText = "Usuario";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "idAdentro";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // adentroModBindingSource
            // 
            this.adentroModBindingSource.DataMember = "AdentroMod";
            this.adentroModBindingSource.DataSource = this.parkingDataSet;
            // 
            // parkingDataSet
            // 
            this.parkingDataSet.DataSetName = "ParkingDataSet";
            this.parkingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adentroDataGridView1
            // 
            this.adentroDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adentroDataGridView1.Location = new System.Drawing.Point(4, 5);
            this.adentroDataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.adentroDataGridView1.Name = "adentroDataGridView1";
            this.adentroDataGridView1.RowTemplate.Height = 24;
            this.adentroDataGridView1.Size = new System.Drawing.Size(785, 474);
            this.adentroDataGridView1.TabIndex = 2;
            // 
            // inButton
            // 
            this.inButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inButton.Location = new System.Drawing.Point(5, 524);
            this.inButton.Margin = new System.Windows.Forms.Padding(2);
            this.inButton.Name = "inButton";
            this.inButton.Size = new System.Drawing.Size(92, 42);
            this.inButton.TabIndex = 2;
            this.inButton.Text = "» Entrada";
            this.inButton.UseVisualStyleBackColor = true;
            this.inButton.Click += new System.EventHandler(this.inButton_Click);
            // 
            // outButton
            // 
            this.outButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outButton.Location = new System.Drawing.Point(102, 524);
            this.outButton.Margin = new System.Windows.Forms.Padding(2);
            this.outButton.Name = "outButton";
            this.outButton.Size = new System.Drawing.Size(92, 42);
            this.outButton.TabIndex = 3;
            this.outButton.Text = "« Salida";
            this.outButton.UseVisualStyleBackColor = true;
            this.outButton.Click += new System.EventHandler(this.outButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fillBy6ToolStrip
            // 
            this.fillBy6ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillBy6ToolStripButton});
            this.fillBy6ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillBy6ToolStrip.Name = "fillBy6ToolStrip";
            this.fillBy6ToolStrip.Size = new System.Drawing.Size(950, 25);
            this.fillBy6ToolStrip.TabIndex = 4;
            this.fillBy6ToolStrip.Text = "fillBy6ToolStrip";
            this.fillBy6ToolStrip.Visible = false;
            // 
            // fillBy6ToolStripButton
            // 
            this.fillBy6ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillBy6ToolStripButton.Name = "fillBy6ToolStripButton";
            this.fillBy6ToolStripButton.Size = new System.Drawing.Size(45, 22);
            this.fillBy6ToolStripButton.Text = "FillBy6";
            this.fillBy6ToolStripButton.Click += new System.EventHandler(this.fillBy6ToolStripButton_Click);
            // 
            // adentroModTableAdapter
            // 
            this.adentroModTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AdentroTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = e_billing.ParkingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(198, 524);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Ticket";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.fillBy6ToolStrip);
            this.Controls.Add(this.outButton);
            this.Controls.Add(this.inButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adentroModDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adentroModBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adentroDataGridView1)).EndInit();
            this.fillBy6ToolStrip.ResumeLayout(false);
            this.fillBy6ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridView adentroDataGridView1;
        private System.Windows.Forms.BindingSource adentroModBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.Button inButton;
        private System.Windows.Forms.Button outButton;
        public System.Windows.Forms.DataGridView adentroModDataGridView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton fillBy6ToolStripButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn str_descrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        public ParkingDataSetTableAdapters.AdentroModTableAdapter adentroModTableAdapter;
        public ParkingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        public ParkingDataSet parkingDataSet;
        public System.Windows.Forms.ToolStrip fillBy6ToolStrip;
        private System.Windows.Forms.Button button1;
    }
}