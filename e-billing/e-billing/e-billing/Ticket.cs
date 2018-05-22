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
        private User userModel = User.Instance;

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

            generateMovCaja(chargeS, rutS, rsocialS, minutesS, vehicleTS, totalCS, userModel);
            generateMovParking();

            client.CreateXml();
            this.Close();
        }

        private void generateMovCaja(int chargeS, String rutS, string rsocialS,
           string minutesS, string vehicleTS, string totalCS, User userModel)
        {

            movCaja.str_fecha = Program.getFormatedDate();
            movCaja.str_hora = Program.getFormatedHour();
            movCaja.importe = chargeS;
            movCaja.cerrado = false;
            movCaja.id_referencia_cierre = 0;
            movCaja.id_tipo_movimiento = 1;
            movCaja.str_eliminado = "NO";
            movCaja.id_usuario = userModel.ID;
            movCaja.id_tipo_documento_emision = 1;
            movCaja.correlativo_documento_emision = Program.getCorrelativo();
            movCaja.serie_documento_emision = "A";
            movCaja.rollo = 74049;// esta bien esto ???
            movCaja.rut = rutS;
            movCaja.razon_social = rsocialS;
            movCaja.str_observaciones = "";
            movCaja.correlativo_ticket = movCaja.correlativo_documento_emision;//no se si es lo mismo 
            movCaja.str_tipo_vehiculo = vehicleTS;
            movCaja.str_convenio = "Sin convenio";//esta bien ?
            movCaja.minutos = Int32.Parse(minutesS);
            movCaja.importe_calculado = Int32.Parse(totalCS);
            movCaja.valor_comision = 0;
            movCaja.com_cobrada = false;

            movCajaDAO.addMovCaja(ref movCaja);

        }
        private void generateMovParking()
        {

            movParking.str_fecha_entrada = "";//TODO
            movParking.str_fecha_salida = "";//TODO
            movParking.str_hora_entrada = "";//TODO
            movParking.str_hora_salida = "";//TODO
            movParking.id_tipo_movimiento = 0;
            movParking.id_tipo_vehiculo = 1;//TODO
            movParking.id_cliente = 1;//TODO
            movParking.dob_importe = 1;//TODO IMPORTE TOTAL
            movParking.id_vehiculo_registrado = 1;//TODO
            movParking.str_matricula = "";//TODO
            movParking.str_observaciones = "";//TODO
            movParking.id_convenio = 1;//TODO
            movParking.id_pension = 0;
            movParking.str_desde_fecha_pension = "";
            movParking.str_hasta_fecha_pension = "";
            movParking.id_servicio = 0;
            movParking.id_usuario = 1;//TODO USUARIO LOGIN
            movParking.id_movimiento_caja = 1;//TODO ID MOVCAJA
            movParking.creditos_generados = 0;
            movParking.creditos_usados = false;

            movParkingDAO.addMovParking(ref movParking);

        }
    }
}
