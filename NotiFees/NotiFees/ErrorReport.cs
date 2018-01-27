using NotiFees.anpr.dao;
using NotiFees.parking.dao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotiFees
{
    public partial class ErrorReport : Form
    {
        private readonly NotificacionesDao notiDao = new NotificacionesDao();
        private readonly Notificaciones_ErroresDao notiDaoErr = new Notificaciones_ErroresDao();
        private readonly AdentroDAO adentroDao = new AdentroDAO();
        private readonly IncidenceDao incidenceDao = new IncidenceDao();

        private List<Notificaciones> notiList = new List<Notificaciones>();
        List<string> adentroPlates = new List<string>();
        List<string> notiPlates = new List<string>();



        public string plate;
        public int id;

        public ErrorReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notiDao.removeNotificationById(id);
            notiDaoErr.addNotiError(plate,this.errorObs.Text);
            this.Close();
        }
    }
}
