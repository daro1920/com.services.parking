using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_billing.parking.dao
{
    class ConfigDAO
    {

        public Configu getConfig()
        {

            Configu config = new Configu();

            try
            {
                using (var context = new ParkingEntities2())
                {
                    config = (from con in context.Configus select con).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Program.log.Error(DateTime.Now.ToString() + " ConfigDAO getConfig " + ex);
            }
            return config;
        }

    }
}
