using Pulsometro.ParkinEs.dao;
using Pulsometro.ParkingEu.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pulsometro
{

    

    public partial class Form1 : Form
    {
        private readonly AdentroDAO adeEsDAO = new AdentroDAO();
        private readonly AdentroEuDAO adeEuDAO = new AdentroEuDAO();
        private readonly TipoDocEmiCorrDAO tipoDocEmiDAO = new TipoDocEmiCorrDAO();

        private Adentro adentroEs = new Adentro();
        private TipoDocumentoEmision_Correlativos tipoDocEmi = new TipoDocumentoEmision_Correlativos();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.ticket.Text) || String.IsNullOrEmpty(this.plate.Text)) {

                MessageBox.Show("Ambos campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            adentroEs = adeEsDAO.getAdentroEster(this.plate.Text, Int32.Parse(this.ticket.Text));

            tipoDocEmi = tipoDocEmiDAO.SelectByStr_codigo("TICKE");

            int numTicket = tipoDocEmi.int_correlativo_prox;

            tipoDocEmi.int_correlativo_prox++;
            tipoDocEmiDAO.updateByStr_codigo(tipoDocEmi);

            adentroEs.correlativo_ticket = numTicket;

            adeEuDAO.addAdentro(ref adentroEs);


            MessageBox.Show("El vehiculo se intercambio correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.ticket.Clear();
            this.plate.Clear();


        }

    }
}
