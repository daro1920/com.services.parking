using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using GEN_BE;
using GEN_BE.DAO;
using System.Media;
using System.Diagnostics;
using System.Data.SqlClient;



namespace Parking40_SalidaBarrera
{
    public partial class SalidaBarrera : Form
    {
        public int timeout_mensajes = Convert.ToInt32(ConfigurationManager.AppSettings["TIMEOUT_MENSAJES"].ToString().Trim());
        public string mostrar_mensajes = ConfigurationManager.AppSettings["MOSTRAR_MENSAJES"].ToString().Trim();

        public String numAnt = String.Empty;

        public SalidaBarrera()
        {
            InitializeComponent();
        }

        private void SalidaBarrera_Load(object sender, EventArgs e)
        {

        }
        
        private void textBoxCB_TextChanged(object sender, EventArgs e)
       {
           
            if (this.textBoxCB.Text.Trim().Length > 4)
            {
                if (this.textBoxCB.Text.Trim().Length > 30)
                {
                    textBoxCB.Text = String.Empty;
                    textBoxCB.Refresh();
                    textBoxCB.Focus();
                    this.numAnt = "";
                }else
                {
				    // NUEVA MODIFICACION
                    SoundPlayer simpleSound = null;
                    int n;
                    if ((this.textBoxCB.Text.Trim().Length == 10) && (int.TryParse(this.textBoxCB.Text.Trim().Substring(0, 8), out n)))
                    {

                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PARKING"].ConnectionString;
                        //string connectionString = "Server=GIMEDARO\\LOCALHOST; Trusted_Connection=Yes;";
                       // string connectionString = "Server=localhost\\SQLEXPRESS; Database=PARKING_EUGENIO; User ID=sa; Password=";


                        string insertStmt = "SELECT autorizado1_ci,autorizado2_ci,autorizado3_ci ,str_matricula FROM [Parking_ester].[dbo].[VehiculosRegistrados]";

                        //int cardID = 

                        //SqlDataReader myReader;
                        using(SqlConnection conn = new SqlConnection(connectionString))
                        using(SqlCommand cmd = new SqlCommand(insertStmt, conn))
                        {

                            // open connection, execute command, close connection
                            conn.Open();
                            Boolean notFound = true;
                            var myReader = cmd.ExecuteReader();

                            string plateNumber = "";
                            string cardID ="";
                            int hourIn = 0;
                            int hourOut = 0;
                            int margen = 20;

                            while (myReader.Read())
                            {

                                cardID = myReader.GetString(0);
                                

                                //Write logic to process data for the first result.
                                if (textBoxCB.Text.Equals(cardID)) 
                                {
                                    hourIn = Int32.Parse(myReader.GetString(1));
                                    hourOut = Int32.Parse(myReader.GetString(2));
                                    plateNumber = myReader.GetString(3);

                                    var currentHour = DateTime.Now.Hour;
                                    var currentMin = DateTime.Now.Minute;
                                    if ((Program.isWeekEnd() || Program.isHoliday()))
                                    {
                                        //Playing beep
                                        simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_CARD"].ToString().Trim());
                                        simpleSound.Play();

                                        Program.Abrir_Barrera();

                                        textBoxCB.Text = String.Empty;
                                        textBoxCB.Refresh();
                                        textBoxCB.Focus();
                                        this.numAnt = "";

                                        notFound = false;

                                        break;
                                    }
                                    else if (currentHour <= hourOut)
                                    {
                                        if (currentHour == hourOut)
                                        {
                                            if(currentMin<= margen)
                                            {
                                                //Playing beep
                                                simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_CARD"].ToString().Trim());
                                                simpleSound.Play();

                                                Program.Abrir_Barrera();

                                                textBoxCB.Text = String.Empty;
                                                textBoxCB.Refresh();
                                                textBoxCB.Focus();
                                                this.numAnt = "";

                                                notFound = false;

                                                break;
                                            }
                                        } else {
                                            //Playing beep
                                            simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_CARD"].ToString().Trim());
                                            simpleSound.Play();

                                            Program.Abrir_Barrera();

                                            textBoxCB.Text = String.Empty;
                                            textBoxCB.Refresh();
                                            textBoxCB.Focus();
                                            this.numAnt = "";

                                            notFound = false;

                                            break;
                                        }
                                    } else if(currentHour >= hourIn) {
                                        //Playing beep
                                        simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_CARD"].ToString().Trim());
                                        simpleSound.Play();

                                        Program.Abrir_Barrera();

                                        textBoxCB.Text = String.Empty;
                                        textBoxCB.Refresh();
                                        textBoxCB.Focus();
                                        this.numAnt = "";

                                        notFound = false;

                                        break;
                                    }
                                }
                            }
                            
                            if(notFound)
                            {
                       
                                Console.WriteLine("Sonido error ");
                                simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_NOT_ALLOW"].ToString().Trim());
                                simpleSound.Play();
                                //TODO TERMINAR DE AJUSTAR EL FORMATO DEL TICKET
                                Program.ImprimirTicket(hourIn, hourOut, cardID, plateNumber);
                                
                                textBoxCB.Text = String.Empty;
                                textBoxCB.Refresh();
                                textBoxCB.Focus();
                                this.numAnt = "";

                            }
                            conn.Close();
                        }
                        
                    }else // FIN MODIFICACION
                    if ((this.textBoxCB.Text.Trim().Substring(0, 3) == "BAR") && (this.textBoxCB.Text.Trim().Substring(this.textBoxCB.Text.Trim().Length - 1, 1) == "Z"))
                    {
                    
                        string ticket = this.textBoxCB.Text.Trim().Substring(3, this.textBoxCB.Text.Trim().Length - 4);
                        Program.Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortDateString(), "Lectura de ticket - Ticket: "+ticket);

                        int tolerancia_salida = Convert.ToInt32(ConfigurationManager.AppSettings["TOLERANCIA_SALIDA"].ToString());

                        List<MovimientosCaja> movimientosCajaList = new List<MovimientosCaja>();
                        MovimientosCajaDAO movimientosCajaDAO = new MovimientosCajaDAO();
                        movimientosCajaList = movimientosCajaDAO.SelectAll_Cerrado_Eliminado(false, false);

                        bool pago_ticket = false;
                        int resultado_salida = 0;

                        foreach (MovimientosCaja mc in movimientosCajaList)
                        {
                            if (Convert.ToInt32(ticket) == mc.Correlativo_ticket)
                            {
                                DateTime fecha_hora_pago = new DateTime(Convert.ToInt32(mc.Str_fecha.Substring(0, 4)), Convert.ToInt32(mc.Str_fecha.Substring(4, 2)), Convert.ToInt32(mc.Str_fecha.Substring(6, 2)), Convert.ToInt32(mc.Str_hora.Substring(0, 2)), Convert.ToInt32(mc.Str_hora.Substring(3, 2)), 0);
                                DateTime fecha_maxima_salida = fecha_hora_pago.AddMinutes(tolerancia_salida);
                                resultado_salida = DateTime.Compare(DateTime.Now, fecha_maxima_salida);
                                pago_ticket = true;
                                break;
                            }
                        }

                        if (pago_ticket)
                        {
                            if (resultado_salida < 0)
                            {
                                if (ConfigurationManager.AppSettings["ENVIAR_SALIDA"].ToString().ToUpper() == "SI")
                                {
                                    Program.Abrir_Barrera();
                                    //sale

                                    //Playing beep
                                    simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_SUCCES"].ToString().Trim());
                                    simpleSound.Play();
                                
                                    //OJO CON LA BAJADA DE LA BARRERA. NO SE MANEJA POR SOFTWARE SINO POR DETECTOR Y LA CONTROLADORA
                                }
                            }
                            else
                            {
                                Program.Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortDateString(), "Tiempo de salida excedido - Ticket: " + ticket);
                                if (mostrar_mensajes == "SI")
                                {
                                    Mensaje mensaje = new Mensaje();
                                    mensaje.timer_mensaje.Interval = timeout_mensajes;
                                    mensaje.label_mensaje.Text = "El ticket ha excedido el tiempo máximo";
                                    mensaje.ShowDialog();


                                    //Playing beep
                                    simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_TIME_OUT"].ToString().Trim());
                                    simpleSound.Play();
                                }
                            }
                        }
                        else
                        {
                            Program.Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortDateString(), "Ticket no habilitado - #: " + ticket);
                            Mensaje mensaje = new Mensaje();
                            mensaje.timer_mensaje.Interval = timeout_mensajes;
                            mensaje.label_mensaje.Text = "El ticket no esta hablitado para salida";
                            mensaje.ShowDialog();

                            //Playing beep
                            simpleSound = new SoundPlayer(ConfigurationManager.AppSettings["BEEP_SOUND_NOT_ALLOW"].ToString().Trim());
                            simpleSound.Play();
                        }

                        textBoxCB.Text = String.Empty;
                        textBoxCB.Refresh();
                        textBoxCB.Focus();
                        //foreach (MovimientosCaja mc in movimientosCajaList)
                        //{
                        //    if (Convert.ToInt32(ticket) == mc.Correlativo_ticket)
                        //    {
                        //        DateTime fecha_hora_pago = new DateTime(Convert.ToInt32(mc.Str_fecha.Substring(0, 4)), Convert.ToInt32(mc.Str_fecha.Substring(4, 2)), Convert.ToInt32(mc.Str_fecha.Substring(6, 2)), Convert.ToInt32(mc.Str_hora.Substring(0, 2)), Convert.ToInt32(mc.Str_fecha.Substring(3, 2)), 0);
                        //        DateTime fecha_maxima_salida = fecha_hora_pago.AddMinutes(tolerancia_salida);
                        //        int resultado_salida = DateTime.Compare(DateTime.Now, fecha_maxima_salida);

                        //        if (resultado_salida >= 0)
                        //        {
                        //            if (ConfigurationManager.AppSettings["ENVIAR_SALIDA"].ToString().ToUpper() == "SI")
                        //            {
                        //                Program.Abrir_Barrera();
                        //                //OJO CON LA BAJADA DE LA BARRERA. NO SE MANEJA POR SOFTWARE SINO POR DETECTOR Y LA CONTROLADORA
                        //            }
                        //        }
                        //        else
                        //        {
                        //            Program.Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortDateString(), "Tiempo de salida excedido - Ticket: " + ticket);
                        //            MessageBox.Show("El ticket ha excedido el tiempo máximo de salida", "", MessageBoxButtons.OK);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        Program.Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortDateString(), "Ticket no habilitado - #: " + ticket);
                        //        MessageBox.Show("El ticket no se ha hablitado para salida", "", MessageBoxButtons.OK);
                        //    }
                        //}
                    }
                }
            }
        }
        // el reloj se ejecuta cada 4 segundos
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.textBoxCB.Text.Trim().Length != 0)
            {
                if (this.numAnt.Length == 0)//si el registro anterior es vacio
                {
                    this.numAnt = this.textBoxCB.Text.Trim();
                } else
                if (this.numAnt.Equals(this.textBoxCB.Text.Trim()))// si la lectura es igual al registro anterior
                {
                    // borro todo
                    textBoxCB.Text = String.Empty;
                    textBoxCB.Refresh();
                    textBoxCB.Focus();
                    this.numAnt = "";
                }
            }
        }
    }
}