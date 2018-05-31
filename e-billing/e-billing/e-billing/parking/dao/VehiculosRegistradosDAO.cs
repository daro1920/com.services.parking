using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class VehiculosRegistradosDAO
    {

        public VehiculosRegistrado getRegVehicle(string plate)
        {
            VehiculosRegistrado rgvh = new VehiculosRegistrado();
            Program.log.Info("entra VehiculosRegistrado");
            try
            {
                using (var context = new ParkingEntities2())
                {
                    rgvh = (from vh in context.VehiculosRegistrados
                            where vh.str_matricula == plate select vh).FirstOrDefault();
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
            return rgvh;
        }
    }
}
