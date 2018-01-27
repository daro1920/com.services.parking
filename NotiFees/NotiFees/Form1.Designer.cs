namespace NotiFees
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
            this.components = new System.ComponentModel.Container();
            this.notificationsGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pARKINGDataSet = new NotiFees.PARKINGDataSet();
            this.notificacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notificacionesTableAdapter = new NotiFees.PARKINGDataSetTableAdapters.NotificacionesTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strmatriculaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strobservacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pARKINGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // notificationsGrid
            // 
            this.notificationsGrid.AllowUserToAddRows = false;
            this.notificationsGrid.AutoGenerateColumns = false;
            this.notificationsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.notificationsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.strmatriculaDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.resultidDataGridViewTextBoxColumn,
            this.strobservacionesDataGridViewTextBoxColumn});
            this.notificationsGrid.DataSource = this.notificacionesBindingSource;
            this.notificationsGrid.Location = new System.Drawing.Point(44, 100);
            this.notificationsGrid.Name = "notificationsGrid";
            this.notificationsGrid.ReadOnly = true;
            this.notificationsGrid.RowTemplate.Height = 24;
            this.notificationsGrid.Size = new System.Drawing.Size(1063, 322);
            this.notificationsGrid.TabIndex = 0;
            this.notificationsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.notificationsGrid_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matriculas pendientes";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pARKINGDataSet
            // 
            this.pARKINGDataSet.DataSetName = "PARKINGDataSet";
            this.pARKINGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // notificacionesBindingSource
            // 
            this.notificacionesBindingSource.DataMember = "Notificaciones";
            this.notificacionesBindingSource.DataSource = this.pARKINGDataSet;
            // 
            // notificacionesTableAdapter
            // 
            this.notificacionesTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // strmatriculaDataGridViewTextBoxColumn
            // 
            this.strmatriculaDataGridViewTextBoxColumn.DataPropertyName = "str_matricula";
            this.strmatriculaDataGridViewTextBoxColumn.HeaderText = "Matricula";
            this.strmatriculaDataGridViewTextBoxColumn.Name = "strmatriculaDataGridViewTextBoxColumn";
            this.strmatriculaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 200;
            // 
            // resultidDataGridViewTextBoxColumn
            // 
            this.resultidDataGridViewTextBoxColumn.DataPropertyName = "result_id";
            this.resultidDataGridViewTextBoxColumn.HeaderText = "result_id";
            this.resultidDataGridViewTextBoxColumn.Name = "resultidDataGridViewTextBoxColumn";
            this.resultidDataGridViewTextBoxColumn.ReadOnly = true;
            this.resultidDataGridViewTextBoxColumn.Visible = false;
            // 
            // strobservacionesDataGridViewTextBoxColumn
            // 
            this.strobservacionesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.strobservacionesDataGridViewTextBoxColumn.DataPropertyName = "str_observaciones";
            this.strobservacionesDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            this.strobservacionesDataGridViewTextBoxColumn.Name = "strobservacionesDataGridViewTextBoxColumn";
            this.strobservacionesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 455);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.notificationsGrid);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Name = "Form1";
            this.Text = "Notificaciones";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.notificationsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pARKINGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificacionesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.DataGridView notificationsGrid;
        private PARKINGDataSet pARKINGDataSet;
        private System.Windows.Forms.BindingSource notificacionesBindingSource;
        private PARKINGDataSetTableAdapters.NotificacionesTableAdapter notificacionesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn strmatriculaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn strobservacionesDataGridViewTextBoxColumn;
    }
}

