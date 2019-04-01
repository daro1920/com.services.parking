using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class RefCierreCajaDAO
    {


        public void addRefCC(ref Referencia_Cierre_Caja refCC)
        {
            try
            {
                using (var context = new ParkingEntities2())
                {
                    context.Referencia_Cierre_Caja.Add(refCC);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() + " RefCierreCaja addAdentro" + ex);
            }
        }
    }
}
