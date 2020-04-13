using e_billing.parking.dao;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Configuration;
using System.Media;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace e_billing
{
    static class Program
    {

        private static Font printFont;
        private static string Codigo_Barras;
        private static string xrLabel_Fecha;
        private static string xrLabel_Hora;
        private static string xrLabel_Ticket;
        private static string xrLabel_Entrada;
        private static string xrLabel_Matricula;
        private static string xrLabel_Llave;
        private static string xrLabel_Veh;
        private static string typeMove;
        private static string movDate;
        private static string movHour;
        private static MovimientosCaja movCaja;
        private static List<MovimientosCaja> listMovCaja;

        private static string veh_type;

        private static Random random = new Random();
        private static PrintDocument ticket = new PrintDocument();
        private static PrintDocument ticket2 = new PrintDocument();
        private static PrintDocument ticketClose = new PrintDocument();
        private static PrintDocument ticketMove = new PrintDocument();
        

        private static AdentroDAO adentroDAO = new AdentroDAO();
        private static EstadoLlaveroDAO keyDao = new EstadoLlaveroDAO();
        private static TipoDocumentoEmision_CorrelativosDAO tdecDAO = new TipoDocumentoEmision_CorrelativosDAO();

        private static Adentro adentro = new Adentro();
        private static EstadoLlavero key = new EstadoLlavero();
        private static TipoDocumentoEmision_Correlativos tdec = new TipoDocumentoEmision_Correlativos();
        

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        internal static string sumMonthDate(string date)
        {
            int month = Convert.ToInt32(date.Substring(4,2));
            int year = Convert.ToInt32(date.Substring(0,4));
            if (month == 12)
            {
                year = year + 1;
                return year + "01";
            } else
            {
                month = month + 1;
                string monthS = month < 10 ? "0" + month :""+month;
                return year+""+ monthS;
            }
        }
        internal static string getFormatDate(string dateString, string hour)
        {

            string date = dateString.Insert(4, "/").Insert(7, "/");
            string dateTime = date + " " + hour;
            return dateTime;
        }

        internal static string getFormatDate(string dateString)
        {

            string[] date = dateString.Split('/');
            return date[2] + date[1] + date[0];
        }

        internal static string getFormatHour(string hourString)
        {

            string[] date = hourString.Split(':');
            return date[0] + ":" + date[1];
        }

        public static string getFormatedDate()
        {
            //generate date

            string str_mes = DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month.ToString().Trim() : DateTime.Now.Month.ToString().Trim();
            string str_dia = DateTime.Now.Day < 10 ? "0" + DateTime.Now.Day.ToString().Trim() : DateTime.Now.Day.ToString().Trim();

            return DateTime.Now.Year.ToString() + str_mes + str_dia;
        }

        public static string getFormatedHour()
        {
            return DateTime.Now.TimeOfDay.ToString().Trim().Substring(0, 5);

        }

        public static string getFormatedDate(DateTime date)
        {
            //generate date

            string str_mes = date.Month < 10 ? "0" + date.Month.ToString().Trim() : date.Month.ToString().Trim();
            string str_dia = date.Day < 10 ? "0" + date.Day.ToString().Trim() : date.Day.ToString().Trim();

            return date.Year.ToString() + str_mes + str_dia;
        }

        public static string getFormatedHour(DateTime date)
        {
            return date.TimeOfDay.ToString().Trim().Substring(0, 5);

        }

        public static int getCorrelativo(string type)
        {
            tdec = tdecDAO.SelectByStr_codigo(type);

            int nro_ticket = tdec.int_correlativo_prox;

            tdec.int_correlativo_prox++;
            tdecDAO.updateByStr_codigo(tdec);

            return nro_ticket;
        }
        public static void generateEntrence(string plate, int vehType,int conv)
        {
            try
            {

                int matricula = random.Next(100000000, 999999999);

                //Obtengo usuario automatico de la barrera
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                
                string usr_barrera = ConfigurationManager.AppSettings["USUARIO_BARRERA"].ToString().Trim().ToUpper();
                Usuario user = usuarioDAO.getUserByName(usr_barrera);

                string str_fecha_entrada = getFormatedDate(); 
                string str_hora_entrada = getFormatedHour();
                
                //Registro vehiculo en adentro
                int nro_ticket = getCorrelativo("TICKE");
                adentro.correlativo_ticket = nro_ticket;
                adentro.es_nocturno = false;
                adentro.fecha_venc_prepago = "";
                adentro.hora_venc_prepago = "";
                adentro.id_convenio = conv;
                adentro.id_tipo_vehiculo = vehType;
                adentro.id_usuario = Login.logUser.ID;
                adentro.importe_prepago = 0;
                adentro.prepago = "NO";
                adentro.str_fecha_entrada = str_fecha_entrada;
                adentro.str_hora_entrada = str_hora_entrada;
                adentro.str_llave = "";
                adentro.str_lugar = "";
                adentro.str_matricula = plate;
                adentro.str_observaciones = "Ingreso " + usr_barrera.ToString().Trim() + " " + str_hora_entrada + " " + str_fecha_entrada;
                adentroDAO.addAdentro(ref adentro);

                keyDao.assignFreeEstadoLlavero(plate, nro_ticket);
                log.Error(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " Entrada generada, ticket " + adentro.correlativo_ticket.ToString());
                //TODO imprimir ticket Notifee



                //Imprimo ticket
                //Codigo_Barras = "*BAR" + matricula + "Z*";
                Codigo_Barras = "*BAR" + adentro.correlativo_ticket.ToString().Trim() + "Z*";
                xrLabel_Fecha = "Fecha: " + str_fecha_entrada.Substring(6, 2) + "/" + str_fecha_entrada.Substring(4, 2) + "/" + str_fecha_entrada.Substring(0, 4);
                xrLabel_Hora = "Hora: " + str_hora_entrada;
                xrLabel_Ticket = "Ticket: " + adentro.correlativo_ticket.ToString().Trim();
                xrLabel_Matricula = "Matricula: " + plate;
                xrLabel_Entrada = "Entrada: B" + ConfigurationManager.AppSettings["NRO_BARRERA"].ToString();
                xrLabel_Llave = "Llave: " + keyDao.getKeyState(plate, nro_ticket).nro_llave;
                veh_type = vehType == 3 ? "Auto grande" : "Vehiculo";
                xrLabel_Veh = "Tipo veh: " + veh_type;

                printFont = new Font("Arial", 13);
                ticket.PrintPage += new PrintPageEventHandler(ticket_PrintPage);
                ticket2.PrintPage += new PrintPageEventHandler(ticket_PrintPage2);
                ticket2.Print();
                ticket.Print();

            }
            catch (Exception ex)
            {
                log.Error(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " Error al generar ticket de entrada " + ex);
            }
        }

        public static void generateClose(List<MovimientosCaja> movsCaja)
        {
            listMovCaja = movsCaja;
            printFont = new Font("Arial", 13);
            ticketClose.PrintPage += new PrintPageEventHandler(ticket_printClose);
            ticketClose.Print();
        }

        public static void generateMove(MovimientosCaja movCajaPar,String typeMovPar,string date,string hour)
        {
            typeMove = typeMovPar;
            movCaja = movCajaPar;
            movDate = date;
            movHour = hour;
            printFont = new Font("Arial", 13);
            ticketMove.PrintPage += new PrintPageEventHandler(ticket_printMove);
            ticketMove.Print();
        }
        private static void ticket_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;


            // Print each line of the file. 
            Point p = new Point(0, 0);
            //int n;

            int margen_der = 10;
            int margen_cod_barr = 13;

            Image img = Properties.Resources.TICKET_IMAGE;
            Bitmap ticket_image = new Bitmap(img);

            img = Properties.Resources.TICKET_ROWS;
            Bitmap ticket_rows = new Bitmap(img);

            ev.Graphics.DrawString(Codigo_Barras, new Font("ccode39", margen_cod_barr, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 20, 3 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(Codigo_Barras, new Font("ccode39", margen_cod_barr, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 20, 4 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Bienvenido", new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 80, 8 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Parking Eugenio", new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 70, 9 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("CASSINONI 1426", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 60, 10 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Fecha, printFont, Brushes.Black, margen_der, 13 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Hora, printFont, Brushes.Black, margen_der, 14 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Matricula, new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, margen_der, 15 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("VIA CLIENTE: Operador: EUGENIO", new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, margen_der, 16 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Veh, new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, margen_der, 17 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Ticket, new Font("Arial", 17, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, 50, 18 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Gracias por su preferencia", new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 60, 19 * printFont.GetHeight(ev.Graphics), new StringFormat());


        }

        // The PrintPage event is raised for each page to be printed. 
        private static void ticket_PrintPage2(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.DrawString(xrLabel_Ticket, new Font("Arial", 17, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, 50, 2 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Fecha, printFont, Brushes.Black, 40, 3 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Hora, printFont, Brushes.Black, 70, 4 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Matricula, printFont, Brushes.Black, 40, 5 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Llave, printFont, Brushes.Black, 70, 6 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Tipo veh: Automovil", new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 60, 7 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("VIA CONTROL", new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 10, 8 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Operador: Ester", new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 140, 8 * printFont.GetHeight(ev.Graphics), new StringFormat());

        }

        private static void ticket_printClose(object sender, PrintPageEventArgs ev)
        {
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;


            // Print each line of the file. 
            Point p = new Point(0, 0);
            //int n;

            int margen_der = 10;

            Image img = Properties.Resources.TICKET_IMAGE;
            Bitmap ticket_image = new Bitmap(img);

            img = Properties.Resources.TICKET_ROWS;
            Bitmap ticket_rows = new Bitmap(img);

            string str_fecha_entrada = getFormatedDate(); ;
            string str_hora_entrada = getFormatedHour();

            xrLabel_Fecha = "Fecha: " + str_fecha_entrada.Substring(6, 2) + "/" + str_fecha_entrada.Substring(4, 2) + "/" + str_fecha_entrada.Substring(0, 4);
            xrLabel_Hora = "Hora: " + str_hora_entrada;

            ev.Graphics.DrawString("PARKING EUGENIO", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 70, 9 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Cardely S.R.L", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 70, 10 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("RUT 214378950013", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 70, 11 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Cassinoni 1426", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 70, 12 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("CIERRE DE CAJA", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 70, 13 * printFont.GetHeight(ev.Graphics), new StringFormat());

            ev.Graphics.DrawString(xrLabel_Fecha, printFont, Brushes.Black, margen_der, 15 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Hora, printFont, Brushes.Black, margen_der, 16 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("VIA CLIENTE: Operador: EUGENIO", new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, margen_der, 17 * printFont.GetHeight(ev.Graphics), new StringFormat());

            ev.Graphics.DrawString("Tkt.", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 5, 19 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Entrada", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 50, 19 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Min.", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 110, 19 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Doc.", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 150, 19 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Importe", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 180, 19 * printFont.GetHeight(ev.Graphics), new StringFormat());

            int i = 1;
            decimal totalCaja = 0;
            foreach (MovimientosCaja movCaja in listMovCaja)
            {
                totalCaja = movCaja.importe + totalCaja;
                ev.Graphics.DrawString(movCaja.correlativo_ticket.ToString(), new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 5, (19 + i) * printFont.GetHeight(ev.Graphics), new StringFormat());
                ev.Graphics.DrawString(movCaja.str_fecha.ToString(), new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 50, (19 + i) * printFont.GetHeight(ev.Graphics), new StringFormat());
                ev.Graphics.DrawString(movCaja.minutos.ToString(), new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 110, (19 + i) * printFont.GetHeight(ev.Graphics), new StringFormat());
                ev.Graphics.DrawString(movCaja.correlativo_documento_emision.ToString(), new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 150, (19 + i) * printFont.GetHeight(ev.Graphics), new StringFormat());
                ev.Graphics.DrawString(movCaja.importe.ToString(), new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 200, (19 + i) * printFont.GetHeight(ev.Graphics), new StringFormat());
                i++;
            }

            ev.Graphics.DrawString("Cantidad movimientos: "+i, new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 5, ((19 + i)+1) * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Total caja: "+ totalCaja, new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 5, ((19 + i)+2) * printFont.GetHeight(ev.Graphics), new StringFormat());



        }

        private static void ticket_printMove(object sender, PrintPageEventArgs ev)
        {
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;


            // Print each line of the file. 
            Point p = new Point(0, 0);
            //int n;

            int margen_der = 10;

            Image img = Properties.Resources.TICKET_IMAGE;
            Bitmap ticket_image = new Bitmap(img);

            img = Properties.Resources.TICKET_ROWS;
            Bitmap ticket_rows = new Bitmap(img);

            string str_fecha_entrada = getFormatedDate(); ;
            string str_hora_entrada = getFormatedHour();

            xrLabel_Fecha = "Fecha: " +movDate;
            xrLabel_Hora = "Hora: " +movHour;

            ev.Graphics.DrawString("Salida de Caja", new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, margen_der, 9 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Nro: "+getCorrelativo("COMPS").ToString(), new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, margen_der, 10 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Fecha, new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, margen_der, 11 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Hora, new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, margen_der, 12 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Tipo: "+ typeMove, new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, margen_der, 13 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Obs: " + movCaja.str_observaciones, new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, margen_der, 14 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Importe: "+ movCaja.importe, new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, margen_der, 15 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString("Firma___________________________________________", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, margen_der, 16 * printFont.GetHeight(ev.Graphics), new StringFormat());

        }
    }
}
