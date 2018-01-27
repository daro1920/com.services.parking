using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Media;
using System.Drawing.Printing;

using GEN_BE;
using GEN_BE.DAO;

namespace Parking40_SalidaBarrera
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 

        //Set the font style of output image
        public static Font barCodeF = new Font("Free 3 of 9", 45, FontStyle.Regular, GraphicsUnit.Pixel);
        public static Font plainTextF = new Font("Arial", 20, FontStyle.Regular, GraphicsUnit.Pixel);

        private static Font printFont;
        private static StreamReader streamToPrint;
        private static string Codigo_Barras;
        private static string xrLabel_Salida;
        private static string xrLabel_Hora;
        private static string xrLabel_Ticket;
        private static string xrLabel_Entrada;
        private static string xrLabel_Matricula;

        private static SoundPlayer simpleSound = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SalidaBarrera());
        }

        public static void Abrir_Barrera()
        {
            if (ConfigurationManager.AppSettings["ENVIAR_SALIDA"].ToString() == "SI")
            {
                Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortDateString(), "Apertura de barrera");

                int demora_senal = Convert.ToInt32(ConfigurationManager.AppSettings["DEMORA_SENAL_SALIDA"].ToString());
                System.IO.Ports.SerialPort sp = new System.IO.Ports.SerialPort(ConfigurationManager.AppSettings["PORT_O"].ToString());
                sp.Open();
                sp.DiscardInBuffer();
                sp.DiscardOutBuffer();
                sp.DtrEnable = true; //High
                System.Threading.Thread.Sleep(demora_senal);
                sp.DtrEnable = false; //Low
                System.Threading.Thread.Sleep(demora_senal);
                sp.DiscardInBuffer();
                sp.DiscardOutBuffer();
                sp.Close();
            }
        }

        public static void Escribir_Log(string fecha_hora, string evento)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(ConfigurationManager.AppSettings["ARCHIVO_LOG"].ToString().Trim(), true))
            {
                file.WriteLine(fecha_hora + ", " + evento);
            }
        }

                // The PrintPage event is raised for each page to be printed. 
        private static void ticket_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;


            // Print each line of the file. 
            Point p = new Point(0,0);
            //int n;

            int margen_der = 10;
            int margen_cod_barr = 18;
            // parking logo
            Stream BitmapStream = System.IO.File.Open(ConfigurationManager.AppSettings["TICKET_IMAGE"].ToString().Trim(),System.IO.FileMode.Open);
            Image img = Image.FromStream(BitmapStream);
            Bitmap ticket_image =new Bitmap(img);
            BitmapStream.Close();

            BitmapStream = System.IO.File.Open(ConfigurationManager.AppSettings["TICKET_ROWS"].ToString().Trim(), System.IO.FileMode.Open);
            img = Image.FromStream(BitmapStream);
            Bitmap ticket_rows = new Bitmap(img);
            BitmapStream.Close();

            //string barString = "*99985566*";
            //Image barCode = stringToImage(barString);
            
            //ev.Graphics.DrawString(Codigo_Barras, new Font("Free 3 of 9", 10, FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(Color.Black), 0, 0);
            ev.Graphics.DrawImage(ticket_rows, 15, 0);
            ev.Graphics.DrawImage(ticket_rows, 55, 0);
            ev.Graphics.DrawImage(ticket_rows, 95, 0);
            ev.Graphics.DrawImage(ticket_rows, 135, 0);
            ev.Graphics.DrawImage(ticket_rows, 175, 0);
            ev.Graphics.DrawImage(ticket_rows, 215, 0);
            ev.Graphics.DrawImage(ticket_rows, 255, 0);
            ev.Graphics.DrawString(Codigo_Barras, new Font("ccode39", margen_cod_barr, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 1, 2 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(Codigo_Barras, new Font("ccode39", margen_cod_barr, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 1, 5 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(Codigo_Barras, new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, margen_der, 8 * printFont.GetHeight(ev.Graphics), new StringFormat());
            //ev.Graphics.DrawString(xrLabel_Hora , printFont, Brushes.Black, leftMargin, topMargin + (6 * printFont.GetHeight(ev.Graphics)), new StringFormat());
            ev.Graphics.DrawImage(ticket_image, 10, 9 * printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(xrLabel_Entrada, printFont, Brushes.Black, margen_der, 13 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Salida,   printFont, Brushes.Black, margen_der, 14 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Ticket,  printFont, Brushes.Black, margen_der, 15 * printFont.GetHeight(ev.Graphics), new StringFormat());
            ev.Graphics.DrawString(xrLabel_Matricula, printFont, Brushes.Black, margen_der, 16 * printFont.GetHeight(ev.Graphics), new StringFormat());

            
            
             
        }



        public static int ImprimirTicket(int hourIn, int hourOut, string cardID, string plateNumber)
        {
            try
            {
                

                //Genero fecha y hora de entrada
                string str_mes = "";
                string str_dia = "";
                string str_fecha_entrada = "";
                string str_hora_entrada = "";
                string hourOutSTR = "";

                hourOutSTR = hourOut.ToString();
                if (hourOut >= 0 && hourOut <= 9)
                {
                    hourOutSTR = "0" + hourOut;
                }

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
                str_fecha_entrada = DateTime.Now.Year.ToString() + str_mes + str_dia;
                str_hora_entrada = DateTime.Now.TimeOfDay.ToString().Trim().Substring(0, 5);




                //Obtengo usuario automatico de la barrera
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                List<Usuario> usuarioList = new List<Usuario>();
                usuarioList = usuarioDAO.SelectAll();
                int id_usr_barrera = 0;
                string usr_barrera = ConfigurationManager.AppSettings["USUARIO_BARRERA"].ToString().Trim().ToUpper();

                foreach (Usuario usr in usuarioList)
                {
                    if (usr.Str_nombre_usuario == usr_barrera)
                    {
                        id_usr_barrera = usr.Id;
                    }
                }

                //////Obtengo y grabo nro. de ticket
                TipoDocumentoEmision_CorrelativosDAO tdecDAO = new TipoDocumentoEmision_CorrelativosDAO();
                TipoDocumentoEmision_Correlativos tdec = new TipoDocumentoEmision_Correlativos();

                tdec = tdecDAO.SelectByStr_codigo("TICKE");

                int nro_ticket = tdec.Int_correlativo_prox;

                tdec.Int_correlativo_prox++;
                tdecDAO.UpdateByStr_codigo(tdec);

                //Registro vehiculo en adentro
                AdentroDAO adentroDAO = new AdentroDAO();
                Adentro adentro = new Adentro();

                adentro.Correlativo_ticket = nro_ticket;
                adentro.Es_nocturno = false;
                adentro.Fecha_venc_prepago = "";
                adentro.Hora_venc_prepago = "";
                adentro.Id_convenio = 1;
                adentro.Id_tipo_vehiculo = 1;
                adentro.Id_usuario = id_usr_barrera;
                adentro.Importe_prepago = 0;
                adentro.Prepago = "NO";
                adentro.Str_fecha_entrada = str_fecha_entrada;
                adentro.Str_hora_entrada = hourOutSTR + ":00";
                adentro.Str_llave = "";
                adentro.Str_lugar = "";
                adentro.Str_matricula = "NR-" + plateNumber;
                adentro.Str_observaciones = "Ingreso " + cardID.Trim() + " " + hourIn + " " + hourOut;
                adentroDAO.Insert(ref adentro);

                //Imprimo ticket

                //Codigo_Barras = "*BAR" + 99985566 + "Z*";
                Codigo_Barras = "*BAR" + adentro.Correlativo_ticket.ToString().Trim() + "Z*";
                xrLabel_Salida = str_fecha_entrada + " " + str_hora_entrada;
                //xrLabel_Hora = str_hora_entrada;
                xrLabel_Ticket = "Ticket: " + adentro.Correlativo_ticket.ToString().Trim();
                //xrLabel_Ticket = "Ticket: " + 99985566;
                xrLabel_Entrada = "Entrada: " + hourIn + ":00";
                xrLabel_Salida = "Salida: " + hourOutSTR + ":00";
                xrLabel_Matricula = "Matricula: " + plateNumber;

                PrintDocument ticket = new PrintDocument();
                printFont = new Font("Arial", 10);
                ticket.PrintPage += new PrintPageEventHandler(ticket_PrintPage);
                ticket.Print();

                
               /* Ticket_Barrera tb = new Ticket_Barrera();
                tb.Bands["Detail"].Controls["Codigo_Barras"].Text = "BAR" + adentro.Correlativo_ticket.ToString().Trim() + "Z";
                tb.Bands["Detail"].Controls["xrLabel_Fecha"].Text = str_fecha_entrada + " " + str_hora_entrada;
                tb.Bands["Detail"].Controls["xrLabel_Hora"].Text = str_hora_entrada;
                tb.Bands["Detail"].Controls["xrLabel_Ticket"].Text = "Ticket: " + adentro.Correlativo_ticket.ToString().Trim();
                tb.Bands["Detail"].Controls["xrLabel_Entrada"].Text = "Entrada: B" + ConfigurationManager.AppSettings["NRO_BARRERA"].ToString();

                tb.PrinterName = ConfigurationManager.AppSettings["IMPRESORA_TICKETS"].ToString();
                tb.CreateDocument();
                tb.PrintingSystem.ShowMarginsWarning = false;
                tb.PrintingSystem.ShowPrintStatusDialog = false;
                tb.Print();*/

                //Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), "Entrada generada, ticket " + adentro.Correlativo_ticket.ToString());

                return (0);
            }
            catch (Exception)
            {
                //Playing beep
                Console.WriteLine("Sonido error ");
                simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_NOT_ALLOW"].ToString().Trim());
                simpleSound.Play();

                Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), "Error al generar ticket de entrada");

                return (1);
            }
        }

        public static bool isHoliday()
        {
            bool holiday = false;

            // Days
            int first = 1;
            int eighteenth = 18;
            int nineteenth = 19;
            int twentyfifth = 25;

            // Month
            int jan = 1;
            int may = 5;
            int jun = 6;
            int jul = 7;
            int agu = 8;
            int dec = 12;

            DateTime date = DateTime.Today;

            int day = date.Day;
            int month = date.Month;

            // 1-jan 1-may 18-may 19-jun 18-jul 25-agu 25-dec
            if ((day == first && month == jan) || (day == first && month == may) ||
                (day == eighteenth && month == may) || (day == nineteenth && month == jun) ||
                (day == eighteenth && month == jul) || (day == twentyfifth && month == agu) ||
                (day == twentyfifth && month == dec))
            {
                holiday = true;
            }

            return holiday;
        }

        // return true if it's saturday or sunday
        public static bool isWeekEnd()
        {

            bool week = false;

            int day = (int)DateTime.Now.DayOfWeek;
            if ((day == 6 || day == 7))
            {
                week = true;
            }

            return week;
        }
    }
}
