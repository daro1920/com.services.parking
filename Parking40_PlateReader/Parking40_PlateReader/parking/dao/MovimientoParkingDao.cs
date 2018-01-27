using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;

namespace Parking40_PlateReader.parking.dao
{
    class MovimientoParkingDao
    {

        public MovimientoParking getMoviParkByPlate(string plate, double conf)
        {

            MovimientoParking movimiento = null;

            Program.log.Debug("Analizando Movimientos parking matricula:" + plate);

            try
            {
                using (var context = new ParkingDB())
                {

                    movimiento = (from movi in context.MovimientoParkings
                                  where movi.str_matricula == plate
                                  select movi).FirstOrDefault();

                }
                if (movimiento == null && !(conf == 99.99 && plate.Length == 7))
                {
                    //we double check in case we have a bad reading
                    movimiento = getMoviParkContainPlate(plate);
                }
                Program.log.Debug("La matricula esta en movimientos?" + (movimiento != null));
            }
            catch (EntityException ex)
            {
                Program.log.Error("EntityException" + ex);
            }
            catch (Exception ex)
            {
                Program.log.Error("Exception" + ex);
            }

            return movimiento;
        }

        public MovimientoParking getMoviParkByPlate(string plate,DateTime date,double conf) {

            MovimientoParking movimiento = null;

            string formatDate = date.Date.ToString("yyyyMMdd");
            string hour1 = date.AddMinutes(-10).ToString("HH:mm");
            string hour2 = date.ToString("HH:mm");

            Program.log.Debug("Analizando Movimientos parking matricula:" + plate);
            Program.log.Debug("Entre las :" + hour1+"y las :"+ hour2);

            try
            {
                using (var context = new ParkingDB())
                {
                    movimiento = (from movi in context.MovimientoParkings
                                  where movi.str_matricula == plate && movi.str_fecha_salida == formatDate && (hour1.CompareTo(movi.str_hora_salida) < 0 && hour2.CompareTo(movi.str_hora_salida) >= 0)
                                  select movi).FirstOrDefault();
                    
                }
                if (movimiento == null && !(conf == 99.99 && plate.Length == 7))
                {
                    //we double check in case we have a bad reading
                    movimiento = getMoviParkContainPlateByDate(plate, date);
                }
                Program.log.Debug("La matricula esta en movimientos?" + (movimiento != null));
            } catch (EntityException ex) {
                Program.log.Error("EntityException" + ex);
            } catch (Exception ex) {
                Program.log.Error("Exception" + ex);
            }
            
            return movimiento;
        }


        public MovimientoParking getMoviParkContainPlateByDate(string plate, DateTime date)
        {

            List<MovimientoParking> movimientos = new List<MovimientoParking>();
            MovimientoParking movimiento = null;

            string formatDate = date.Date.ToString("yyyyMMdd");
            string hour1 = date.AddMinutes(-10).ToString("HH:mm");
            string hour2 = date.ToString("HH:mm");

            Program.log.Debug("Analizando Movimientos parking matricula:" + plate);
            Program.log.Debug("Entre las :" + hour1 + "y las :" + hour2);

            try
            {
                using (var context = new ParkingDB())
                {

                    movimientos = (from movi in context.MovimientoParkings
                                  where movi.str_fecha_salida == formatDate && (hour1.CompareTo(movi.str_hora_salida) < 0 && hour2.CompareTo(movi.str_hora_salida) >= 0)
                                  select movi).ToList();

                }


                foreach (MovimientoParking mov in movimientos)
                {
                    if (Program.getEquivalent(mov.str_matricula,plate))
                    {
                        movimiento = mov;
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

            return movimiento;
        }

        public MovimientoParking getMoviParkContainPlate(string plate)
        {

            List<MovimientoParking> movimientos = new List<MovimientoParking>();
            MovimientoParking movimiento = null;

            Program.log.Debug("Analizando Movimientos parking matricula:" + plate);

            try
            {
                using (var context = new ParkingDB())
                {

                    movimientos = (from movi in context.MovimientoParkings
                                   select movi).ToList();

                }


                foreach (MovimientoParking mov in movimientos)
                {
                    if (Program.getEquivalent(mov.str_matricula, plate))
                    {
                        movimiento = mov;
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

            return movimiento;
        }
    }
}


}