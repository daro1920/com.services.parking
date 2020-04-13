using e_billing.parking;
using e_billing.parking.dao;
using e_billing.parking.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;

namespace e_billing
{
    public partial class Main : Form
    {
        private TarifaDAo rateDao = new TarifaDAo();
        private TipoVehiculoDAO tvDAO = new TipoVehiculoDAO();
        private EstadoLlaveroDAO elDAO = new EstadoLlaveroDAO();
        private AdentroDAO adeDAO = new AdentroDAO();
        private ConfigDAO conDAO = new ConfigDAO();
        private VehiculosRegistradosDAO vehRegDao = new VehiculosRegistradosDAO();
        private RefCierreCajaDAO refCCDAO = new RefCierreCajaDAO();
        private MovimientosCajaDAO movCajaDAO = new MovimientosCajaDAO();
        private MovimientosCaja movCaja = new MovimientosCaja();
        private InvoicyClient client = new InvoicyClient();
        private MovimientoParking movParking = new MovimientoParking();
        private VehiculosPensionDAO vehPenDao = new VehiculosPensionDAO();


        public Main()
        {
            InitializeComponent();
        }

        private void adentroBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.parkingDataSet);

        }

        private void adentroModDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            salida(rowIndex,-1);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parkingDataSet.Mensuales' table. You can move, or remove it, as needed.
            this.MensualesTableAdapter.mensuales(this.parkingDataSet.Mensuales);
            // TODO: This line of code loads data into the 'parkingDataSet.MovimientosCaja' table. You can move, or remove it, as needed.
            this.movimientosCajaTableAdapter1.Fill(this.parkingDataSet.MovimientosCaja);
            // TODO: This line of code loads data into the 'movimientoCajaDataSet.MovimientosCaja' table. You can move, or remove it, as needed.
            this.movimientosCajaTableAdapter.Fill(this.movimientoCajaDataSet.MovimientosCaja);
            // TODO: This line of code loads data into the 'parkingDataSet.AdentroMod' table. You can move, or remove it, as needed.
            this.adentroModTableAdapter.Fill(this.parkingDataSet.AdentroMod);

            refreshTotals();
        }

        

        private void inButton_Click(object sender, EventArgs e)
        {
            Entrence entrence = new Entrence(this);
            entrence.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F10)
            {
                TicketFinder ticketf = new TicketFinder(adentroModDataGridView, this);
                ticketf.Show();
                return true;
            }
            return false;
        }

        private void outButton_Click(object sender, EventArgs e)
        {
            int rowIndex = adentroModDataGridView.CurrentCell.RowIndex;
            salida(rowIndex,-1);
            
        }
        public void salida(int rowIndex,int conv)
        {
            if (rowIndex >= 0)
            {

                DataGridViewRow row = adentroModDataGridView.Rows[rowIndex];

                int adentroId = Int32.Parse(row.Cells[9].Value.ToString());

                Adentro aden = adeDAO.getAdentro(adentroId);

                Boolean isPrep = aden.prepago.Equals("SI");
                int convId = conv == -1 ? aden.id_convenio: conv;

                int ticketId = Int32.Parse(row.Cells[0].Value.ToString());
                string plate = row.Cells[1].Value.ToString();

                string dateS = row.Cells[2].Value.ToString();
                string hourS = row.Cells[3].Value.ToString();

                string dateIn = Program.getFormatDate(dateS, hourS);
                string dateInPrep = isPrep ? Program.getFormatDate(row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString()) : "";

                string vehicleType = row.Cells[4].Value.ToString();
                int vehicleId = tvDAO.getVehicleID(vehicleType);

                DateTime dateInTime = isPrep ? DateTime.ParseExact(dateInPrep, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture): DateTime.ParseExact(dateIn, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);

                DateTime today = DateTime.Now;
                int minutes = Convert.ToInt32((today - dateInTime).TotalMinutes);
                int days = Convert.ToInt32((today - dateInTime).TotalDays);
                
                Tarifa rate = getRate(vehicleId, minutes, convId, dateInTime); 
                EstadoLlavero estLl = elDAO.getKeyState(plate,ticketId);

                showTicketForm(Convert.ToInt32(rate.importe), plate,minutes, rate.str_tarifa,estLl,ticketId, vehicleId,row, adentroId, ticketId, isPrep,false, convId);
                
            }
        }

        public void showTicketForm(int importe, string plate, int minutes, string str_tarifa, 
            EstadoLlavero estLl, int ticketId, int vehicleId, DataGridViewRow row, 
            int adentroId, int ticketId2, bool isPrep, bool isPrepDays,int convId)
        {

            Ticket ticket = new Ticket(this);

            VehiculosRegistrado vehReg = vehRegDao.getRegVehicle(plate);
            ticket.rut.Text = vehReg != null && !"".Equals(vehReg.rut) ? vehReg.rut : "";

            ticket.plate.Text = plate;

            ticket.minutes.Text = minutes <= 0 ? "0" : minutes.ToString();
            ticket.rate.Text = str_tarifa == null ? "Prepago" : str_tarifa;
            ticket.charge.Text = importe.ToString();
            ticket.received.Text = "";
            ticket.change.Text = "0";

            ticket.key.Text = estLl != null ? estLl.nro_llave : "";

            ticket.toPayLabel.Text = "A Pagar: $" + importe;
            ticket.ticketLabel.Text = "Ticket: " + ticketId;
            ticket.toPayLabel.Visible = true;
            ticket.ticketLabel.Visible = true;

            ticket.vehicleType.Text = vehicleId.ToString();
            ticket.totalCharge.Text = importe.ToString();
            ticket.inDate.Text = row.Cells[2].Value.ToString();
            ticket.inHour.Text = row.Cells[3].Value.ToString();
            ticket.impTotal.Text = importe.ToString();
            ticket.rowIndex.Text = row.Index.ToString();
            ticket.idAdent.Text = adentroId.ToString();
            ticket.ticketId.Text = ticketId.ToString();
            // isPrep could be SI, but the time could be expired
            ticket.isPrep.Text = minutes <= 0 ? isPrep.ToString() : "false";
            ticket.isPrepDays.Text = isPrepDays.ToString();
            ticket.conv.Text = convId.ToString();

            ticket.Show();
        }

        private Tarifa getRate(int vehicleId, int minutes, int conv , DateTime dateInTime)
        {
            Tarifa rate = rateDao.getRate(vehicleId, minutes, conv);
            Configu config = conDAO.getConfig();

            DateTime now = DateTime.Now;
            DateTime nightHourBegins = DateTime.ParseExact(config.hora_fin_diurno, "HH:mm", CultureInfo.InvariantCulture);
            DateTime nightHourEnds = DateTime.ParseExact(config.hora_comienzo_diurno, "HH:mm", CultureInfo.InvariantCulture).AddDays(1);
            
            Boolean sameDay = Convert.ToInt32((dateInTime - nightHourBegins).TotalDays) == 0;
            Boolean yestearday = Convert.ToInt32((nightHourBegins - dateInTime).TotalDays) == 1;

            Boolean afterNightStart = dateInTime.Hour >= nightHourBegins.Hour;
            Boolean beforeNightEnds = (now.Hour < nightHourEnds.Hour);

            if ( (sameDay || yestearday) &&
                (afterNightStart && beforeNightEnds) )
            {
                Tarifa nightRate = rateDao.getRateByStr_Tarifa(vehicleId, "Nocturna");
                rate = rate.importe >= nightRate.importe ? nightRate : rate;
            }
            

            return rate;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int rowCount = adentroModDataGridView.RowCount;
            int adeCount = adeDAO.getTotalRecord();

            try
            {
                if (rowCount != adeCount)
                {
                    Program.log.Debug(DateTime.Now.ToString() + "Recargando datos Adentro");
                    refreshGrid();
                }

            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() + "timer1_Tick" + ex);
            }

        }
        public void refreshGrid()
        {
            this.adentroModTableAdapter.Fill(this.parkingDataSet.AdentroMod);

        }

        public void refreshGridCaja()
        {
            this.movimientosCajaTableAdapter1.Fill(this.parkingDataSet.MovimientosCaja);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TicketFinder  ticketf = new TicketFinder(adentroModDataGridView,this);
            ticketf.Show();
        }

        private void addPrep_Click(object sender, EventArgs e)
        {
            int rowIndex = adentroModDataGridView.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = adentroModDataGridView.Rows[rowIndex];
                PrepDays prepDays = new PrepDays(this, row);
                prepDays.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Services services = new Services(adentroModDataGridView, this);
            services.Show();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            refreshGridCaja();
            refreshTotals();
        }

        private void refreshTotals()
        {
            int i = 0;
            decimal totalCaja = 0;
            List<MovimientosCaja> movsCaja = movCajaDAO.getListMovCaja();
            foreach (MovimientosCaja movCaja in movsCaja)
            {
                totalCaja = movCaja.importe + totalCaja;
                i++;
            }

            this.cantMovLabel.Text = "CANTIDAD DE MOVIMIENTOS: "+i;
            this.totCajLabel.Text = "TOTAL CAJA: " + totalCaja;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Referencia_Cierre_Caja refCC = new Referencia_Cierre_Caja();
            decimal importeCierre = movCajaDAO.getSumImporteMovCaja();

            List<MovimientosCaja> movsCaja = movCajaDAO.getListMovCaja();


            refCC.str_fecha = Program.getFormatedDate();
            refCC.str_hora = Program.getFormatedHour();
            User user = Login.logUser;
            refCC.observaciones ="ID del usuario:"+ user.ID.ToString()+". Nombre Usuario: "+user.NOMBRE+" "+user.APELLIDO;

            refCCDAO.addRefCC(ref refCC);

            movCajaDAO.updateMovCaja(refCC.id);

            MovimientosCaja movCaja = new MovimientosCaja();

            movCaja.str_fecha = Program.getFormatedDate();
            movCaja.str_hora = Program.getFormatedHour();
            movCaja.importe = importeCierre;
            movCaja.id_tipo_movimiento = 9;
            movCaja.str_eliminado = "NO";
            movCaja.id_usuario = user.ID;

            movCajaDAO.addMovCaja(ref movCaja);

            Program.generateClose(movsCaja);

            refreshGridCaja();
        }

        private void addMov_Click(object sender, EventArgs e)
        {
            AddMove addMoveWin = new AddMove();
            addMoveWin.Show();
        }

        private void mensualesToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.MensualesTableAdapter.mensuales(this.parkingDataSet.Mensuales);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

            int rowIndex = mensualesGridView.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {

                DataGridViewRow row = mensualesGridView.Rows[rowIndex];

                string plate = row.Cells[0].Value.ToString();
                string str_marca_modelo = row.Cells[1].Value.ToString();
                string nombre_cliente = row.Cells[2].Value.ToString();
                int amount = Convert.ToInt32(row.Cells[3].Value.ToString());
                string ultimo_mes_pago = row.Cells[4].Value.ToString();
                int vehicleID = Convert.ToInt32(row.Cells[5].Value.ToString());
                string month = Program.sumMonthDate(ultimo_mes_pago).Substring(4, 2);
                string concepto = "Estacionamiento mensual: (Mes" + month + ") - (Mat. " + plate + ")" + nombre_cliente + " ";

                VehiculosRegistrado vehReg = vehRegDao.getRegVehicle(plate);

                string rut = vehReg != null && !"".Equals(vehReg.rut) ? vehReg.rut : "";
                string rsocialS = vehReg.razon_social;

                double impNoIva = Math.Round((amount / 1.22));
                double impIva = (impNoIva * 0.22);

                string empCod = ConfigurationManager.AppSettings["EMP_CODE"].ToString();
                string empPK = ConfigurationManager.AppSettings["EMP_PK"].ToString();
                string empCA = ConfigurationManager.AppSettings["EMP_CA"].ToString();


                generateMovCaja(amount, rut, rsocialS, "0", "-", amount.ToString(), 0, rsocialS, "-");
                vehPenDao.updateVehiculoPension(vehicleID,Program.sumMonthDate(ultimo_mes_pago));

                if ("".Equals(rut))
                {
                    int CFEnro = Program.getCorrelativo("CFE");
                    client.CreateXml(amount.ToString(), impNoIva, impIva, CFEnro, 0, concepto,empCod, empCA, empPK, movCaja, movParking);
                }
                else
                {
                    int CFEnro = Program.getCorrelativo("CTE");
                    client.CreateXmlRUT(amount.ToString(), impNoIva, impIva, CFEnro, rut, rsocialS, 0, concepto, empCod, empCA, empPK, movCaja, movParking);
                }

                this.MensualesTableAdapter.mensuales(parkingDataSet.Mensuales);
            }
        }

        private void generateMovCaja(int chargeS, String rutS, string rsocialS,
           string minutesS, string vehicleTS, string totalCS, int ticketIdS, string obs, string conS)
        {

            movCaja.str_fecha = Program.getFormatedDate();
            movCaja.str_hora = Program.getFormatedHour();
            movCaja.importe = chargeS;
            movCaja.cerrado = false;
            movCaja.id_referencia_cierre = 0;
            movCaja.id_tipo_movimiento = 1;
            movCaja.str_eliminado = "NO";
            movCaja.id_usuario = Login.logUser.ID;
            movCaja.id_tipo_documento_emision = 1;
            movCaja.correlativo_documento_emision = Program.getCorrelativo("CONTA");
            movCaja.serie_documento_emision = "A";
            movCaja.rollo = 1;
            movCaja.rut = rutS;
            movCaja.razon_social = rsocialS;
            movCaja.str_observaciones = obs;
            movCaja.correlativo_ticket = ticketIdS;
            movCaja.str_tipo_vehiculo = vehicleTS;
            movCaja.str_convenio = conS;
            movCaja.minutos = Int32.Parse(minutesS);
            movCaja.importe_calculado = Int32.Parse(totalCS);
            movCaja.valor_comision = 0;
            movCaja.com_cobrada = false;


            movCajaDAO.addMovCaja(ref movCaja);

        }

        private void adentroModDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {

                DataGridViewRow row = adentroModDataGridView.Rows[rowIndex];

                int adentroId = Int32.Parse(row.Cells[9].Value.ToString());
                string plate = row.Cells[1].Value.ToString();

                Adentro ade =  adeDAO.getAdentro(adentroId);
                if (ade.str_matricula.StartsWith("NR"))
                {
                    adeDAO.updateAdentroByPlate(adentroId, plate);
                }
                

            }
        }
    }

}
    