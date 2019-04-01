using System;
using System.Globalization;
using System.Windows.Forms;
using e_billing.parking.dao;

namespace e_billing
{
    public partial class PrepDays : Form
    {
        private Main main;
        private DataGridViewRow row;

        private TarifaDAo rateDao = new TarifaDAo();
        private TipoVehiculoDAO tvDAO = new TipoVehiculoDAO();
        private EstadoLlaveroDAO elDAO = new EstadoLlaveroDAO();
        private AdentroDAO adeDAO = new AdentroDAO();
        private ConfigDAO conDAO = new ConfigDAO();

        public PrepDays()
        {
            InitializeComponent();
        }

        public PrepDays(Main main, DataGridViewRow row)
        {
            this.main = main;
            this.row = row;
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int adentroId = Int32.Parse(row.Cells[9].Value.ToString());

            Adentro aden = adeDAO.getAdentro(adentroId);

            Boolean isPrep = false;
            Boolean isPrepDays = true;

            int ticketId = Int32.Parse(row.Cells[0].Value.ToString());
            string plate = row.Cells[1].Value.ToString();

            DateTime dateS = DateTime.Now;
            string hourS = row.Cells[3].Value.ToString();

            string vehicleType = row.Cells[4].Value.ToString();
            int vehicleId = tvDAO.getVehicleID(vehicleType);

            int convId = aden.id_convenio;

            Tarifa rate = rateDao.getRate(vehicleId, 1440, convId);
            EstadoLlavero estLl = elDAO.getKeyState(plate, ticketId);

            int prepDays = Int32.Parse(prepD.Text);
            int prepRate = Int32.Parse(rate.importe.ToString()) * prepDays;
            int minutes = (prepDays * 24 * 60);

            this.Close();

            main.showTicketForm(prepRate, plate, minutes, "Prepago", estLl, ticketId, vehicleId, row, adentroId, ticketId, isPrep, isPrepDays, convId);

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
