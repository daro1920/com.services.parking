using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class TipoVehiculoDAO
    {

        public int getVehicleID(string vehicleType)
        {
            int id = 0;
            Program.log.Info("entra TipoVehiculoDAO");
            try
            {
                using (var context = new ParkingEntities2())
                {
                    id = (from vt in context.TipoVehiculoes where vt.str_descrip == vehicleType  select vt.id).FirstOrDefault();
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
            return id;
        }
    }
}
