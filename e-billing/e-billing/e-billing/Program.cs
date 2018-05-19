using e_billing.parking.dao;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Configuration;
using System.Media;

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

        private static string veh_type;

        private static Random random = new Random();
        private static PrintDocument ticket = new PrintDocument();
        private static PrintDocument ticket2 = new PrintDocument();

        private static AdentroDAO adentroDAO = new AdentroDAO();
        private static EstadoLlaveroDAO keyDao = new EstadoLlaveroDAO();
        private static TipoDocumentoEmision_CorrelativosDAO tdecDAO = new TipoDocumentoEmision_CorrelativosDAO();

        private static Adentro adentro = new Adentro();
        private static EstadoLlavero key = new EstadoLlavero();
        private static TipoDocumentoEmision_Correlativos tdec = new TipoDocumentoEmision_Correlativos();

        private static SoundPlayer simpleSound = null;

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
        internal static string getFormatDate(string dateString,string hour)
        {

            string date = dateString.Insert(4, "/").Insert(7, "/");
            string dateTime = date + " " + hour;
            return dateTime;
        }

        public static void generateEntrence(string plate, int vehType, string dateIn, string hourIn)
        {
            try
            {
                //Genero fecha y hora de entrada
                string str_mes = "";
                string str_dia = "";

                if (DateTime.Now.Month < 10)
                {
                    str_mes = "0" + DateTime.Now.Month.ToString().Trim();
                }
                else
                {
                    str_mes = DateTime.Now.Month.ToString().Trim();
                }

                if (DateTime.Now.Day < 10)
                {
                    str_dia = "0" + DateTime.Now.Day.ToString().Trim();
                }
                else
                {
                    str_dia = DateTime.Now.Day.ToString().Trim();
                }
                //str_fecha_entrada = DateTime.Now.Year.ToString() + str_mes + str_dia;
                //str_hora_entrada = DateTime.Now.TimeOfDay.ToString().Trim().Substring(0, 5);



                int matricula = random.Next(100000000, 999999999);

                //Obtengo usuario automatico de la barrera
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                
                int id_usr_barrera = 0;
                string usr_barrera = ConfigurationManager.AppSettings["USUARIO_BARRERA"].ToString().Trim().ToUpper();
                Usuario user = usuarioDAO.getUserByName(usr_barrera);
                
                //Obtengo y grabo nro. de ticket
                tdec = tdecDAO.SelectByStr_codigo("TICKE");

                int nro_ticket = tdec.int_correlativo_prox;

                tdec.int_correlativo_prox++;
                tdecDAO.updateByStr_codigo(tdec);

                //Registro vehiculo en adentro
                adentro.correlativo_ticket = nro_ticket;
                adentro.es_nocturno = false;
                adentro.fecha_venc_prepago = "";
                adentro.hora_venc_prepago = "";
                adentro.id_convenio = 1;
                adentro.id_tipo_vehiculo = vehType;
                adentro.id_usuario = id_usr_barrera;
                adentro.importe_prepago = 0;
                adentro.prepago = "NO";
                adentro.str_fecha_entrada = dateIn;
                adentro.str_hora_entrada = hourIn;
                adentro.str_llave = "";
                adentro.str_lugar = "";
                adentro.str_matricula = plate;
                adentro.str_observaciones = "Ingreso " + usr_barrera.ToString().Trim() + " " + dateIn + " " + dateIn;
                adentroDAO.addAdentro(ref adentro);


                //Imprimo ticket
                //Codigo_Barras = "*BAR" + matricula + "Z*";
                Codigo_Barras = "*BAR" + adentro.correlativo_ticket.ToString().Trim() + "Z*";
                xrLabel_Fecha = "Fecha: " + dateIn.Substring(6, 2) + "/" + dateIn.Substring(4, 2) + "/" + dateIn.Substring(0, 4);
                xrLabel_Hora = "Hora: " + hourIn;
                xrLabel_Ticket = "Ticket: " + adentro.correlativo_ticket.ToString().Trim();
                xrLabel_Matricula = "Matricula: " + plate;
                xrLabel_Entrada = "Entrada: B" + ConfigurationManager.AppSettings["NRO_BARRERA"].ToString();
                xrLabel_Llave = "Llave: " + keyDao.getFreeEstadoLlavero(plate, nro_ticket).nro_llave;
                veh_type = vehType == 3 ? "Auto grande" : "Vehiculo";
                xrLabel_Veh = "Tipo veh: " + veh_type;


                printFont = new Font("Arial", 13);
                ticket.PrintPage += new PrintPageEventHandler(ticket_PrintPage);
                ticket2.PrintPage += new PrintPageEventHandler(ticket_PrintPage2);
                ticket2.Print();
                ticket.Print();
                log.Error(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()+ " Entrada generada, ticket " + adentro.correlativo_ticket.ToString());
                
            }
            catch (Exception ex)
            {
                log.Error(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()+" Error al generar ticket de entrada " + ex);
            }
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
    }
}
