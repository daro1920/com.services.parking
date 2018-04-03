using e_billing.parking.dao;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace e_billing
{
    public partial class Main : Form
    {
        private TarifaDAo rateDao = new TarifaDAo();
        private TipoVehiculoDAO tvDAO = new TipoVehiculoDAO();
        
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

            if (rowIndex >= 0)
            {

                DataGridViewRow row = adentroModDataGridView.Rows[rowIndex];

                int ticketId = Int32.Parse(row.Cells[0].Value.ToString());
                string plate = row.Cells[1].Value.ToString();
                string dateIn = Program.getFormatDate(row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString());

                string vehicleType = row.Cells[4].Value.ToString();
                int vehicleId = tvDAO.getVehicleID(vehicleType);


                DateTime dateInTime = DateTime.ParseExact(dateIn, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
                DateTime today = DateTime.Now;

                int minutes = Convert.ToInt32((today - dateInTime).TotalMinutes);

                Tarifa rate = rateDao.getRate(vehicleId,minutes);

                Ticket ticket = new Ticket();

                int importe = Convert.ToInt32(rate.importe);
                ticket.plate.Text = plate;
                ticket.minutes.Text = minutes.ToString();
                ticket.rate.Text = rate.str_tarifa.ToString();
                ticket.charge.Text = importe.ToString();
                ticket.received.Text = "1000";
                ticket.change.Text = (1000-importe).ToString();

                ticket.toPayLabel.Text = "A Pagar: $" + importe;
                ticket.ticketLabel.Text = "Ticket: " + ticketId;
                ticket.toPayLabel.Visible = true;
                ticket.ticketLabel.Visible = true;
                ticket.Show();


                /*OptionsForm options = new OptionsForm();

                options.id = id;
                options.plate = plate;
                options.rowIndex = rowIndex;
                options.grid = notificationsGrid;
                options.resultId = resultId;
                options.dateIn = dateIn;
                options.hourIn = hourIn;

                Notificaciones notificacion = notiDao.getNotificacionByPlate(plate);
                if (notificacion.id_tipo_vehiculo == 3)
                {
                    options.imprimir.Enabled = false;
                }
                else
                {
                    options.imprimir.Enabled = true;
                }

                options.Show();*/
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parkingDataSet.AdentroMod' table. You can move, or remove it, as needed.
            this.adentroModTableAdapter.Fill(this.parkingDataSet.AdentroMod);
        }
        
    }
}
