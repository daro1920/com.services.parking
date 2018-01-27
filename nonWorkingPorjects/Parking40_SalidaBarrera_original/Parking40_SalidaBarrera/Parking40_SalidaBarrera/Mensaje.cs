using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Parking40_SalidaBarrera
{
    public partial class Mensaje : Form
    {
        public Mensaje()
        {
            InitializeComponent();
        }

        private void timer_mensaje_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void Mensaje_Load(object sender, EventArgs e)
        {
            timer_mensaje.Start();
        }
    }
}
