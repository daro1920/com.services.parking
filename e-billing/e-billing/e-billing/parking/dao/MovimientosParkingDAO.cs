using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class MovimientosParkingDAO
    {

        public void addMovParking(ref MovimientoParking movParking)
        {
            try
            {
                using (var context = new ParkingEntities2())
                {
                    context.MovimientoParkings.Add(movParking);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() + " MovimientosParkingDAO addMovParking" + ex);
            }
        }
    }
}
