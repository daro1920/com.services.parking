using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class VehiculosPensionDAO
    {

        public void updateVehiculoPension(int idVehicle, string ultimoMesPago)
        {
            try
            {
                using (var context = new ParkingEntities2())
                {
                    var vehiculoPension = (from vp in context.VehiculosPensions where vp.id_vehiculo_registrado == idVehicle select vp).FirstOrDefault();

                    vehiculoPension.ultimo_mes_pago = ultimoMesPago;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() + " AdentroDao remove" + ex);
            }
        }
    }
}
