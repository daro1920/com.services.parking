using e_billing.ParkingDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_billing
{
    public partial class Entrence : Form
    {

        private Main mainForm;
        public Entrence()
        {
            InitializeComponent();
        }

        public Entrence(Main main)
        {
            this.mainForm = main;
            InitializeComponent();
        }

        private void Entrence_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parkingDataSet1.TipoVehiculo' table. You can move, or remove it, as needed.
            this.tipoVehiculoTableAdapter.Fill(this.parkingDataSet1.TipoVehiculo);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string plateS = plate.Text;;
            int vehTypeS = ((e_billing.ParkingDataSet1.TipoVehiculoRow)((DataRowView)vehType.SelectedValue).Row).id;
            Program.generateEntrence(plateS, vehTypeS);
            mainForm.refreshGrid();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
