using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Configuration;

namespace Parking40_SalidaBarrera
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
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
    }
}
