using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

using GEN_BE;
using GEN_BE.DAO;

namespace Parking40_ExpendedorBarrera
{
    public partial class MonitorPuertoSerie : Form
    {
        public MonitorPuertoSerie()
        {
            InitializeComponent();
        }

        private void MonitorPuertoSerie_Load(object sender, EventArgs e)
        {
            try
            {
                Program.pEntrada.Start();
            }
            catch (Exception exc)
            {
                Program.Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), "Error al iniciar interfase de entrada por puerto Port_I");
                Program.Escribir_Log(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), "Excepcion "+ exc.Message);
            }
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            Program.pEntrada.Suspend();
            Close();
        }
    }
}
