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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.addPrep = new System.Windows.Forms.Button();
            this.inButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.outButton = new System.Windows.Forms.Button();
            this.tabCaja = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.str_fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.str_hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe_calculado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correlativo_documento_emision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rollo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razon_social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_tipo_movimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.str_tipo_vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.str_convenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minutos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movimientosCajaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.movimientosCajaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.movimientoCajaDataSet = new e_billing.MovimientoCajaDataSet();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.fillBy6ToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillBy6ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.movimientosCajaTableAdapter = new e_billing.MovimientoCajaDataSetTableAdapters.MovimientosCajaTableAdapter();
            this.cerrado0ToolStrip = new System.Windows.Forms.ToolStrip();
            this.cerrado0ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.adentroModTableAdapter = new e_billing.ParkingDataSetTableAdapters.AdentroModTableAdapter();
            this.tableAdapterManager = new e_billing.ParkingDataSetTableAdapters.TableAdapterManager();
            this.movimientosCajaTableAdapter1 = new e_billing.ParkingDataSetTableAdapters.MovimientosCajaTableAdapter();
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adentroModDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adentroModBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet)).BeginInit();
            this.tabCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimientosCajaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimientosCajaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimientoCajaDataSet)).BeginInit();
            this.fillBy6ToolStrip.SuspendLayout();
            this.cerrado0ToolStrip.SuspendLayout();
            this.fillToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tabCaja);
            this.tabControl1.Location = new System.Drawing.Point(5, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(942, 613);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tab1
            // 
            this.tab1.AutoScroll = true;
            this.tab1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tab1.Controls.Add(this.adentroModDataGridView);
            this.tab1.Controls.Add(this.button3);
            this.tab1.Controls.Add(this.button2);
            this.tab1.Controls.Add(this.addPrep);
            this.tab1.Controls.Add(this.inButton);
            this.tab1.Controls.Add(this.button1);
            this.tab1.Controls.Add(this.outButton);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Margin = new System.Windows.Forms.Padding(2);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(2);
            this.tab1.Size = new System.Drawing.Size(934, 587);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Adentro";
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
            this.adentroModDataGridView.Location = new System.Drawing.Point(3, 4);
            this.adentroModDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.adentroModDataGridView.Name = "adentroModDataGridView";
            this.adentroModDataGridView.RowTemplate.Height = 24;
            this.adentroModDataGridView.Size = new System.Drawing.Size(927, 532);
            this.adentroModDataGridView.TabIndex = 9;
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
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(389, 540);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 42);
            this.button3.TabIndex = 8;
            this.button3.Text = "Facturar Servicios";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(838, 541);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 42);
            this.button2.TabIndex = 7;
            this.button2.Text = "Refrescar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // addPrep
            // 
            this.addPrep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPrep.Location = new System.Drawing.Point(293, 540);
            this.addPrep.Margin = new System.Windows.Forms.Padding(2);
            this.addPrep.Name = "addPrep";
            this.addPrep.Size = new System.Drawing.Size(92, 42);
            this.addPrep.TabIndex = 6;
            this.addPrep.Text = "Pasar a Prepago";
            this.addPrep.UseVisualStyleBackColor = true;
            this.addPrep.Click += new System.EventHandler(this.addPrep_Click);
            // 
            // inButton
            // 
            this.inButton.BackColor = System.Drawing.SystemColors.Control;
            this.inButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.inButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inButton.Location = new System.Drawing.Point(4, 541);
            this.inButton.Margin = new System.Windows.Forms.Padding(2);
            this.inButton.Name = "inButton";
            this.inButton.Size = new System.Drawing.Size(92, 42);
            this.inButton.TabIndex = 2;
            this.inButton.Text = "» Entrada";
            this.inButton.UseVisualStyleBackColor = false;
            this.inButton.Click += new System.EventHandler(this.inButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(197, 541);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Ticket (F10)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // outButton
            // 
            this.outButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outButton.Location = new System.Drawing.Point(101, 541);
            this.outButton.Margin = new System.Windows.Forms.Padding(2);
            this.outButton.Name = "outButton";
            this.outButton.Size = new System.Drawing.Size(92, 42);
            this.outButton.TabIndex = 3;
            this.outButton.Text = "« Salida";
            this.outButton.UseVisualStyleBackColor = true;
            this.outButton.Click += new System.EventHandler(this.outButton_Click);
            // 
            // tabCaja
            // 
            this.tabCaja.AutoScroll = true;
            this.tabCaja.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabCaja.Controls.Add(this.button5);
            this.tabCaja.Controls.Add(this.button4);
            this.tabCaja.Controls.Add(this.dataGridView1);
            this.tabCaja.Location = new System.Drawing.Point(4, 22);
            this.tabCaja.Name = "tabCaja";
            this.tabCaja.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaja.Size = new System.Drawing.Size(934, 587);
            this.tabCaja.TabIndex = 1;
            this.tabCaja.Text = "Caja";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(5, 540);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 42);
            this.button5.TabIndex = 9;
            this.button5.Text = "Cierre";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(837, 540);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 42);
            this.button4.TabIndex = 8;
            this.button4.Text = "Refrescar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.str_fecha,
            this.str_hora,
            this.importe,
            this.importe_calculado,
            this.correlativo_documento_emision,
            this.rollo,
            this.rut,
            this.razon_social,
            this.id_tipo_movimiento,
            this.id_usuario,
            this.dataGridViewTextBoxColumn2,
            this.str_tipo_vehiculo,
            this.str_convenio,
            this.minutos});
            this.dataGridView1.DataSource = this.movimientosCajaBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(927, 517);
            this.dataGridView1.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // str_fecha
            // 
            this.str_fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.str_fecha.DataPropertyName = "str_fecha";
            this.str_fecha.HeaderText = "Fecha";
            this.str_fecha.Name = "str_fecha";
            this.str_fecha.Width = 62;
            // 
            // str_hora
            // 
            this.str_hora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.str_hora.DataPropertyName = "str_hora";
            this.str_hora.HeaderText = "Hora";
            this.str_hora.Name = "str_hora";
            this.str_hora.Width = 55;
            // 
            // importe
            // 
            this.importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.importe.DataPropertyName = "importe";
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.Width = 67;
            // 
            // importe_calculado
            // 
            this.importe_calculado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.importe_calculado.DataPropertyName = "importe_calculado";
            this.importe_calculado.HeaderText = "Importe calculado";
            this.importe_calculado.Name = "importe_calculado";
            this.importe_calculado.Width = 106;
            // 
            // correlativo_documento_emision
            // 
            this.correlativo_documento_emision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.correlativo_documento_emision.DataPropertyName = "correlativo_documento_emision";
            this.correlativo_documento_emision.HeaderText = "Nro. Doc";
            this.correlativo_documento_emision.Name = "correlativo_documento_emision";
            this.correlativo_documento_emision.Width = 69;
            // 
            // rollo
            // 
            this.rollo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.rollo.DataPropertyName = "rollo";
            this.rollo.HeaderText = "Rollo";
            this.rollo.Name = "rollo";
            this.rollo.Width = 56;
            // 
            // rut
            // 
            this.rut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.rut.DataPropertyName = "rut";
            this.rut.HeaderText = "RUT";
            this.rut.Name = "rut";
            this.rut.Width = 55;
            // 
            // razon_social
            // 
            this.razon_social.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.razon_social.DataPropertyName = "razon_social";
            this.razon_social.HeaderText = "Razon Social";
            this.razon_social.Name = "razon_social";
            this.razon_social.Width = 87;
            // 
            // id_tipo_movimiento
            // 
            this.id_tipo_movimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.id_tipo_movimiento.DataPropertyName = "id_tipo_movimiento";
            this.id_tipo_movimiento.HeaderText = "Tipo Mov.";
            this.id_tipo_movimiento.Name = "id_tipo_movimiento";
            this.id_tipo_movimiento.Width = 74;
            // 
            // id_usuario
            // 
            this.id_usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.id_usuario.DataPropertyName = "id_usuario";
            this.id_usuario.HeaderText = "Usuario";
            this.id_usuario.Name = "id_usuario";
            this.id_usuario.Width = 68;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "correlativo_ticket";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ticket";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 62;
            // 
            // str_tipo_vehiculo
            // 
            this.str_tipo_vehiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.str_tipo_vehiculo.DataPropertyName = "str_tipo_vehiculo";
            this.str_tipo_vehiculo.HeaderText = "Tipo Vehiculo";
            this.str_tipo_vehiculo.Name = "str_tipo_vehiculo";
            this.str_tipo_vehiculo.Width = 89;
            // 
            // str_convenio
            // 
            this.str_convenio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.str_convenio.DataPropertyName = "str_convenio";
            this.str_convenio.HeaderText = "Convenio";
            this.str_convenio.Name = "str_convenio";
            this.str_convenio.Width = 77;
            // 
            // minutos
            // 
            this.minutos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.minutos.DataPropertyName = "minutos";
            this.minutos.HeaderText = "Min.";
            this.minutos.Name = "minutos";
            this.minutos.Width = 52;
            // 
            // movimientosCajaBindingSource1
            // 
            this.movimientosCajaBindingSource1.DataMember = "MovimientosCaja";
            this.movimientosCajaBindingSource1.DataSource = this.parkingDataSet;
            // 
            // movimientosCajaBindingSource
            // 
            this.movimientosCajaBindingSource.DataMember = "MovimientosCaja";
            this.movimientosCajaBindingSource.DataSource = this.movimientoCajaDataSet;
            // 
            // movimientoCajaDataSet
            // 
            this.movimientoCajaDataSet.DataSetName = "MovimientoCajaDataSet";
            this.movimientoCajaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // 
            // movimientosCajaTableAdapter
            // 
            this.movimientosCajaTableAdapter.ClearBeforeFill = true;
            // 
            // cerrado0ToolStrip
            // 
            this.cerrado0ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrado0ToolStripButton});
            this.cerrado0ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.cerrado0ToolStrip.Name = "cerrado0ToolStrip";
            this.cerrado0ToolStrip.Size = new System.Drawing.Size(950, 25);
            this.cerrado0ToolStrip.TabIndex = 5;
            this.cerrado0ToolStrip.Text = "cerrado0ToolStrip";
            this.cerrado0ToolStrip.Visible = false;
            // 
            // cerrado0ToolStripButton
            // 
            this.cerrado0ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cerrado0ToolStripButton.Name = "cerrado0ToolStripButton";
            this.cerrado0ToolStripButton.Size = new System.Drawing.Size(57, 22);
            this.cerrado0ToolStripButton.Text = "cerrado0";
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
            this.tableAdapterManager.MovimientosCajaTableAdapter = null;
            this.tableAdapterManager.ServiciosTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = e_billing.ParkingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // movimientosCajaTableAdapter1
            // 
            this.movimientosCajaTableAdapter1.ClearBeforeFill = true;
            // 
            // fillToolStrip
            // 
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(950, 25);
            this.fillToolStrip.TabIndex = 6;
            this.fillToolStrip.Text = "fillToolStrip";
            this.fillToolStrip.Visible = false;
            // 
            // fillToolStripButton
            // 
            this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillToolStripButton.Name = "fillToolStripButton";
            this.fillToolStripButton.Size = new System.Drawing.Size(26, 22);
            this.fillToolStripButton.Text = "Fill";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 617);
            this.Controls.Add(this.fillToolStrip);
            this.Controls.Add(this.cerrado0ToolStrip);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.fillBy6ToolStrip);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e parking";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adentroModDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adentroModBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet)).EndInit();
            this.tabCaja.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimientosCajaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimientosCajaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimientoCajaDataSet)).EndInit();
            this.fillBy6ToolStrip.ResumeLayout(false);
            this.fillBy6ToolStrip.PerformLayout();
            this.cerrado0ToolStrip.ResumeLayout(false);
            this.cerrado0ToolStrip.PerformLayout();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.BindingSource adentroModBindingSource;
        private System.Windows.Forms.Button inButton;
        private System.Windows.Forms.Button outButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton fillBy6ToolStripButton;
        public ParkingDataSetTableAdapters.AdentroModTableAdapter adentroModTableAdapter;
        public ParkingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        public ParkingDataSet parkingDataSet;
        public System.Windows.Forms.ToolStrip fillBy6ToolStrip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addPrep;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabCaja;
        public System.Windows.Forms.DataGridView dataGridView1;
        private MovimientoCajaDataSet movimientoCajaDataSet;
        private System.Windows.Forms.BindingSource movimientosCajaBindingSource;
        private MovimientoCajaDataSetTableAdapters.MovimientosCajaTableAdapter movimientosCajaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn str_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn str_hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe_calculado;
        private System.Windows.Forms.DataGridViewTextBoxColumn correlativo_documento_emision;
        private System.Windows.Forms.DataGridViewTextBoxColumn rollo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rut;
        private System.Windows.Forms.DataGridViewTextBoxColumn razon_social;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_tipo_movimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn str_tipo_vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn str_convenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn minutos;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.DataGridView adentroModDataGridView;
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
        private System.Windows.Forms.ToolStripButton cerrado0ToolStripButton;
        public System.Windows.Forms.ToolStrip cerrado0ToolStrip;
        private System.Windows.Forms.BindingSource movimientosCajaBindingSource1;
        private ParkingDataSetTableAdapters.MovimientosCajaTableAdapter movimientosCajaTableAdapter1;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        public System.Windows.Forms.ToolStrip fillToolStrip;
    }
}