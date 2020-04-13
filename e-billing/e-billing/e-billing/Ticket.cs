using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_billing.parking;
using e_billing.parking.dao;
using e_billing.parking.model;

namespace e_billing
{
    public partial class Ticket : Form
    {

        private InvoicyClient client = new InvoicyClient();
        private MovimientosCaja movCaja = new MovimientosCaja();
        private MovimientoParking movParking = new MovimientoParking();

        private MovimientosCajaDAO movCajaDAO = new MovimientosCajaDAO();
        private MovimientosParkingDAO movParkingDAO = new MovimientosParkingDAO();
        private VehiculosRegistradosDAO vehRegDao = new VehiculosRegistradosDAO();
        private AdentroDAO adenDao = new AdentroDAO();
        private EstadoLlaveroDAO keyDao = new EstadoLlaveroDAO();

        private Main main;

        public Ticket(Main main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string plateS = plate.Text;
            string minutesS = minutes.Text;
            string rateS = rate.Text;
            int chargeS = Int32.Parse(charge.Text);
            string receivedS = received.Text;
            string changeS = change.Text;
            string keyS = key.Text;
            string rutS = rut.Text;
            string rsocialS = rsocial.Text;
            string vehicleTS = vehicleType.Text;
            string totalCS = totalCharge.Text;
            string inDateS = inDate.Text;
            string inHourS = inHour.Text;
            string impTotalS = impTotal.Text;
            double impNoIva = Math.Round((chargeS / 1.22));
            double impIva = (impNoIva * 0.22);
            int ticketIdS = Int32.Parse(ticketId.Text);
            bool isPreps = Boolean.Parse(isPrep.Text);
            bool isPrepDayss = Boolean.Parse(isPrepDays.Text);
            string obs = obsInput.Text;
            string conS = conv.Text;
            
            int rowInd = Int32.Parse(rowIndex.Text);
            int idAd = Int32.Parse(idAdent.Text);
           
            if(!isPreps) generateMovCaja(chargeS, rutS, rsocialS, minutesS, vehicleTS, totalCS, ticketIdS, obs, conS);
            if (!isPrepDayss) generateMovParking(inDateS,inHourS, vehicleTS, plateS, impTotalS, obs, conS);


            int hours = Int32.Parse(minutesS) / 60;
            string empCod = ConfigurationManager.AppSettings["EMP_CODE"].ToString();
            string empPK = ConfigurationManager.AppSettings["EMP_PK"].ToString();
            string empCA = ConfigurationManager.AppSettings["EMP_CA"].ToString();

            if ("".Equals(rutS))
            {
                int CFEnro = Program.getCorrelativo("CFE");
                client.CreateXml(changeS, impNoIva, impIva, CFEnro, hours, hours+" Horas", empCod, empCA, empPK, movCaja, movParking);
            }
            else
            {
                int CFEnro = Program.getCorrelativo("CTE");
                client.CreateXmlRUT(changeS, impNoIva, impIva, CFEnro, rutS, rsocialS, hours, hours + " Horas", empCod, empCA, empPK, movCaja, movParking);
            }

            if (!isPrepDayss)
            {
                
                adenDao.deleteAdentro(idAd);
                keyDao.setFreeEstadoLlavero(plateS, ticketIdS);

                main.adentroModDataGridView.Rows.RemoveAt(rowInd);
                main.refreshGrid();

            } else {
                string dateInS  = Program.getFormatDate(inDateS, inHourS);
                DateTime dateIn = DateTime.ParseExact(dateInS, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);

                DateTime prepOut = dateIn.AddMinutes(Int32.Parse(minutesS));

                string prepDate = Program.getFormatedDate(prepOut);
                string prepHour = Program.getFormatedHour(prepOut);

                adenDao.updateAdentro(idAd, prepDate,prepHour, Int32.Parse(totalCS));
            } 
            
            this.Close();
        }

        private void generateMovCaja(int chargeS, String rutS, string rsocialS,
           string minutesS, string vehicleTS, string totalCS,int ticketIdS, string obs,string conS)
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
        private void generateMovParking(string inDateS,string inHourS, string vehicleTS,
            string plateS, string impTotalS, string obs, string conS)
        {

            VehiculosRegistrado vehReg = vehRegDao.getRegVehicle(plateS);
            movParking.str_fecha_entrada = inDateS;
            movParking.str_fecha_salida = Program.getFormatedDate(); ;
            movParking.str_hora_entrada = inHourS;
            movParking.str_hora_salida = Program.getFormatedHour();
            movParking.id_tipo_movimiento = 0;
            movParking.id_tipo_vehiculo = Int32.Parse(vehicleTS);
            movParking.id_cliente = vehReg != null ? vehReg.id_cliente : 0;
            movParking.dob_importe = Int32.Parse(impTotalS);
            movParking.id_vehiculo_registrado = vehReg != null ? vehReg.id : 0;
            movParking.str_matricula = plateS;

            movParking.str_observaciones = obs;
            movParking.id_convenio = Int32.Parse(conS);
            movParking.id_pension = 0;
            movParking.str_desde_fecha_pension = "";
            movParking.str_hasta_fecha_pension = "";
            movParking.id_servicio = 0;
            movParking.id_usuario = Login.logUser.ID;
            movParking.id_movimiento_caja = movCaja.id;
            movParking.creditos_generados = 0;
            movParking.creditos_usados = false;

            movParkingDAO.addMovParking(ref movParking);

        }

        private void received_TextChanged(object sender, EventArgs e)
        {
            /*int n;
            bool isNumeric = int.TryParse(received.Text, out n);
            if (isNumeric)
            {*/
                int importe = !"".Equals(charge.Text) ? Int32.Parse(charge.Text) : 0;
                int revcived = !"".Equals(received.Text) ? Int32.Parse(received.Text) : 0;
                change.Text = (revcived - importe).ToString();
            /*} else
            {
                received.Text = received.Text.Remove(received.Text.Length - 1);
            }*/
            
            
        }

        private void charge_TextChanged(object sender, EventArgs e)
        {
            /*int n;
            bool isNumeric = int.TryParse(charge.Text, out n);
            if (isNumeric)
            {*/
            

            int importe = !"".Equals(charge.Text) ? Int32.Parse(charge.Text) : 0;
            int revcived = !"".Equals(received.Text) ? Int32.Parse(received.Text) : 0;
            change.Text = (revcived - importe).ToString();

            toPayLabel.Text = "A Pagar: $" + importe;
            
            int realCharge = !"".Equals(totalCharge.Text) ? Int32.Parse(totalCharge.Text) : -1;

            if (realCharge != -1 && realCharge != importe)
            {
                obsT.Show();
                obsInput.Show();
                AcceptB.Enabled = false;
            } else
            {
                obsT.Hide();
                obsInput.Hide();
                AcceptB.Enabled = true;
            }
            /*}
            else
            {
                charge.Text = charge.Text.Remove(charge.Text.Length - 1);
            }*/
            
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parkingDataSet1.Convenios' table. You can move, or remove it, as needed.
            this.conveniosTableAdapter.Fill(this.parkingDataSet1.Convenios);

        }

        private void obsInput_TextChanged(object sender, EventArgs e)
        {
            if (!"".Equals(obsInput.Text))
            {
                AcceptB.Enabled = true;
            } else
            {
                AcceptB.Enabled = false;
            }
        }
    }
}
