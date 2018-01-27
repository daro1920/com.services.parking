using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotiFees.parking.dao
{
    class Notificaciones_ErroresDao
    {
        private readonly NotificacionesDao notiDao = new NotificacionesDao();

        public void addNotiError(string plate,string obs)
        {

            var date = DateTime.Now;
            var notiErr = new Notificaciones_errores();

            Notificaciones noti =notiDao.getNotificacionByPlate(plate);

            try
            {
                using (var context = new ParkingDB())
                {

                    notiErr.str_matricula = plate;
                    notiErr.str_observaciones = noti.str_observaciones + obs;
                    notiErr.fecha = noti.fecha;
                    context.Notificaciones_errores.Add(notiErr);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "Notificacion_ErroresDao addNotiError" + ex);
            }

        }

    }
}
