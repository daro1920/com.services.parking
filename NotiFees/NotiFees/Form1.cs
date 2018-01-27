using NotiFees.anpr.dao;
using NotiFees.parking.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NotiFees
{

    public partial class Form1 : Form {

        private readonly NotificacionesDao notiDao = new NotificacionesDao();
        private readonly Notificaciones_ErroresDao notiDaoErr = new Notificaciones_ErroresDao();
        private readonly AdentroDAO adentroDao = new AdentroDAO();
        private readonly IncidenceDao incidenceDao = new IncidenceDao();

        private List<Notificaciones> notiList = new List<Notificaciones>();
        List<string> adentroPlates = new List<string>();
        List<string> notiPlates = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void notificationsGrid_CellClick(object sender, DataGridViewCellEventArgs e) {

            int rowIndex = e.RowIndex;

            if (rowIndex >= 0) {

                DataGridViewRow row = notificationsGrid.Rows[rowIndex];

                int id = Int32.Parse(row.Cells[0].Value.ToString());
                String plate = row.Cells[1].Value.ToString();
                String dateIn = Program.getFormatDate(row.Cells[2].Value.ToString());
                String hourIn = Program.getFormatHour(row.Cells[2].Value.ToString());
                int resultId = Int32.Parse(row.Cells[3].Value.ToString());

                OptionsForm options = new OptionsForm();
                
                options.id = id;
                options.plate = plate;
                options.rowIndex = rowIndex;
                options.grid = notificationsGrid;
                options.resultId = resultId;
                options.dateIn = dateIn;
                options.hourIn = hourIn;

                Notificaciones notificacion = notiDao.getNotificacionByPlate(plate);
                if (notificacion.id_tipo_vehiculo == 3 )
                {
                    options.imprimir.Enabled = false;
                } else
                {
                    options.imprimir.Enabled = true;
                }

                options.Show();
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            int rowCount = notificationsGrid.RowCount;
            int notiCount = notiDao.getTotalRecord();

            
            try
            {
                if (rowCount != notiCount)
                {
                    Program.Escribir_Log(DateTime.Now.ToString(), "Recargando datos Notificaciones");
                    this.notificacionesTableAdapter.Fill(this.pARKINGDataSet.Notificaciones);
                }

                adentroPlates = adentroDao.getAll();
                notiPlates = notiDao.getNotificationsPlates();

                foreach (string adePlate in adentroPlates)
                {
                    if (notiPlates.Contains(adePlate))
                    {
                        Program.Escribir_Log(DateTime.Now.ToString(), "Remuevo notificacion "+ adePlate);
                        notiDao.removeNotificationByPlate(adePlate);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "timer1_Tick" + ex);
            }


        }

        private void Form1_Load(object sender, EventArgs e) {
            
            try
            {
                this.notificacionesTableAdapter.Fill(this.pARKINGDataSet.Notificaciones);
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "Form1_Load" + ex);
            }
        }

    }
}
