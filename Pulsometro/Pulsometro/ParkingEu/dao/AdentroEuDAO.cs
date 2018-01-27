using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsometro.ParkingEu.dao
{
    class AdentroEuDAO
    {

        public void addAdentro(ref Adentro adentro)
        {


            try
            {
                using (var context = new ParkingEugenio())
                {
                    context.AdentroEU.Add(adentro);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error("AdentroDao addAdentro" + ex);
            }
        }
    }
}
