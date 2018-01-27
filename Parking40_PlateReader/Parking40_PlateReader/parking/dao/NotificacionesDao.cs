using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Parking40_PlateReader.parking.dao
{
    class NotificacionesDao
    {

        public List<Notificacione> getAll() {

            List<Notificacione> notiList = new List<Notificacione>();
            using (var context = new ParkingDB()) {

                notiList = (from noti in context.Notificaciones orderby noti.id select noti).ToList();

            }
            return notiList;
        }

        public Notificacione getNotificacion(string plate,double conf)
        {
            Notificacione notificacion = new Notificacione();

            
            try
            {
                using (var context = new ParkingDB())
                {
                    notificacion = (from ade in context.Notificaciones orderby ade.id where ade.str_matricula == plate select ade).FirstOrDefault();
                }

                if (notificacion == null && !( conf == 99.99 && plate.Length == 7))
                {
                    //we double check in case we have a bad reading
                    notificacion = getNotificacionContainPlate(plate);
                }
            }
            catch (EntityException ex)
            {
                Program.log.Error("NotificacionesDao EntityException getNotificacion" + ex);
            }
            catch (Exception ex)
            {
                Program.log.Error("NotificacionesDao Exception getNotificacion" + ex);
            }

            return notificacion;
        }

        public void addnotifications(string str_matricula, DateTime date,int id) {

            VehiculosRegistradosDao vehDao = new VehiculosRegistradosDao();
            Notificacione notification = new Notificacione();
            using (var context = new ParkingDB()) {

                notification.str_matricula = str_matricula;
                notification.str_observaciones = (vehDao.getVehiculoMensual(str_matricula) !=null?"Mensual fuera de horario": "Notificacion ingresada por el sistema");
                notification.fecha = date;
                notification.result_id = id;
                context.Notificaciones.Add(notification);
                context.SaveChanges();
            }

        }

        internal void addnotifications(string str_matricula, DateTime date, int id, int id_tipo_vehiculo)
        {
            VehiculosRegistradosDao vehDao = new VehiculosRegistradosDao();
            Notificacione notification = new Notificacione();
            using (var context = new ParkingDB())
            {

                notification.str_matricula = str_matricula;
                notification.str_observaciones = (vehDao.getVehiculoMensual(str_matricula) != null ? "Mensual fuera de horario" : "Notificacion ingresada por el sistema");
                notification.fecha = date;
                notification.result_id = id;
                notification.id_tipo_vehiculo = id_tipo_vehiculo;
                context.Notificaciones.Add(notification);
                context.SaveChanges();
            }
        }

        public void removeNotificationByPlate(string plate)
        {
            Program.log.Info("eliminar la notificacion");
            using (var context = new ParkingDB())
            {

                var notification = (from noti in context.Notificaciones where noti.str_matricula == plate select noti).FirstOrDefault();

                // Submit the changes to the database.
                try
                {
                    context.Notificaciones.Remove(notification);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Program.log.Error("Error al eliminar la notificacion" + ex);
                }

            }
        }

        internal Notificacione getNotificacionContainPlate(string plate)
        {
            List<Notificacione> notificaciones = new List<Notificacione>();
            Notificacione notificacion = null;
            

            try
            {
                using (var context = new ParkingDB())
                {
                    notificaciones = (from ade in context.Notificaciones orderby ade.id  select ade).ToList();
                }


                foreach (Notificacione noti in notificaciones)
                {
                    if (Program.getEquivalent(noti.str_matricula, plate))
                    {
                        notificacion = noti;
                        break;
                    }
                }
            }
            catch (EntityException ex)
            {
                Program.log.Error("EntityException" + ex);
            }
            catch (Exception ex)
            {
                Program.log.Error("Exception" + ex);
            }

            return notificacion;
        }

        internal void addnotifications(string plate, DateTime date, int id, int? id_tipo_vehiculo)
        {
            throw new NotImplementedException();
        }
    }
}
