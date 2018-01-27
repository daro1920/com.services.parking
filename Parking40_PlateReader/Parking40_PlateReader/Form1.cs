using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Parking40_PlateReader.parking.dao;
using Parking40_PlateReader.anpr.dao;
using System.Data.Entity.Core;

namespace Parking40_PlateReader
{
    public partial class Form1 : Form
    {
        public int IN_DIR = 1;
        public int OUT_DIR = -1;
        public string YES = "Yes";

        private readonly ResultDao resDao = new ResultDao();
        private readonly ProcesadoDao proDao = new ProcesadoDao();
        private readonly NotificacionesDao notDao = new NotificacionesDao();
        private readonly IncidenceDao incDao = new IncidenceDao();
        private readonly MovimientoParkingDao movParkDao = new MovimientoParkingDao();

        private  List<Result> resultsList = new List<Result>();
        private MovimientoParking moviPark = new MovimientoParking();
        private Notificacione noti = new Notificacione();

        private int lastProcess = 0;
        private int process;
        private string plate;
        private DateTime date;
        private int id;
        private int cam;
        private double conf;



        public Form1()
        {
            InitializeComponent();
        }
        
        private void timer1_Tick(object sender, EventArgs e) {

            

            lastProcess = proDao.getLastProcess();
            if (lastProcess > 0)
            {
                process = lastProcess;
            } else
            {
                Program.log.Error("Error!! imposible consultar la base de datos, se seguira procesando desde el ultimo leido hasta volver a la normalidad");
                Program.log.Error("Ultimo procesado: "+ process);
                lastProcess = process;
            }

            resultsList = resDao.getNoProcessResults(lastProcess);

            if (resultsList.Count() > 0) {
                
                

                try
                {
                    foreach (Result resItem in resultsList)
                    {

                        plate = resItem.NumberPlate;
                        date = resItem.Date_Send_Server;
                        id = resItem.INCIDENCEID;
                        conf = Math.Round(resItem.GlobalConfidence.Value, 2);

                        noti = notDao.getNotificacion(plate, conf);
                        moviPark = movParkDao.getMoviParkByPlate(plate, date, conf);
                        
                        Program.log.Info("Analizando Matricula:" + plate);
                        if (moviPark == null)//if it is not in movimientosParking
                        {
                            Program.log.Info("La matricula " + plate + " NO esta en movimientos");
                            if (noti != null)//Already in Notifications
                            {
                                Program.log.Info("La matricula " + plate + " ya esta en Notificaciones");
                                cam = incDao.getCam(id);
                                if ((cam == 1) && ((noti.fecha - date).TotalMinutes <= 4))
                                {
                                    Program.log.Info("La matricula " + plate + " esta  cruzando y se removera");
                                    notDao.removeNotificationByPlate(noti.str_matricula);
                                }
                                else if (Program.notifyIn(plate))
                                {
                                    Program.log.Info("La matricula " + plate + " sera notificada");
                                    //verificar si ya existia
                                    moviPark = movParkDao.getMoviParkByPlate(plate,conf);
                                    if (moviPark != null)
                                    {
                                        notDao.addnotifications(plate, date, id,moviPark.id_tipo_vehiculo);
                                    } else
                                    {
                                        notDao.addnotifications(plate, date, id);
                                    }
                                    
                                }
                            }
                            else if (Program.notifyIn(plate))
                            {
                                Program.log.Info("La matricula " + plate + " sera notificada");
                                //verificar si ya existia
                                moviPark = movParkDao.getMoviParkByPlate(plate, conf);
                                if (moviPark != null)
                                {
                                    notDao.addnotifications(plate, date, id, moviPark.id_tipo_vehiculo);
                                }
                                else
                                {
                                    notDao.addnotifications(plate, date, id);
                                }
                            }
                            
                        }

                        Program.log.Info("Actualizando procesados" + plate);
                        proDao.updateProcess(resItem.ID);
                    }
                }
                catch (EntityException ex)
                {
                    Program.log.Error("Error metodo principal procesando la matricula:"+ plate + " " + ex);
                }
                catch (Exception ex)
                {
                    Program.log.Error("Error metodo principal procesando la matricula:" + plate + " " + ex);
                }

            }

        }


    }
}
