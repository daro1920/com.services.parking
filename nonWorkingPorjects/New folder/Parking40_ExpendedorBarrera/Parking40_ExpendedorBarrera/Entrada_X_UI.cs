using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Parking40_ExpendedorBarrera
{
    public partial class Entrada_X_UI : Form
    {
        public Entrada_X_UI()
        {
            InitializeComponent();
        }

        private void button_Ingreso_Click(object sender, EventArgs e)
        {
            Program.Generar_Entrada();
            Program.Abrir_Barrera();
        }
    }
}
