using e_billing.parking;
using e_billing.parking.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_billing
{
    public partial class Services : Form
    {

        private Main mainForm;

        private MovimientosCajaDAO movCajaDAO = new MovimientosCajaDAO();

        private InvoicyClient client = new InvoicyClient();
        private MovimientosCaja movCaja = new MovimientosCaja();
        private MovimientoParking movParking = new MovimientoParking();

        int price;
        int totalPay;
        string servName;
        
        public Services()
        {
            InitializeComponent();
        }

        public Services(DataGridView adentroModDataGridView, Main main)
        {
            this.serviciosDataGridView = adentroModDataGridView;
            this.mainForm = main;
            InitializeComponent();
        }

        private void Services_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parkingDataSet.Servicios' table. You can move, or remove it, as needed.
            this.serviciosTableAdapter.Fill(this.parkingDataSet.Servicios);

        }
        
       
        private void button3_Click(object sender, EventArgs e)
        {
            if (serviciosDataGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = serviciosDataGridView.SelectedRows[0];
                
                servName = row.Cells[1].Value.ToString();
                price = Int32.Parse(row.Cells[2].Value.ToString());
            }
            string totalS = total.Text;
            if (!"".Equals(totalS))
            {
                int totalServ = Int32.Parse(total.Text);
                totalPay = price * totalServ;
                totalToPay.Text = "TOTAL A FACTURAR: $" + totalPay;
            } else
            {
                totalToPay.Text = "TOTAL A FACTURAR: $" + price;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rutS = rut.Text;
            string rsocialS = name.Text;

            double impNoIva = Math.Round((totalPay / 1.22));
            double impIva = (impNoIva * 0.22);

            string empCod = ConfigurationManager.AppSettings["EMP_CODE"].ToString();
            string empPK = ConfigurationManager.AppSettings["EMP_PK"].ToString();
            string empCA = ConfigurationManager.AppSettings["EMP_CA"].ToString();


            generateMovCaja(totalPay, rutS, rsocialS, "0", "-", totalPay.ToString(), -1, name.Text, "-");

            if ("".Equals(rutS))
            {
                int CFEnro = Program.getCorrelativo("CFE");
                client.CreateXml(totalPay.ToString(), impNoIva, impIva, CFEnro, 0, "0 Horas",empCod, empCA, empPK, movCaja, movParking);
            }
            else
            {
                int CFEnro = Program.getCorrelativo("CTE");
                client.CreateXmlRUT(totalPay.ToString(), impNoIva, impIva, CFEnro, rutS, rsocialS, 0, "0 Horas", empCod, empCA, empPK, movCaja, movParking);
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
        
    }
}
