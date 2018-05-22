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
        private EstadoLlaveroDAO elDAO = new EstadoLlaveroDAO();
        private AdentroDAO adeDAO = new AdentroDAO();

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

            salida(rowIndex);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parkingDataSet.AdentroMod' table. You can move, or remove it, as needed.
            this.adentroModTableAdapter.Fill(this.parkingDataSet.AdentroMod);
        }

        private void inButton_Click(object sender, EventArgs e)
        {
            Entrence entrence = new Entrence();
            entrence.Show();
            /* generar entrada  program.getEntrance*/
            //string plate, int vehType, string dateIn, string hourIn
            //Program.generateEntrence();


        }

        private void outButton_Click(object sender, EventArgs e)
        {
            int rowIndex = adentroModDataGridView.CurrentCell.RowIndex;
            salida(rowIndex);
            
        }
        private void salida(int rowIndex)
        {
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

                Tarifa rate = rateDao.getRate(vehicleId, minutes);
                EstadoLlavero estLl = elDAO.getKeyState(plate,ticketId);

                Ticket ticket = new Ticket();

                int importe = Convert.ToInt32(rate.importe);
                ticket.plate.Text = plate;
                ticket.minutes.Text = minutes.ToString();
                ticket.rate.Text = rate.str_tarifa.ToString();
                ticket.charge.Text = importe.ToString();
                ticket.received.Text = "1000";
                ticket.change.Text = (1000 - importe).ToString();
                ticket.key.Text = estLl.nro_llave;

                ticket.toPayLabel.Text = "A Pagar: $" + importe;
                ticket.ticketLabel.Text = "Ticket: " + ticketId;
                ticket.toPayLabel.Visible = true;
                ticket.ticketLabel.Visible = true;
                ticket.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int rowCount = adentroModDataGridView.RowCount;
            int adeCount = adeDAO.getTotalRecord();


            try
            {
                if (rowCount != adeCount)
                {
                    Program.log.Debug(DateTime.Now.ToString() + "Recargando datos Notificaciones");
                    this.adentroModTableAdapter.Fill(this.parkingDataSet.AdentroMod);
                }

            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString()+ "timer1_Tick" + ex);
            }


        }

        private void fillBy6ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.adentroModTableAdapter.FillBy6(this.parkingDataSet.AdentroMod);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
