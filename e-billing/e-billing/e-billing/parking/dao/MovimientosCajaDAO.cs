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
                    List<MovimientosCaja> movsCaja = (from movC in context.MovimientosCajas where movC.cerrado == false select movC).ToList();

                    foreach (MovimientosCaja movCaja in movsCaja)
                    {
                        movCaja.cerrado = true;
                        movCaja.id_referencia_cierre = idRef;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() + "MovimientosCajaDAO updateMovimientoCaja" + ex);
            }
        }

        public List<MovimientosCaja> getListMovCaja()
        {

            List<MovimientosCaja> movsCaja = new List<MovimientosCaja>();
            try
            {
                using (var context = new ParkingEntities2())
                {
                    movsCaja = (from movC in context.MovimientosCajas where movC.cerrado == false select movC).ToList();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() + "MovimientosCajaDAO updateMovimientoCaja" + ex);
            }
            return movsCaja;
        }

        public decimal getSumImporteMovCaja()
        {
            decimal movCaja = 0;
            try
            {
                using (var context = new ParkingEntities2())
                {
                    movCaja = (from movC in context.MovimientosCajas where movC.cerrado == false select movC.importe).Sum();
                    
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() + "MovimientosCajaDAO getSumImporteMovCaja" + ex);
            }
            return movCaja;
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
