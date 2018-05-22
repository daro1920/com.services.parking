using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class MovimientosCajaDAO
    {


        public void addMovCaja(ref MovimientosCaja movCaja)
        {
            try
            {
                using (var context = new ParkingEntities2())
                {
                    context.MovimientosCajas.Add(movCaja);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() + " MovimientosCajaDAO addMovCaja" + ex);
            }
        }
    }
}
