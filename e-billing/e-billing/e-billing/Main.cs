using e_billing.parking.dao;
using e_billing.parking.model;
using System;
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
            // TODO: This line of code loads data into the 'parkingDataSet.MovimientosCaja' table. You can move, or remove it, as needed.
            this.movimientosCajaTableAdapter1.Fill(this.parkingDataSet.MovimientosCaja);
            // TODO: This line of code loads data into the 'movimientoCajaDataSet.MovimientosCaja' table. You can move, or remove it, as needed.
            this.movimientosCajaTableAdapter.Fill(this.movimientoCajaDataSet.MovimientosCaja);
            // TODO: This line of code loads data into the 'parkingDataSet.AdentroMod' table. You can move, or remove it, as needed.
            this.adentroModTableAdapter.Fill(this.parkingDataSet.AdentroMod);
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
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            Referencia_Cierre_Caja refCC = new Referencia_Cierre_Caja();
            decimal importeCierre = movCajaDAO.getSumImporteMovCaja();

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

            movCajaDAO.addMovCaja(ref movCaja);

            refreshGridCaja();
        }
        
        
    }
}
    