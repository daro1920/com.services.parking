using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class MovimientosCajaDAO
    {
        public void updateMovCaja(int idRef)
        {
            try
            {
                using (var context = new ParkingEntities2())
                {
                    var movCaja = (from movC in context.MovimientosCajas where movC.cerrado == false select movC).FirstOrDefault();

                    movCaja.cerrado = true;
                    movCaja.id_referencia_cierre = idRef;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() + "MovimientosCajaDAO updateMovimientoCaja" + ex);
            }
        }

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
