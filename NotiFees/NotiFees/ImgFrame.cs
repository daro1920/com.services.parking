using NotiFees.anpr.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotiFees
{
    public partial class ImgFrame : Form
    {

        public int resultId;

        private readonly IncidenceDao incidenceDao = new IncidenceDao();

        public ImgFrame()
        {
            InitializeComponent();
        }

        private void ImgFrame_Load(object sender, EventArgs e)
        {
            
            try
            {
                PictureBox PictureBox1 = new PictureBox();
                Bitmap image = new Bitmap(incidenceDao.getImage(resultId));
                Bitmap reImae = new Bitmap(image, 1000, 500);
                PictureBox1.Image = reImae;
                PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(PictureBox1);
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "Error creando el bitmap id: "+ resultId+" " + ex);
            }
        }
    }
}
