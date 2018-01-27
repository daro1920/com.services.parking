using NotiFees.anpr.dao;
using NotiFees.parking.dao;
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
    public partial class OptionsForm : Form
    {

        private readonly NotificacionesDao notiDao = new NotificacionesDao();
        private readonly IncidenceDao incidenceDao = new IncidenceDao();

        private List<Notificaciones> notiList = new List<Notificaciones>();
        List<string> adentroPlates = new List<string>();
        List<string> notiPlates = new List<string>();
        
        public int id;
        public int rowIndex;
        public int resultId;
        public string plate;
        public string hourIn;
        public string dateIn;

        public DataGridView grid;


        public OptionsForm()
        {
            InitializeComponent();
        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            notiDao.removeNotificationById(id);
            Program.Generar_Entrada(plate,1, dateIn, hourIn);
            grid.Rows.RemoveAt(rowIndex);
            this.Close();
        }

        private void reportError_Click(object sender, EventArgs e)
        {
            ErrorReport errorForm = new ErrorReport();
            errorForm.Show();
            errorForm.plate = plate;
            errorForm.id = id;
            grid.Refresh();
            this.Close();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void markAsBig_Click(object sender, EventArgs e)
        {
            notiDao.removeNotificationById(id);
            Program.Generar_Entrada(plate,3,dateIn,hourIn);
            grid.Rows.RemoveAt(rowIndex);
            this.Close();
        }

        private void showImage_Click(object sender, EventArgs e)
        {
            ImgFrame imgF = new ImgFrame();
            imgF.resultId = resultId;
            imgF.Show();
            
        }
    }
}
