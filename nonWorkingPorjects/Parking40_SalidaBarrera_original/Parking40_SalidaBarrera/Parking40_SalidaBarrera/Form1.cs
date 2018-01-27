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

namespace Parking40_SalidaBarrera
{
    public partial class SalidaBarrera : Form
    {
        public int timeout_mensajes = Convert.ToInt32(ConfigurationManager.AppSettings["TIMEOUT_MENSAJES"].ToString().Trim());
        public string mostrar_mensajes = ConfigurationManager.AppSettings["MOSTRAR_MENSAJES"].ToString().Trim();

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
                            DateTime fecha_hora_pago = new DateTime(Convert.ToInt32(mc.Str_fecha.Substring(0, 4)), Convert.ToInt32(mc.Str_fecha.Substring(4, 2)), Convert.ToInt32(mc.Str_fecha.Substring(6, 2)), Convert.ToInt32(mc.Str_hora.Substring(0, 2)), Convert.ToInt32(mc.Str_fecha.Substring(3, 2)), 0);
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
}
