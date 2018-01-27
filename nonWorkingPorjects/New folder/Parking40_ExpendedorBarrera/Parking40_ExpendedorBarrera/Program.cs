using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;
using System.IO.Ports;

using GEN_BE;
using GEN_BE.DAO;

namespace Parking40_ExpendedorBarrera
{
    static class Program
    {
        private static string interfase_entrada = ConfigurationManager.AppSettings["INTERFASE_ENTRADA"].ToString();
        private static string puerto_entrada = ConfigurationManager.AppSettings["PORT_I"].ToString();
        private static string puerto_salida = ConfigurationManager.AppSettings["PORT_O"].ToString();

        //public static Thread uiMonitor = new Thread(new ThreadStart(UI_Monitor));
        public static Thread pEntrada = new Thread(new ThreadStart(Entrada_Port));
        public static Thread uiEntrada = new Thread(new ThreadStart(Entrada_Ui));
        public static System.IO.Ports.SerialPort sp_entrada = new System.IO.Ports.SerialPort(ConfigurationManager.AppSettings["PORT_I"].ToString());

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (ConfigurationManager.AppSettings["MOSTRAR_MONITOR_UI"].ToString() == "SI")
            //{
            //    Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), "Iniciando monitor de actividad...");
            //    uiMonitor.Start();
            //}

            if (ConfigurationManager.AppSettings["INTERFASE_ENTRADA"].ToString() == "UI")
            {
                Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), "Iniciando interfase de entrada - UI...");
                uiEntrada.Start();
            }
            else
            {
                Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), "Iniciando interfase de entrada - Port_I...");
                MonitorPuertoSerie mps = new MonitorPuertoSerie();
                mps.ShowDialog();
            }
        }

        public static void UI_Monitor()
        {
            Application.Run(new Monitor());
        }

        public static void Entrada_Port()
        {
            try
            {
                sp_entrada.Open();
                sp_entrada.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(port_PinChanged);
            }
            catch (Exception)
            {
                Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), "Error al abrir puerto PORT_I");
            }
        }
       
        static void port_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            sp_entrada.DiscardInBuffer();
            sp_entrada.DiscardOutBuffer();
            sp_entrada.Close();
            Program.Generar_Entrada();
            Program.Abrir_Barrera();
            sp_entrada.Open();
            sp_entrada.DiscardInBuffer();
            sp_entrada.DiscardOutBuffer();
            sp_entrada.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(port_PinChanged);
        }

        public static void Entrada_Ui()
        {
            Application.Run(new Entrada_X_UI());
        }

        public static void Escribir_Log(string fecha_hora, string evento)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(ConfigurationManager.AppSettings["ARCHIVO_LOG"].ToString().Trim(), true))
            {
                file.WriteLine(fecha_hora+", "+evento);
            }
        }

        public static int Generar_Entrada()
        {
            try
            {
                //Genero fecha y hora de entrada
                string str_mes = "";
                string str_dia = "";
                string str_fecha_entrada = "";
                string str_hora_entrada = "";

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

                //Obtengo y grabo nro. de ticket
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
                adentro.Str_hora_entrada = str_hora_entrada;
                adentro.Str_llave = "";
                adentro.Str_lugar = "";
                adentro.Str_matricula = "NR-" + usr_barrera.ToString().Trim();
                adentro.Str_observaciones = "Ingreso " + usr_barrera.ToString().Trim() + " " + str_fecha_entrada + " " + str_hora_entrada;
                adentroDAO.Insert(ref adentro);

                //Imprimo ticket
                Ticket_Barrera tb = new Ticket_Barrera();
                tb.Bands["Detail"].Controls["Codigo_Barras"].Text = "BAR" + adentro.Correlativo_ticket.ToString().Trim() + "Z";
                tb.Bands["Detail"].Controls["xrLabel_Fecha"].Text = str_fecha_entrada + " " + str_hora_entrada;
                tb.Bands["Detail"].Controls["xrLabel_Hora"].Text = str_hora_entrada;
                tb.Bands["Detail"].Controls["xrLabel_Ticket"].Text = "Ticket: " + adentro.Correlativo_ticket.ToString().Trim();
                tb.Bands["Detail"].Controls["xrLabel_Entrada"].Text = "Entrada: B" + ConfigurationManager.AppSettings["NRO_BARRERA"].ToString();

                tb.PrinterName = ConfigurationManager.AppSettings["IMPRESORA_TICKETS"].ToString();
                tb.CreateDocument();
                tb.PrintingSystem.ShowMarginsWarning = false;
                tb.PrintingSystem.ShowPrintStatusDialog = false;
                tb.Print();

                Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), "Entrada generada, ticket " + adentro.Correlativo_ticket.ToString());

                return (0);
            }
            catch (Exception)
            {
                Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), "Error al generar ticket de entrada");

                return (1);
            }
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
    }
}
