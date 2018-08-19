using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class TarifaDAo
    {

        public Tarifa getRate(int vehicleId,int minutes)
        {
            Tarifa rate = new Tarifa();
            if (minutes > 0)
            {
                Program.log.Info("entra TarifaDAO");
                try
                {
                    using (var context = new ParkingEntities2())
                    {
                        rate = (from rt in context.Tarifas where rt.id_tipo_vehiculo == vehicleId && (rt.minutos + rt.minutos_tolerancia) >= minutes select rt).FirstOrDefault();
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
            }
            
            return rate;
        }
    }
}
