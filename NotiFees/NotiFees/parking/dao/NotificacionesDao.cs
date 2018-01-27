using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotiFees.parking.dao
{
    class NotificacionesDao {

        public List<Notificaciones> getAll() {

            List<Notificaciones> notiList = new List<Notificaciones>();
            
            try
            {
                using (var context = new ParkingDB())
                {

                    notiList = (from noti in context.Notificaciones orderby noti.id select noti).ToList();

                }
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "NotificacionesDao getAll" + ex);
            }
            return notiList;
        }

        public void removeNotificationById(int id) {
            
            using (var context = new ParkingDB()) {

                var notification = (from noti in context.Notificaciones where noti.id == id select noti).FirstOrDefault();
                
                // Submit the changes to the database.
                try {
                    context.Notificaciones.Remove(notification);
                    context.SaveChanges();
                } catch (Exception ex) {
                    Program.Escribir_Log(DateTime.Now.ToString(), "Error al eliminar la notificacion" + ex);
                }

            }
        }

        public Notificaciones getNotificacionByPlate(string plate)
        {
            Notificaciones notificacion = new Notificaciones();
            try
            {
                using (var context = new ParkingDB())
                {
                   notificacion = (from ade in context.Notificaciones orderby ade.id where ade.str_matricula == plate select ade).FirstOrDefault();
                }
                
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "Error al obtener la notificacion" + ex);
            }

            return notificacion;
        }

        public int getTotalRecord() {

            int total = 0;
            

            try
            {
                using (var context = new ParkingDB())
                {

                    total = (from noti in context.Notificaciones select noti).Count();

                }
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "NotificacionesDao getTotalRecord" + ex);
            }
            return total;
        }

        public List<string> getNotificationsPlates()
        {

            List<string> list = new List<string>();
            
            try
            {
                using (var context = new ParkingDB())
                {
                    list = (from noti in context.Notificaciones orderby noti.id select noti.str_matricula).ToList();
                }
            }
            catch (Exception ex)
            {
                Program.Escribir_Log(DateTime.Now.ToString(), "NotificacionesDao getNotificationsPlates" + ex);
            }
            return list;
        }
        


        public void removeNotificationByPlate(string adePlate) {
            using (var context = new ParkingDB()) {

                var notification = (from noti in context.Notificaciones where noti.str_matricula == adePlate select noti).FirstOrDefault();

                // Submit the changes to the database.
                try
                {
                    context.Notificaciones.Remove(notification);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Program.Escribir_Log(DateTime.Now.ToString(), "Error al eliminar la notificacion" + ex);
                }

            }
        }
    }
}
