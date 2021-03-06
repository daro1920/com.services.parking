﻿namespace e_billing
{
    partial class Ticket
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
            this.minutes = new System.Windows.Forms.TextBox();
            this.charge = new System.Windows.Forms.TextBox();
            this.rate = new System.Windows.Forms.TextBox();
            this.key = new System.Windows.Forms.TextBox();
            this.change = new System.Windows.Forms.TextBox();
            this.received = new System.Windows.Forms.TextBox();
            this.rsocial = new System.Windows.Forms.TextBox();
            this.rut = new System.Windows.Forms.TextBox();
            this.matricula = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ticketLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toPayLabel = new System.Windows.Forms.Label();
            this.AcceptB = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.totalCharge = new System.Windows.Forms.TextBox();
            this.vehicleType = new System.Windows.Forms.TextBox();
            this.inHour = new System.Windows.Forms.TextBox();
            this.inDate = new System.Windows.Forms.TextBox();
            this.impTotal = new System.Windows.Forms.TextBox();
            this.rowIndex = new System.Windows.Forms.TextBox();
            this.idAdent = new System.Windows.Forms.TextBox();
            this.ticketId = new System.Windows.Forms.TextBox();
            this.isPrep = new System.Windows.Forms.TextBox();
            this.isPrepDays = new System.Windows.Forms.TextBox();
            this.parkingDataSet1 = new e_billing.ParkingDataSet1();
            this.conveniosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conveniosTableAdapter = new e_billing.ParkingDataSet1TableAdapters.ConveniosTableAdapter();
            this.obsT = new System.Windows.Forms.Label();
            this.obsInput = new System.Windows.Forms.TextBox();
            this.conv = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conveniosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // plate
            // 
            this.plate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.plate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.plate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.plate.Location = new System.Drawing.Point(125, 62);
            this.plate.Margin = new System.Windows.Forms.Padding(2);
            this.plate.Multiline = true;
            this.plate.Name = "plate";
            this.plate.ReadOnly = true;
            this.plate.Size = new System.Drawing.Size(184, 25);
            this.plate.TabIndex = 0;
            // 
            // minutes
            // 
            this.minutes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.minutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.minutes.ForeColor = System.Drawing.SystemColors.WindowText;
            this.minutes.Location = new System.Drawing.Point(125, 90);
            this.minutes.Margin = new System.Windows.Forms.Padding(2);
            this.minutes.Multiline = true;
            this.minutes.Name = "minutes";
            this.minutes.ReadOnly = true;
            this.minutes.Size = new System.Drawing.Size(184, 25);
            this.minutes.TabIndex = 1;
            // 
            // charge
            // 
            this.charge.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.charge.Location = new System.Drawing.Point(125, 150);
            this.charge.Margin = new System.Windows.Forms.Padding(2);
            this.charge.Multiline = true;
            this.charge.Name = "charge";
            this.charge.Size = new System.Drawing.Size(184, 25);
            this.charge.TabIndex = 3;
            this.charge.TextChanged += new System.EventHandler(this.charge_TextChanged);
            // 
            // rate
            // 
            this.rate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.rate.ForeColor = System.Drawing.Color.Black;
            this.rate.Location = new System.Drawing.Point(125, 120);
            this.rate.Margin = new System.Windows.Forms.Padding(2);
            this.rate.Multiline = true;
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            this.rate.Size = new System.Drawing.Size(184, 26);
            this.rate.TabIndex = 2;
            // 
            // key
            // 
            this.key.BackColor = System.Drawing.Color.WhiteSmoke;
            this.key.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key.ForeColor = System.Drawing.SystemColors.WindowText;
            this.key.Location = new System.Drawing.Point(125, 237);
            this.key.Margin = new System.Windows.Forms.Padding(2);
            this.key.Multiline = true;
            this.key.Name = "key";
            this.key.ReadOnly = true;
            this.key.Size = new System.Drawing.Size(184, 25);
            this.key.TabIndex = 6;
            // 
            // change
            // 
            this.change.BackColor = System.Drawing.Color.WhiteSmoke;
            this.change.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.change.ForeColor = System.Drawing.SystemColors.WindowText;
            this.change.Location = new System.Drawing.Point(125, 207);
            this.change.Margin = new System.Windows.Forms.Padding(2);
            this.change.Multiline = true;
            this.change.Name = "change";
            this.change.ReadOnly = true;
            this.change.Size = new System.Drawing.Size(184, 25);
            this.change.TabIndex = 5;
            // 
            // received
            // 
            this.received.BackColor = System.Drawing.Color.White;
            this.received.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.received.Location = new System.Drawing.Point(125, 178);
            this.received.Margin = new System.Windows.Forms.Padding(2);
            this.received.Multiline = true;
            this.received.Name = "received";
            this.received.Size = new System.Drawing.Size(184, 25);
            this.received.TabIndex = 4;
            this.received.TextChanged += new System.EventHandler(this.received_TextChanged);
            // 
            // rsocial
            // 
            this.rsocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.rsocial.Location = new System.Drawing.Point(123, 345);
            this.rsocial.Margin = new System.Windows.Forms.Padding(2);
            this.rsocial.Multiline = true;
            this.rsocial.Name = "rsocial";
            this.rsocial.Size = new System.Drawing.Size(354, 25);
            this.rsocial.TabIndex = 9;
            // 
            // rut
            // 
            this.rut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.rut.Location = new System.Drawing.Point(123, 316);
            this.rut.Margin = new System.Windows.Forms.Padding(2);
            this.rut.Multiline = true;
            this.rut.Name = "rut";
            this.rut.Size = new System.Drawing.Size(354, 25);
            this.rut.TabIndex = 8;
            // 
            // matricula
            // 
            this.matricula.AutoSize = true;
            this.matricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matricula.Location = new System.Drawing.Point(9, 62);
            this.matricula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.matricula.Name = "matricula";
            this.matricula.Size = new System.Drawing.Size(100, 24);
            this.matricula.TabIndex = 10;
            this.matricula.Text = "Matricula:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Minutos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tarifa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cobrado $:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 179);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Recibido $:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 208);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Vuelto $:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 237);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 24);
            this.label7.TabIndex = 17;
            this.label7.Text = "Llave:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 316);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "Rut:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 346);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 24);
            this.label10.TabIndex = 20;
            this.label10.Text = "R. Social:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ticketLabel);
            this.panel1.Location = new System.Drawing.Point(356, 83);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 82);
            this.panel1.TabIndex = 21;
            // 
            // ticketLabel
            // 
            this.ticketLabel.AutoSize = true;
            this.ticketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketLabel.Location = new System.Drawing.Point(43, 28);
            this.ticketLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ticketLabel.Name = "ticketLabel";
            this.ticketLabel.Size = new System.Drawing.Size(109, 36);
            this.ticketLabel.TabIndex = 0;
            this.ticketLabel.Text = "Ticket:";
            this.ticketLabel.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toPayLabel);
            this.panel2.Location = new System.Drawing.Point(356, 171);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 82);
            this.panel2.TabIndex = 22;
            // 
            // toPayLabel
            // 
            this.toPayLabel.AutoSize = true;
            this.toPayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toPayLabel.Location = new System.Drawing.Point(43, 13);
            this.toPayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toPayLabel.Name = "toPayLabel";
            this.toPayLabel.Size = new System.Drawing.Size(139, 36);
            this.toPayLabel.TabIndex = 1;
            this.toPayLabel.Text = "A Pagar:";
            this.toPayLabel.Visible = false;
            // 
            // AcceptB
            // 
            this.AcceptB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcceptB.ForeColor = System.Drawing.Color.DarkGreen;
            this.AcceptB.Location = new System.Drawing.Point(494, 316);
            this.AcceptB.Margin = new System.Windows.Forms.Padding(2);
            this.AcceptB.Name = "AcceptB";
            this.AcceptB.Size = new System.Drawing.Size(95, 54);
            this.AcceptB.TabIndex = 24;
            this.AcceptB.Text = "✓ Aceptar";
            this.AcceptB.UseVisualStyleBackColor = true;
            this.AcceptB.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(594, 316);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 54);
            this.button3.TabIndex = 25;
            this.button3.Text = "x Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // totalCharge
            // 
            this.totalCharge.Enabled = false;
            this.totalCharge.Location = new System.Drawing.Point(303, 11);
            this.totalCharge.Margin = new System.Windows.Forms.Padding(2);
            this.totalCharge.Name = "totalCharge";
            this.totalCharge.Size = new System.Drawing.Size(32, 20);
            this.totalCharge.TabIndex = 29;
            this.totalCharge.Visible = false;
            // 
            // vehicleType
            // 
            this.vehicleType.Enabled = false;
            this.vehicleType.Location = new System.Drawing.Point(125, 11);
            this.vehicleType.Margin = new System.Windows.Forms.Padding(2);
            this.vehicleType.Name = "vehicleType";
            this.vehicleType.Size = new System.Drawing.Size(32, 20);
            this.vehicleType.TabIndex = 28;
            this.vehicleType.Visible = false;
            // 
            // inHour
            // 
            this.inHour.Enabled = false;
            this.inHour.Location = new System.Drawing.Point(339, 11);
            this.inHour.Margin = new System.Windows.Forms.Padding(2);
            this.inHour.Name = "inHour";
            this.inHour.Size = new System.Drawing.Size(32, 20);
            this.inHour.TabIndex = 31;
            this.inHour.Visible = false;
            // 
            // inDate
            // 
            this.inDate.Enabled = false;
            this.inDate.Location = new System.Drawing.Point(161, 11);
            this.inDate.Margin = new System.Windows.Forms.Padding(2);
            this.inDate.Name = "inDate";
            this.inDate.Size = new System.Drawing.Size(32, 20);
            this.inDate.TabIndex = 30;
            this.inDate.Visible = false;
            // 
            // impTotal
            // 
            this.impTotal.Enabled = false;
            this.impTotal.Location = new System.Drawing.Point(197, 11);
            this.impTotal.Margin = new System.Windows.Forms.Padding(2);
            this.impTotal.Name = "impTotal";
            this.impTotal.Size = new System.Drawing.Size(32, 20);
            this.impTotal.TabIndex = 33;
            this.impTotal.Visible = false;
            // 
            // rowIndex
            // 
            this.rowIndex.Enabled = false;
            this.rowIndex.Location = new System.Drawing.Point(375, 11);
            this.rowIndex.Margin = new System.Windows.Forms.Padding(2);
            this.rowIndex.Name = "rowIndex";
            this.rowIndex.Size = new System.Drawing.Size(32, 20);
            this.rowIndex.TabIndex = 34;
            this.rowIndex.Visible = false;
            // 
            // idAdent
            // 
            this.idAdent.Enabled = false;
            this.idAdent.Location = new System.Drawing.Point(411, 11);
            this.idAdent.Margin = new System.Windows.Forms.Padding(2);
            this.idAdent.Name = "idAdent";
            this.idAdent.Size = new System.Drawing.Size(32, 20);
            this.idAdent.TabIndex = 35;
            this.idAdent.Visible = false;
            // 
            // ticketId
            // 
            this.ticketId.Enabled = false;
            this.ticketId.Location = new System.Drawing.Point(233, 11);
            this.ticketId.Margin = new System.Windows.Forms.Padding(2);
            this.ticketId.Name = "ticketId";
            this.ticketId.Size = new System.Drawing.Size(32, 20);
            this.ticketId.TabIndex = 36;
            this.ticketId.Visible = false;
            // 
            // isPrep
            // 
            this.isPrep.Enabled = false;
            this.isPrep.Location = new System.Drawing.Point(269, 11);
            this.isPrep.Margin = new System.Windows.Forms.Padding(2);
            this.isPrep.Name = "isPrep";
            this.isPrep.Size = new System.Drawing.Size(32, 20);
            this.isPrep.TabIndex = 37;
            this.isPrep.Visible = false;
            // 
            // isPrepDays
            // 
            this.isPrepDays.Enabled = false;
            this.isPrepDays.Location = new System.Drawing.Point(447, 11);
            this.isPrepDays.Margin = new System.Windows.Forms.Padding(2);
            this.isPrepDays.Name = "isPrepDays";
            this.isPrepDays.Size = new System.Drawing.Size(32, 20);
            this.isPrepDays.TabIndex = 38;
            this.isPrepDays.Visible = false;
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
            // obsT
            // 
            this.obsT.AutoSize = true;
            this.obsT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.obsT.Location = new System.Drawing.Point(9, 275);
            this.obsT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.obsT.Name = "obsT";
            this.obsT.Size = new System.Drawing.Size(156, 24);
            this.obsT.TabIndex = 40;
            this.obsT.Text = "Observaciones:";
            this.obsT.Visible = false;
            // 
            // obsInput
            // 
            this.obsInput.BackColor = System.Drawing.Color.White;
            this.obsInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.obsInput.Location = new System.Drawing.Point(169, 275);
            this.obsInput.Margin = new System.Windows.Forms.Padding(2);
            this.obsInput.Multiline = true;
            this.obsInput.Name = "obsInput";
            this.obsInput.Size = new System.Drawing.Size(519, 25);
            this.obsInput.TabIndex = 41;
            this.obsInput.Visible = false;
            this.obsInput.TextChanged += new System.EventHandler(this.obsInput_TextChanged);
            // 
            // conv
            // 
            this.conv.Enabled = false;
            this.conv.Location = new System.Drawing.Point(483, 11);
            this.conv.Margin = new System.Windows.Forms.Padding(2);
            this.conv.Name = "conv";
            this.conv.Size = new System.Drawing.Size(32, 20);
            this.conv.TabIndex = 42;
            this.conv.Visible = false;
            // 
            // Ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 392);
            this.Controls.Add(this.conv);
            this.Controls.Add(this.obsInput);
            this.Controls.Add(this.obsT);
            this.Controls.Add(this.isPrepDays);
            this.Controls.Add(this.isPrep);
            this.Controls.Add(this.ticketId);
            this.Controls.Add(this.idAdent);
            this.Controls.Add(this.rowIndex);
            this.Controls.Add(this.impTotal);
            this.Controls.Add(this.inHour);
            this.Controls.Add(this.inDate);
            this.Controls.Add(this.totalCharge);
            this.Controls.Add(this.vehicleType);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.AcceptB);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.matricula);
            this.Controls.Add(this.rsocial);
            this.Controls.Add(this.rut);
            this.Controls.Add(this.key);
            this.Controls.Add(this.change);
            this.Controls.Add(this.received);
            this.Controls.Add(this.charge);
            this.Controls.Add(this.rate);
            this.Controls.Add(this.minutes);
            this.Controls.Add(this.plate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ticket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket";
            this.Load += new System.EventHandler(this.Ticket_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conveniosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label matricula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button AcceptB;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.TextBox plate;
        public System.Windows.Forms.TextBox minutes;
        public System.Windows.Forms.TextBox charge;
        public System.Windows.Forms.TextBox rate;
        public System.Windows.Forms.TextBox key;
        public System.Windows.Forms.TextBox change;
        public System.Windows.Forms.TextBox received;
        public System.Windows.Forms.TextBox rsocial;
        public System.Windows.Forms.TextBox rut;
        public System.Windows.Forms.Label ticketLabel;
        public System.Windows.Forms.Label toPayLabel;
        public System.Windows.Forms.TextBox totalCharge;
        public System.Windows.Forms.TextBox vehicleType;
        public System.Windows.Forms.TextBox inHour;
        public System.Windows.Forms.TextBox inDate;
        public System.Windows.Forms.TextBox impTotal;
        public System.Windows.Forms.TextBox rowIndex;
        public System.Windows.Forms.TextBox idAdent;
        public System.Windows.Forms.TextBox ticketId;
        public System.Windows.Forms.TextBox isPrep;
        public System.Windows.Forms.TextBox isPrepDays;
        private ParkingDataSet1 parkingDataSet1;
        private System.Windows.Forms.BindingSource conveniosBindingSource;
        private ParkingDataSet1TableAdapters.ConveniosTableAdapter conveniosTableAdapter;
        private System.Windows.Forms.Label obsT;
        public System.Windows.Forms.TextBox obsInput;
        public System.Windows.Forms.TextBox conv;
    }
}