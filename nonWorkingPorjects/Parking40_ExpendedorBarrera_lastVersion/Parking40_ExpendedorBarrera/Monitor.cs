using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Parking40_ExpendedorBarrera
{
    public partial class Monitor : Form
    {
        public Monitor()
        {
            InitializeComponent();
        }

        private void Monitor_Load(object sender, EventArgs e)
        {
            this.textBox_Actividad.Text = "/nIniciando monitor de actividad";
            this.textBox_Barrera.Text = ConfigurationManager.AppSettings["NRO_BARRERA"].ToString();
            this.textBox_Impresora.Text = ConfigurationManager.AppSettings["IMPRESORA_TICKETS"].ToString();
            this.textBox_Log.Text = ConfigurationManager.AppSettings["GUARDAR_EN_LOG"].ToString();
            this.textBox_ModoEntrada.Text = ConfigurationManager.AppSettings["INTERFASE_ENTRADA"].ToString();
            this.textBox_PuertoEntrada.Text = ConfigurationManager.AppSettings["PORT_I"].ToString();
            this.textBox_PuertoSalida.Text = ConfigurationManager.AppSettings["PORT_O"].ToString();
        }

        private void button_CerrarMonitor_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_CerrarAplicacion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma cerrar aplicación? (Se dejará de operar la barrera por sistema)", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
            }
        }
    }
}
