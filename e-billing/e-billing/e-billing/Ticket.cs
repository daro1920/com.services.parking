using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_billing.parking;


namespace e_billing
{
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            /*
             Generar xml
             ingresar movCaja  y movParking
             si todo esta bien -> borrar registro adentro.
             
             
             */
            InvoicyClient client = new InvoicyClient();
            client.CreateXml();

            string plateNum = plate.Text;
            //String vehType = plate.
            //Program.generateEntrence();
        }
    }
}
