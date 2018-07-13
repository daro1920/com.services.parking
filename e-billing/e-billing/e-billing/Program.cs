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
        internal static string getFormatDate(string dateString, string hour)
        {

            string date = dateString.Insert(4, "/").Insert(7, "/");
            string dateTime = date + " " + hour;
            return dateTime;
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

        public static int getCorrelativo(string type)
        {
            tdec = tdecDAO.SelectByStr_codigo(type);

            int nro_ticket = tdec.int_correlativo_prox;

            tdec.int_correlativo_prox++;
            tdecDAO.updateByStr_codigo(tdec);

            return nro_ticket;
        }
        public static void generateEntrence(string plate, int vehType)
        {
            try
            {

                int matricula = random.Next(100000000, 999999999);

                //Obtengo usuario automatico de la barrera
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                
                string usr_barrera = ConfigurationManager.AppSettings["USUARIO_BARRERA"].ToString().Trim().ToUpper();
                Usuario user = usuarioDAO.getUserByName(usr_barrera);

                string str_fecha_entrada = getFormatedDate(); ;
                string str_hora_entrada = getFormatedHour();



                //Registro vehiculo en adentro
                int nro_ticket = getCorrelativo("TICKE");
                adentro.correlativo_ticket = nro_ticket;
                adentro.es_nocturno = false;
                adentro.fecha_venc_prepago = "";
                adentro.hora_venc_prepago = "";
                adentro.id_convenio = 1;
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

            }
            catch (Exception ex)
            {
                log.Error(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " Error al generar ticket de entrada " + ex);
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
